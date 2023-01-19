FROM mcr.microsoft.com/dotnet/sdk:5.0 AS BUILD

WORKDIR /src

COPY *.sln ./
COPY *.config ./
COPY *.xml ./
COPY *.runsettings ./
COPY Portifolio.Domain/Portifolio.Domain.csproj/ Portifolio.Domain/
COPY Portifolio.Domain.Command/Portifolio.Domain.Command.csproj/ Portifolio.Domain.Command/
COPY Portifolio.Domain.Query/Portifolio.Domain.Query.csproj/ Portifolio.Domain.Query/
COPY Portifolio.Domain.Test/Portifolio.Domain.Test.csproj/ Portifolio.Domain.Test/
COPY Portifolio.Infrastructure.Database/Portifolio.Infrastructure.Database.csproj/ Portifolio.Infrastructure.Database/
COPY Portifolio.Utils/Portifolio.Utils.csproj/ Portifolio.Utils/
COPY Portifolio.WebApi/Portifolio.WebApi.csproj/ Portifolio.WebApi/

RUN dotnet restore

COPY . .

RUN dotnet build

WORKDIR /src/Portifolio.WebApi

RUN dotnet publish -o /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 

WORKDIR /app

ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80

COPY --from=BUILD /app .

ENTRYPOINT ["dotnet","Portifolio.WebApi.dll"]
