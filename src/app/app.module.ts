import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RoomComponent } from './room/room.component';
import {RoomService} from 'src/app/services/room.service'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RoomDetailsComponent } from "./room-details/room-details.component";
import { FormsModule }   from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    RoomComponent,
    RoomDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [RoomService],
  bootstrap: [AppComponent]
})
export class AppModule { }
