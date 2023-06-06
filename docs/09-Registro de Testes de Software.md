# Registro de Testes de Software

## RF-004: O sistema deverá permitir o gerenciamento de empresas (CRUD)

### Testes de unidade automatizados

Ferramenta de testes: xUnit.net (disponilizada para aplicações do .NET Framework)

Para o RF-004 foram executados 10 testes de unidade automatizados, que cobrem os principais métodos da camada de serviços do contexto EmpresasServices. Para cada método, foram implementados 2 testes de unidade: um cenário de sucesso e outro de insucesso.

**Resumo da execução:**
</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/TestesUnitariosEmpresas.png>
</p>


## RF-006: O sistema deverá permitir o gerenciamento de departamentos (CRUD)

### Testes de unidade automatizados

Além dos testes manuais evidenciados abaixo, foram implementados também os testes de unidade automatizados utilizando a ferramenta de testes xUnit.net disponilizada para aplicações do .NET Framework.

Para o RF-006 foram executados 10 testes de unidade automatizados, que cobrem todos os métodos da camada de serviços do contexto DepartamentosServices. Para cada método, foram implementados 2 testes de unidade: um cenário de sucesso e outro de insucesso.

**Resumo da execução:**
</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/TestesUnitariosDepartamentos2.png>
</p>


### Testes manuais

**CT01: POST api/Departamentos - Realizando a requisição informando os dados obrigatórios corretamente**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** que as propriedades nomeDepartamento e empresaId sejam informados no request body <br/>
**When** a rota POST api/Departamentos for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter os dados do departamento cadastrado conforme as informações enviadas na requisição <br/>
**And** o departamento cadastrado deve ser inserido no banco de dados

**Evidências:**

Dados obrigatórios conforme contrato:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT01.1.png>
</p>
</br>

Executando a rota informando os dados obrigatórios:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT01.2.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT01.3.png>
</p>
</br>

Departamento inserido no banco de dados:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT01.4.png>
</p>
</br>

**CT02: POST api/Departamentos - Realizando a requisição sem informar os dados obrigatórios**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** que alguma propriedade obrigatória não seja informada no request body <br/>
**When** a rota POST api/Departamentos for executada <br/>
**Then** o status code 400 deve ser retornado <br/>
**And** o objeto errors no response body deve conter uma mensagem informando sobre a obrigatoriedade dos campos

**Evidências:**

Dados obrigatórios conforme contrato:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT01.1.png>
</p>
</br>

Executando a rota sem informar todos os dados obrigatórios:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT02.1.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT02.2.png>
</p>
</br>

**CT03: GET api/Departamentos - Executando a rota sem informar nenhum parâmetro**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** que nenhum parâmetro seja informado <br/>
**When** a rota GET api/Departamentos for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter um array de objetos para cada departamento cadastrado no banco de dados

**Evidências:**

Executando a rota sem informar nenhum parâmetro:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT03.1.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT03.2.png>
</p>
</br>

Departamentos cadastrados no banco de dados:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT03.3.png>
</p>
</br>

**CT04: GET api/Departamentos/{departamentoId} - Executando a rota informando um departamentoId válido (existente)**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** um departamentoId válido (existente) seja informado como parâmetro <br/>
**When** a rota GET api/Departamentos/{departamentoId} for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter os dados do departamento informado como parâmetro

**Evidências:**

Executando a rota informando um departamentoId válido (existente) como parâmetro:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT04.1.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT04.2.png>
</p>
</br>

Dados do departamento no banco de dados:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT04.3.png>
</p>
</br>

**CT06: PUT api/Departamentos/{departamentoId} - Executando a rota informando um departamentoId válido (existente) e todos os dados obrigatórios**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** um departamentoId válido (existente) seja informado como parâmetro e que no request body todos os dados obrigatórios sejam preenchidos <br/>
**When** a rota PUT api/Departamentos/{departamentoId} for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter os dados do departamento alterado <br/>
**And** os dados do departamento devem ser atualizados no banco de dados conforme os dados enviados na requisição

**Evidências:**

Dados do departamento 10 no banco de dados antes da alteração:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT06.1.png>
</p>
</br>

Executando a rota para atualizar o nome do departamento,a sigla e a empresa associada:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT06.2.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT06.3.png>
</p>
</br>

Dados do departamento atualizados no banco de dados:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT06.4.png>
</p>
</br>

**CT08: PUT api/Departamentos/{departamentoId} - Executando a rota informando um departamentoId inválido (inexistente)**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** um departamentoId inválido (inexistente) seja informado como parâmetro <br/>
**When** a rota PUT api/Departamentos/{departamentoId} for executada <br/>
**Then** o status code 400 deve ser retornado <br/>
**And** o response body deve conter uma mensagem informando que o departamento informado como parâmetro não foi localizado

**Evidências:**

Departamento 12 não existe no banco de dados:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT08.1.png>
</p>
</br>

Executando a rota informando o departamentoId inválido (inexistente):

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT08.2.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT08.3.png>
</p>
</br>

**CT09: DELETE api/Departamentos/{departamentoId} - Executando a rota informando um departamentoId inativo**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** um departamentoId inativo seja informado como parâmetro <br/>
**When** a rota DELETE api/Departamentos/{departamentoId} for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o departamento deve ser excluído no banco de dados

**Evidências:**

Departamento 11 existe no banco de dados e consta inativo:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT09.1.png>
</p>
</br>

Executando a rota informando o departamentoId inativo:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT09.2.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT09.3.png>
</p>
</br>

Departamento excluído no banco de dados:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT09.4.png>
</p>
</br>

**CT11: GET api/Departamentos/{empresaId}/empresa - Executando a rota informando uma empresa que possui departamentos vinculados**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** uma empresaId que possui departamentos vinculados seja informada como parâmetro <br/>
**When** a rota GET api/Departamentos/{empresaId}/empresa for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter um array de objetos para cada departamento vinculado à empresa no banco de dados

**Evidências:**

EmpresaId 2 possui um departamento cadastrado:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT11.1.png>
</p>
</br>

Executando a rota informando a EmpresaId 2:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT11.2.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerDepartamentos/CT11.3.png>
</p>
</br>

## RF-007: O sistema deverá permitir o gerenciamento de cargos (CRUD)

### Testes de unidade automatizados

Além dos testes manuais evidenciados abaixo, foram implementados também os testes de unidade automatizados utilizando a ferramenta de testes xUnit.net disponilizada para aplicações do .NET Framework.

Para o RF-007 foram executados 10 testes de unidade automatizados, que cobrem todos os métodos da camada de serviços do contexto CargosServices. Para cada método, foram implementados 2 testes de unidade: um cenário de sucesso e outro de insucesso.

**Resumo da execução:**
</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/TestesUnitariosCargos2.png>
</p>

### Testes manuais

**CT01: POST api/Cargos- Realizando a requisição informando os dados obrigatórios corretamente**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** que as propriedades nomeCargo, departamentoId e empresaId sejam informados no request body <br/>
**When** a rota POST api/Cargos for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter os dados do cargo cadastrado conforme as informações enviadas na requisição <br/>
**And** o cargo cadastrado deve ser inserido no banco de dados

**Evidências:**

Dados obrigatórios conforme contrato:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT01.1.png>
</p>
</br>

Executando a rota informando os dados obrigatórios:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT01.2.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT01.3.png>
</p>
</br>

Cargo inserido no banco de dados:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT01.4.png>
</p>
</br>


**CT03: GET api/Cargos - Executando a rota sem informar nenhum parâmetro**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** que nenhum parâmetro seja informado <br/>
**When** a rota GET api/Cargos for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter um array de objetos para cada cargo cadastrado no banco de dados

**Evidências:**

Executando a rota sem informar nenhum parâmetro:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT03.1.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT03.2.png>
</p>
</br>

Cargos cadastrados no banco de dados:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT03.3.png>
</p>
</br>

**CT04: GET api/Cargos/{cargoId} - Executando a rota informando um cargoId válido (existente)**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** um cargoId válido (existente) seja informado como parâmetro <br/>
**When** a rota GET api/Cargos/{cargoId} for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter os dados do cargo informado como parâmetro

**Evidências:**

Executando a rota informando um cargoId válido (existente) como parâmetro:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT04.1.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT04.2.png>
</p>
</br>

Dados do cargo no banco de dados:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT04.3.png>
</p>
</br>

**CT06: PUT api/Cargos/{cargoId} - Executando a rota informando um cargoId válido (existente) e todos os dados obrigatórios**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** um cargoId válido (existente) seja informado como parâmetro e que no request body todos os dados obrigatórios sejam preenchidos <br/>
**When** a rota PUT api/Cargos/{cargoId} for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter os dados do cargo alterado <br/>
**And** os dados do cargo devem ser atualizados no banco de dados conforme os dados enviados na requisição

**Evidências:**

Dados do cargo 6 no banco de dados antes da alteração:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT06.1.png>
</p>
</br>

Executando a rota para atualizar o nome do cargo e a situação para inativo:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT06.2.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT06.3.png>
</p>
</br>

Dados do cargo atualizados no banco de dados:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT06.4.png>
</p>
</br>

**CT08: PUT api/Cargos/{cargoId} - Executando a rota informando um cargoId inválido (inexistente)**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** um cargoId inválido (inexistente) seja informado como parâmetro <br/>
**When** a rota PUT api/Cargos/{cargoId} for executada <br/>
**Then** o status code 400 deve ser retornado <br/>
**And** o response body deve conter uma mensagem informando que o cargo informado como parâmetro não foi localizado

**Evidências:**

Cargo 10 não existe no banco de dados:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT08.1.png>
</p>
</br>

Executando a rota informando o cargoId inválido (inexistente):

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT08.2.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT08.3.png>
</p>
</br>

**CT09: DELETE api/Cargos/{cargoId} - Executando a rota informando um cargoId inativo**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** um cargoId inativo seja informado como parâmetro <br/>
**When** a rota DELETE api/Cargos/{cargoId} for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o cargo deve ser excluído no banco de dados

**Evidências:**

Cargo 6 existe no banco de dados e consta inativo:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT09.1.png>
</p>
</br>

Executando a rota informando o cargoId inativo:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT09.2.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT09.3.png>
</p>
</br>

Cargo excluído no banco de dados:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT09.4.png>
</p>
</br>

**CT11: GET api/Cargos/{departamentoId}/departamento - Executando a rota informando um departamento que possui cargos vinculados**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** um departamentoId que possui cargos vinculados seja informado como parâmetro <br/>
**When** a rota GET api/Cargos/{departamentoId}/departamento for executadaa <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter um array de objetos para cada cargo vinculado ao departamento no banco de dados

**Evidências:**

DepartamentoId 8 possui dois cargos cadastrados:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT11.1.png>
</p>
</br>

Executando a rota informando a DepartamentoId 8:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT11.2.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Evidencias/ControllerCargos/CT11.3.png>
</p>
</br>



## RF-009: O sistema deverá permitir o cadastro de novas metas

### CT01: POST api/Metas - Realizando a requisição informando os dados obrigatórios corretamente

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
Given que as propriedades nomeMeta e empresaId sejam informados <br />
When a rota POST api/Metas for executada <br />
Then o status code 200 deve ser retornado <br />
And o response body deve conter os dados da meta cadastrada conforme as informações enviadas na requisição <br />
And a meta cadastrada deve ser inserida no banco de dados <br />

**Evidências:**

Schema mostrando os dados obrigatórios:
![SCHEMA Metas](https://user-images.githubusercontent.com/91227083/233862947-6e8bdff7-8ae2-458c-b5f7-31f75fffabfb.jpg)

Parametros informados, rota executada e resposta retornou status 200 conforme o esperado:
![POST Metas](https://user-images.githubusercontent.com/91227083/233863167-8763f453-05b1-4223-9b1f-f09014d9f4c9.jpg)

Registro inserido na base de dados com sucesso:
![DB Inclusao](https://user-images.githubusercontent.com/91227083/233868054-22415cb6-6f38-450d-a564-bf577c64d272.jpg)


### CT02: POST api/Metas - Realizando a requisição sem informar os dados obrigatórios

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
Given que alguma propriedade obrigatória (nomeMeta e empresaId) não seja informada no request body <br />
When a rota POST api/Metas for executada <br />
Then o status code 400 deve ser retornado <br />

**Evidências:**

Schema mostrando os dados obrigatórios:

![SCHEMA Metas](https://user-images.githubusercontent.com/91227083/233862947-6e8bdff7-8ae2-458c-b5f7-31f75fffabfb.jpg)

Parametros informados, rota executada e resposta retornou status 400 conforme o esperado:
![POSTFALHA Metas](https://user-images.githubusercontent.com/91227083/233863335-b739b56a-24b5-468c-bac7-3f3d449850ec.jpg)

### CT03: GET api/Meta - Executando a rota sem informar nenhum parâmetro

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
Given que nenhum parâmetro seja informado <br />
When a rota GET api/Metas for executada <br />
Then o status code 200 deve ser retornado <br />
And o response body deve conter um array de objetos para cada meta cadastrada no banco de dados <br />

**Evidências:**

Rota executada e resposta retornou status 200 conforme o esperado:
![GET Metas](https://user-images.githubusercontent.com/91227083/233863409-54b5deb3-600a-4c9f-9562-109336665013.jpg)

### CT04: GET api/Metas/{id} - Executando a rota informando um Id válido (existente)

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
Given um Id válido (existente) seja informado como parâmetro <br />
When a rota GET api/Metas/{id} for executada <br />
Then o status code 200 deve ser retornado <br />
And o response body deve conter os dados da meta informada como parâmetro <br />

**Evidências:**

Rota executada e resposta retornou status 200 conforme o esperado:
![GETBYID Metas](https://user-images.githubusercontent.com/91227083/233863620-ad5f4c43-640b-4a5f-bc3f-e328ace72ef3.jpg)

### CT05: GET api/Metas/{id} - Executando a rota informando um Id inválido (inexistente)

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
Given um Id inválido (inexistente) seja informado como parâmetro <br />
When a rota GET api/Metas/{id} for executada <br />
Then o status code 204 (No Content) deve ser retornado <br />

**Evidências:**

Rota executada e resposta retornou status 200 conforme o esperado:
![GETBYID falha Metas](https://user-images.githubusercontent.com/91227083/233863955-0842215a-3ebb-4735-94a2-eec2e447e4b8.jpeg)

### CT06: PUT api/Metas/{id} - Executando a rota informando um Id válido (existente)

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
Given um Id válido (existente) seja informado como parâmetro e todos os dados obrigatórios sejam preenchidos <br />
When a rota PUT api/Metas/{id} for executada <br />
Then o status code 200 deve ser retornado <br />
And o response body deve conter os dados da meta alterada <br />
And os dados da meta devem ser atualizados no banco de dados <br />

**Evidências:**

Parametros para alteração informados, rota executada e resposta retornou status 200 conforme o esperado:
![PUT Metas](https://user-images.githubusercontent.com/91227083/233864081-e3a7f7ee-161c-4a29-8866-88a2db376ec8.jpg)

Alteração na base de dados feita com sucesso:
![DB Alteracao](https://user-images.githubusercontent.com/91227083/233868073-61305746-f1a8-4426-8802-24581d4e4aa5.jpg)


### CT07: CT07: DELETE api/Metas/{id} - Executando a rota informando um Id válido

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
Given um Id válido seja informado como parâmetro <br />
When a rota DELETE api/Metas/{id} for executada <br />
Then o status code 200 deve ser retornado <br />
And o departamento deve ser excluído no banco de dados <br />

**Evidências:**

Id para deleção informado, rota executada e resposta retornou status 200 conforme o esperado:
![DELETE Metas](https://user-images.githubusercontent.com/91227083/233864179-940cfc15-8296-4caf-8f7c-4aaf78103880.jpg)

### CT08: DELETE api/Metas/{id} - Executando a rota informando um Id inválido

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
Given um Id inválido seja informado como parâmetro <br />
When a rota DELETE api/Metas/{id} for executada <br />
Then o status code 204 (No Content) deve ser retornado <br />

**Evidências:**

Id invalido para deleção informado, rota executada e resposta retornou status 204 conforme o esperado:
![DELETE Fail Metas](https://user-images.githubusercontent.com/91227083/233864413-975f1bb4-1f5f-47eb-979e-c4e19893c357.jpeg)

### CT09: GET api/Metas/{tipoMeta}/tipo - Executando a rota informando um tipoMeta que possua tipos cadastrados

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
Given um tipoMeta que possua um tipo cadastrado seja informado como parâmetro <br />
When a rota GET api/Metas/{tipoMeta}/tipo for executada <br />
Then o status code 200 deve ser retornado <br />
And o response body deve conter um array de objetos que contenham o parâmetro informado <br />

**Evidências:**

Parametros para localização de tipo de Meta informados, rota executada e resposta retornou status 200 conforme o esperado:
![GETBYTIPO Metas](https://user-images.githubusercontent.com/91227083/233864531-a17c5d4e-1ce6-4ff1-8acc-0d9ae67a5ba6.jpg)

### CT10: GET api/Metas/{tipoMeta}/tipo - Executando a rota informando um tipoMeta que não possua tipos cadastrados

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
Given uma tipoMeta que não possui um tipo cadastrado seja informado como parâmetro <br />
When a rota GET api/Metas/{tipoMeta}/tipo for executada <br />
Then o status code 200 deve ser retornado <br />
And o response body deve conter um array vazio <br />

**Evidências:**

Parametros inválidos para localização de tipo de Meta informados, rota executada e resposta retornou status 200 e array vazio conforme o esperado:
![GETBYTIPO Fail Metas](https://user-images.githubusercontent.com/91227083/233864877-5a933abe-303d-4733-b04b-11eb5185b844.jpeg)

