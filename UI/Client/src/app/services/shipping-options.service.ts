import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IShippingOptions } from '../models/shippingOptions';

@Injectable({
  providedIn: 'root',
})
export class ShippingOptionsService {
  url: string = 'http://localhost:5000/api/shipping';

  constructor(private http: HttpClient) {}

  public getShippingOptions(): Observable<IShippingOptions[]> {
    return this.http.get<IShippingOptions[]>(this.url);

  }
}
