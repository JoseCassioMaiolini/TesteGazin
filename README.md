Não foi possivel entregar a aplicação com Docker ou testes unitarios. Estou com uma demanda muito grande no meu emprego atual e so tive tempo de fazer durante o final de semana.
Caso esta solução não tenha sido avaliada até o proximo final de semana(03/07), commito as alterações para incluir os testes e docker.

A solução foi desenvolvida utilizando o VS2019 asp.net core 5.0

Api desenvolvida utilizando framework .NET 5.0 e base de dados SqlServer.

Deve-se executar o script para criação da base de dados e tabelas do banco de dados. ...\TesteGazinApi\Script\ScriptDados.txt.

O server name do banco “(localdb)\\mssqllocaldb” ou alterar string de conexão do arquivo -> ...\TesteGazinApi\appsettings.json.

Inicializiar a API TesteGazinApi.

Para consumir a api via postman -> https://localhost:44366/api/DesenvolvedoresModels .

Inicializiar TesteGazinFrontEnd -> para realizar o crud, ele consome os endpoints da API.

Para desenvolvimento desta solução foram usados vários tutoriais, utilizei varias partes de cada um deles, retiradas diretamente da documentação oferecida pela microsoft:

https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-5.0
https://docs.microsoft.com/pt-br/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
https://docs.microsoft.com/pt-br/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-5.0&tabs=visual-studio


Agradeço a oprotunidade e espero ser aceito. Estou ansioso para trabalharmos juntos.
