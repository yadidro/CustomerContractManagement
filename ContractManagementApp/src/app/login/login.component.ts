import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { AppService } from '../_services/app.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router: Router, private appService: AppService) { }

  model: User = new User();

  ngOnInit() {
  }

  onSubmit(loginForm: NgForm) {
    console.log(this.model)
    this.appService.checkCustomer('656').subscribe(
      (res: boolean) => {
        if (loginForm.valid && res) {
          this.appService.setUserLoggedIn(true)
          this.router.navigate(['/dashboard']);
        }
        //this.textError = '';
      },
      (err) => {
        console.log(err);
        //  this.textError = 'An error has occured, please try again later';
      }
    );
  }
}
export class User {

  public userName: string = '';
  public password: string = '';
  constructor(

  ) { }



}
