FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./FogApi/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ./FogApi ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS=http://+:6969
EXPOSE 6969
ENTRYPOINT ["dotnet", "FogApi.dll"]