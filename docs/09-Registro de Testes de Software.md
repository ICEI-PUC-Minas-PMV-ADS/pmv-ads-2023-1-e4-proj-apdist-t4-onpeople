# Registro de Testes de Software

## RF-006: O sistema deverá permitir o gerenciamento de departamentos (CRUD)

**CT01: POST api/Departamentos - Realizando a requisição informando os dados obrigatórios corretamente**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** que as propriedades nomeDepartamento e empresaId sejam informados no request body <br/>
**When** a rota api/Departamentos for executada <br/>
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
**When** a rota api/Departamentos for executada <br/>
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
