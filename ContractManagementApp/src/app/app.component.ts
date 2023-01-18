import { Component, ViewChild, TemplateRef, ElementRef, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';

import { Idle, DEFAULT_INTERRUPTSOURCES } from '@ng-idle/core';
import { Keepalive } from '@ng-idle/keepalive';

import { BsModalService } from 'ngx-bootstrap/modal';
import { AppService } from './_services/app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  idleState = '';
  timedOut = false;
  lastPing?: Date;
  title = 'angular-idle-timeout';
  showLogOut=false;

  //@ViewChild('childModal', { static: false }) childModal;

  constructor(private idle: Idle, private keepalive: Keepalive, 
    private router: Router, private modalService: BsModalService, private appService: AppService) {
    // sets a timeout period of 5 minutes.
    idle.setTimeout(5);
    idle.setIdle(5);
    // sets the default interrupts, in this case, things like clicks, scrolls, touches to the document
    idle.setInterrupts(DEFAULT_INTERRUPTSOURCES);

    idle.onIdleEnd.subscribe(() => { 
      this.idleState = 'No longer idle.'
      console.log(this.idleState);
      this.reset();
    });
    
    idle.onTimeout.subscribe(() => {
      this.idleState = 'Timed out!';
      this.timedOut = true;
      console.log(this.idleState);
      this.router.navigate(['/']);
    });
    
    idle.onIdleStart.subscribe(() => {
        this.idleState = 'You\'ve gone idle!'
        console.log(this.idleState);
    });
    
    idle.onTimeoutWarning.subscribe((countdown) => {
      this.idleState = 'You will time out in ' + countdown + ' seconds!'
      console.log(this.idleState);
    });

    // sets the ping interval to 15 seconds
    keepalive.interval(15);

    keepalive.onPing.subscribe(() => this.lastPing = new Date());

    this.appService.getUserLoggedIn().subscribe(userLoggedIn => {
      if (userLoggedIn) {
        idle.watch()
        this.timedOut = false;
        this.showLogOut=true
      } else {
        idle.stop();
      }
    })
    this.logout();
  }

  reset() {
    this.idle.watch();
    this.timedOut = false;
  }

  stay() {
    this.reset();
  }

  logout() {
    this.appService.setUserLoggedIn(false);
    this.router.navigate(['/']);
    this.showLogOut=false;
  }

}
