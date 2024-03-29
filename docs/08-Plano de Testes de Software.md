# Plano de Testes de Software

## RF-005: O sistema deverá permitir o gerenciamento de funcionários (CRUD)

**CT01: POST api/Funcionarios - Realizando a requisição informando os dados obrigatórios corretamente**

**Given** que as propriedades userId, departamentoId, cargoId e empresaId sejam informados no request body <br/>
**When** a rota POST api/Funcionarios for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter os dados do funcionário cadastrado conforme as informações enviadas na requisição <br/>
**And** o funcionário cadastrado deve ser inserido no banco de dados

**CT02: POST api/Funcionarios - Realizando a requisição sem informar os dados obrigatórios**

**Given** que alguma propriedade obrigatória não seja informada no request body <br/>
**When** a rota POST api/Funcionarios for executada <br/>
**Then** o status code 400 deve ser retornado <br/>
**And** o objeto errors no response body deve conter uma mensagem informando sobre a obrigatoriedade dos campos

**CT03: GET api/Funcionarios - Executando a rota sem informar nenhum parâmetro**

**Given** que nenhum parâmetro seja informado <br/>
**When** a rota GET api/Departamentos for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter um array de objetos para cada funcionário cadastrado no banco de dados

**CT04: GET api/Funcionarios/{funcionarioId} - Executando a rota informando um funcionarioId válido (existente)**

**Given** um funcionarioId válido (existente) seja informado como parâmetro<br/>
**When** a rota GET api/Funcionarios/{funcionarioId} for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter os dados do funcionário informado como parâmetro

**CT05: GET api/Departamentos/{funcionarioId} - Executando a rota informando um departamentoId inválido (inexistente)**

**Given** um funcionarioId inválido (inexistente) seja informado como parâmetro<br/>
**When** a rota GET api/Funcionarios/{funcionarioId} for executada <br/>
**Then** o status code 404 deve ser retornado <br/>
**And** o response body deve conter uma mensagem informando que o funcionário informado como parâmetro não foi localizado

**CT06: PUT api/Funcionarios/{funcionarioId} - Executando a rota informando um funcionarioId válido (existente) e todos os dados obrigatórios**

**Given** um funcionarioId válido (existente) seja informado como parâmetro e que no request body todos os dados obrigatórios sejam preenchidos<br/>
**When** a rota PUT api/Funcionarios/{funcionarioId} for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter os dados do funcionário alterado <br/>
**And** os dados do funcionário devem ser atualizados no banco de dados conforme os dados enviados na requisição

**CT07: PUT api/Funcionarios/{funcionarioId} - Executando a rota informando um funcionarioId válido (existente), mas sem informar todos os dados obrigatórios**

**Given** um funcionarioId válido (existente) seja informado como parâmetro e que no request body nem todos os dados obrigatórios sejam preenchidos<br/>
**When** a rota PUT api/Funcionarios/{funcionarioId} for executada <br/>
**Then** o status code 400 deve ser retornado <br/>
**And** o objeto errors no response body deve conter uma mensagem informando sobre a obrigatoriedade dos campos

**CT08: PUT api/Funcionarios/{funcionarioId} - Executando a rota informando um funcionarioId inválido (inexistente)**

**Given** um funcionarioId inválido (inexistente) seja informado como parâmetro <br/>
**When** a rota PUT api/Funcionarios/{funcionarioId} for executada <br/>
**Then** o status code 400 deve ser retornado <br/>
**And** o response body deve conter uma mensagem informando que o funcionário informado como parâmetro não foi localizado

**CT09: DELETE api/Funcionarios/{funcionarioId} - Executando a rota informando um funcionarioId válido (existente)**

**Given** um funcionarioId válido (existente) seja informado como parâmetro<br/>
**When** a rota DELETE api/Funcionarios/{funcionarioId} for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o funcionário deve ser excluído no banco de dados

**CT09: DELETE api/Funcionarios/{funcionarioId} - Executando a rota informando um funcionarioId inválido (inexistente)**

**Given** um funcionarioId inválido (inexistente) seja informado como parâmetro<br/>
**When** a rota DELETE api/Funcionarios/{funcionarioId} for executada <br/>
**Then** o status code 400 deve ser retornado <br/>
**And** o response body deve conter uma mensagem informando que o funcionário informado como parâmetro não foi localizado

## RF-006: O sistema deverá permitir o gerenciamento de departamentos (CRUD)

**CT01: POST api/Departamentos - Realizando a requisição informando os dados obrigatórios corretamente**

**Given** que as propriedades nomeDepartamento e empresaId sejam informados no request body <br/>
**When** a rota POST api/Departamentos for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter os dados do departamento cadastrado conforme as informações enviadas na requisição <br/>
**And** o departamento cadastrado deve ser inserido no banco de dados

**CT02: POST api/Departamentos - Realizando a requisição sem informar os dados obrigatórios**

**Given** que alguma propriedade obrigatória não seja informada no request body <br/>
**When** a rota POST api/Departamentos for executada <br/>
**Then** o status code 400 deve ser retornado <br/>
**And** o objeto errors no response body deve conter uma mensagem informando sobre a obrigatoriedade dos campos

**CT03: GET api/Departamentos - Executando a rota sem informar nenhum parâmetro**

**Given** que nenhum parâmetro seja informado <br/>
**When** a rota GET api/Departamentos for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter um array de objetos para cada departamento cadastrado no banco de dados

**CT04: GET api/Departamentos/{departamentoId} - Executando a rota informando um departamentoId válido (existente)**

**Given** um departamentoId válido (existente) seja informado como parâmetro<br/>
**When** a rota GET api/Departamentos/{departamentoId} for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter os dados do departamento informado como parâmetro

**CT05: GET api/Departamentos/{departamentoId} - Executando a rota informando um departamentoId inválido (inexistente)**

**Given** um departamentoId inválido (inexistente) seja informado como parâmetro<br/>
**When** a rota GET api/Departamentos/{departamentoId} for executada <br/>
**Then** o status code 404 deve ser retornado <br/>
**And** o response body deve conter uma mensagem informando que o departamento informado como parâmetro não foi localizado

**CT06: PUT api/Departamentos/{departamentoId} - Executando a rota informando um departamentoId válido (existente) e todos os dados obrigatórios**

**Given** um departamentoId válido (existente) seja informado como parâmetro e que no request body todos os dados obrigatórios sejam preenchidos<br/>
**When** a rota PUT api/Departamentos/{departamentoId} for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter os dados do departamento alterado <br/>
**And** os dados do departamento devem ser atualizados no banco de dados conforme os dados enviados na requisição

**CT07: PUT api/Departamentos/{departamentoId} - Executando a rota informando um departamentoId válido (existente), mas sem informar todos os dados obrigatórios**

**Given** um departamentoId válido (existente) seja informado como parâmetro e que no request body nem todos os dados obrigatórios sejam preenchidos<br/>
**When** a rota PUT api/Departamentos/{departamentoId} for executada <br/>
**Then** o status code 400 deve ser retornado <br/>
**And** o objeto errors no response body deve conter uma mensagem informando sobre a obrigatoriedade dos campos

**CT08: PUT api/Departamentos/{departamentoId} - Executando a rota informando um departamentoId inválido (inexistente)**

**Given** um departamentoId inválido (inexistente) seja informado como parâmetro <br/>
**When** a rota PUT api/Departamentos/{departamentoId} for executada <br/>
**Then** o status code 400 deve ser retornado <br/>
**And** o response body deve conter uma mensagem informando que o departamento informado como parâmetro não foi localizado

**CT09: DELETE api/Departamentos/{departamentoId} - Executando a rota informando um departamentoId inativo**

**Given** um departamentoId inativo seja informado como parâmetro<br/>
**When** a rota DELETE api/Departamentos/{departamentoId} for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o departamento deve ser excluído no banco de dados

**CT10: DELETE api/Departamentos/{departamentoId} - Executando a rota informando um departamentoId ativo**

**Given** um departamentoId ativo seja informado como parâmetro<br/>
**When** a rota DELETE api/Departamentos/{departamentoId} for executada <br/>
**Then** o status code 400 deve ser retornado <br/>
**And** o objeto errors no response body deve conter uma mensagem informando que é necessário inativar o departamento antes de excluí-lo.

**CT11: GET api/Departamentos/{empresaId}/empresa - Executando a rota informando uma empresa que possui departamentos vinculados**

**Given** uma empresaId que possui departamentos vinculados seja informada como parâmetro<br/>
**When** a rota GET api/Departamentos/{empresaId}/empresa for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter um array de objetos para cada departamento vinculado à empresa no banco de dados

**CT12: GET api/Departamentos/{empresaId}/empresa - Executando a rota informando uma empresa que não possui departamentos vinculados**

**Given** uma empresaId que não possui departamentos vinculados seja informada como parâmetro<br/>
**When** a rota GET api/Departamentos/{empresaId}/empresa for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter um objeto vazio

## RF-007: O sistema deverá permitir o gerenciamento de cargos (CRUD)

**CT01: POST api/Cargos- Realizando a requisição informando os dados obrigatórios corretamente**

**Given** que as propriedades nomeCargo, departamentoId e empresaId sejam informados no request body <br/>
**When** a rota POST api/Cargos for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter os dados do cargo cadastrado conforme as informações enviadas na requisição <br/>
**And** o cargo cadastrado deve ser inserido no banco de dados

**CT02: POST api/Cargos - Realizando a requisição sem informar os dados obrigatórios**

**Given** que alguma propriedade obrigatória não seja informada no request body <br/>
**When** a rota POST api/Cargos for executada <br/>
**Then** o status code 400 deve ser retornado <br/>
**And** o objeto errors no response body deve conter uma mensagem informando sobre a obrigatoriedade dos campos

**CT03: GET api/Cargos - Executando a rota sem informar nenhum parâmetro**

**Given** que nenhum parâmetro seja informado <br/>
**When** a rota GET api/Cargos for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter um array de objetos para cada cargo cadastrado no banco de dados

**CT04: GET api/Cargos/{cargoId} - Executando a rota informando um cargoId válido (existente)**

**Given** um cargoId válido (existente) seja informado como parâmetro <br/>
**When** a rota GET api/Cargos/{cargoId} for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter os dados do cargo informado como parâmetro

**CT05: GET api/Cargos/{cargoId} - Executando a rota informando um cargoId inválido (inexistente)**

**Given** um cargoId inválido (inexistente) seja informado como parâmetro<br/>
**When** a rota GET api/Cargos/{cargoId} for executada <br/>
**Then** o status code 404 deve ser retornado <br/>
**And** o response body deve conter uma mensagem informando que o cargo informado como parâmetro não foi localizado

**CT06: PUT api/Cargos/{cargoId} - Executando a rota informando um cargoId válido (existente) e todos os dados obrigatórios**

**Given** um cargoId válido (existente) seja informado como parâmetro e que no request body todos os dados obrigatórios sejam preenchidos <br/>
**When** a rota PUT api/Cargos/{cargoId} for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter os dados do cargo alterado <br/>
**And** os dados do cargo devem ser atualizados no banco de dados conforme os dados enviados na requisição

**CT07: PUT api/Cargos/{cargoId} - Executando a rota informando um cargoId válido (existente), mas sem informar todos os dados obrigatórios**

**Given** um cargoId válido (existente) seja informado como parâmetro e que no request body nem todos os dados obrigatórios sejam preenchidos <br/>
**When** a rota PUT api/Cargos/{cargoId} for executada <br/>
**Then** o status code 400 deve ser retornado <br/>
**And** o objeto errors no response body deve conter uma mensagem informando sobre a obrigatoriedade dos campos

**CT08: PUT api/Cargos/{cargoId} - Executando a rota informando um cargoId inválido (inexistente)**

**Given** um cargoId inválido (inexistente) seja informado como parâmetro <br/>
**When** a rota PUT api/Cargos/{cargoId} for executada <br/>
**Then** o status code 400 deve ser retornado <br/>
**And** o response body deve conter uma mensagem informando que o cargo informado como parâmetro não foi localizado

**CT09: DELETE api/Cargos/{cargoId} - Executando a rota informando um cargoId inativo**

**Given** um cargoId inativo seja informado como parâmetro <br/>
**When** a rota DELETE api/Cargos/{cargoId} for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o cargo deve ser excluído no banco de dados

**CT10: DELETE api/Cargos/{cargoId} - Executando a rota informando um cargoId ativo**

**Given** um cargoId ativo seja informado como parâmetro<br/>
**When** a rota DELETE api/Cargos/{cargoId} for executada <br/>
**Then** o status code 400 deve ser retornado <br/>
**And** o objeto errors no response body deve conter uma mensagem informando que é necessário inativar o cargo antes de excluí-lo.

**CT11: GET api/Cargos/{departamentoId}/departamento - Executando a rota informando um departamento que possui cargos vinculados**

**Given** um departamentoId que possui cargos vinculados seja informado como parâmetro<br/>
**When** a rota GET api/Cargos/{departamentoId}/departamento for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter um array de objetos para cada cargo vinculado ao departamento no banco de dados

**CT12: GET api/Cargos/{departamentoId}/departamento - Executando a rota informando um departamento que não possui cargos vinculados**

**Given** um departamentoId que não possui cargos vinculados seja informado como parâmetro<br/>
**When** a rota GET api/Cargos/{departamentoId}/departamento for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter um objeto vazio


## RF-009: O sistema deverá permitir o cadastro de novas metas

### CT01: POST api/Metas - Realizando a requisição informando os dados obrigatórios corretamente

Given que as propriedades nomeMeta e empresaId sejam informados <br />
When a rota POST api/Metas for executada <br />
Then o status code 200 deve ser retornado <br />
And o response body deve conter os dados da meta cadastrada conforme as informações enviadas na requisição <br />
And a meta cadastrada deve ser inserida no banco de dados <br />

### CT02: POST api/Metas - Realizando a requisição sem informar os dados obrigatórios

Given que alguma propriedade obrigatória (nomeMeta e empresaId) não seja informada no request body <br />
When a rota POST api/Metas for executada <br />
Then o status code 400 deve ser retornado <br />

### CT03: GET api/Meta - Executando a rota sem informar nenhum parâmetro

Given que nenhum parâmetro seja informado <br />
When a rota GET api/Metas for executada <br />
Then o status code 200 deve ser retornado <br />
And o response body deve conter um array de objetos para cada meta cadastrada no banco de dados <br />

### CT04: GET api/Metas/{id} - Executando a rota informando um Id válido (existente)

Given um Id válido (existente) seja informado como parâmetro <br />
When a rota GET api/Metas/{id} for executada <br />
Then o status code 200 deve ser retornado <br />
And o response body deve conter os dados da meta informada como parâmetro <br />

### CT05: GET api/Metas/{id} - Executando a rota informando um Id inválido (inexistente)

Given um Id inválido (inexistente) seja informado como parâmetro <br />
When a rota GET api/Metas/{id} for executada <br />
Then o status code 204 (No Content) deve ser retornado <br />

### CT06: PUT api/Metas/{id} - Executando a rota informando um Id válido (existente)

Given um Id válido (existente) seja informado como parâmetro e todos os dados obrigatórios sejam preenchidos <br />
When a rota PUT api/Metas/{id} for executada <br />
Then o status code 200 deve ser retornado <br />
And o response body deve conter os dados da meta alterada <br />
And os dados da meta devem ser atualizados no banco de dados <br />

### CT07: DELETE api/Metas/{id} - Executando a rota informando um Id válido

Given um Id válido seja informado como parâmetro <br />
When a rota DELETE api/Metas/{id} for executada <br />
Then o status code 200 deve ser retornado <br />
And o departamento deve ser excluído no banco de dados <br />

### CT08: DELETE api/Metas/{id} - Executando a rota informando um Id inválido

Given um Id inválido seja informado como parâmetro <br />
When a rota DELETE api/Metas/{id} for executada <br />
Then o status code 204 (No Content) deve ser retornado <br />

### CT09: GET api/Metas/{tipoMeta}/tipo - Executando a rota informando um tipoMeta que possua tipos cadastrados

Given um tipoMeta que possua um tipo cadastrado seja informado como parâmetro <br />
When a rota GET api/Metas/{tipoMeta}/tipo for executada <br />
Then o status code 200 deve ser retornado <br />
And o response body deve conter um array de objetos que contenham o parâmetro informado <br />

### CT10: GET api/Metas/{tipoMeta}/tipo - Executando a rota informando um tipoMeta que não possua tipos cadastrados

Given uma tipoMeta que não possui um tipo cadastrado seja informado como parâmetro <br />
When a rota GET api/Metas/{tipoMeta}/tipo for executada <br />
Then o status code 200 deve ser retornado <br />
And o response body deve conter um array vazio <br />
