# Plano de Testes de Software

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
