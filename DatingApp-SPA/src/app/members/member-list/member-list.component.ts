import { Component, OnInit } from '@angular/core';
import { UserService } from '../../_services/user.service';
import { Observable, EMPTY } from 'rxjs';
import { User } from '../../_models/user';
import { catchError } from 'rxjs/operators';
import { AlertifyService } from '../../_services/alertify.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  constructor(
    private userService: UserService,
    private alertify: AlertifyService
  ) {}

  users$: Observable<User[]> = this.userService.getUsers().pipe(
    catchError(err => {
      this.alertify.error(err);
      return EMPTY;
    })
  );
  ngOnInit() {}
}
