import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Movement } from './models';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class MovementsService {

  constructor (
    private http: HttpClient,
    private toastr: ToastrService,
  ) { }

  getMovements(): Observable<Movement[]> {
    return this.http.get<Movement[]>('https://localhost:7032/api/Movement');
  }

  sendMessage(movement: Movement, message: string) {
    const notification = {
      phoneNumber: movement.phoneNumber,
      message
    }

    this.http.post('https://localhost:7032/api/Notification', notification).subscribe(() => {
      this.toastr.success('', 'Message Sent', { toastClass: 'alert alert-success' });
    });
  }

}
