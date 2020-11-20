import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { from } from 'rxjs';
import { RoomDetailsComponent } from "./room-details/room-details.component";
import {RoomComponent} from './room/room.component';

const routes: Routes = [
  { path: '', redirectTo: '/room', pathMatch: 'full' },
  {
    path: 'room',
    component: RoomComponent, // this is the component with the <router-outlet> in the template
    children: [
      {
        path: 'detail', // child route path
        component: RoomDetailsComponent, // child route component that the router renders
      },
    ],
  },
  {
    path: 'room-detail',
    component: RoomDetailsComponent, // this is the component with the <router-outlet> in the template
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
