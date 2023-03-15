# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas

| Lucas De Oliveira Santos | Melissa Fernandes Santos | Lúcia De Medeiros Silva |
| ---        |    ----   |          --- |
| <img src="/docs/img/photo-lucas.jpg " alt="Lucas De Oliveira Santos"/>| <img src="/docs/img/photo-melissa.jpeg" alt="Melissa Fernandes Santos"/>| <img src="/docs/img/photo-lucia.png" alt="Lúcia De Medeiros Silva" /> |
| Idade: 32 anos <br>Ocupação: foi promovido a Gerente do setor de RH há aproximadamente 2 anos, trabalha na empresa Neskal do Brasil, uma multinacional de grande porte.| Idade: 22 anos <br>Ocupação: Estagiária do setor de RH na empresa Neskal do Brasil. Faz faculdade de Ciências Contábeis e obteve uma oportunidade de expressar seus conhecimentos contábeis junto ao setor de RH.| Idade: 42 anos <br>Ocupação: Gestora de RH na empresa Neskal do Brasil. Faz o gerenciamento do time e atividades de RH.|
|Hobbies, História:<br>Lucas sonha em revolucionar as relação funcionário x empregador e, para isso, dedica parte de seu tempo em estudo, pesquisas e treinamentos em inovações de RH.|Hobbies, História:<br>Além de ser uma jogador de vôlei e estudante, Melissa dedica uma fração do tempo em pesquisa e desenvolvimento interpessoal.|Hobbies, História:<br>Lucia realiza um sonho de estudar e conhecer belas artes.|
|Motivações: <br>Lucas tem ótimas ideias de gerenciamento e controle da produção, bem como, a gestão de expectativas de carreira e motivacional.|Motivações: <br>Melissa está conhecendo o mercado de trabalho e viu a oportunidade de trabalhar na empresa de Lucas desafiadora pois conciliar contabilidade com RH será um desafio inovador para sua carreira.|Motivações: <br>Lúcia está na empresa a 10 anos e foi recentemente promovida à Gestora de RH. Está motivada com as ideias e metodologias de Lucas e está empenhada em fazer acontecer a inovação na empresa.|
|Frustrações: <br>Atualmente Lucas tem dificuldades de acompanhar/avaliar as metas e os objetivos profissionais de cada funcionário, pois não possui uma ferramenta sistematizada que fornece dados estatísticos dos funcionários.|Frustrações: <br>Não domina a maratona de atividades do RH e precisa se orientar dentro da empresa através de uma ferramenta de suporte e capacitação.|Frustrações:  <br>A ausência de ferramentas sistematizadas de gestão de RH, onera seu tempo de pensamento inovador com funções operacionais de preenchimento de formulários de cadastros, envio e recebimento de malotes, dentre outras necessidades do setor.|

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
| Lucas	| Receber dados estatísticos de funcionários(metas atingidas, não atingidas e em atraso) | Analisar tendências, cumprimento das metas e atendimento aos objetivos.|
| Lucia | Estabelecer metas para cumprimento em curto, médio e longo prazo para departamento, individuais e RH | Melhoria contínua no desenvolvimento pessoal e profissional.|
| Melissa |Gostaria de fazer a gestão dos funcionários permitndo que eles tenham uma conta própria no sistema para entrar, sair e manter estes dados. | Ter uma maior agilidade na gestão de pessoas.|
| Lucas |	Realizar cadastros de metas	| Controle de metas.|
| Lucia	| Gostaria de controlar as empresas com seus departamentos e cargos | Ter uma maior agilidade de gestão administrativa. |
| Lucia |	Acompanhar objetivos individuais | Garantir o aperfeicoamento profissional de cada membro da equipe.|

## Modelagem do Processo de Negócio 

### Análise da Situação Atual

Apresente aqui os problemas existentes que viabilizam sua proposta. Apresente o modelo do sistema como ele funciona hoje. Caso sua proposta seja inovadora e não existam processos claramente definidos, apresente como as tarefas que o seu sistema pretende implementar são executadas atualmente, mesmo que não se utilize tecnologia computacional. 

### Descrição Geral da Proposta

Apresente aqui uma descrição da sua proposta abordando seus limites e suas ligações com as estratégias e objetivos do negócio. Apresente aqui as oportunidades de melhorias.

### Processo 1 – NOME DO PROCESSO

Apresente aqui o nome e as oportunidades de melhorias para o processo 1. Em seguida, apresente o modelo do processo 1, descrito no padrão BPMN. 

![Processo 1](img/02-bpmn-proc1.png)

### Processo 2 – NOME DO PROCESSO

Apresente aqui o nome e as oportunidades de melhorias para o processo 2. Em seguida, apresente o modelo do processo 2, descrito no padrão BPMN.

![Processo 2](img/02-bpmn-proc2.png)

## Indicadores de Desempenho

Apresente aqui os principais indicadores de desempenho e algumas metas para o processo. Atenção: as informações necessárias para gerar os indicadores devem estar contempladas no diagrama de classe. Colocar no mínimo 5 indicadores. 

Usar o seguinte modelo: 

![Indicadores de Desempenho](img/02-indic-desemp.png)
Obs.: todas as informações para gerar os indicadores devem estar no diagrama de classe a ser apresentado a posteriori. 

## Requisitos

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| O sistema deverá permitir o login de funcionários da empresa | ALTA | 
|RF-002| O sistema deverá permitir o recuperação de senha   | MÉDIA |
|RF-003| O sistema deverá permitir o gerenciamento de usuários (CRUD) | ALTA | 
|RF-004| O sistema deverá permitir o gerenciamento de empresas (CRUD)   | ALTA |
|RF-005| O sistema deverá permitir o gerenciamento de funcionários (CRUD) | ALTA | 
|RF-006| O sistema deverá permitir o gerenciamento de departamentos   | ALTA |
|RF-007| O sistema deverá permitir o gerenciamento de salários e aumentos | ALTA | 
|RF-008| O sistema deverá permitir o cadastro de novas metas   | ALTA |
|RF-009| O sistema deverá permitir a associação de metas a funcionarios | ALTA | 
|RF-010| O sistema deve apresentar um filtro para pesquisa de funcionários   | ALTA |
|RF-011| O sistema deverá permitir que o Usuário Comum visualize dados referentes a si (CRUD) | ALTA | 
|RF-012| O sistema deverá permitir que o Usuário Comum altere dados cadastrais não críticos (CRUD)   | BAIXA |
|RF-013| O sistema deverá permitir que o Usuário Comum cadastre metas pessoais de auto aprimoramento (CRUD) | MÉDIA | 


### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| O sistema de ser feito usando práticas de UX e IxD | ALTA | 
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

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.

> **Links Úteis**:
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)

# Matriz de Rastreabilidade

A matriz de rastreabilidade é uma ferramenta usada para facilitar a visualização dos relacionamento entre requisitos e outros artefatos ou objetos, permitindo a rastreabilidade entre os requisitos e os objetivos de negócio. 

A matriz deve contemplar todos os elementos relevantes que fazem parte do sistema, conforme a figura meramente ilustrativa apresentada a seguir.

![Exemplo de matriz de rastreabilidade](img/02-matriz-rastreabilidade.png)

> **Links Úteis**:
> - [Artigo Engenharia de Software 13 - Rastreabilidade](https://www.devmedia.com.br/artigo-engenharia-de-software-13-rastreabilidade/12822/)
> - [Verificação da rastreabilidade de requisitos usando a integração do IBM Rational RequisitePro e do IBM ClearQuest Test Manager](https://developer.ibm.com/br/tutorials/requirementstraceabilityverificationusingrrpandcctm/)
> - [IBM Engineering Lifecycle Optimization – Publishing](https://www.ibm.com/br-pt/products/engineering-lifecycle-optimization/publishing/)


# Gerenciamento de Projeto

De acordo com o PMBoK v6 as dez áreas que constituem os pilares para gerenciar projetos, e que caracterizam a multidisciplinaridade envolvida, são: Integração, Escopo, Cronograma (Tempo), Custos, Qualidade, Recursos, Comunicações, Riscos, Aquisições, Partes Interessadas. Para desenvolver projetos um profissional deve se preocupar em gerenciar todas essas dez áreas. Elas se complementam e se relacionam, de tal forma que não se deve apenas examinar uma área de forma estanque. É preciso considerar, por exemplo, que as áreas de Escopo, Cronograma e Custos estão muito relacionadas. Assim, se eu amplio o escopo de um projeto eu posso afetar seu cronograma e seus custos.

## Gerenciamento de Tempo

Com diagramas bem organizados que permitem gerenciar o tempo nos projetos, o gerente de projetos agenda e coordena tarefas dentro de um projeto para estimar o tempo necessário de conclusão.

![Diagrama de rede simplificado notação francesa (método francês)](img/02-diagrama-rede-simplificado.png)

O gráfico de Gantt ou diagrama de Gantt também é uma ferramenta visual utilizada para controlar e gerenciar o cronograma de atividades de um projeto. Com ele, é possível listar tudo que precisa ser feito para colocar o projeto em prática, dividir em atividades e estimar o tempo necessário para executá-las.

![Gráfico de Gantt](img/gerenciamento_tempo.png)

## Gerenciamento de Equipe

O gerenciamento adequado de tarefas contribuirá para que o projeto alcance altos níveis de produtividade. Por isso, é fundamental que ocorra a gestão de tarefas e de pessoas, de modo que os times envolvidos no projeto possam ser facilmente gerenciados. 

![Simple Project Timeline](img/02-project-timeline.png)

## Gestão de Orçamento

O processo de determinar o orçamento do projeto é uma tarefa que depende, além dos produtos (saídas) dos processos anteriores do gerenciamento de custos, também de produtos oferecidos por outros processos de gerenciamento, como o escopo e o tempo.

![Orçamento](img/02-orcamento.png)
