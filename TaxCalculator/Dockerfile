# build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /src
COPY . ./
RUN dotnet restore "./IncomeTaxCalculator.csproj"
RUN dotnet publish "./IncomeTaxCalculator.csproj" -c release -o /publish --no-restore

# runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /publish
COPY --from=build-env /publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "IncomeTaxCalculator.dll"]

# build cmd
# docker build --rm -t income-tax-calculator:latest .

# run command
# docker run --rm --name income-tax-container -p 7118:80  income-tax-calculator
# docker run --name income-tax-container-net --network taxing-network -d -p 7118:80  income-tax-calculator
