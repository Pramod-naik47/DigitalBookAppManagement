import { Component, OnInit, TemplateRef } from '@angular/core';
import { Book } from '../models/book-model';
import { Payment } from '../models/purchase';
import { PaymentService } from '../services/purchase-service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';  
import { VBookPayment } from '../models/book-payment-model';
import { NotificationService } from '../services/notificationservice/notification.service';

@Component({
  selector: 'app-purchase-history',
  templateUrl: './purchase-history.component.html',
  styleUrls: ['./purchase-history.component.css']
})
export class PurchaseHistoryComponent implements OnInit {
  payments : VBookPayment[] = [];
  paymentObject : VBookPayment = {
    bookId: 0,
    bookTitle: '',
    category: '',
    price: 0,
    content: '',
    active: false,
    createdDate: new Date,
    publishDate: new Date,
    publisher: '',
    paymentId:0,
    email: '',
    paymentDate: new Date
}
message: any ='';

  modalRef!: BsModalRef; 
  constructor(private purchaseService : PaymentService,
             private modalService: BsModalService,
             private notificationService : NotificationService) { }

  ngOnInit(): void {
  }
  

  GetPaymentHistory(){
    this.purchaseService.GetPymemtHistory('https://digitalbookmanagementservice.azure-api.net/reader/api/Reader/GetPaymentHistory', this.paymentObject.email).
    subscribe( 
      res => {
        this.payments = res;
      }
    )
  }

  OpenInvoiceModel(template: TemplateRef<any>, bookId: number) {
    this.purchaseService.GetBookByIdForPayment('https://digitalbookmanagementservice.azure-api.net/reader/api/Reader/GetBookByIdForPayment', bookId).
      subscribe(
        res => {
          this.paymentObject = res;

          this.modalRef = this.modalService.show(
            template,
            Object.assign({}, { class: 'gray modal-lg' })
          );
        }
      )
  }

  GetRefund(paymentId: number, paymentDate : Date) {
     let purchaseDate = new Date(paymentDate);
     let currentDate = new Date();
     let timedifferenceInSecond  = Math.round((currentDate.getTime() -purchaseDate.getTime())/1000)

     if (timedifferenceInSecond < 86400){
      this.purchaseService.GetRefund('https://digitalbookmanagementservice.azure-api.net/reader/api/Reader/GetRefund', paymentId)
      .subscribe(
        res => {
          this.message = res;
            this.notificationService.showSuccess(this.message.join(''),"Book App");
            this.GetPaymentHistory();
        }
      )
     } else {
        this.notificationService.showWarning("After 24 hours no refund will be given", "Book app");
     }
  }

  ReadBook(template: TemplateRef<any>, bookId: number) {
    this.purchaseService.GetBookByIdForPayment('https://digitalbookmanagementservice.azure-api.net/reader/api/Reader/GetBookByIdForPayment', bookId).
      subscribe(
        res => {
          this.paymentObject = res;

          this.modalRef = this.modalService.show(
            template,
            Object.assign({}, { class: 'gray modal-lg' })
          );
        }
      )
  }
}
