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




-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 005: EMPRESAS - Clicar na aba Empresas deve retornar uma lista de empresas ou "Nenhuma Empresa encontrada"

STATUS: Aprovado

Dado que o usuário clique na aba Empresas<br>
Quando estiver logado e autorizado<br>
Então a aba deve retornar a lista de empresas cadastradas ou uma informação de que nada foi encontrado<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 006: EMPRESAS - Clicar no botão + e informar o CNPJ no cadastro deve retornar o formulário pré-preenchido

STATUS: Aprovado

Dado que um CNPJ seja informado após clicar no botão +<br>
Quando o CNPJ for válido<br>
Então uma busca feita deve retornar um formulário pré-preenchido<br>


Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 007: EMPRESAS - Cadastro de empresa

STATUS: Aprovado

Dado que todos os dados do formulário sejam validados<br>
Quando clicar no botão Criar<br>
Então os dados devem ser salvos na base de dados<br>
E a Empresa cadastrada deve constar na lista inicial<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 008: DEPARTAMENTOS - Clicar na aba Departamentos deve retornar uma lista de departamento ou "Nenhum Departamento encontrado"

STATUS: Aprovado

Dado que um usuário clique na aba Departamentos<br>
Quando estiver logado e autorizado<br>
Então a aba de retornar a lista de departamentos cadastrados ou uma informação de que nada foi encontrado<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 009: DEPARTAMENTOS - Formulário de Departamentos deve retornar lista de Empresas cadastradas

STATUS: Aprovado

Dado que após entrar no Formulário de cadastro de Departamentos<br>
Quando clicar no campo Empresas<br>
Então um menu deve ser mostrado contendo as Empresas cadastradas<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 010: DEPARTAMENTOS - Cadastro de Departamentos

STATUS: Aprovado

Dado que o formulário seja corretamente preenchido e validado<br>
Quando clicar no botão Criar<br>
Então os dados devem ser salvos na base de dados<br>
E o Departamento cadastrado deve constar na lista inicial<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 011: CARGOS - Clicar na aba Cargos deve retornar uma lista de cargos cadastrados ou "Nenhum Cargo encontrado"

STATUS: Aprovado

Dado que um usuário clique na aba Cargos<br>
Quando estiver logado e autorizado<br>
Então a aba de retornar a lista de cargos cadastrados ou uma informação de que nada foi encontrado<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 012: CARGOS - Formulário de Cargos deve retornar uma lista de Empresas cadastradas que possuem Departamentos cadastrados

STATUS: Aprovado

Dado que após entrar no Formulário de cadastro de Cargos<br>
Quando clicar no campo Empresas<br>
Então um menu deve ser mostrado contendo as Empresas cadastradas que possuem Departamentos válidos<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 013: CARGOS - Formulário de Cargos deve retornar uma lista de Departamentos a qual o cargo será vinculado

STATUS: Aprovado

Dado que após entrar no Formulário de cadastro de Cargos<br>
Quando clicar no campo Departamento<br>
E campo Empresa estiver validado<br>
Então um menu deve ser mostrado contendo os Departamentos cadastrados ao qual o cargo será vinculado<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 014: CARGOS - Cadastro de Cargos

STATUS: Aprovado

Dado que o formulário seja corretamente preenchido e validado<br>
Quando clicar no botão Criar<br>
Então os dados devem ser salvos na base de dados<br>
E o Cargo cadastrado deve constar na lista inicial<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 015: METAS - Validação do formulário Metas

STATUS: Aprovado

Dado que o formulário não seja corretamento preenchido<br>
Quando finalizar a input de dados e mudar o campo<br>
Então uma mensagem de campo obrigatório deve ser mostrada<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 016: METAS - Cadastro de nova Meta

STATUS: Aprovado

Dado que todos os campos do formulário sejam preenchidos e validados<br>
Quando clicar no botão Criar<br>
Então a Meta deve ser salva na base de dados<br>
E ser mostrada na lista de Metas da aplicação<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 017: FUNCIONÁRIOS - Validação dos Dados da Empresas no cadastro de Funcionários

STATUS: Aprovado

Dado que seja iniciado o cadastro de Funcionário<br>
Quando clicar no campo Empresas<br>
Então apenas Empresas com Departamentos cadastrados devem ser mostrados<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 018: FUNCIONÁRIOS - Validação dos Dados do Departamento no cadastro de Funcionários

STATUS: Aprovado

Dado que seja iniciado o cadastro de Funcionário<br>
Quando clicar no campo Departamento<br>
Então apenas Departamentos com Cargos cadastrados devem ser mostrados<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 019: FUNCIONÁRIOS - Validação dos Dados do Cargo no cadastro de Funcionários

STATUS: Aprovado

Dado que seja iniciado o cadastro de Funcionário<br>
Quando clicar no campo Cargo<br>
Então apenas Cargos cadastrados e validados devem ser mostrados<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 020: FUNCIONÁRIOS - Cadastro de Funcionários

STATUS: Aprovado

Dado que todos os campos do formulário Funcionários sejam corretamente preenchidos<br>
Quando clicar em Criar<br>
Então o Funcionário deve ser salvo na base de dados<br>
E mostrá-lo na lista de Funcionários<br>
E habilitar as subabas Endereços, Documentos Pessoais, Atribuição de Metas e Minhas Metas<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 021: FUNCIONÁRIOS - Registro da subaba Endereços

STATUS: Aprovado

Dado que um Funcionário seja criado<br>
Quando a subaba Endereços for selecionada e preenchida<br>
Então o registro do Funcionário será atualizado<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 022: FUNCIONÁRIOS - Registro da subaba Documentos Pessoais

STATUS: Aprovado

Dado que um Funcionário seja criado<br>
Quando a subaba Documentos Pessoais for selecionada e preenchida<br>
Então o registro do Funcionário será atualizado<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 023: FUNCIONÁRIOS - Registro da subaba Atribuição de Metas

STATUS: Aprovado

Dado que um Funcionário seja criado<br>
Quando a subaba Atribuição de Metas for selecionada e preenchida<br>
Então o registro do Funcionário será atualizado com as Metas atribuidas a ele<br>
E a lista de Metas associadas deve parar de mostrar a mensagem 'Nenhuma meta associada' e mostrar a lista de Metas associadas<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 024: FUNCIONÁROS - Subaba Minhas Metas

STATUS: Aprovado

Dado que um Funcionário seja criado<br>
Quando a subaba Minhas Metas for selecionada<br>
Então cards dinâmicos com informações das Metas associadas devem ser mostrados<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 025: VISÕES - Permissões da Visão Gold

STATUS: Aprovado

Dado que um acesso seja feito com um usuario com permissões de visão Gold<br>
Quando fizer uso das funcionálidades do sistema<br>
Então apenas os dados relevantes à Empresa a que está vinculado será mostrada<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 025: VISÕES - Permissões da Visão Bronze 

STATUS: Aprovado

Dado que um acesso seja feito com um usuário com permissões de visão Bronze<br>
Quando fizer uso das funcionálidades do sistema<br>
Então apenas dados pessoais relevantes e do Cargo do usuário logado será mostrado<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-

CASO DE TESTE 026: DASHBOARD - Consumo dos dados pelo Dashboard

STATUS: Aprovado

Dado que os cadastros de Empresa, Departamentos, Cargos, Funcionários e Metas sejam feitos corretamente<br>
Quando o usuário entrar na tela de Dashboard<br>
Então diversos cards devem refletir a situação atual dos dados cadastrados na base de dados<br>
E devem permitir filtro por Departamentos, Cargos, Funcionários e Metas<br>

Evidências:

-_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-   -_-
