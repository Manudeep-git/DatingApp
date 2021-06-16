import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Dating App Client Side';
  users: any;

  constructor(private http: HttpClient) { }

  //required for making http calls - lifecycle hook provided by angular
  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.http.get("https://localhost:5001/api/users").subscribe((observer) => {
      this.users = observer;
    }, (e) => {
      console.log(e);
    })
  }
  
  
}
