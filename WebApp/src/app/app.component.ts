import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
  <div class="container-fluid">
    <div class="row">
      <div class="col-2 bg-dark text-white align-self-center">
        <app-sidebar></app-sidebar>
      </div>
      <div class="col">
        <router-outlet></router-outlet> 
      </div>
    </div>
  </div>
`,
})
export class AppComponent {

}
