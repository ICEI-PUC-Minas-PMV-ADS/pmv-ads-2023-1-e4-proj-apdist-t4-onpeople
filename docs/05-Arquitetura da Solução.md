# Arquitetura da Solução

A arquitetura da solução será baseada no estilo arquitetural de microserviços. Este estilo arquitetural coloca prioridade no desacoplamento entre serviços através da definição de domínios de aplicação que são independentes de outros, em termos de código fonte e esquemas de banco de dados. Este estilo baseia-se no conceito de contexto limitado, onde em cada contexto são acoplados código e esquemas de forma coesa, mas sem acoplamento com contextos externos. Desta forma, os serviços são menos complexos que em outros estilos arquiteturais.

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Arquitetura%20distribu%C3%ADda.png>
</p>
<p align="center"> Arquitetura da solução </p>
</br>

## Diagrama de Classes

O diagrama de classes ilustra graficamente como será a estrutura do software, e como cada uma das classes da sua estrutura estarão interligadas. Essas classes servem de modelo para materializar os objetos que executarão na memória.


</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/Diagrama%20de%20Classes%20-%20OnPeople.png>
</p>
<p align="center"> Diagrama de Classes </p>
</br>

## Modelo ER

O Modelo ER representa, através de um diagrama, como as entidades (coisas, objetos) se relacionam entre si na aplicação interativa.]

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-apdist-t4-onpeople/main/docs/img/EntityRelationshipDiagram.png>
</p>
<p align="center"> Diagrama Entidade-Relacionamento </p>
</br>

## Modelo Físico

Entregar um arquivo banco.sql contendo os scripts de criação das tabelas do banco de dados. Este arquivo deverá ser incluído dentro da pasta src\bd.

## Tecnologias Utilizadas

* **Tecnologias front-end:** HTML, CSS, JavaScript, Angular e Bootstrap
* **Tecnologias back-end:** C# e SQL
* **Sistema Gerenciador de Banco de Dados:** SQLServer
* **Editor de código:** Visual Studio Code

## Hospedagem

Explique como a hospedagem e o lançamento da plataforma foi feita.

> **Links Úteis**:
>
> - [Website com GitHub Pages](https://pages.github.com/)
> - [Programação colaborativa com Repl.it](https://repl.it/)
> - [Getting Started with Heroku](https://devcenter.heroku.com/start)
> - [Publicando Seu Site No Heroku](http://pythonclub.com.br/publicando-seu-hello-world-no-heroku.html)

## Qualidade de Software

Conceituar qualidade de fato é uma tarefa complexa, mas ela pode ser vista como um método gerencial que através de procedimentos disseminados por toda a organização, busca garantir um produto final que satisfaça às expectativas dos stakeholders.

No contexto de desenvolvimento de software, qualidade pode ser entendida como um conjunto de características a serem satisfeitas, de modo que o produto de software atenda às necessidades de seus usuários. Entretanto, tal nível de satisfação nem sempre é alcançado de forma espontânea, devendo ser continuamente construído. Assim, a qualidade do produto depende fortemente do seu respectivo processo de desenvolvimento.

A norma internacional ISO/IEC 25010, que é uma atualização da ISO/IEC 9126, define oito características e 30 subcaracterísticas de qualidade para produtos de software.
Com base nessas características e nas respectivas sub-características, identifique as sub-características que sua equipe utilizará como base para nortear o desenvolvimento do projeto de software considerando-se alguns aspectos simples de qualidade. Justifique as subcaracterísticas escolhidas pelo time e elenque as métricas que permitirão a equipe avaliar os objetos de interesse.

> **Links Úteis**:
>
> - [ISO/IEC 25010:2011 - Systems and software engineering — Systems and software Quality Requirements and Evaluation (SQuaRE) — System and software quality models](https://www.iso.org/standard/35733.html/)
> - [Análise sobre a ISO 9126 – NBR 13596](https://www.tiespecialistas.com.br/analise-sobre-iso-9126-nbr-13596/)
> - [Qualidade de Software - Engenharia de Software 29](https://www.devmedia.com.br/qualidade-de-software-engenharia-de-software-29/18209/)
