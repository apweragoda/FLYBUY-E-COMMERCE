import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProduct } from '../models/product';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  baseUrl = 'http://localhost:5000/api/product';
  constructor(private http: HttpClient) {}

  getAllProducts(): Observable<IProduct[]> {
    return this.http.get<IProduct[]>(`${this.baseUrl}/`);
  }

  getSingleProduct(id: number): Observable<IProduct> {
    return this.http.get<IProduct>(`${this.baseUrl}/${id}`);
  }

  getAllProductsByCategory(category: string): Observable<IProduct[]> {
    // return this.http.get<IProduct[]>(`${this.baseUrl}/category/${category}`);
    return this.http.get<IProduct[]>(`${this.baseUrl}/${category}`);
  }
}
