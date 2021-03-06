FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
COPY src/IstioDemoDotNet.Tests.Integration /build
RUN dotnet publish /build -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS runtime
WORKDIR /app
COPY --from=build /app ./
COPY --from=redboxoss/scuttle:latest /scuttle /bin/scuttle
ENTRYPOINT ["scuttle", "dotnet", "IstioDemoDotNet.Tests.Integration.dll"]