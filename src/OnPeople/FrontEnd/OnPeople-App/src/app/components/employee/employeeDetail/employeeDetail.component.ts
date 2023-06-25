import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

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

  public spinnerShow: boolean = false;

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
      selectCompanyId: [0, Validators.required],
      selectDepartmentId: [0, Validators.required],
      selectJobRoleId: [0, Validators.required],
      selectUserNameId: [0, Validators.required],
      cnpj: [''],
      sigla: [''],
      userName: [''],
      nomeCompleto: [''],
      email: [''],
      phoneNumber: ["", [Validators.required,]],
      selectVisao: ["default", [Validators.required]],
      visao: ["", [Validators.required]],
      dataAdmissao: ["", [Validators.required]],
      dataDemissao: [""],
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
    this.spinnerShow = true;

    this.companyService
      .getCompanyById(this.ctrF.selectCompanyId.value)
      .subscribe(
        (company: Empresa) => {
          this.company = company;
          this.department = this.company.departamentos[0]
          this.departments = this.company.departamentos
          this.jobRole = this.company.cargos[0];
          this.jobRoles = this.company.cargos
          this.ctrF.selectDepartmentId.setValue(this.department.id);
          this.ctrF.selectJobRoleId.setValue(this.jobRole.id);
          this.formDetail.patchValue(this.company);
          this.formDetail.patchValue(this.department);
          this.formDetail.patchValue(this.jobRole);
          this.user.email = this.user.userName + this.company.padraoEmail;
          this.logoURL = (this.company.logotipo !== 'Image_not_available.png')
            ? `${environment.resourcesLogosURL}${this.company.logotipo}`
            : `../../../../assets/img/${this.company.logotipo}`;
        },
        (error: any) => {
          this.logoURL = "../../../../assets/img/Image_not_available.png";
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
          console.error(error)
        }
      )
      .add(() => this.spinnerShow = false);
  }

  public changeSelectDepartment(): void {
    this.spinnerShow = true;

    this.departmentService
      .getDepartmentById(this.ctrF.selectDepartmentId.value)
      .subscribe(
        (department: Departamento) => {
          this.department = department
          this.jobRole = this.department.cargos[0];
          this.jobRoles = this.department.cargos
          this.ctrF.selectJobRoleId.setValue(this.jobRole.id);
          this.formDetail.patchValue(this.department);
          this.formDetail.patchValue(this.jobRole);
          this.changeSelectJobRole();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
          console.error(error)
        }
      )
      .add(() => this.spinnerShow = false);
  }

  public changeSelectJobRole(): void {
    this.spinnerShow = true;

    this.jobRoleService
      .getJobRoleById(this.ctrF.selectJobRoleId.value)
      .subscribe(
        (jobRole: Cargo) => {
          this.jobRole = jobRole;
          this.formDetail.patchValue(this.jobRole);
          console.log(this.jobRole.nomeCargo)
          if (this.jobRole.nomeCargo.toLowerCase().includes("diretor") && (this.jobRole.nomeCargo.toLowerCase().includes("rh") || this.jobRole.nomeCargo.toLowerCase().includes("recursos humanos"))) {
            this.user.visao = 'Master';
            this.ctrF.selectVisao.setValue('Master');
          } else if (this.jobRole.nomeCargo.toLowerCase().includes('rh')) {
            this.user.visao = 'Gold';
            this.ctrF.selectVisao.setValue('Gold');
          } else {
            this.user.visao = 'Bronze';
            this.ctrF.selectVisao.setValue('Bronze');
          }
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
          console.error(error)
        }
      )
      .add(() => this.spinnerShow = false);
  }

  public changeSelectUserName(): void {
    this.spinnerShow = true;

    this.userService
      .getUserById(this.ctrF.selectUserNameId.value)
      .subscribe(
        (user: Users) => {
          this.user = user;
          this.users[0] = user;
          this.user.email = this.user.userName + this.company.padraoEmail
          this.ctrF.selectVisao.setValue(this.user.visao);
          console.log(this.jobRole.nomeCargo)
          if (this.jobRole.nomeCargo.toLowerCase().includes("diretor") && (this.jobRole.nomeCargo.toLowerCase().includes("rh") || this.jobRole.nomeCargo.toLowerCase().includes("recursos humanos"))) {
            this.user.visao = 'Master';
            this.ctrF.selectVisao.setValue('Master');
          } else if (this.jobRole.nomeCargo.toLowerCase().includes('rh')) {
            this.user.visao = 'Gold';
            this.ctrF.selectVisao.setValue('Gold');
          } else {
            this.user.visao = 'Bronze';
            this.ctrF.selectVisao.setValue('Bronze');
          }

          this.formDetail.patchValue(this.user)
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
          console.error(error)
        }
      )
      .add(() => this.spinnerShow = false);
  }

  public getCompanies(): void {
    this.spinnerShow = true;;

    this.companyService
      .getCompanies(environment.initialPageDefault, environment.totalPagesDefault)
      .subscribe(
        (companies: PaginatedResult<Empresa[]>) => {
          this.companies = companies.result.filter(c => c.cargos.length > 0);
          console.log("companies", this.companies)
          this.company = this.companies[0]
          this.department = this.companies[0].departamentos[0]
          this.departments = this.companies[0].departamentos
          this.jobRole = this.companies[0].cargos[0];
          this.jobRoles = this.companies[0].cargos
          this.ctrF.selectCompanyId.setValue(this.company.id);
          this.ctrF.selectDepartmentId.setValue(this.department.id);
          this.ctrF.selectJobRoleId.setValue(this.jobRole.id);
          this.formDetail.patchValue(this.company);
          this.formDetail.patchValue(this.department);
          this.formDetail.patchValue(this.jobRole);
          this.logoURL = (this.company.logotipo !== 'Image_not_available.png')
          ? `${environment.resourcesLogosURL}${this.company.logotipo}`
            : `../../../../assets/img/${this.company.logotipo}`;
          this.getUsers();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerShow = false);
  }

  public getDepartmentsByCompanyId(): void {
    this.spinnerShow = true;;

    this.departmentService
      .getDepartmentsByCompanyId(this.ctrF.selectCompanyId.value)
      .subscribe(
        (departments: Departamento[]) => {
          this.departments = departments.filter(c => c.cargos.length > 0)
          this.department = this.departments[0]
          this.ctrF.selectDepartmentId.setValue(this.department.id);
          this.formDetail.patchValue(this.department)
          this.getJobRolesByDepartmentId();
        },
       (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerShow = false);
  }

    public getJobRolesByDepartmentId(): void {
    this.spinnerShow = true;;

    this.jobRoleService
      .getJobRoleByDepartmentId(this.ctrF.selectDepartmentId.value)
      .subscribe(
        (jobRoles: Cargo[]) => {
          this.jobRoles = jobRoles;
          this.jobRole = this.jobRoles[0]
          this.ctrF.selectJobRoleId.setValue(this.jobRole.id);
          this.formDetail.patchValue(this.jobRole)
          this.getUsers();
        },
       (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerShow = false);
    }

  public getUsers(): void {
    this.spinnerShow = true;;

    this.userService
      .getAccountsToAssociate()
      .subscribe(
        (users: Users[]) => {
          this.users = users;
          this.user = users[0]
          this.ctrF.selectUserNameId.setValue(this.user.id)
 
          if (this.jobRole.nomeCargo.toLowerCase().includes("diretor") && (this.jobRole.nomeCargo.toLowerCase().includes("rh") || this.jobRole.nomeCargo.toLowerCase().includes("recursos humanos"))) {
            this.user.visao = 'Master';
            this.ctrF.selectVisao.setValue('Master')
          } else if (this.jobRole.nomeCargo.toLowerCase().includes('rh')) {
            this.user.visao = 'Gold';
            this.ctrF.selectVisao.setValue('Gold')
          } else {
            this.user.visao = 'Bronze';
            this.ctrF.selectVisao.setValue('Bronze');
          }

          this.user.email = this.user.userName.toLowerCase() + this.company.padraoEmail
          this.formDetail.patchValue(this.user);

        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerShow = false);
  }

  public getEmployee(): void {
    this.spinnerShow = true;;

    this.employeeService
      .getEmployeeById(this.employeeParm)
      .subscribe(
        (employee: Funcionario) => {
          this.employee = employee;
          this.formDetail.patchValue(employee);

          this.company = this.employee.empresa;
          this.companies[0] = this.employee.empresa;
          this.ctrF.selectCompanyId.setValue(this.employee.empresaId);
          this.formDetail.patchValue(this.company);

          this.ctrF.selectDepartmentId.setValue(this.employee.departamentoId);
          this.department = this.employee.departamento
          this.departments[0] = this.employee.departamento
          this.formDetail.patchValue(this.department)

          this.ctrF.selectJobRoleId.setValue(this.employee.cargoId);
          this.jobRole = this.employee.cargo;
          this.jobRoles[0] = this.employee.cargo;
          this.formDetail.patchValue(this.jobRole)

          this.ctrF.selectUserNameId.setValue(this.employee.userId);
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
      .add(() => this.spinnerShow = false);
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
    this.spinnerShow = true;;

    this.employee = { ...this.formDetail.value };
    this.employee.userId = this.ctrF.selectUserNameId.value;
    this.employee.departamentoId = this.ctrF.selectDepartmentId.value;
    this.employee.cargoId = this.ctrF.selectJobRoleId.value;
    this.employee.empresaId = this.ctrF.selectCompanyId.value;
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
    .add(() => this.spinnerShow = false)
  }

  public updateAccount(): void {
    this.spinnerShow = true;;

    if (this.ctrF.selectVisao.value  == "Gerencial") {
      this.user.master = true;
      this.user.gold = false;
      this.user.bronze = false;
    } else if (this.ctrF.selectVisao.value  == "Operacional") {
      this.user.master = false;
      this.user.gold = true;
      this.user.bronze = false;
    } else {
      this.user.master = false
      this.user.gold = false;
      this.user.bronze = true;
    }

//    this.user.visao = this.selectVisao;
    this.user.codEmpresa = this.ctrF.selectCompanyId.value;
    this.user.codFuncionario = this.employee.id;
    this.user.codCargo = this.ctrF.selectJobRoleId.value;
    this.user.codDepartamento = this.ctrF.selectDepartmentId.value;
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
      .add(() => this.spinnerShow = false)
  }

  public updateEmployee(): void {
    this.spinnerShow = true;;

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
      .add(() => this.spinnerShow = false);
  }

  public createAddress(): void {
    this.spinnerShow = true;;

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
      .add(() => this.spinnerShow = false)
  }

  public createPersonalDocuments(): void {
    this.spinnerShow = true;;
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
      .add(() => this.spinnerShow = false)

  }

}
