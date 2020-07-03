# Case The Cat API

## a.	Documentação do projeto

Projeto para consumir, gravar e expor as informações da API "The Cat" (https://thecatapi.com/).

Utilizamos o banco de dados **MySql online** que contem as seguintes tabelas:
- **Raca**: para cada uma das raças de gatos disponíveis, armazenamos as informações de origem, temperamento e descrição (informações estão disponíveis no arquivo **/docs/Raca.pdf**)
- **ImagemRaca**: para cada uma das raças, armazenamos o endereço de 3 imagens (informações estão disponíveis no arquivo **/docs/ImagemRaca.pdf**)
- **Categoria**: armazenamos todas as categorias (informações estão disponíveis no arquivo **/docs/Categoria.pdf**)
- **ImagemCategoria**: para as categorias de gatos com chapéu e de gatos com óculos, armazenamos o endereço de 3 imagens de cada (informações estão disponíveis no arquivo **/docs/ImagemCategoria.pdf**)



### Pre-requisitos

- Microsoft Visual Studio 2019
- Acesso a uma conexão de internet


## b.	Documentação das APIs REST
  A coleção do postman para consumir as APIs se encontram no arquivo **/docs/CatAPI.postman_collection.json**.
  
    - Endpoint : localhost:8752
    - Metodo   : GET

#### Listar todas as raças
    - Rota      : /racas
    - Parâmetro : não tem
    - Exemplo :
![](/Imagem/racas.png)
 
#### Listar as informações de uma raça
    - Rota      : /racas/{nomeRaca}
    - Parâmetro : {nomeRaca}
    - Exemplo :
![](/Imagem/racas_nome.png)
     
#### Listar as raças a partir de um temperamento
    - Rota      : /racasTemperamento/{nomeTemperamento}
    - Parâmetro : {nomeTemperamento}
    - Exemplo :
![](/Imagem/temperamento.png)
    
#### Listar as raças a partir de uma origem
    - Rota      : /racasOrigem/{nomeOrigem}
    - Parâmetro : {nomeOrigem}
    - Exemplo :
![](/Imagem/origem.png)
    
    
---

## c. Documentação da arquitetura

A solução foi desenvolvida :
- Sistema operacional : Windows
- Linguem de programação : Microsoft Visual Studio 2019
- Plataforma : .net Framework 4.8 com MySql Entity Framework 
- Banco de dados : MySql Server
- Docker Container:
  - ElasticSearch
  - Kibana

Temos 5 projetos dentro da solução:
- Unit Tests : Responsável pelos testes unitarios automatizados que podem ser executados da aba "Test Explorer";
- CatRestAPI : Responsável pelas APIs rest usadas para retornar as informações da base de dados;
- CatApiIntegration : Responsável pelas chamadas das APIs The Cat e inclusão das informações na base de dados;
- CatApiData : Responsável pelo gerenciamento do contexto (entidades, conexão com a base de dados e gravação e consulta);
- CatApiCore : Responsãvel pelas interfaces dos modelos.

 ![](/Imagem/Projeto.png)

---

## d.	Documentação para Execução

- Realizar o download do repositório em uma pasta local
- Abrir o Microsoft Visual Studio 2019
- Abrir a solução CatProject.sln
- Teclar F5 para rodar o programa que abrirá uma tela do browser apontando para o localhost (localhost:8752)
![](/Imagem/localhost.png)
- Abrir o Postman e importar o arquivo **/docs/CatAPI.postman_collection.json**
- Caso não tenha um programa de execução de API (como Postman por exemplo) esta tela pode ser usada para testar as chamadas das APIs rest bastando incluir as rotas disponíveis após o endereço (ex.: localhost:8752/racas)
![](/Imagem/localhost_racas.png)



## e.	Manual com prints dos Logs (item 6) e os 3 Dashboards (item 7).
- Utilizado a solução ElasticSearch para realizar o loggin das requisições e Kibana para criação das visualizações.
- Utilizei o pacote NEST para realizar a integração do .Net com o Elastic.

-Confirmação do serviço Elastic:

 ![](/Imagem/elastic.PNG)

-Confirmação do serviço Kibana:
 ![](/Imagem/kibana.PNG)
 ![](/Imagem/kibana2.PNG)

-Monitoramento das chamadas controladas e gravadas em banco de dados:
 ![](/Imagem/localhost_logging.png)




## Autor

* **Roberto Evangelista** - *Initial work* - [catapi](https://github.com/betorocamo)
