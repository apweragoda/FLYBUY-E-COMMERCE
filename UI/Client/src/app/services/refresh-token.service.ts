import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class RefreshTokenService {
  private url: string = 'http://localhost:5000/api/user/refreshToken';

  constructor(private http: HttpClient) {}

  async refreshToken() {
    const res = await this.http
      .get(this.url, { withCredentials: true })
      .toPromise();
    return res;
  }
}
