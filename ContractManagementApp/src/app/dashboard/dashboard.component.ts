import { Component, OnInit } from '@angular/core';
import { AppService } from '../_services/app.service';
import { Customer, ContractType, PackageType } from '../models/customer';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  textError: string = '';
  public currentCustomer: Customer | undefined;
  public userId: string = '';
  packageTypes:string[]=Object.values(PackageType)
  contractTypes:string[]=Object.values(ContractType)

  constructor(private appService: AppService) { }

  ngOnInit() {
    this.userId = localStorage.getItem('id')!;
    this.GetCustomer();
  }

  GetCustomer() {
    this.appService.GetCustomer(this.userId).subscribe(
      (res: Customer) => {
        if (res) {
          this.currentCustomer = res;
        }
      },
      (err) => {
        console.log(err);
        this.textError = err;
      }
    );
  }
  
  getContractType(value: string) {
    return this.contractTypes[Number(value)];
  }

  getPackgeType(value: string) {
    return this.packageTypes[Number(value)];
    }
}

