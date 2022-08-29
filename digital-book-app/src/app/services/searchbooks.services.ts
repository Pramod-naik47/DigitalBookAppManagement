import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { VBook2User } from '../models/book2-user-model';

@Injectable({
  providedIn: 'root'
})
export class SearchBooksService {

  baseUrl = 'https://digitalbookmanagementservice.azure-api.net/reader/api/Reader/SearchForBook';

  constructor(private http: HttpClient) { }

  //Get all books
  SearchBook(serachCriteria: VBook2User):Observable<VBook2User[]>{

    let queryParams = new HttpParams();
      queryParams = queryParams.append("bookTitle",serachCriteria.bookTitle);
      queryParams = queryParams.append("category",serachCriteria.category);
      queryParams = queryParams.append("author",serachCriteria.userName);
      queryParams = queryParams.append("price",serachCriteria.price);
      queryParams = queryParams.append("publisher",serachCriteria.publisher);

      return this.http.get<VBook2User[]>(this.baseUrl,{params:queryParams});
  }
}
