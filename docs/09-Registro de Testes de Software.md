# Registro de Testes de Software

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
