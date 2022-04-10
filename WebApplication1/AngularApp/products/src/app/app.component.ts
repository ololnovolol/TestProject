import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'products 2';
  products: any;
  constructor(private http: HttpClient) {
    http.get("localhost:5001/api/products").subscribe(data => {
      console.log(data);
      this.products = data;
    })
  }
}
