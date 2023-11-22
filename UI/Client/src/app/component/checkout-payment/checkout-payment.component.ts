import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-checkout-payment',
  templateUrl: './checkout-payment.component.html',
  styleUrls: ['./checkout-payment.component.css']
})
export class CheckoutPaymentComponent implements OnInit {
  @Output() goBack = new EventEmitter();
  @Output() placeOrder = new EventEmitter();

  @Input() payment!: string;

  constructor() { }

  ngOnInit(): void {
  }

  goBackToShipping(){
    console.log("Back to shipping");
    this.goBack.emit();
  }

  confirmOrder(): void{
    console.log("Confirmed order with details...");
    this.placeOrder.emit(this.payment);
  }
}
