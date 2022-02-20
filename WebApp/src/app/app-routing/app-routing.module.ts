import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router'
import { ProtectedComponent } from '../components/protected/protected.component';

const routes: Routes = [
  { path: 'protected', component: ProtectedComponent }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
