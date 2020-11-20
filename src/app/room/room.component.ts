import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RoomService } from 'src/app/services/room.service'
import { Room } from '../models/room.model';
import { Location } from '@angular/common';
@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.css']
})
export class RoomComponent implements OnInit {
  public room = [];


  constructor(private roomService: RoomService,
    private route: ActivatedRoute,
    private location: Location,
    private router: Router
  ) { }
  selectedId: number;
  ngOnInit(): void {
    this.getRoom();
  }
  getRoom(): void {
    this.roomService.getRoom().subscribe(room => {
      this.room = room;
    });
  }
  goToDetail() {

  }
  createRoom(): void {
    this.router.navigate(['/room-detail', {}]);
  }

  deleteRoom(room: Room): void {
    this.room = this.room.filter(r => r !== room);
    this.roomService.deleteRoom(room).subscribe();
  }

  gotoItems(id: string) {
    this.router.navigate(['/room-detail', { id: id }]);
  }
}