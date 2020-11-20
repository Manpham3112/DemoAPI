import { Component, OnInit } from '@angular/core';
import { Room } from '../models/room.model';
import { RoomService } from '../services/room.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Location } from '@angular/common';



@Component({
  selector: 'app-room-details',
  templateUrl: './room-details.component.html',
  styleUrls: ['./room-details.component.css']
})
export class RoomDetailsComponent implements OnInit {

  public roomDetail: Room = {
    id: '',
    name: '',
    price: 0,
    status: 0,
  }
  constructor(
    private route: ActivatedRoute,
    private roomService: RoomService,
    private location: Location
  ) { }
  ngOnInit() {
    const roomId = this.route.snapshot.paramMap.get('id');
    if (roomId) {
      this.roomService.getRoomDetail(roomId).subscribe(detail => {
        this.roomDetail = detail;
      });
    }
  }
  goBack() {
    this.location.back();
  }
  save() {
    if (!this.roomDetail?.id) {
      this.roomService.insertRoom(this.roomDetail).subscribe((result) => {
        console.log("save room successfully.");
        this.goBack();
      });
      return;
    }
    this.roomService.updateRoom(this.roomDetail).subscribe((result) => {

      this.goBack()
    });
  }
}



