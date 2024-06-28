import { NgIf, CommonModule } from '@angular/common';
import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormsModule, NgForm, ReactiveFormsModule, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { Router, RouterLink } from '@angular/router';
import { fuseAnimations } from '@fuse/animations';
import { FuseAlertComponent, FuseAlertType } from '@fuse/components/alert';
import { LoginResponseDto, Client } from 'app/api-client/api-client'

@Component({
  selector: 'app-login',
    templateUrl  : './login.component.html',
    encapsulation: ViewEncapsulation.None,
    animations   : fuseAnimations,
    standalone   : true,
    imports      : [RouterLink, FuseAlertComponent, NgIf, FormsModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatIconModule, MatCheckboxModule, MatProgressSpinnerModule, CommonModule],
})
export class LoginComponent implements OnInit
{
  @ViewChild('signInNgForm') signInNgForm: NgForm;

  alert: { type: FuseAlertType; message: string } = {
      type   : 'success',
      message: '',
  };
  signInForm: UntypedFormGroup;
  showAlert: boolean = false;
  client = new Client('https://localhost:44340');
  loginResponse: LoginResponseDto;
  login: string;
  password: string;
  errorAlert: boolean = false;

  /**
   * Constructor
   */
  constructor(
      private _formBuilder: UntypedFormBuilder,
      private _router: Router,
  )
  {
  }

  ngOnInit(): void
  {
      // Create the form
      this.signInForm = this._formBuilder.group({
          login     : ['rskrebels', [Validators.required]],
          password  : ['1lxSrSE6GLBb', Validators.required]
      });
  }

  async signIn()
  {
    try {
      this.loginResponse = await this.client.login(this.login, this.password);
      this._router.navigate(['/users/current/']);
    } catch (error) {
      this.errorAlert = true;
    }
  }
}

