import { Component } from '@angular/core';
import { ApiService } from 'src/shared/services/api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'List of users';
  users: any;
  constructor(apiService: ApiService) {
    apiService.get("https:localhost:5001/api/users").subscribe(data => {
      this.users = data;
    })
  }
}
