# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais, além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar as especificações do projeto

## Personas

| Lucas de Oliveira Santos | Melissa Fernandes Santos | Lúcia de Medeiros Silva |
| ---        |    ----   |          --- |
| <img src="/docs/img/photo-lucas.jpg " alt="Lucas de Oliveira Santos"/>| <img src="/docs/img/photo-melissa.jpeg" alt="Melissa Fernandes Santos"/>| <img src="/docs/img/photo-lucia.png" alt="Lúcia de Medeiros Silva" /> |
| Idade: 32 anos <br>Ocupação: foi promovido a Gerente do setor de RH há aproximadamente 2 anos, trabalha na empresa Neskal do Brasil, uma multinacional de grande porte.| Idade: 22 anos <br>Ocupação: Estagiária do setor de RH na empresa Neskal do Brasil. Faz faculdade de Ciências Contábeis e obteve uma oportunidade de expressar seus conhecimentos contábeis, junto ao setor de RH.| Idade: 42 anos <br>Ocupação: Gestora de RH na empresa Neskal do Brasil. Faz o gerenciamento do time e atividades de RH.|
|Hobbies, História:<br>Lucas sonha em revolucionar a relação funcionário x empregador e, para isso, dedica parte de seu tempo em estudo, pesquisas e treinamentos em inovações de RH.|Hobbies, História:<br>Além de ser uma jogadora de vôlei e estudante, Melissa dedica uma fração do tempo em pesquisa e desenvolvimento interpessoal.|Hobbies, História:<br>Lucia realiza um sonho de estudar e conhecer belas artes.|
|Motivações: <br>Lucas tem ótimas ideias de gerenciamento e controle da produção, bem como, a gestão de expectativas de carreira e motivacional.|Motivações: <br>Melissa está conhecendo o mercado de trabalho, e viu como um desafio a oportunidade de trabalhar na empresa de Lucas, pois conciliar contabilidade com RH será um desafio inovador para sua carreira.|Motivações: <br>Lúcia está na empresa há 10 anos e foi recentemente promovida à Gestora de RH. Está motivada com as ideias e metodologias de Lucas e está empenhada em fazer acontecer a inovação na empresa.|
|Frustrações: <br>Atualmente,Lucas tem dificuldades de acompanhar/avaliar as metas e os objetivos profissionais de cada funcionário, pois não possui uma ferramenta sistematizada que fornece dados estatísticos dos funcionários.|Frustrações: <br>Não domina a maratona de atividades do RH e precisa se orientar dentro da empresa, através de uma ferramenta de suporte e capacitação.|Frustrações:  <br>A ausência de ferramentas sistematizadas de gestão de RH, onera seu tempo de pensamento inovador com funções operacionais de preenchimento de formulários de cadastros, envio e recebimento de malotes, dentre outras necessidades do setor.|

## Histórias de Usuários

Com base na análise das personas, foram identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
| Lucas	| Receber dados estatísticos de funcionários(metas atingidas, não atingidas e em atraso) | Analisar tendências, cumprimento das metas e atendimento aos objetivos.|
| Lucia | Estabelecer metas para cumprimento em curto, médio e longo prazo para departamento, individuais e RH | Melhoria contínua no desenvolvimento pessoal e profissional.|
| Melissa |Gostaria de fazer a gestão dos funcionários, permitindo que eles tenham uma conta própria no sistema para entrar, sair e manter estes dados. | Ter uma maior agilidade na gestão de pessoas.|
| Lucas |	Realizar cadastros de metas	| Controle de metas.|
| Lucia	| Gostaria de controlar as empresas com seus departamentos e cargos | Ter uma maior agilidade de gestão administrativa. |
| Lucia |	Acompanhar objetivos individuais | Garantir o aperfeiçoamento profissional de cada membro da equipe.|

## Modelagem do Processo de Negócio 

### Análise da Situação Atual

<p>Com o avanço e crescimento no setor de RH, existe a necessidade de organização e automação das diferentes funções de forma ágil, como por exemplo: a verificação cadastral de funcionários, análise de metas e desempenho deles.</p> Muitas empresas enfrentam problemas no que diz respeito à análise de desempenho de cada funcionário. Tal dificuldade de verificar e analisar o crescimento ao longo dos meses, torna muito despercebido e pouco notado, além de se formarem inúmeros gargalos, impossibilitando agilidade e criando um grande desafio de análise; dessa forma, enxerga-se a necessidade de criação de um sistema automatizado para que este desenvolvimento seja visto, gerando ânimo e consequentemente um reconhecimento a longo prazo.

### Descrição Geral da Proposta

O objetivo é desenvolver um sistema que auxilie no gerenciamento do crescimento e desenvolvimento de cada colaborador, com cadastro de funcionários, metas, cargos e salários.

### Processo 1 – USUÁRIO COMUM 

Atualmente o processos funcionam assim, sem realizar nenhuma análise crítica e sem discutir se o processo está bom ou ruim. 

![Usuário Comum](img/02-bpmn-user-comum.png)

### Processo 2 – OPERACIONAL RH

Atualmente o processos funcionam assim, sem realizar nenhuma análise crítica e sem discutir se o processo está bom ou ruim. 

![Operacional RH](img/02-bpmn-oper-rh.png)

### Processo 2 – GESTÃO RH

Atualmente o processos funcionam assim, sem realizar nenhuma análise crítica e sem discutir se o processo está bom ou ruim.

![Gestão RH](img/02-bpmn-gestao-rh.png)
## Indicadores de Desempenho

| | Indicador | Objetivo | Descrição | Cálculo | Fonte de Dados | Perspectiva
|--------------------|--------------------|--------------------|--------------------|--------------------|--------------------|--------------------|
| 0	| Total de usuários cadastrados | Analisar crescimento da plataforma | Quantidade de usuários registrados no banco de dados | Qtde. absoluta de registros  | Tabela aspnetusers | Solidez no mercado |
| 2	| Total de empresas cadastradas | Analisar crescimento da plataforma | Quantidade de empresas registradas no banco de dados | Qtde. absoluta de registros | Tabela empresas | Solidez no mercado |
| 3	| Total de funcionários cadastrados | Avaliar porte das empresas que utilizam a aplicação | Quantidade de funcionários registrados no banco de dados | Qtde. absoluta de registros | Tabela funcionarios | Análise dos perfis de clientes |
| 4	| Total de departamentos cadastrados | Avaliar porte das empresas que utilizam a aplicação | Quantidade de departamentos registrados no banco de dados | Qtde. absoluta de registros | Tabela departamentos | Análise dos perfis de clientes |
| 5	| Total de metas cadastradas | Avaliar uso pelas empresas | Quantidade de metas registradas no banco de dados | Qtde. absoluta de registros | Tabela metas | Avaliar uso da aplicação pelas empresas |
| 6	| Total de associações metas x funcionários | Avaliar uso pelas empresas | Quantidade de funcionariosmetas registrados no banco de dados | Qtde. absoluta de registros | Tabela funcionariosmetas | Avaliar uso da aplicação pelas empresas |
| 7	| Total de bugs encontrados (web) | Analisar qualitativamente os ciclos de desenvolvimento e teste do produto | Quantidade de metas registradas no banco de dados | Qtde. absoluta de registros | | Processos internos |
| 8	| Total de bugs encontrados (mobile) | Analisar qualitativamente os ciclos de desenvolvimento e teste do produto | Quantidade de metas registradas no banco de dados | Qtde. absoluta de registros | | Processos internos |

## Requisitos

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| O sistema deverá permitir o Login de funcionários da empresa | ALTA | 
|RF-002| O sistema deverá permitir a recuperação de senha   | BAIXA |
|RF-003| O sistema deverá permitir o gerenciamento de usuários (CRUD) | ALTA | 
|RF-004| O sistema deverá permitir o gerenciamento de empresas (CRUD)   | ALTA |
|RF-005| O sistema deverá permitir o gerenciamento de funcionários (CRUD) | ALTA | 
|RF-006| O sistema deverá permitir o gerenciamento de departamentos (CRUD) | ALTA |
|RF-007| O sistema deverá permitir o gerenciamento de cargos (CRUD) | ALTA | 
|RF-008| O sistema deverá permitir o gerenciamento de salários e atualizações do mesmo | ALTA | 
|RF-009| O sistema deverá permitir o cadastro de novas metas   | ALTA |
|RF-010| O sistema deverá permitir a associação de metas aos funcionários | ALTA | 


### Requisitos Não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| O sistema deve ser feito usando práticas de UX e IxD | ALTA | 
|RNF-002| O sistema deve ser disponibilizado publicamente no GitHub |  ALTA | 
|RNF-003| O sistema deve apresentar baixo tempo de resposta nas requisições (não superior a 3 segundos) | MÉDIA | 
|RNF-004| O sistema deve ser implementado em C# e Angular |  ALTA | 
|RNF-005| O sistema deve ser responsivo e compatível com os principais navegadores | MÉDIA | 
|RNF-006| O sistema deve possuir uma versão mobile |  ALTA | 


## Restrições


|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do EIXO-4 (01/2023) |
|02| Deve ser desenvolvido um módulo de backend em C#      |


## Diagrama de Casos de Uso


|ATOR|	DESCRIÇÃO|
|----|-----------|
| Usuário Comum | Ator que faz login, visualiza o cadastro feito pelo RH, atualiza dados cadastrais, visualiza metas definidas pelo RH, cadastra metas pessoais e realiza consultas.|
| Operacional RH | Ator que cadastra funcionários, associa e cadastra novas metas, atualiza o cadastro (departamento e cargos), não faz cadastros administrativos, mas faz cadastro de usuários e cria contas.|
| Gestão RH | Ator com o papel master. Cria departamentos, cria metas, cria cargos e salários, realiza cadastros administrativos ("faz tudo").|

|CASO DE USO|	DESCRIÇÃO|	RF|
|-|-|-|
|Realizar Login no Sistema| O Usuário Comum deve conseguir realizar login com suas credenciais no sistema.| RF01/RF02|
|Gerenciar Perfil| O Usuário Comum deve conseguir gerenciar o seu perfil (atualizar dados não críticos e alterar senha) (CRUD) |RF01/RF02/RF03|
|Gerenciar Metas| O Usuário Comum deve conseguir cadastrar e visualizar metas de auto aprimoramento| RF08|
|Realizar pesquisa de funcionários | O Usuário Operacional RH deve conseguir realizar consultas no sistema| RF05|
|Gerenciar Usuário Comum| O Usuário Operacional RH deve conseguir gerenciar Usuários Comuns (CRUD)| RF03|
|Gerenciar Departamentos e Cargos| O Usuário Operacional RH deve conseguir atualizar o cadastro de departamentos e cargos | RF06 |
|Associar Metas| O Usuário Operacional RH deve conseguir associar novas metas | RF09 |
|Cadastrar Funcionários| O Usuário Operacional RH deve conseguir cadastrar funcionários  | RF05 |
|Gerenciar empresas| O Usuário Gestão RH deve conseguir gerenciar empresas (CRUD)| RF04|
|Gerenciar Funcionários| O Usuário Gestão RH deve conseguir gerenciar funcionários (CRUD) | RF05 |
|Gerenciar salários |O Usuário Gestão RH deve conseguir gerenciar salários |RF07 |
|Cadastrar Metas| O Usuário Gestão RH deve conseguir cadastrar metas | RF08 |


## Representação Visual
 ![Diagrama de Caso de Uso](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/blob/main/docs/img/diagrama-caso-uso.png)


# Matriz de Rastreabilidade

A matriz de rastreabilidade é uma ferramenta utilizada para facilitar a visualização de relacionamento entre requisitos e outros artefatos ou objetos, permitindo a rastreabilidade entre os requisitos e os objetivos de negócio. 

A matriz deve contemplar todos os elementos relevantes que fazem parte do sistema, conforme a figura meramente ilustrativa apresentada a seguir:

<p align="center">
 <p align="center"> Matriz de rastreabilidade </p>
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Rastreabilidade%20OnPeople.png>
</p>

# Gerenciamento de Projeto

## Gerenciamento de Tempo

O cronograma da equipe é atualizado a cada sprint.

Cronograma das etapas 1 e 2:
![Gráfico de Gantt](img/cronograma-onpeople.png)

Cronograma da etapa 3:
![Gráfico de Gantt](img/cronograma-etapa3.png)

## Gerenciamento de Equipe

O gerenciamento adequado de tarefas contribuirá para que o projeto alcance altos níveis de produtividade. Por isso, é fundamental que ocorra a gestão de tarefas e de pessoas, de modo que os times envolvidos no projeto possam ser facilmente gerenciados. 

![Simple Project Timeline](img/gerenciamento_equipe.png)

#### Time Back-End: 
* Alex de Souza Galdino
* Ciro Hideki Artiga Watanabe
* Pedro Luiz Braga Andrade Leite
* Rafaela Cristina Souza de Oliveira

#### Time Front-End: 
* Isabella Carolina de Almeida Siqueira Damião
* Vitória Gabriella Maffei Corrêa Rocha

## Gestão de Orçamento

O processo de determinar o orçamento do projeto é uma tarefa que depende, além dos produtos (saídas) dos processos anteriores, do gerenciamento de custos, e também de produtos oferecidos por outros processos de gerenciamento, como o escopo e o tempo.

![Orçamento](img/gerenciamento_recursos.png)
