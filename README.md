Portifolio Pedro Furlan V3

Pacotes necessarios para rodar o projeto 

	- Dotnet CORE CLI
	- Dotnet Tools 6.0.1

Instrução de uso para rodar o sistema:

	* Identificar se em seu computador esta instalado o CLI dotnet

	* Buildar o projeto para gerar as DLL's

	* identificar se a connection strings da web API esta de acordo com o servidor local no projeto "Portifolio.WebApi"

	* Atualizar database local. Caso esteja utilizando o  dotnet tools entrar no CMD e entrar na pasta do projeto "Portifolio.Infrastructure.Database" e logo apos entrar com o comando "dotnet ef database update -v -s ..\Portifolio.WebApi"
	  Caso queira instalar o pacote "Microsoft.EntityFrameworkCore.Tools" , utilizar o comando database-update.

	* Subir a WEB api rodando 'dotnet run' ou se estiver no Visual Studio so dar play no IIS Express.

Bibliotecas utilizadas no projeto:
	
	* AutoMapper - 11.0.0
	* Dapper - 2.0.123
	* Dapper.SqlBuilder - 2.0.78
	* FluentValidation - 10.3.6
	* FluentValidation.AspNetCore - 11.0.1
	* ITextSharp - 5.5.13
	* MediatR - 10.0.1
	* MediatR.Extensions.Microsoft.DependencyInjection - 10.0.1
	* Microsoft.EntityFrameworkCore - 5.0.13
	* Microsoft.EntityFrameworkCore.Design - 5.0.13
	* Microsoft.EntityFrameworkCore.SqlServer - 5.0.13
	* MinIO - 4.0.0
	* AutoFixture - 4.17.0
	* Moq - 4.18.2
	* Xunit - 2.4.1

	
