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

<b>Tecnologias Utilizadas:</b>

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

 <b>Padrões de Projetos Utilizados:</b>
 - Generic Repository Pattern.
 - Unit of Work Paterrn.
 - Notification Pattern.
 - Middleware Pattern.
 - Singleton Pattern.
 - Inversion of Control Pattern.
 - Interceptor Pattern.
 - Command Pattern.
 - Dependency Injection Pattern.

  <b>Metodologias Utilizadas</b>
  - Clean Code.
  - SOLID.
  - TDD.
  - Documentação de Classes.
  - Principio do DDD (Insolamento do Dominio da Aplicação);

<b>Arquitetura Utilizada: Clean Architecture:</b>
</br>
<b>Motivos:</b>
- Independência de Framework.
- Independência de identidade.
- Independência de banco de dados.
- Independência de qualquer elemento externo.
- Ter uma maior estabilidade.

<b>Outros Motivos de Decisão de Implementação:</b>
 - Alteração no retorno da API para ao invés de retornar apenas um verdadeiro/falso, a aplicação retornará as inconsistências da validações de senha e se a validação foi verdadeiro ou não.
 - Implementação de uma criptografia básica para ter uma maior segurança na transferência das senhas entre as camandas e a persistência de banco. 
 - Decisão de utilizar o Mediatr para abstrair o projeto da API com o projeto da Application, tendo a abstração através da interface do MediatR.
- Utilização do Regex separadamente. Para ter uma maior entendimento e retornar as validações separadamente para os usuários. 
- Implementação do repositório MongoDB. Mesmo que o escopo inicial não pedisse, tive a proatividade de mostrar mais da minha implementação.
- Implementação de alguns padrões de projetos normalmente utilizados e outros para demostrar o meu nivel de conhecimento.
- Utilização do Clean Code a risca.
