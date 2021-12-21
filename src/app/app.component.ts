import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `<div>Hello {{value}}</div>
  <div><button><a href="/.auth/login/github?post_login_redirect_uri=http://localhost:4200/">Login with github</a></button></div>`,
})
export class AppComponent {
  value = 'World';

  constructor(private http:HttpClient) {

    const headers = new HttpHeaders().set('Content-Type', 'text/plain; charset=utf-8');

    this.http.get('http://localhost:7071/api/GetRecipes', {
      headers: headers,
      responseType:'text'
    })
      .subscribe((data:any) => {
        console.log("got data")
        this.value = data;
      });
  }
}
