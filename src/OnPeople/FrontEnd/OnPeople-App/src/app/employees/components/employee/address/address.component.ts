import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Endereco } from 'src/app/employees/models';
import { AddressService } from 'src/app/employees/services/address.service';
import { FormValidator } from 'src/app/shared/models';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.scss']
})
export class AddressComponent implements OnInit {
  @Input() addressId: any;

  public formAddress: FormGroup;

  public selectAddressId = 0;

  public employeeParm: any = "";

  public editMode: Boolean = false;

  public address = {} as Endereco;
  public addresses: Endereco[] = [];

  public get ctrF(): any {
    return this.formAddress.controls;
  }

  constructor(
    private activevateRouter: ActivatedRoute,
    private addressService: AddressService,
    private formBuilder: FormBuilder,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
  ) { }

  ngOnInit() {
    this.employeeParm = this.activevateRouter.snapshot.paramMap.get('id');
    console.log(this.employeeParm)
    this.formValidator();

    this.getAddresses();
  }

  public formValidator(): void {
    this.formAddress = this.formBuilder.group({
      selectAddressId: [0, Validators.required],
    });
  }

  public fieldValidator(campoForm: FormControl): any {
    return FormValidator.checkFieldsWhithError(campoForm);
  }

  public messageReturned(nomeCampo: FormControl, nomeElemento: string): any {
    return FormValidator.returnMessage(nomeCampo, nomeElemento);
  }

  public clearForm(): void {
    this.formAddress.reset();
  }
  public changeSelectAddress(): void {
  }

  public getAddresses(): void {
    console.log("Address father", this.addressId)
    this.spinnerService.show();

    this.addressService
      .getAllAddressesByEmployeeId(parseInt(this.employeeParm))
      .subscribe(
        (addresses: Endereco[]) => {
          this.addresses = addresses;
          this.address = this.addresses[0]
          this.selectAddressId = this.address.id;
          this.formAddress.patchValue(this.address);
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerService.hide());
  }
}
