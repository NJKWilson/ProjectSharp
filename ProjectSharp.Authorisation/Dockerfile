FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProjectSharp.Authorisation/ProjectSharp.Authorisation.csproj", "ProjectSharp.Authorisation/"]
RUN dotnet restore "ProjectSharp.Authorisation/ProjectSharp.Authorisation.csproj"
COPY . .
WORKDIR "/src/ProjectSharp.Authorisation"
RUN dotnet build "ProjectSharp.Authorisation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectSharp.Authorisation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectSharp.Authorisation.dll"]
