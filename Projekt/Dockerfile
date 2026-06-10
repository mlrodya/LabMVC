FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["CyfrowaBiblioteka/CyfrowaBiblioteka.csproj", "CyfrowaBiblioteka/"]
RUN dotnet restore "CyfrowaBiblioteka/CyfrowaBiblioteka.csproj"
COPY . .
WORKDIR "/src/CyfrowaBiblioteka"
RUN dotnet build "CyfrowaBiblioteka.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CyfrowaBiblioteka.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CyfrowaBiblioteka.dll"]
