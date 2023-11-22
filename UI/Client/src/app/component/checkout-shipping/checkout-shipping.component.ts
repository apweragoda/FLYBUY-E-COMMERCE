import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IShippingOptions } from 'src/app/models/shippingOptions';
import { ShippingOptionsService } from 'src/app/services/shipping-options.service';

@Component({
  selector: 'app-checkout-shipping',
  templateUrl: './checkout-shipping.component.html',
  styleUrls: ['./checkout-shipping.component.css'],
})
export class CheckoutShippingComponent implements OnInit {
  @Output() goBack = new EventEmitter();
  @Output() setOption = new EventEmitter();
  @Output() goToPayment = new EventEmitter();
  @Input() shippingOptions: any;
  shippingOption: IShippingOptions[] = [];
  @Input() selectedShippingOption: any;

  constructor(private shippingService: ShippingOptionsService) {}

  ngOnInit(): void {
    this.shippingService.getShippingOptions().subscribe({
      next: (data) => (this.shippingOption = data),
      error: (err) => console.log(err),
      complete: () => {
        console.log(this.shippingOption);
      },
    });
  }

  calculateDays(day: number) {
    let today = new Date();
    const expectedDeliveryDate = new Date(today.setDate(today.getDate() + day));
    return expectedDeliveryDate.toDateString();
  }

  setShippingOptions(option: string) {
    console.log('changing option : ' + option);
    this.setOption.emit(option);
  }

  routeToInformation() {
    console.log('go back');

    this.goBack.emit();
  }

  routeToPayment(): void {
    this.goToPayment.emit(this.selectedShippingOption);
  }
}
