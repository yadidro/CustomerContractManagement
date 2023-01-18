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
  textError: string = '';
  ngOnInit() {
  }

  onSubmit(loginForm: NgForm) {
    console.log(this.model)
    if (!loginForm.valid) {
      this.textError = 'Empty field is not allowed';
      return;
    }
    if (!this.checkIdValid(this.model.id)) {
      this.textError = 'Id should contain numbers only';
      return;
    }
    this.appService.checkCustomer(this.model.id).subscribe(
      (res: boolean) => {
        if (res) {
          localStorage.setItem('id', this.model.id);
          this.appService.setUserLoggedIn(true)
          this.router.navigate(['/dashboard']);
        }
        else
          this.textError = 'This id not exist on out system';
      },
      (err) => {
        console.log(err);
        this.textError = err;
      }
    );
  }

  checkIdValid(id: string): boolean {
    return /^$|^[0-9 ]+$/.test(id);
  }
}



export class User {
  public id: string = '';
  constructor(

  ) { }



}
