# build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /src
COPY . ./
RUN dotnet restore
RUN dotnet publish "./CanadaTaxCalculator.csproj" -c release -o /publish --no-restore

# runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /publish
COPY --from=build-env /publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "CanadaTaxCalculator.dll"]

# build cmd
# docker build --rm -t canada-tax-calculator:latest .

# run command
# docker run --rm --name canada-tax-container -p 7253:80 canada-tax-calculator
# docker run --name canada-tax-container-net --network taxing-network -d -p 7253:80 canada-tax-calculator
