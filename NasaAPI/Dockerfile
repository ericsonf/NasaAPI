FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine as publish
WORKDIR /publish
COPY NasaAPI.csproj .
RUN dotnet restore "NasaAPI.csproj"
COPY . .
RUN dotnet publish "NasaAPI.csproj" -c Release -o ./out

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine 
WORKDIR /var/www/aspnetcoreapp
COPY --from=publish /publish/out .
EXPOSE 5000
ENTRYPOINT ["dotnet", "NasaAPI.dll"]