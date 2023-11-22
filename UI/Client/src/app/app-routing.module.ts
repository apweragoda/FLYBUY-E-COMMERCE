import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './component/home/home.component';
import { SigninComponent } from './component/signin/signin.component';
import { ProductDetailsComponent } from './component/product-details/product-details.component';
import { ProductPageComponent } from './component/product-page/product-page.component';
import { SignupComponent } from './component/signup/signup.component';
import { CartComponent } from './component/cart/cart.component';
import { CheckoutComponent } from './component/checkout/checkout.component';
import { OrderItemComponent } from './component/order-item/order-item.component';
import { OrdersComponent } from './component/orders/orders.component';
import { CheckoutGuard } from './guards/checkout.guard';
import { OrderGuard } from './guards/order.guard';
import { PageNotFoundComponent } from './component/page-not-found/page-not-found.component';
const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'signin', component: SigninComponent },
  { path: 'products/:category', component: ProductPageComponent },
  { path: 'product/:id', component: ProductDetailsComponent },
  { path: 'product/:id/quantity/1', component: CartComponent },
  { path: 'cart', component: CartComponent },
  { path: 'order', canActivate: [OrderGuard], component: OrdersComponent },
  {
    path: 'order/:id',
    canActivate: [OrderGuard],
    component: OrderItemComponent,
  },
  {
    path: 'checkout',
    canActivate: [CheckoutGuard],
    component: CheckoutComponent,
  },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: '**', component: PageNotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
