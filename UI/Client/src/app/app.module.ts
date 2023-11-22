import { NgModule } from '@angular/core';
import { SlickCarouselModule } from 'ngx-slick-carousel';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProductComponent } from './component/product/product.component';
import { HomeComponent } from './component/home/home.component';
import { HeaderComponent } from './component/header/header.component';
import { FooterComponent } from './component/footer/footer.component';
import { ProductDetailsComponent } from './component/product-details/product-details.component';
import { ProductPageComponent } from './component/product-page/product-page.component';
import { SignupComponent } from './component/signup/signup.component';
import { SigninComponent } from './component/signin/signin.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CartComponent } from './component/cart/cart.component';
import { CheckoutInformationComponent } from './component/checkout-information/checkout-information.component';
import { CheckoutPaymentComponent } from './component/checkout-payment/checkout-payment.component';
import { CheckoutShippingComponent } from './component/checkout-shipping/checkout-shipping.component';
import { CheckoutComponent } from './component/checkout/checkout.component';
import { NotificationComponent } from './component/notification/notification.component';
import { OrderItemComponent } from './component/order-item/order-item.component';
import { OrdersComponent } from './component/orders/orders.component';
import { PageNotFoundComponent } from './component/page-not-found/page-not-found.component';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { far } from '@fortawesome/free-regular-svg-icons';
import { fas } from '@fortawesome/free-solid-svg-icons';

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    ProductDetailsComponent,
    ProductPageComponent,
    CartComponent,
    CheckoutComponent,
    CheckoutInformationComponent,
    CheckoutShippingComponent,
    CheckoutPaymentComponent,
    PageNotFoundComponent,
    NotificationComponent,
    OrdersComponent,
    OrderItemComponent,
    SignupComponent,
    SigninComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    SlickCarouselModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {
  constructor(library: FaIconLibrary) {
    library.addIconPacks(fas, far);
  }
}
