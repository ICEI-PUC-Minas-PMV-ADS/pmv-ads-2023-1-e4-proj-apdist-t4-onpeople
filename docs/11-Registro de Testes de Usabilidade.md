# Registro de Testes de Usabilidade

CASO DE TESTE 001: LOGIN - Campos não preenchidos devem retornar um alerta de obrigatoriedade.

STATUS: Aprovado

Dado que o Campo Conta e/ou Senha<br>
Quando estiver em branco<br>
Então retorna um alerta de obrigatoriedade<br>

Evidências:

![Login campos obrigatorios](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/a5cdcc14-fcdd-44bb-9313-c7ba8428f8bb)

![Login campos validados](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/ba6e4fbd-032a-404a-8f75-6fd8b3301999)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 002: LOGIN - Tentar efetuar login sem informar dados existentes na base deve retornar erro.

STATUS: Aprovado

Dado que uma tentativa de login seja feita<br>
Quando a conta for inexistente na base de dados<br>
Então um alerta de conta não existente deve ser emitido<br>

Evidências: 

![Login conta nao cadastrada](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/ee0200c7-8956-47b1-9f49-572a3378894a)


-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 003: CADASTRO - Campos não preenchidos devem retornar um alerta de obrigatoriedade.

STATUS: Aprovado

Dado que o Campo Conta, Nome Completo e/ou Senha<br>
Quando estiver em branco<br>
Então retorna um alerta de obrigatoriedade<br>

Evidências: 

![Cadastro campos obrigatorios](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/8d70cb44-e1c9-4534-ba3a-24362b1ceb89)

![Cadastro campos validados](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/05a9e2c5-2b7c-4d4c-a9b6-f593fb68e573)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 004: CADASTRO - Cadastro deve ser efetuado caso todos os dados estiverem corretos.

STATUS: Aprovado

Dado que todos os campos estão validados<br>
Quando clicar em cadastrar<br>
Então cadastro deve ser salvo na base de dados<br>
E usuário deve ser logado no sistema com sucesso<br>

Evidências:

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/a0facd37-caaf-4db8-8f24-270fd815af51)

![Login efetuado](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/24116b05-52de-40f4-b05f-8e682ad1c849)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 005: EMPRESAS - Clicar na aba Empresas deve retornar uma lista de empresas ou "Nenhuma Empresa encontrada"

STATUS: Aprovado

Dado que o usuário clique na aba Empresas<br>
Quando estiver logado e autorizado<br>
Então a aba deve retornar a lista de empresas cadastradas ou uma informação de que nada foi encontrado<br>

Evidências:

![Lista empresa criada](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/7d0138ff-b7a0-4272-ad25-8af88a5fad2f)

![Lista vazia](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/23b2a4b9-8a54-489d-bc53-4e033045edfa)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 006: EMPRESAS - Clicar no botão + e informar o CNPJ no cadastro deve retornar o formulário pré-preenchido

STATUS: Aprovado

Dado que um CNPJ seja informado após clicar no botão +<br>
Quando o CNPJ for válido<br>
Então uma busca feita deve retornar um formulário pré-preenchido<br>


Evidências:

![Formulário Empresa Preenchido](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/ac9e6dd8-afeb-4919-be06-18f2bd3d647c)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 007: EMPRESAS - Cadastro de empresa

STATUS: Aprovado

Dado que todos os dados do formulário sejam validados<br>
Quando clicar no botão Criar<br>
Então os dados devem ser salvos na base de dados<br>
E a Empresa cadastrada deve constar na lista inicial<br>

Evidências:

![Empresa Base de Dados](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/722717f2-ed1c-4378-9962-adddb4e03f36)

![Lista empresa criada](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/e71f46b4-5fb0-4845-bf92-dfa9d83ae5fd)

OPCIONAL: Uma imagem pode ser adicionada à Empresa. Para tal, basta retornar ao cadastro feito e a opção de adicionar imagem estará disponível.

![Formulário Empresa Imagem Opcional](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/22519114-2b04-44b7-82b9-53e5a539281e)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 008: DEPARTAMENTOS - Clicar na aba Departamentos deve retornar uma lista de departamento ou "Nenhum Departamento encontrado"

STATUS: Aprovado

Dado que um usuário clique na aba Departamentos<br>
Quando estiver logado e autorizado<br>
Então a aba de retornar a lista de departamentos cadastrados ou uma informação de que nada foi encontrado<br>

Evidências:

![Lista Departamentos criada](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/72c37297-8b08-4a65-a338-4925185bd332)

![Lista Departamentos Vazia](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/935a8207-6d39-4d47-a24f-37711530a879)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 009: DEPARTAMENTOS - Formulário de Departamentos deve retornar lista de Empresas cadastradas

STATUS: Aprovado

Dado que após entrar no Formulário de cadastro de Departamentos<br>
Quando clicar no campo Empresas<br>
Então um menu deve ser mostrado contendo as Empresas cadastradas<br>

Evidências:

![Formulario Departamentos lista Empresas](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/a480e9ea-5f5d-4458-a79f-13cc4f8b7ca9)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 010: DEPARTAMENTOS - Cadastro de Departamentos

STATUS: Aprovado

Dado que o formulário seja corretamente preenchido e validado<br>
Quando clicar no botão Criar<br>
Então os dados devem ser salvos na base de dados<br>
E o Departamento cadastrado deve constar na lista inicial<br>

Evidências:

![Formulario Departamentos preenchido](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/5318241a-5677-40db-bd98-87f7b01041c1)

![Departamentos Base de Dados](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/f0af3299-b780-4937-a9a1-e8a2bfce9525)

![Lista Departamentos criada](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/00281ceb-56ba-4216-a63c-3291e66dd97a)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 011: CARGOS - Clicar na aba Cargos deve retornar uma lista de cargos cadastrados ou "Nenhum Cargo encontrado"

STATUS: Aprovado

Dado que um usuário clique na aba Cargos<br>
Quando estiver logado e autorizado<br>
Então a aba de retornar a lista de cargos cadastrados ou uma informação de que nada foi encontrado<br>

Evidências:

![Lista Cargos preenchida](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/4a37e5ce-e4c0-45b6-9f54-d847033c03ba)

![Lista Cargos vazia](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/8d4710c1-3571-4074-87b0-5890c73aacbc)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 012: CARGOS - Formulário de Cargos deve retornar uma lista de Empresas cadastradas que possuem Departamentos cadastrados

STATUS: Aprovado

Dado que após entrar no Formulário de cadastro de Cargos<br>
Quando clicar no campo Empresas<br>
Então um menu deve ser mostrado contendo as Empresas cadastradas que possuem Departamentos válidos<br>

Evidências:

![Formulario Cargos apenas empresas com departamentos](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/600ed45f-69f5-4c70-9159-dd6b487d2df6)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 013: CARGOS - Formulário de Cargos deve retornar uma lista de Departamentos a qual o cargo será vinculado

STATUS: Aprovado

Dado que após entrar no Formulário de cadastro de Cargos<br>
Quando clicar no campo Departamento<br>
E campo Empresa estiver validado<br>
Então um menu deve ser mostrado contendo os Departamentos cadastrados ao qual o cargo será vinculado<br>

Evidências:

![Formulario Cargos lista departamentos](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/e0d76f1c-6449-4dca-b593-31aa6b03faae)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 014: CARGOS - Cadastro de Cargos

STATUS: Aprovado

Dado que o formulário seja corretamente preenchido e validado<br>
Quando clicar no botão Criar<br>
Então os dados devem ser salvos na base de dados<br>
E o Cargo cadastrado deve constar na lista inicial<br>

Evidências:

![Formulario Cargos preenchido](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/2fc08ef9-a5a1-49a4-b002-cdcf7c0473cc)

![Cargos Base de Dados](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/4665018a-7280-413c-a214-b34e0f8fcda2)

![Lista Cargos preenchida](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/350d5f9c-a560-4bcf-b353-8b553c3901aa)



-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 015: METAS - Validação do formulário Metas

STATUS: Aprovado

Dado que o formulário não seja corretamento preenchido<br>
Quando finalizar a input de dados e mudar o campo<br>
Então uma mensagem de campo obrigatório deve ser mostrada<br>

Evidências:

![Formulario de Metas nao validadas](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/f5778a65-f50d-4740-9626-022a34a4e1e0)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 016: METAS - Cadastro de nova Meta

STATUS: Aprovado

Dado que todos os campos do formulário sejam preenchidos e validados<br>
Quando clicar no botão Criar<br>
Então a Meta deve ser salva na base de dados<br>
E ser mostrada na lista de Metas da aplicação<br>

Evidências:

![Formulario de Metas preenchido](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/b2820375-269d-4f9e-a395-a2dad12c0f35)

![Metas Base de Dados](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/b0c5b711-20cd-4190-b2fc-b63fc2b1944f)

![Lista de Metas preenchida](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/50865914-93f1-40a0-a4f0-086470df19ad)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 017: FUNCIONÁRIOS - Validação dos Dados da Empresas no cadastro de Funcionários

STATUS: Aprovado

Dado que seja iniciado o cadastro de Funcionário<br>
Quando clicar no campo Empresas<br>
Então apenas Empresas com Departamentos cadastrados devem ser mostrados<br>

Evidências:

![Formulario Funcionarios apenas empresas com departamentos existentes](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/6db1ce5c-af38-4d91-8d7d-f0b41c6fa0a7)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 018: FUNCIONÁRIOS - Validação dos Dados do Departamento no cadastro de Funcionários

STATUS: Aprovado

Dado que seja iniciado o cadastro de Funcionário<br>
Quando clicar no campo Departamento<br>
Então apenas Departamentos com Cargos cadastrados devem ser mostrados<br>

Evidências:

![Formulario Funcionarios apenas departamentos existentes](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/65af1e32-2e28-4624-9222-2810baf54fe4)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 019: FUNCIONÁRIOS - Validação dos Dados do Cargo no cadastro de Funcionários

STATUS: Aprovado

Dado que seja iniciado o cadastro de Funcionário<br>
Quando clicar no campo Cargo<br>
Então apenas Cargos cadastrados e validados devem ser mostrados<br>

Evidências:

![Formulario Funcionarios lista de cargos](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/ddff3fa6-b0fb-4a9a-b7f6-7feeff6cdc95)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 020: FUNCIONÁRIOS - Cadastro de Funcionários

STATUS: Aprovado

Dado que todos os campos do formulário Funcionários sejam corretamente preenchidos<br>
Quando clicar em Criar<br>
Então o Funcionário deve ser salvo na base de dados<br>
E mostrá-lo na lista de Funcionários<br>
E habilitar as subabas Endereços, Documentos Pessoais, Atribuição de Metas e Minhas Metas<br>

Evidências:

![Formulario Funcionarios lista de usuarios](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/12f2bbde-1f6b-4e75-8bbc-def65d2e835e)

![Funcionarios Base de Dados](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/7e8a8d26-b0c3-44a4-816a-0889788f6463)

![Lista Funcionarios preenchido](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/a8698214-b544-4680-afea-9785f2ea3f2a)

![Funcionario pos criação](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/67bca0e8-9061-4976-bc5f-658c00f43858)


-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 021: FUNCIONÁRIOS - Registro da subaba Endereços

STATUS: Aprovado

Dado que um Funcionário seja criado<br>
Quando a subaba Endereços for selecionada e preenchida<br>
Então o registro do Funcionário será atualizado<br>

Evidências:

![Funcionarios Endereco](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/55d001b8-1072-4c6e-a5f4-e44efd415789)

![Funcionarios Endereco preenchido](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/ae86aefe-8ac6-481c-a262-540349c57641)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 022: FUNCIONÁRIOS - Registro da subaba Documentos Pessoais

STATUS: Aprovado

Dado que um Funcionário seja criado<br>
Quando a subaba Documentos Pessoais for selecionada e preenchida<br>
Então o registro do Funcionário será atualizado<br>

Evidências:

![Funcionarios Documentos Pessoais](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/2939b031-427a-43a2-a8f5-db6d7893e318)

![Funcionarios Documentos Pessoais preenchido](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/10eef7e6-8f1a-4293-9d93-f2d78d78dbfc)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 023: FUNCIONÁRIOS - Registro da subaba Atribuição de Metas

STATUS: Aprovado

Dado que um Funcionário seja criado<br>
Quando a subaba Atribuição de Metas for selecionada e preenchida<br>
Então o registro do Funcionário será atualizado com as Metas atribuidas a ele<br>
E a lista de Metas associadas deve parar de mostrar a mensagem 'Nenhuma meta associada' e mostrar a lista de Metas associadas<br>

Evidências:

![Funcionarios Atribuição de Metas](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/165f1cd8-9e69-4408-a886-2b79a718d31d)

![Funcionarios Atribuição de Metas preenchido](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/8ef30f5f-1ee2-48c1-8113-8de4621ef59d)

![Funcionarios Atribuição de Metas Completo](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/9887d396-9bb9-473e-9a41-5dac6de2bef7)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 024: FUNCIONÁROS - Subaba Minhas Metas

STATUS: Aprovado

Dado que um Funcionário seja criado<br>
Quando a subaba Minhas Metas for selecionada<br>
Então cards dinâmicos com informações das Metas associadas devem ser mostrados<br>

Evidências:

![Funcionarios Minhas Metas preenchido](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/1b2e54b9-77d1-4343-b8ad-07b4cb71d2a0)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 025: VISÕES - Permissões da Visão Gold

STATUS: Aprovado

Dado que um acesso seja feito com um usuario com permissões de visão Gold<br>
Quando fizer uso das funcionálidades do sistema<br>
Então apenas os dados relevantes à Empresa a que está vinculado será mostrada<br>

Evidências:

![Visão_Gold](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/450aba32-f1f1-4bfe-a2bd-d804c1790d8a)

![Visão_Gold_2](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/1dc2a77b-3a48-45cc-aa08-95231329919f)

![Visão_Gold_3](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/3b696658-67e6-42f3-8028-a618e77696cf)

![Visão_Gold_4](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/51cf4b24-c2c8-429e-ace9-26b89157eb9c)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 025: VISÕES - Permissões da Visão Bronze 

STATUS: Aprovado

Dado que um acesso seja feito com um usuário com permissões de visão Bronze<br>
Quando fizer uso das funcionálidades do sistema<br>
Então apenas dados pessoais relevantes e do Cargo do usuário logado será mostrado<br>

Evidências:

![Visão_Bronze](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/c99ea5b1-6e75-4a3f-a266-c8b9aceb4020)

![Visão_Bronze_2](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/a8b8f91a-2b68-425c-8b3e-42153b622db9)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 026: DASHBOARD - Consumo dos dados pelo Dashboard

STATUS: Aprovado

Dado que os cadastros de Empresa, Departamentos, Cargos, Funcionários e Metas sejam feitos corretamente<br>
Quando o usuário entrar na tela de Dashboard<br>
Então diversos cards devem refletir a situação atual dos dados cadastrados na base de dados<br>
E devem permitir filtro por Departamentos, Cargos, Funcionários e Metas<br>

Evidências:

![Dashboard vazio1](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/99588cc3-c79e-4614-9074-bffc563bfcf1)

![Dashboard vazio2](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/199b7498-59fd-4f3a-87c0-e07a92affbf3)

![Dashboard com dados](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/e300020a-f796-44a8-a245-bef121fc4c7f)

![Dashboard com dados2](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/e7b38868-1987-48c7-ac9a-cac647a8b4f4)

![Filtro1](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/25ec265d-d7ce-485f-ba00-1a385f1a2e9a)

![Filtro2](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/4e8fb5fe-a4db-48a2-b0de-675932e4c965)

![Filtro3](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/ef4d0f81-f04a-4cee-b207-51eccadb5ef9)

![Filtro4](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/assets/91227083/5f61f710-4456-4f9e-ab6e-2b42b8d76fc3)

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-
