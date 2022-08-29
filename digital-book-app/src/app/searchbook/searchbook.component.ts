import { Component, OnInit } from '@angular/core';
import { VBook2User } from '../models/book2-user-model';
import { SearchBooksService } from '../services/searchbooks.services';

@Component({
  selector: 'app-searchbook',
  templateUrl: './searchbook.component.html',
  styleUrls: ['./searchbook.component.css']
})
export class SearchbookComponent implements OnInit {
  title = "Search books";
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

  constructor(private searchBooksService : SearchBooksService) { }

  ngOnInit(): void {
    this.onSearchSubmit()
  }

  onSearchSubmit(){
      this.searchBooksService.SearchBook(this.criteria)
      .subscribe(
        response => {
           this.books = response;
        }
      );
  }
}
