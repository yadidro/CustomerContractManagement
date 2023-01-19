import { Component, Input, Output , EventEmitter } from '@angular/core';
import { AppService } from '../_services/app.service';

@Component({
  selector: 'app-address-edit',
  templateUrl: './address-edit.component.html',
  styleUrls: ['./address-edit.component.css']
})
export class AddressEditComponent {
  editmode: boolean = false;
  customerEditRequest: CustomerRequest = new CustomerRequest();
  textError: string = '';
  @Output() updateCustomer = new EventEmitter();
  @Input() userId: string = '';

  constructor(private appService: AppService) {
    this.customerEditRequest.id = this.userId;
   }

   ngOnInit() {
    this.customerEditRequest.id = this.userId;
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
        this.updateCustomer.emit();
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

  editAddressDetails() {
    this.editmode = true;
  }

  hideAddressDetails() {
    this.editmode = false;
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
