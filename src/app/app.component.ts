import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `<div>Hello {{value}}</div>`,
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
