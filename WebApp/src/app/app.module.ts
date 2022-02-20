import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from './app-routing/app-routing.module';
import { ProtectedComponent } from './components/protected/protected.component';

@NgModule({
  declarations: [AppComponent, SidebarComponent, ProtectedComponent],
  imports: [BrowserModule, HttpClientModule, AppRoutingModule],
  bootstrap: [AppComponent]
})
export class AppModule {}
