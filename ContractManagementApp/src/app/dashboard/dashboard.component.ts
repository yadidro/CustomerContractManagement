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
  customerEditRequest: CustomerRequest = new CustomerRequest();
  editmode: boolean = false;
  public currentCustomer: Customer | undefined;
  public userId: string = '';
  constructor(private appService: AppService) { }

  ngOnInit() {
    this.userId = localStorage.getItem('id')!;
    this.GetCustomer();
    this.customerEditRequest.id = this.userId;
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

  editAddressDetails() {
    this.editmode = true;
  }

  hideAddressDetails() {
    this.editmode = false;
  }

  onSubmit() {
    console.log(this.customerEditRequest)
    if (!this.checkInputValid(this.customerEditRequest.city)
      || !this.checkInputValid(this.customerEditRequest.street)
      || !this.checkInputValid(this.customerEditRequest.homeNumber)
      || !this.checkInputValid(this.customerEditRequest.postalCode)) {
      this.textError = 'Text should not contain any special character';
      return;
    }
    
    this.appService.EditCustomer(this.customerEditRequest).subscribe(
      () => {
          this.GetCustomer();
          this.textError = 'Address details hs been updated successfully';
      },
      (err) => {
        console.log(err);
        this.textError = err;
      }
    );
  }

  checkInputValid(input: string): boolean {
      return /^$|^[a-zA-ZÀ-ÖØ-öø-ÿ0-9 ]+$/.test(input);
  }

}

export class CustomerRequest {
  public id: string = '';
  public city: string = '';
  public street: string = '';
  public homeNumber: string = '';
  public postalCode: string = '';
  constructor(
  ) { }

}
