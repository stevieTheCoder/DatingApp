import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Observable, EMPTY } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { catchError, tap } from 'rxjs/operators';
import {
  GalleryItem, ImageItem
} from '@ngx-gallery/core';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css']
})
export class MemberDetailComponent implements OnInit {
  images: GalleryItem[];

  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private alertify: AlertifyService
  ) {}

  user$: Observable<User> = this.userService
    .getUser(+this.route.snapshot.params.id)
    .pipe(
      tap(user => {
        const imageItems = [];
        for (const photo of user.photos) {
          imageItems.push(new ImageItem({
            src: photo.url,
            thumb: photo.url
          }));
        }
        this.images = imageItems;
      }),
      catchError(err => {
        console.log(err);
        this.alertify.error(err);
        return EMPTY;
      })
    );

  ngOnInit() { }
}
