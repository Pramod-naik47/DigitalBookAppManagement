import { Component, OnInit } from '@angular/core';
import { Book } from '../models/book-model';
import { VBook2User } from '../models/book2-user-model';
import { BookService } from '../services/book-service';
import { NotificationService } from '../services/notificationservice/notification.service';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent implements OnInit {
  title = "Author list screen";
  books: VBook2User[] = [];
  criteria :  VBook2User = {
    bookId: 0,
    bookTitle: '',
    category: '',
    price: 0,
    content: '',
    active: false,
    createdDate: new Date,
    modifiedDate: new Date,
    publishDate: new Date,
    publisher: '',
    userName: '',
    userType: '',
    userId : 0,
    email: '',
    phoneNumber: 0
};
  token : string = '';
  message : any = '';

  constructor(private bookService : BookService, private notificationService : NotificationService) { }

  ngOnInit(): void {
    this.token = localStorage.getItem('token')!;
    this.GetBookForAuthor();
  }
  
  GetBookForAuthor(){
    this.bookService.GetBookForAuthor('https://digitalbookmanagementservice.azure-api.net/author/api/Author/GetAllBooks', this.token)
    .subscribe(
      response => {
        this.books = response;
      }
    )
  }

  DeleteBook(bookId : number) {
    this.bookService.DeleteBook('https://digitalbookmanagementservice.azure-api.net/author/api/Author/DeleteBook', bookId, this.token)
    .subscribe(
      response => {
        this.message = response;
        this.GetBookForAuthor();
        this.notificationService.showSuccess(this.message.join(''), "Book app")
      }
     )
  }
}
