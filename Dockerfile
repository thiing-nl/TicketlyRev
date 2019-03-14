FROM microsoft/dotnet:2.2-sdk AS build-env

RUN mkdir /app
RUN ls
COPY . app
WORKDIR /app
RUN ls

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "Screend.dll"]