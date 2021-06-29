FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Validacao.Senha.Web/Validacao.Senha.Web.csproj", "Validacao.Senha.Web/"]
COPY ["Validacao.Senha.Infrastructure/Validacao.Senha.Infrastructure.csproj", "Validacao.Senha.Infrastructure/"]
COPY ["Validacao.Senha.Domain/Validacao.Senha.Domain.csproj", "Validacao.Senha.Domain/"]
COPY ["Validacao.Senha.Application/Validacao.Senha.Application.csproj", "Validacao.Senha.Application/"]
RUN dotnet restore "Validacao.Senha.Web/Validacao.Senha.Web.csproj"
COPY . .
WORKDIR "/src/Validacao.Senha.Web"
RUN dotnet build "Validacao.Senha.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Validacao.Senha.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Validacao.Senha.Web.dll"]