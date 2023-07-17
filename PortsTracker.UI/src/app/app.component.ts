import { Component, OnInit } from '@angular/core';
import { timer } from 'rxjs';
import { Movement } from './models';
import { MovementsService } from './movements.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Ports Tracker';
  movements$: any;

  changeDetector = 0;
  /**
   *
   */
  constructor (
    private movementsSerivce: MovementsService,
  ) {


  }

  ngOnInit() {
    this.movements$ = this.movementsSerivce.getMovements();

    timer(1000, 1000).subscribe(() => {
      this.changeDetector++;
    })
  }

  toDuration(movementTime: Date) {
    const rightNow = new Date();
    const movement = Date.parse(`${movementTime}`);
    const timeDiff = rightNow.getTime() - movement;

    return timeDiff;

  }

  toBreak(movementTime: Date) {
    const rightNow = new Date();
    const movement = Date.parse(`${movementTime}`);
    const timeDiff = rightNow.getTime() - (movement - (50 * 60 * 1000));
    return timeDiff;
  }

  sendMessage(movement: Movement, message: string) {
    this.movementsSerivce.sendMessage(movement, message)
  }
}
