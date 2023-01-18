import { Component, OnInit } from '@angular/core';
import { AppService } from '../_services/app.service';
import { Customer, ContractType, PackageType} from '../models/customer';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  textError: string = '';
  public currentCustomer: Customer | undefined;
  public userId: string = '';
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
    switch (Number(value)) {
      case 0:
        return ContractType.CostPlus
      case 1:
        return ContractType.FixedPrice
      case 2:
        return ContractType.TimeAndMaterial
      default:
        return ContractType.TimeAndMaterial
    }
  }
  getPackgeType(value: string) {
    switch (Number(value)) {
      case 0:
        return PackageType.Extra
      case 1:
        return PackageType.Full
      case 2:
        return PackageType.Partly
      default:
        return PackageType.Extra
    }

  }
}
