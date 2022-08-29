import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SearchbookComponent } from './searchbook/searchbook.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { Route, RouterModule } from '@angular/router';
import { AuthorComponent } from './author/author.component';
import { CreateBookComponent } from './create-book/create-book.component';
import { CreateAccountComponent } from './create-account/create-account.component';
import { PurchaseComponent } from './purchase/purchase.component';
import { PurchaseHistoryComponent } from './purchase-history/purchase-history.component'; 

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { ModalModule } from 'ngx-bootstrap/modal';  
import { NgxPrintModule } from 'ngx-print';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SearchbookComponent,
    SignInComponent,
    AuthorComponent,
    CreateBookComponent,
    CreateAccountComponent,
    PurchaseComponent,
    PurchaseHistoryComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    ModalModule.forRoot(),  
    NgxPrintModule,
    RouterModule.forRoot([
      {path: '', component: SearchbookComponent},
      {path: 'sign-in', component: SignInComponent},
      {path: 'create-book', component: CreateBookComponent},
      {path: 'author', component : AuthorComponent},
      {path: 'create-account', component : CreateAccountComponent},
      {path: 'create-book/:bookId', component: CreateBookComponent},
      {path: 'purchase/:bookId', component: PurchaseComponent},
      {path: 'purchase-history', component: PurchaseHistoryComponent},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
