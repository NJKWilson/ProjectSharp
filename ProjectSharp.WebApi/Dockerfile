FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProjectSharp.WebApi/ProjectSharp.WebApi.csproj", "ProjectSharp.WebApi/"]
RUN dotnet restore "ProjectSharp.WebApi/ProjectSharp.WebApi.csproj"
COPY . .
WORKDIR "/src/ProjectSharp.WebApi"
RUN dotnet build "ProjectSharp.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectSharp.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectSharp.WebApi.dll"]
