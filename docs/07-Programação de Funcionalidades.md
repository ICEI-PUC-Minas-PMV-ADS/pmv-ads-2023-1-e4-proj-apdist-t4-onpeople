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

## RF-007: O sistema deverá permitir o gerenciamento de cargos (CRUD)

Endpoints implementados na controller Cargos para atender o requisito especificado:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/ControllerCargosSwagger.png>
</p>


## Artefatos gerados

### Camada OnPeople.API

* src\OnPeople\BackEnd\src\OnPeople.API\Controllers\Cargos\CargosController.cs

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/OnPeopleAPI_Cargos.png>
</p>
</br>

### Camada OnPeople.Application

* src\OnPeople\BackEnd\src\OnPeople.Application\Dtos\Cargos\CargoDto.cs
* src\OnPeople\BackEnd\src\OnPeople.Application\Services\Contracts\Cargos\ICargosServices.cs
* src\OnPeople\BackEnd\src\OnPeople.Application\Services\Implementations\Cargos\CargosServices.cs

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/OnPeopleApplication_Cargos.png>
</p>
</br>

### Camada OnPeople.Domain

* src\OnPeople\BackEnd\src\OnPeople.Domain\Models\Cargos\Cargo.cs

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/OnPeopleDomain_Cargos.png>
</p>
</br>

### Camada OnPeople.Persistence

* src\OnPeople\BackEnd\src\OnPeople.Persistence\Interfaces\Contexts\OnPeopleContext.cs
* src\OnPeople\BackEnd\src\OnPeople.Persistence\Interfaces\Contracts\Cargos\ICargosPersistence.cs
* src\OnPeople\BackEnd\src\OnPeople.Persistence\Interfaces\Contracts\Shared\ISharedPersistence.cs
* src\OnPeople\BackEnd\src\OnPeople.Persistence\Interfaces\Implementations\Cargos\CargosPersistence.cs
* src\OnPeople\BackEnd\src\OnPeople.Persistence\Interfaces\Implementations\Shared\SharedPersistence.cs

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/OnPeoplePersistence_Cargos.png>
</p>
</br>


## RF-009: O sistema deverá permitir o cadastro de novas metas

Endpoints implementados no controller Metas para atender o requisito especificado:

![ENDPOINTS Metas](https://user-images.githubusercontent.com/91227083/233861632-758601d4-d935-4fc5-971e-8b11de3596cf.jpg)
![SCHEMA Metas](https://user-images.githubusercontent.com/91227083/233862082-f684efc2-b7c6-4edb-a65d-e9682b2e4606.jpg)


## Artefatos gerados

### Camada OnPeople.API

![API Metas](https://user-images.githubusercontent.com/91227083/233861706-1849ab0c-b092-4aac-a726-28fa4c5f1feb.jpg)

### Camada OnPeople.Application

![APPLICATION Metas](https://user-images.githubusercontent.com/91227083/233861787-fdde7f60-c660-4877-9879-d95bf733a1db.jpg)

### Camada OnPeople.Domain

![DOMAIN Metas](https://user-images.githubusercontent.com/91227083/233861799-14b52f1f-214e-447f-8a50-2a45e0aed042.jpg)

### Camada OnPeople.Persistence

![PERSISTENCE Metas](https://user-images.githubusercontent.com/91227083/233861810-aa25d1a4-1918-458b-8213-927600e63261.jpg)

