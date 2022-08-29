import { Component, OnInit } from '@angular/core';
import { Book } from '../models/book-model';
import { Payment } from '../models/purchase';
import { Router, ActivatedRoute } from '@angular/router';
import { PaymentService } from '../services/purchase-service';
import { NotificationService } from '../services/notificationservice/notification.service';

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.css']
})
export class PurchaseComponent implements OnInit {
  paramBookId : number = 0;
  token : string = '';

  bookObject: Book = {
    bookId: 0,
    bookTitle: '',
    category: '',
    price: 0,
    publisher: '',
    content: '',
    active: false
  };

  paymentObject: Payment = {
    paymentId: 0,
    email: '',
    bookId: 0,
    paymentDate : new Date
  };

  message : any = '';
  constructor(private router : Router, 
              private activatedRoute : ActivatedRoute, 
              private paymentService : PaymentService,
              private notificationService : NotificationService ) { }

  ngOnInit(): void {
    this.paramBookId = this.activatedRoute.snapshot.params['bookId']
    this.token = localStorage.getItem('token')!; 
    this.GetBookById();
  }

  GetBookById(){
    this.paymentService.GetBookById('https://digitalbookmanagementservice.azure-api.net/reader/api/Reader/GetBookById', this.paramBookId).
    subscribe(
      res => {
        this.bookObject = res;
        this.paymentObject = {
          paymentId: 0,
          email: '',
          bookId: res.bookId,
          paymentDate : new Date
        };
      }
    )
  }

  PurchaseBook(): void {
    this.paymentService.PurchaseBook(this.paymentObject, 'https://digitalbookmanagementservice.azure-api.net/reader/api/Reader/PurchaseBook')
    .subscribe(
      res => {
        this.message = res;
        this.notificationService.showSuccess("Purchase successfull", "Book app");
        this.router.navigate([''])
      }
    )
  }
}
