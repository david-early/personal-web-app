import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { identityProviders, UserInfo } from '../../models/userInfo';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  public value:string = "World";
  constructor(public authService: AuthenticationService,
    private http: HttpClient) { }

  providers = identityProviders;
  redirect = window.location.pathname;
  userInfo: UserInfo;

  async ngOnInit() {
    this.userInfo = await this.authService.getUserInfo();
  }

  public getRecipes() {
    const headers = new HttpHeaders().set('Content-Type', 'text/plain; charset=utf-8')
    .set('x-ms-client-principal', btoa(JSON.stringify(this.authService.userInfo)));

    this.http.get('/api/GetRecipes', {
      headers: headers,
      responseType:'text'
    })
    .subscribe((data:any) => {
      console.log("got data")
      this.value = data;
    }, (error) => {
      console.log("Error getting data");
      console.log(error);
    }); 
  }

}
