FROM  mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR portfoliowebapp

EXPOSE 80

COPY . ./
RUN dotnet restore ./PortfolioBackend/PortfolioBackend.csproj

RUN dotnet publish ./PortfolioBackend/PortfolioBackend.csproj -c Realease -o out

FROM  mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /portfoliowebapp
COPY --from=build /portfoliowebapp/out .

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "PortfolioBackend.dll"]