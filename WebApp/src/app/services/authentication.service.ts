import { Injectable } from '@angular/core';
import { UserInfo } from '../models/userInfo';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor() { }

  private _userInfo:UserInfo;

  get userInfo() {
    return this._userInfo;
  }

  get userId():string {
    return this._userInfo ? this._userInfo.userId : null
  }

  isLoggedIn():boolean {
    return !!this.userId
  }

  async getUserInfo() {
    try {
      const response = await fetch('/.auth/me');
      const payload = await response.json();
      const { clientPrincipal } = payload;
      this._userInfo = clientPrincipal;
      return clientPrincipal;
    } catch (error) {
      console.error('No profile could be found');
      return undefined;
    }
  }
}
