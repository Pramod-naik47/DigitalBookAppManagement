import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from '../models/book-model';
import { VBookPayment } from '../models/book-payment-model';
import { User } from '../models/loginmodel';
import { Payment } from '../models/purchase';

@Injectable({
  providedIn: 'root'
})

export class PaymentService {
  constructor(private http: HttpClient) { }

  PurchaseBook(payment: Payment, url: string): Observable<Payment> {
    return this.http.post<Payment>(url, payment);
  }

  GetBookById(url: string, bookId: number): Observable<Book> {
    let queryParams = new HttpParams();
    queryParams = queryParams.append("bookId", bookId);
    return this.http.get<Book>(url, { params: queryParams });
  }

  GetBookByIdForPayment(url: string, bookId: number): Observable<VBookPayment> {
    let queryParams = new HttpParams();
    queryParams = queryParams.append("bookId", bookId);
    return this.http.get<VBookPayment>(url, { params: queryParams });
  }


  GetPymemtHistory(url: string, email : string): Observable<VBookPayment[]> {
    let queryParams = new HttpParams();
    queryParams = queryParams.append("email", email);
    return this.http.get<VBookPayment[]>(url, { params: queryParams });
  }

  
  GetRefund(url: string, paymentId: number): Observable<Payment> {
    let queryParams = new HttpParams();
    queryParams = queryParams.append("paymentId", paymentId);
    return this.http.delete<Payment>(url, { params: queryParams });
  }
}