FROM mcr.microsoft.com/dotnet/sdk:5.0 

WORKDIR /src

COPY *.sln ./
COPY *.config ./
COPY *.xml ./
COPY *.runsettings ./
COPY Portifolio.Domain/ Portifolio.Domain/
COPY Portifolio.Domain.Command/ Portifolio.Domain.Command/
COPY Portifolio.Domain.Query/ Portifolio.Domain.Query/
COPY Portifolio.Domain.Test/ Portifolio.Domain.Test/
COPY Portifolio.Infrastructure.Database/ Portifolio.Infrastructure.Database/
COPY Portifolio.Utils/ Portifolio.Utils/
COPY Portifolio.WebApi/ Portifolio.WebApi/

RUN dotnet restore
RUN dotnet build

WORKDIR /src/Portifolio.WebApi

RUN dotnet publish -o /app

WORKDIR /app

CMD ["dotnet","Portifolio.WebApi.dll"]

EXPOSE 5001