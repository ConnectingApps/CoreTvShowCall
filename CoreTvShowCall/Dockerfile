FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY CoreTvShowCall/CoreTvShowCall.csproj CoreTvShowCall/
RUN dotnet restore CoreTvShowCall/CoreTvShowCall.csproj
COPY . .
WORKDIR /src/CoreTvShowCall
RUN dotnet build CoreTvShowCall.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CoreTvShowCall.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CoreTvShowCall.dll"]
