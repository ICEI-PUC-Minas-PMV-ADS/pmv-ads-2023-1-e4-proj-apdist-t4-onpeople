# Registro de Testes de Software

## RF-006: O sistema deverá permitir o gerenciamento de departamentos (CRUD)

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

