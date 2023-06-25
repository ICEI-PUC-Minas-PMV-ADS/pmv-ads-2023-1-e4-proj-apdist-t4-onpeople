import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { ToastrService } from 'ngx-toastr';

import { Endereco } from 'src/app/models';

import { AddressService } from 'src/app/services';

import { FormValidator } from 'src/app/shared/class/validators';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.scss']
})
export class AddressComponent implements OnInit {
  public formAddress: FormGroup;

  public spinnerShow: boolean = false;

  public id = 0;

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
    private toastrService: ToastrService,
  ) { }

  ngOnInit() {
    this.employeeParm = this.activevateRouter.snapshot.paramMap.get('id');
    this.formValidator();

    this.getAddresses();
  }

  public formValidator(): void {
    this.formAddress = this.formBuilder.group({
      id: [0, Validators.required],
      tipoEndereco: [""],
      cep: ['', Validators.required],
      logradouro: ['', Validators.required],
      numero: ['', Validators.required],
      complemento: ['', Validators.required],
      bairro: ['', Validators.required],
      cidade: ['', Validators.required],
      uf: ['', Validators.required]
    });
  }

  public fieldValidator(campoForm: FormControl): any {
    return FormValidator.checkFieldsWhithError(campoForm);
  }

  public messageReturned(nomeCampo: FormControl, nomeElemento: string): any {
    return FormValidator.returnMessage(nomeCampo, nomeElemento);
  }

  public getAddresses(): void {
    this.spinnerShow = true;;

    this.addressService
      .getAllAddressesByEmployeeId(parseInt(this.employeeParm))
      .subscribe(
        (addresses: Endereco[]) => {
          this.addresses = addresses;
          this.address = this.addresses[0]
          this.id = this.address.id;
          this.formAddress.patchValue(this.address);
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerShow = false);
  }

  public getCEP(): any {
    this.spinnerShow = true;;

    this.addressService
      .getCEP(this.ctrF.cep.value)
     .subscribe((address: any) => {
        this.address = address
        this.formAddress.patchValue(this.address)
        this.address.cidade = address.localidade
        this.ctrF.cidade.setValue(this.address.cidade);
        },
        (error: any) => {
          this.toastrService.error(error, `Erro!`)
          console.error()
        }
      )
      .add(() => this.spinnerShow = false);

  }

  public saveChange(): void {
    this.spinnerShow = true;;

    this.address = { ...this.formAddress.value }
    this.address.funcionarioId = this.employeeParm;

    this.addressService
      .saveAddress(this.address.id, this.address)
      .subscribe(
        (address: Endereco) => {
          this.toastrService.success('Endereço ataulizado!', "Sucesso")

        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status} `)
        }
      )
      .add(() => this.spinnerShow = false)
  }
}
