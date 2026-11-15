FROM mcr.microsoft.com/dotnet/sdk:10.0 AS builder
WORKDIR /app
COPY Fleet.Center.Platform/*.csproj Fleet.Center.Platform/
RUN dotnet restore ./Fleet.Center.Platform
COPY . .
RUN dotnet publish ./Fleet.Center.Platform -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=builder /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "Fleet.Center.Platform.dll"]