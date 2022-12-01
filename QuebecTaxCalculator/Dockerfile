# build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /src
COPY . ./
RUN dotnet restore
RUN dotnet publish "./QuebecTaxCalculator.csproj" -c release -o /publish --no-restore

# runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /publish
COPY --from=build-env /publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "QuebecTaxCalculator.dll"]

# build cmd
# docker build --rm -t quebec-tax-calculator:latest .

# run cmd
# docker run --rm --name quebec-tax-container -p 7076:80 quebec-tax-calculator
# docker run --name quebec-tax-container-net --network taxing-network -d -p 7076:80 quebec-tax-calculator

