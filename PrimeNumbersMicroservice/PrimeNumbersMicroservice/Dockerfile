FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY . ./
RUN dotnet publish PrimeNumbersMicroservice -c Release -o PrimeNumbersMicroservice/out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/PrimeNumbersMicroservice/out .

ENTRYPOINT ["dotnet", "PrimeNumbersMicroservice.dll"]