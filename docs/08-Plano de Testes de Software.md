# Plano de Testes de Software

### RF-006: O sistema deverá permitir o gerenciamento de departamentos (CRUD)

**CT01: POST api/Departamentos - Realizando a requisição informando os dados obrigatórios corretamente**

**Given** que as propriedades nomeDepartamento e empresaId sejam informados no request body <br/>
**When** a rota api/Departamentos for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter os dados do departamento cadastrado conforme as informações enviadas na requisição

**CT02: POST api/Departamentos - Realizando a requisição sem informar os dados obrigatórios**

**Given** que alguma propriedade obrigatória não seja informada no request body <br/>
**When** a rota api/Departamentos for executada <br/>
**Then** o status code 400 deve ser retornado <br/>
**And** o objeto errors no response body deve conter uma mensagem informando sobre a obrigatoriedade dos campos

**CT03: GET api/Departamentos - Executando a rota sem informar nenhum parâmetro*

**Given** que nenhum parâmetro seja informado <br/>
**When** a rota api/Departamentos for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** um array de objetos para cada departamento cadastrado no banco de dados

**CT04: GET api/Departamentos/{departamentoId} - Executando a rota informando um departamentoId válido (existente)*

**Given** um departamentoId válido (existente) seja informado como parâmetro<br/>
**When** a rota api/Departamentos/{departamentoId} for executada <br/>
**Then** o status code 200 deve ser retornado <br/>
**And** o response body deve conter os dados do departamento informado como parâmetro

**CT05: GET api/Departamentos/{departamentoId} - Executando a rota informando um departamentoId inválido (inexistente)*

**Given** um departamentoId inválido (inexistente) seja informado como parâmetro<br/>
**When** a rota api/Departamentos/{departamentoId} for executada <br/>
**Then** o status code 404 deve ser retornado <br/>
**And** o response body deve conter uma mensagem informando que o departamento informado como parâmetro não foi localizado

