import { Component} from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDividerModule } from '@angular/material/divider';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatRadioModule } from '@angular/material/radio';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { Client, UserDto } from 'app/api-client/api-client';
import { FormsModule } from '@angular/forms';
import {Router} from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-current-details',
  standalone: true,
  imports: [CommonModule,
    MatInputModule,
    MatSelectModule,
    MatFormFieldModule,
    MatDividerModule,
    MatCheckboxModule,
    MatRadioModule,
    MatButtonModule,
    MatIconModule,
    FormsModule],
  templateUrl: './user-current-details.component.html',
  styleUrl: './user-current-details.component.scss'
})
export class UserCurrentDetailsComponent {
  id: number;
  user: UserDto = new UserDto();
  client = new Client('https://localhost:44340');
  errorAlert: boolean = false;

  constructor(private _router: Router, private _route: ActivatedRoute){}

  ngOnInit() {
    this.fetchData();
  }

  async fetchData(){
    try {
      this.user = await this.client.currentUser();
    } catch (error) {
      error.console(error);
    }
  }

  update(){
    this._router.navigate(['/users/update', this.user.id]);
  }
  
}
