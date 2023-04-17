# Programação de Funcionalidades

## RF-006: O sistema deverá permitir o gerenciamento de departamentos (CRUD)

Endpoints implementados na controller Departamentos para atender o requisito especificado:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/ControllerDepartamentosSwagger.png>
</p>


## Artefatos gerados

### Camada OnPeople.API

* src\OnPeople\BackEnd\src\OnPeople.API\Controllers\Departamentos\DepartamentosController.cs

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/OnPeopleAPI_Departamentos.png>
</p>
</br>

### Camada OnPeople.Application

* src\OnPeople\BackEnd\src\OnPeople.Application\Dtos\Departamentos\DepartamentoDto.cs
* src\OnPeople\BackEnd\src\OnPeople.Application\Services\Contracts\Departamentos\IDepartamentosServices.cs
* src\OnPeople\BackEnd\src\OnPeople.Application\Services\Implementations\Departamentos\DepartamentosServices.cs

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/OnPeopleApplication_Departamentos.png>
</p>
</br>

### Camada OnPeople.Domain

* src\OnPeople\BackEnd\src\OnPeople.Domain\Models\Departamentos\Departamento.cs

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/OnPeopleDomain_Departamentos.png>
</p>
</br>

### Camada OnPeople.Persistence

* src\OnPeople\BackEnd\src\OnPeople.Persistence\Interfaces\Contexts\OnPeopleContext.cs
* src\OnPeople\BackEnd\src\OnPeople.Persistence\Interfaces\Contracts\Departamentos\IDepartamentosPersistence.cs
* src\OnPeople\BackEnd\src\OnPeople.Persistence\Interfaces\Contracts\Shared\ISharedPersistence.cs
* src\OnPeople\BackEnd\src\OnPeople.Persistence\Interfaces\Implementations\Departamentos\DepartamentosPersistence.cs
* src\OnPeople\BackEnd\src\OnPeople.Persistence\Interfaces\Implementations\Shared\SharedPersistence.cs

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/OnPeoplePersistence_Departamentos.png>
</p>
</br>
