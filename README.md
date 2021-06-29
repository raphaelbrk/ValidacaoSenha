# Projeto de Validação de Senha

Esse projeto foi desenvolvimento na tecnologia .NET 5 para a validação de senha. Este projeto segue as seguintes regras para validação:

- Nove ou mais caracteres.
- Ao menos 1 dígito.
- Ao menos 1 letra minúscula.
- Ao menos 1 letra maiúscula.
- Ao menos 1 caractere especial.
- Considere como especial os seguintes caracteres: !@#$%^&*()-+.
- Não possuir caracteres repetidos dentro do conjunto.

As regras estão desacopladas e são validadas separadamente. 

Segue abaixo o detalhamento das tecnologias, padrões de projetos e metodologias utilizadas:

<b>#Tecnologias Utilizadas:</b>

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

 <b>#Padrões de Projetos Utilizados:</b>
 - Generic Repository Pattern.
 - Unit of Work Paterrn.
 - Notification Pattern.
 - Middleware Pattern.
 - Singleton Pattern.
 - Inversion of Control Pattern.
 - Interceptor Pattern.
 - Command Pattern.
 - Dependency Injection Pattern.

  <b>#Metodologias Utilizadas</b>
  - Clean Code.
  - SOLID.
  - TDD.
  - Documentação de Classes.
  - Principio do DDD (Insolamento do Dominio da Aplicação);

<b>#Arquitetura Utilizada: Clean Architecture</b>
<b>Motivos:</b>
- Independência de Framework.
- Independência de identidade.
- Independência de banco de dados.
- Independência de qualquer elemento externo.
- Ter uma maior estabilidade.
 
