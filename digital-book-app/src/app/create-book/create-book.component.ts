import { Component, OnInit } from '@angular/core';
import { Book } from '../models/book-model';
import { BookService } from '../services/book-service';
import { Router, ActivatedRoute } from '@angular/router';
import { NotificationService } from '../services/notificationservice/notification.service';

@Component({
  selector: 'app-create-book',
  templateUrl: './create-book.component.html',
  styleUrls: ['./create-book.component.css']
})
export class CreateBookComponent implements OnInit {
  title = "Create book";
  id: number = 0
  addOrUpdateText = '';
  isAddMode: boolean = false
  book: Book[] = [];
  bookObject: Book = {
    bookId: 0,
    bookTitle: '',
    category: '',
    price: 0,
    publisher: '',
    content: '',
    active: false
  }

  token : string = '';
  message : any = '';
  constructor(private bookSerive: BookService, private router: Router,
              private activatedRout: ActivatedRoute,
              private notificationService : NotificationService) { }

  ngOnInit(): void {
    this.token = localStorage.getItem('token')!;
    this.id = this.activatedRout.snapshot.params['bookId'];
    this.isAddMode = !this.id;
    if (this.isAddMode) {
      this.addOrUpdateText = "Create Book";
    } else {
      this.addOrUpdateText = "Update book";
    }
     
    this.GetBookById()
  }

  CreateBook() {
    if (this.isAddMode) {
      this.bookSerive.CreateBook(this.bookObject, 'https://digitalbookmanagementservice.azure-api.net/author/api/Author/CreateBook', this.token).
        subscribe(
          resposnse => {
            this.message = resposnse;
            this.notificationService.showSuccess(this.message.join(''), "Book app")
            this.router.navigate(['/author'])
            this.message = '';
          }
        )
    } else {
      this.UpdateBook();
    }
  }

  GetBookById() {
    if (!this.isAddMode) {
      this.bookSerive.GetBookById('https://digitalbookmanagementservice.azure-api.net/author/api/Author/GetBookById', this.id, this.token)
      .subscribe(
        response => {
          this.bookObject = response;
        }
      )
    }
  }

  UpdateBook() {
    this.bookSerive.UpdateBook(this.bookObject, 'https://digitalbookmanagementservice.azure-api.net/author/api/Author/EditBook', this.token)
    .subscribe(
      res => {
        this.message = res;
        this.bookObject  = {
          bookId: 0,
          bookTitle: '',
          category: '',
          price: 0,
          publisher: '',
          content: '',
          active: false
        };
        this.notificationService.showSuccess(this.message.join(''), "Book app")
        this.router.navigate(['/author']);
        this.message = '';
      }
    )
  }
}
