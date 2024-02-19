FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Quiz.Service.csproj", "./"]
# ADD https://kmxprodzscalercerts.blob.core.windows.net/zscalercerts/zscaler_root_ca.crt /usr/local/share/ca-certificates/zscaler.crt
# RUN cat /usr/local/share/ca-certificates/zscaler.crt >> /etc/ssl/certs/ca-certificates.crt
RUN dotnet restore "Quiz.Service.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "Quiz.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Quiz.Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
ARG ASPNETCORE_ENVIRONMENT=dev
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Quiz.Service.dll"]