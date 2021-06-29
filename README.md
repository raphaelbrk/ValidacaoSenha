# Projeto de Validação de Senha

Esse projeto foi desenvolvimento na tecnologia .NET 5 para a validação de senha. Este projeto segue as seguintes regras para validação:

- Nove ou mais caracteres.
- Ao menos 1 dígito.
- Ao menos 1 letra minúscula.
- Ao menos 1 letra maiúscula.
- Ao menos 1 caractere especial.
- Considere como especial os seguintes caracteres: !@#$%^&*()-+.
- Não possuir caracteres repetidos dentro do conjunto.

As regras estão desacopladas e são validadas separadamente através do FluentValidation. 

Segue abaixo o detalhamento das tecnologias, padrões de projetos e metodologias utilizadas:

## Tecnologias Utilizadas: ##

 - .NET 5.
 - MongoDB.
 - Swagger.
 - JWT.
 - MediatR.
 - NUnit.
 - Newtonsoft.Json.
 - Docker (DockerFile e Docker-Compose).
 - FluentValidation.
 - Regex.
 - Microsoft.AspNetCore.Mvc.Testing

 ## Padrões de Projetos Utilizados: ##
 - Generic Repository Pattern.
 - Unit of Work Paterrn.
 - Notification Pattern.
 - Middleware Pattern.
 - Singleton Pattern.
 - Inversion of Control Pattern.
 - Interceptor Pattern.
 - Command Pattern.
 - Dependency Injection Pattern.

  ## Metodologias Utilizadas ##
  - Clean Code.
  - SOLID.
  - TDD.
  - Documentação de Classes.
  - Principio do DDD (Insolamento do Dominio da Aplicação);

## Arquitetura Utilizada: Clean Architecture: ##

- Independência de Framework.
- Independência de identidade.
- Independência de banco de dados.
- Independência de qualquer elemento externo.
- Ter uma maior estabilidade.

## Outros Motivos de Decisão de Implementação: ##
 - Alteração no retorno da API para ao invés de retornar apenas um verdadeiro/falso, a aplicação retornará as inconsistências da validações de senha e se a validação foi verdadeiro ou não.
 - Implementação de uma criptografia básica para ter uma maior segurança na transferência das senhas entre as camandas e a persistência de banco. 
 - Decisão de utilizar o Mediatr para abstrair o projeto da API com o projeto da Application, tendo a abstração através da interface do MediatR.
- Utilização do Regex separadamente. Para ter uma maior entendimento e retornar as validações separadamente para os usuários. 
- Implementação do repositório MongoDB. Mesmo que o escopo inicial não pedisse, tive a proatividade de mostrar mais da minha implementação.
- Implementação de alguns padrões de projetos normalmente utilizados e outros para demostrar o meu nivel de conhecimento.
- Utilização do Clean Code.
- Utilização da aplicação autenticação JWT básica para ter uma segurança maior na API.


> **_Nota:_** Para cada classe existe uma documentação em cabeçalho explicando a sua responsabilidade. O intuito é para facilitar o entendimento das responsabilidades.

## Estrutura do Projeto: ##


```
📦src
 ┣ 📂Validacao.Senha.Application 
 ┃ ┣ 📂Authorization
 ┃ ┃ ┗ 📜GerarTokenAuthorization.cs
 ┃ ┣ 📂Base
 ┃ ┃ ┗ 📜BaseSenhaQueryCommand.cs
 ┃ ┣ 📂Command
 ┃ ┃ ┗ 📜GravarSenhaCommand.cs
 ┃ ┣ 📂Context
 ┃ ┃ ┗ 📜NotificacaoContext.cs
 ┃ ┣ 📂Handler
 ┃ ┃ ┣ 📜GerarTokenHandler.cs
 ┃ ┃ ┣ 📜GravarSenhaHandler.cs
 ┃ ┃ ┗ 📜ValidarSenhaHandler.cs
 ┃ ┣ 📂Interfaces
 ┃ ┃ ┣ 📜IGerarTokenAuthorization.cs
 ┃ ┃ ┗ 📜INotificacaoContext.cs
 ┃ ┣ 📂Query
 ┃ ┃ ┣ 📜GerarTokenSenhaQuery.cs
 ┃ ┃ ┗ 📜ValidarSenhaQuery.cs
 ┃ ┣ 📜DependencyInjection.cs
 ┃ ┗ 📜Validacao.Senha.Application.csproj
 ┣ 📂Validacao.Senha.Domain
 ┃ ┣ 📂Constantes
 ┃ ┃ ┣ 📜MensagensConstantes.cs
 ┃ ┃ ┣ 📜RegexConstantes.cs
 ┃ ┃ ┗ 📜SenhaConstantes.cs
 ┃ ┣ 📂Entities
 ┃ ┃ ┣ 📜BaseAbstractEntity.cs
 ┃ ┃ ┣ 📜BaseEntity.cs
 ┃ ┃ ┣ 📜NotificacaoEntity.cs
 ┃ ┃ ┗ 📜SenhaEntity.cs
 ┃ ┣ 📂Enums
 ┃ ┃ ┣ 📜AcaoEncryptionEnum.cs
 ┃ ┃ ┣ 📜CodigoErrorValidacaoEnum.cs
 ┃ ┃ ┣ 📜CodigoSucessoValidacaoEnum.cs
 ┃ ┃ ┗ 📜RetornoEnum.cs
 ┃ ┣ 📂Exceptions
 ┃ ┃ ┣ 📜EncriptacaoPossuiEspacoException.cs
 ┃ ┃ ┣ 📜EnumDescricaoNuloReferenceException.cs
 ┃ ┃ ┣ 📜ForbiddenAccessException.cs
 ┃ ┃ ┗ 📜NotFoundException.cs
 ┃ ┣ 📂Extensions
 ┃ ┃ ┣ 📜EnumExtensions.cs
 ┃ ┃ ┣ 📜ObjetoExtensions.cs
 ┃ ┃ ┗ 📜StringExtensions.cs
 ┃ ┣ 📂Helpers
 ┃ ┃ ┣ 📜CriptografarHelper.cs
 ┃ ┃ ┣ 📜DescriptografarHelper.cs
 ┃ ┃ ┗ 📜ValidarSenhaHelper.cs
 ┃ ┣ 📂Validations
 ┃ ┃ ┗ 📜SenhaValidator.cs
 ┃ ┗ 📜Validacao.Senha.Domain.csproj
 ┣ 📂Validacao.Senha.Infrastructure
 ┃ ┣ 📂Context
 ┃ ┃ ┗ 📜MongoContext.cs
 ┃ ┣ 📂Interfaces
 ┃ ┃ ┣ 📜IMongoContext.cs
 ┃ ┃ ┣ 📜IRepository.cs
 ┃ ┃ ┣ 📜ISenhaRepository.cs
 ┃ ┃ ┗ 📜IUnitOfWork.cs
 ┃ ┣ 📂Mappings
 ┃ ┃ ┗ 📜SenhaMap.cs
 ┃ ┣ 📂Persistence
 ┃ ┃ ┗ 📜MongoDbPersistence.cs
 ┃ ┣ 📂Repositories
 ┃ ┃ ┣ 📜BaseRepository.cs
 ┃ ┃ ┗ 📜SenhaRepository.cs
 ┃ ┣ 📂UoW
 ┃ ┃ ┗ 📜UnitOfWork.cs
 ┃ ┣ 📜DependencyInjection.cs
 ┃ ┗ 📜Validacao.Senha.Infrastructure.csproj
 ┣ 📂Validacao.Senha.IntegrationTests
 ┃ ┣ 📂Controllers
 ┃ ┃ ┣ 📜TokenControllerTest.cs
 ┃ ┃ ┗ 📜ValidarControllerTest.cs
 ┃ ┣ 📜BaseTest.cs
 ┃ ┗ 📜Validacao.Senha.IntegrationTests.csproj
 ┣ 📂Validacao.Senha.UnitTests
 ┃ ┣ 📂Extensions
 ┃ ┃ ┣ 📜EnumExtensionsTest.cs
 ┃ ┃ ┣ 📜ObjectExtensionsTest.cs
 ┃ ┃ ┗ 📜StringExtensionsTest.cs
 ┃ ┣ 📂Helpers
 ┃ ┃ ┣ 📜CriptografarHelperTest.cs
 ┃ ┃ ┗ 📜DescriptografarHelperTest.cs
 ┃ ┣ 📂Validations
 ┃ ┃ ┗ 📜SenhaValidatorTest.cs
 ┃ ┣ 📜BaseTest.cs
 ┃ ┗ 📜Validacao.Senha.UnitTests.csproj
 ┣ 📂Validacao.Senha.Web
 ┃ ┣ 📂Controllers
 ┃ ┃ ┣ 📜BaseController.cs
 ┃ ┃ ┣ 📜GravarSenhaController.cs
 ┃ ┃ ┣ 📜TokenController.cs
 ┃ ┃ ┗ 📜ValidarController.cs
 ┃ ┣ 📂Filters
 ┃ ┃ ┣ 📜ApiExceptionFilterAttribute.cs
 ┃ ┃ ┗ 📜NotificacaoFilter.cs
 ┃ ┣ 📂Middleware
 ┃ ┃ ┗ 📜ErrorHandlerMiddleware.cs
 ┃ ┣ 📂Properties
 ┃ ┃ ┗ 📜launchSettings.json
 ┃ ┣ 📂ViewModel
 ┃ ┃ ┗ 📜RetornoViewModel.cs
 ┃ ┣ 📜appsettings.Development.json
 ┃ ┣ 📜appsettings.json
 ┃ ┣ 📜Dockerfile
 ┃ ┣ 📜Program.cs
 ┃ ┣ 📜Startup.cs
 ┃ ┣ 📜Validacao.Senha.Web.csproj
 ┃ ┣ 📜Validacao.Senha.Web.csproj.user
 ┃ ┗ 📜Validacao.Senha.Web.xml
 ┗ 📜ValidacaoSenha.sln
 ```

## Execução da Aplicação ##

  <b>1)</b> Primeiramente, execute o docker-compose up -d para iniciar a instancia do MongoDB. 
  </br>
   > **_Nota:_** Essa etapa, é executada apenas caso queira testar a parte de gravação e executar os testes unitários.
   
   ![alt text](https://github.com/raphaelbrk/ValidacaoSenha/blob/main/img/dockercomposeup.jpg?raw=true)
    <b>2)</b> Executar a aplicação Validacao.Senha.Web, por comando, dotnet run ou pelo visual studio ou code.
    <b>3)</b> Após executar com sucesso, acessar a página do swagger, pela seguite url: http://localhost:9001/swagger
    ![alt text](https://github.com/raphaelbrk/ValidacaoSenha/blob/main/img/pagina-swagger.jpg?raw=true)
    <b>4)</b> Após acessar, executar o endpoint Token/Get para a geração do Token JWT. Após fazer a geração do token copie o response, e ai cole no campo Authorize que fica no canto superior direito. Logo após colar, clique no botão Authorize.
    ![alt text](https://github.com/raphaelbrk/ValidacaoSenha/blob/main/img/tokengerado.jpg?raw=true)
    ![alt text](https://github.com/raphaelbrk/ValidacaoSenha/blob/main/img/inclusao-authorize.jpg?raw=true)
    <b>5)</b>Após ser autorizado na API de Validação de Senha, agora você pode utilizar o endpoint para validar sua senha. O endpoint é Validar/Post. Segue o contrato do endpoint:

    ```
    {
	    "Conteudo":"informar_senha"
    } 
    ```

    ![alt text](https://github.com/raphaelbrk/ValidacaoSenha/blob/main/img/validar-post.jpg?raw=true)
    
    