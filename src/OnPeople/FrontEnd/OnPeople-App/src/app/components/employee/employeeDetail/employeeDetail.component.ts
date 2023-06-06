import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { PaginatedResult } from 'src/app/shared/class/paginator';

import { Cargo, DadoPessoal, Departamento, Empresa, Endereco, Funcionario, Users } from 'src/app/models';

import { AddressService, CompanyService, DepartmentService, EmployeeService, JobRoleService, PersonalDocumentsService, UserService } from 'src/app/services';

import { FormValidator } from 'src/app/shared/class/validators';

import { environment } from 'src/assets/environments';

import { DateAdapter } from '@angular/material/core';

@Component({
  selector: 'app-employeeDetail',
  templateUrl: './employeeDetail.component.html',
  styleUrls: ['./employeeDetail.component.scss']
})
export class EmployeeDetailComponent implements OnInit {
  public formDetail: FormGroup;

  public selectCompanyId = 0;
  public selectDepartmentId = 0;
  public selectJobRoleId = 0;
  public selectUserNameId = 0;

  public selectVisao = "default";

  public employeeParm: any = "";

  public company = {} as Empresa;
  public companies: Empresa[] = [];

  public department = {} as Departamento;
  public departments: Departamento[] = [];

  public user = {} as Users;
  public users: Users[] = [];

  public jobRole = {} as Cargo;
  public jobRoles: Cargo[] = [];

  public address = {} as Endereco;

  public personalDocument = {} as DadoPessoal;

  public employee = {} as Funcionario;

  public editMode: Boolean = false;

  public logoURL: string = "../../../../assets/img/Image_not_available.png";

  public get ctrF(): any {
    return this.formDetail.controls;
  }

  constructor(
    private activevateRouter: ActivatedRoute,
    private addressService: AddressService,
    private companyService: CompanyService,
    private departmentService: DepartmentService,
    private employeeService: EmployeeService,
    private formBuilder: FormBuilder,
    private jobRoleService: JobRoleService,
    private personalDocumentService: PersonalDocumentsService,
    private router: Router,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
    private userService: UserService,
    private dateAdapter: DateAdapter<Date>
  ) { this.dateAdapter.setLocale('pt-BR') }

  ngOnInit() {
    this.employeeParm = this.activevateRouter.snapshot.paramMap.get('id');
    this.editMode = (this.employeeParm != null) ? true : false;

    this.formValidator();

    if (this.editMode) {
      this.getEmployee();
    }
    else {
      this.getCompanies();
    }
  }

  public formValidator(): void {
    this.formDetail = this.formBuilder.group({
      selectUserNameId: [0, Validators.required],
      userName: [''],
      nomeCompleto: [''],
      email: [''],
      phoneNumber: ["", [Validators.required,]],
      selectVisao: ["", [Validators.required]],
      visao: ["", [Validators.required]],
      dataAdmissao: ["", [Validators.required]],
      dataDemissao: [""],
 //     cpf: ["", [Validators.required]],
 //     tituloEleitor: ["", [Validators.required]],
 //     padraoEmail: [""],
 //     impedimentoEleitora: [0, Validators.required],
 //     identidade: ['', Validators.required],
 //     dataExpedicao: ['', Validators.required],
 //     ufEmissao: ['', Validators.required],
 //     estadoCivil: ['Solteiro', Validators.required],
 //     caerteiraTrabalho: ['', Validators.required],
 //     pisPasep: ['', Validators.required],
 //     cep: ['', Validators.required],
 //     tipoEndereco: ['', Validators.required],
 //     logradouro: ['', Validators.required],
//      dataCriacao: [new Date().toString()],
//      dataEncerramento: []
    });
  }

    public fieldValidator(campoForm: FormControl): any {
    return FormValidator.checkFieldsWhithError(campoForm);
  }

  public messageReturned(nomeCampo: FormControl, nomeElemento: string): any {
    return FormValidator.returnMessage(nomeCampo, nomeElemento);
  }

  public clearForm(): void {
    this.formDetail.reset();
  }

  public changeSelectCompany(): void {
    this.spinnerService.show()

    this.companyService
      .getCompanyById(this.selectCompanyId)
      .subscribe(
        (company: Empresa) => {
          this.company = { ...company }
          this.formDetail.patchValue(this.company)
          this.user.email = this.user.userName + this.company.padraoEmail;
          this.logoURL = (this.company.logotipo !== 'Image_not_available.png')
          ? `${environment.resourcesLogosURL}${this.company.logotipo}`
            : `../../../../assets/img/${this.company.logotipo}`;
          this.getDepartmentsByCompanyId();
        },
        (error: any) => {
          this.logoURL = "../../../../assets/img/Image_not_available.png";
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
          console.error(error)
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public changeSelectDepartment(): void {
    this.spinnerService.show()

    this.departmentService
      .getDepartmentById(this.selectDepartmentId)
      .subscribe(
        (department: Departamento) => {
          this.department = department;
          this.formDetail.patchValue(this.department)
          this.getJobRolesByDepartmentId();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
          console.error(error)
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public changeSelectJobRole(): void {
    this.spinnerService.show()

    this.jobRoleService
      .getJobRoleById(this.selectJobRoleId)
      .subscribe(
        (jobRole: Cargo) => {
          this.jobRole = jobRole;
          this.formDetail.patchValue(this.jobRole)
          this.changeSelectUserName();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
          console.error(error)
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public changeSelectUserName(): void {
    this.spinnerService.show()

    this.userService
      .getUserById(this.selectUserNameId)
      .subscribe(
        (user: Users) => {
          this.user = user;
          this.users[0] = user;
          this.user.email = this.user.userName + this.company.padraoEmail
          this.selectVisao = this.user.visao

          if (this.jobRole.nomeCargo == "Diretor RH") {
            this.user.visao = 'Master';
            this.selectVisao = 'Master'
          } else if (this.jobRole.nomeCargo.toLowerCase().includes('rh')) {
            this.user.visao = 'Gold';
            this.selectVisao = 'Gold'
          } else {
            this.user.visao = 'Bronze';
            this.selectVisao = 'Bronze';
          }

          this.formDetail.patchValue(this.user)
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
          console.error(error)
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public getCompanies(): void {
    this.spinnerService.show();

    this.companyService
      .getCompanies(environment.initialPageDefault, environment.totalPagesDefault)
      .subscribe(
        (companies: PaginatedResult<Empresa[]>) => {
          this.companies = companies.result.filter(c => c.cargos.length > 0);
          this.company = this.companies[0]
          this.selectCompanyId = this.company.id;
          this.formDetail.patchValue(this.company);
          this.logoURL = (this.company.logotipo !== 'Image_not_available.png')
          ? `${environment.resourcesLogosURL}${this.company.logotipo}`
            : `../../../../assets/img/${this.company.logotipo}`;

          this.getDepartmentsByCompanyId();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public getDepartmentsByCompanyId(): void {
    this.spinnerService.show();

    this.departmentService
      .getDepartmentsByCompanyId(this.selectCompanyId)
      .subscribe(
        (departments: Departamento[]) => {
          this.departments = departments.filter(c => c.cargos.length > 0)
          this.department = this.departments[0]
          this.selectDepartmentId = this.department.id;
          this.formDetail.patchValue(this.department);
          this.getJobRolesByDepartmentId();
        },
       (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public getJobRolesByDepartmentId(): void {
    this.spinnerService.show();

    this.jobRoleService
      .getJobRoleByDepartmentId(this.selectDepartmentId)
      .subscribe(
        (jobRoles: Cargo[]) => {
          this.jobRoles = jobRoles;
          this.jobRole = this.jobRoles[0]
          this.formDetail.patchValue(this.jobRole);
          this.selectJobRoleId = this.jobRole.id;
          this.getUsers();
        },
       (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerService.hide());
    }

  public getUsers(): void {
    this.spinnerService.show();

    this.userService
      .getAccountsToAssociate()
      .subscribe(
        (users: Users[]) => {
          this.users = users;
          this.user = { ...users[0] }
          this.selectUserNameId = this.user.id

          if (this.jobRole.nomeCargo == "Diretor RH") {
            this.user.visao = 'Master';
            this.selectVisao = 'Master'
          } else if (this.jobRole.nomeCargo.toLowerCase().includes('rh')) {
            this.user.visao = 'Gold';
            this.selectVisao = 'Gold'
          } else {
            this.user.visao = 'Bronze';
            this.selectVisao = 'Bronze';
          }

          this.user.email = this.user.userName.toLowerCase() + this.company.padraoEmail
          this.formDetail.patchValue(this.user);

        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public getEmployee(): void {
    this.spinnerService.show();

    this.employeeService
      .getEmployeeById(this.employeeParm)
      .subscribe(
        (employee: Funcionario) => {
          this.employee = employee;
          this.formDetail.patchValue(employee);

          this.company = this.employee.empresa;
          this.companies[0] = this.employee.empresa;
          this.selectCompanyId = this.employee.empresaId;
          this.formDetail.patchValue(this.company);

          this.selectDepartmentId = this.employee.departamentoId
          this.department = this.employee.departamento
          this.departments[0] = this.employee.departamento
          this.formDetail.patchValue(this.department)

          this.selectJobRoleId = this.employee.cargoId;
          this.jobRole = this.employee.cargo;
          this.jobRoles[0] = this.employee.cargo;
          this.formDetail.patchValue(this.jobRole)

          this.selectUserNameId = this.employee.userId;
          this.changeSelectUserName();


          //this.changeSelectCompany();
          this.logoURL = (this.employee.empresa.logotipo !== 'Image_not_available.png')
            ? `${environment.resourcesLogosURL}${this.employee.empresa.logotipo}`
            : `../../../../assets/img/${this.employee.empresa.logotipo}`;
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! status ${error.status}`)
        }
      )
      .add(() => this.spinnerService.hide());
    }

  public saveChange(): void {
    if(this.formDetail.valid)
      if (!this.editMode){
        this.createEmployee();
      }
      else {
        this.updateEmployee();
      }
  }

  public createEmployee(): void {
    this.spinnerService.show();

    this.employee = { ...this.formDetail.value };
    this.employee.userId = this.selectUserNameId;
    this.employee.departamentoId = this.selectDepartmentId;
    this.employee.cargoId = this.selectJobRoleId;
    this.employee.empresaId = this.selectCompanyId;
    this.employee.ativo = true;

    this.employeeService
    .createEmployee(this.employee)
    .subscribe(
      (employeeCreated: Funcionario) => {
        this.employee = employeeCreated;

        this.updateAccount();
        this.createAddress();
        this.createPersonalDocuments();
        this.toastrService.success('Funcionario criado!', 'Sucesso!');
        window.location.reload;
        this.router.navigateByUrl(`/funcionarios/detail/${this.employee.id}`);
      },
      (error: any) => {
        this.toastrService.error(error.error, `Erro! Status ${error.status}`);
        console.error(error);
      }
    )
    .add(() => this.spinnerService.hide())
  }

  public updateAccount(): void {
    this.spinnerService.show();

    if (this.selectVisao == "Gerencial") {
      this.user.master = true;
      this.user.gold = false;
      this.user.bronze = false;
    } else if (this.selectVisao == "Operacional") {
      this.user.master = false;
      this.user.gold = true;
      this.user.bronze = false;
    } else {
      this.user.master = false
      this.user.gold = false;
      this.user.bronze = true;
    }

//    this.user.visao = this.selectVisao;
    this.user.codEmpresa = this.selectCompanyId;
    this.user.codFuncionario = this.employee.id;
    this.user.codCargo = this.selectJobRoleId;
    this.user.codDepartamento = this.selectDepartmentId;
    this.user.nomeEmpresa = this.company.razaoSocial;
    this.user.phoneNumber = this.ctrF.phoneNumber.value;

    this.userService
      .updateUser(this.user)
      .subscribe(
        (users: any) => {
          this.toastrService.success('Conta atualizada!', 'Sucesso!');
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide())
  }

  public updateEmployee(): void {
    this.spinnerService.show();

    this.employee.id = this.employee.id;
    this.employee.dataAdmissao = this.ctrF.dataAdmissao.value;
    this.employee.dataDemissao = this.ctrF.dataDemissao.value;
    this.employee.nomeCompleto = this.ctrF.nomeCompleto.value;

    this.employeeService
      .saveEmployee(this.employee.id, this.employee)
      .subscribe(
        (employee: Funcionario) => {
          this.toastrService.success('Funcionario salvo!', 'Sucesso!');
          this.updateAccount();
        },
        (error: any) => {
          if (error.status == 401)
            this.toastrService.error("Usuário não autorizado.", `Erro! Status ${error.status}`)
          else {
            this.toastrService.error(error.error, `Erro! Status ${error.status}`);
            console.error(error);
          }
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public createAddress(): void {
    this.spinnerService.show();

    this.address.funcionarioId = this.employee.id

    this.addressService
      .createAddress(this.address)
      .subscribe(
        (address: Endereco) => {
          this.toastrService.success('Aba endereço criada!', "Sucesso")

        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status} `)
        }
      )
      .add(() => this.spinnerService.hide())
  }

  public createPersonalDocuments(): void {
    this.spinnerService.show();
    this.personalDocument.funcionarioId = this.employee.id

     this.personalDocumentService
      .createPersonalDocument(this.personalDocument)
      .subscribe(
        (personalDocument: DadoPessoal) => {
          this.toastrService.success('Aba dados pessoais criada!', "Sucesso")
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status} `)
        }
      )
      .add(() => this.spinnerService.hide())

  }

}
