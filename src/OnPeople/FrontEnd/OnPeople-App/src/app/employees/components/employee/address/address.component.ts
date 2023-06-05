import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Endereco } from 'src/app/employees/models';
import { AddressService } from 'src/app/employees/services/address.service';
import { FormValidator } from 'src/app/shared/models';
import { CEPError, NgxViacepService } from "@brunoc/ngx-viacep";
import { HttpClient } from '@angular/common/http';
import { EMPTY, catchError } from 'rxjs';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.scss']
})
export class AddressComponent implements OnInit {
  public formAddress: FormGroup;

  public id = 0;

  public employeeParm: any = "";

  public cep: any = "";

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
    private viacep: NgxViacepService,
  ) { }

  ngOnInit() {
    this.employeeParm = this.activevateRouter.snapshot.paramMap.get('id');
    console.log(this.employeeParm)
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
    this.spinnerService.show();

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
      .add(() => this.spinnerService.hide());
  }

  public getCEP(): any {
    this.spinnerService.show();

     console.log (this.cep)
    this.viacep
      .buscarPorCep(this.cep)
      .subscribe((address: any) => {
        this.address = { ...address }
        this.formAddress.patchValue(this.address)
        this.address.cidade = address.localidade
        this.formAddress.controls['cidade'].setValue(this.address.cidade);
        console.log(this.address);
        },
        (error: any) => {
          this.toastrService.error(error, `Erro!`)
          console.error()
        }
      )
      .add(() => this.spinnerService.hide());

  }

  public saveChange(): void {
    this.spinnerService.show();

    this.address = { ...this.formAddress.value }
    this.address.funcionarioId = this.employeeParm;

    console.log("Address", this.address)

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
      .add(() => this.spinnerService.hide())
  }
}
