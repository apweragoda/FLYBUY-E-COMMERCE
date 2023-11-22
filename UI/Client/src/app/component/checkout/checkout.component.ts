import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ICartItem } from 'src/app/models/cartItem';
import { AuthService } from 'src/app/services/auth.service';
import { CartService } from 'src/app/services/cart.service';
import { CheckoutService } from 'src/app/services/checkout.service';
import { ShippingOptionsService } from 'src/app/services/shipping-options.service';
import { NotificationService } from 'src/app/services/notification.service';
import { IShippingOptions } from 'src/app/models/shippingOptions';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css'],
})
export class CheckoutComponent implements OnInit {
  cart: ICartItem[] = [];
  total: number = 0;
  subtotal: number = 0;
  currentUser: any;
  isLoading: boolean = false;

  step: number = 1;

  paymentMethod: string = 'cash on delivery';

  shipping: any | undefined;

  shippingOption: IShippingOptions[] = [];

  selectedShippingOption: any = 'Standard';

  shippingPrice!: number;

  orderDetailsReturned: any;

  constructor(
    private cartService: CartService,
    private checkoutService: CheckoutService,
    private authService: AuthService,
    private route: Router,
    private notificationService: NotificationService,
    private shippingService: ShippingOptionsService
  ) {}

  ngOnInit(): void {
    this.cartService.getCart().subscribe((data) => (this.cart = data));
    this.shippingService.getShippingOptions().subscribe({
      next: (data) => (this.shippingOption = data),
      error: (err) => console.log(err),
      complete: () => {
        this.shippingPrice =
          this.shippingOption.find(
            (item) => item.type == this.selectedShippingOption
          )?.price || 0;
        this.calculateTotal();
        this.currentUser = this.authService.getUserValue();
        console.log(this.shippingOption);
        console.log(this.currentUser);
      },
    });
    this.currentUser = this.authService.getUserValue();
  }

  goToPreviousStep() {
    if (this.step > 1) {
      this.step--;
    }
  }

  geToNextStep() {
    this.step++;
  }

  getShipping($event: any) {
    this.shipping = $event;
    console.log(
      'Checkout component get the shipping : ' + JSON.stringify(this.shipping)
    );
    console.log(this.currentUser);

    this.geToNextStep();
  }

  setShippingOption($event: any) {
    console.log('Selected' + JSON.stringify($event));

    this.selectedShippingOption = $event;
    this.shippingPrice =
      this.shippingOption.find(
        (item) => item.type == this.selectedShippingOption
      )?.price || 300;
    this.calculateTotal();
  }

  goToPaymentPage($event: any) {
    console.log('Selected payment option as default : ' + this.paymentMethod);
    console.log(
      this.shippingOption?.find(
        (item) => item.type == this.selectedShippingOption
      )
    );
    this.geToNextStep();
  }

  async confirmOrder($event: any) {
    this.currentUser = this.authService.getUserValue();
    this.isLoading = true;
    console.log(this.isLoading);
    console.log(this.currentUser);
    this.paymentMethod = $event;
    let orderItems = this.cart.map((item) => {
      return {
        productId: item.product.id,
        quantity: Number(item.quantity),
        size: item.size,
      };
    });

    let date = new Date();
    console.log('Order Date (today) : ' + date);

    const shippingOption = this.shippingOption.find(
      (item) => item.type == this.selectedShippingOption
    );
    date.setDate(date.getDate() + (shippingOption?.days || 3)).toLocaleString();
    let expectedDeliveryDate = date.toISOString();
    console.log('Expected Delivery Date : ' + expectedDeliveryDate);

    let shipping = {
      status: 'ordered',
      shippingOptionId: shippingOption?.id,
      expectedDeliveryDate,
      ...this.shipping,
    };
    this.currentUser = this.authService.getUserValue();
    console.log(this.currentUser.user.userName);

    let order = {
      customerId: this.currentUser.user.id,
      Items: orderItems,
      OrderDate: new Date().toISOString(),
      Shipping: shipping,
      Bill: {
        total: this.subtotal,
        paymentMethod: this.paymentMethod,
      },
    };
    console.log(order);

    (await this.checkoutService.addNewOrder(order)).subscribe({
      next: (data) => {
        this.orderDetailsReturned = data;
        this.cartService.clearCart();
        this.notificationService.showNotification('success', data.message);
        this.route.navigate([`/order/${data.order.id}`]);
      },
      error: (error) => console.log(error),
      complete: () => {
        this.isLoading = false;
        console.log('email sent');
      },
    });
  }

  // sendSuccessEmail(order: any) {
  //   this.emailService
  //     .sendOrderSuccessEmail({
  //       toEmail: 'ap.weragoda@gmail.com',
  //       subject: 'Order Confirmation.',
  //       body: "<h1 style='color: gold'>Thank You for shopping with us</h1>",
  //     })
  //     .subscribe({
  //       next: (data) => console.log('Data returned from email res : ' + data),
  //       error: (err) => console.log('Error occured in email req : ' + err),
  //       complete: () => console.log('Email has been send'),
  //     });
  // }

  calculateTotal() {
    this.total = 0;
    this.cart.forEach((item) => {
      this.total += item.product.price * item.quantity;
    });
    this.subtotal = this.total + this.shippingPrice;
  }
}
