# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:9.0-noble AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:9.0-noble AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EventPlatform.WebApi/EventPlatform.WebApi.csproj", "EventPlatform.WebApi/"]
COPY ["EventPlatform.Application/EventPlatform.Application.csproj", "EventPlatform.Application/"]
COPY ["EventPlatform.Domain/EventPlatform.Domain.csproj", "EventPlatform.Domain/"]
COPY ["EventPlatform.BackgroundScheduller/EventPlatform.BackgroundScheduller.csproj", "EventPlatform.BackgroundScheduller/"]
COPY ["EventPlatform.Cache/EventPlatform.Cache.csproj", "EventPlatform.Cache/"]
COPY ["EventPlatform.Database/EventPlatform.Database.csproj", "EventPlatform.Database/"]
COPY ["EventPlatform.EmailProvider/EventPlatform.Email.csproj", "EventPlatform.EmailProvider/"]
COPY ["EventPlatform.JwtProvider/EventPlatform.Jwt.csproj", "EventPlatform.JwtProvider/"]
COPY ["EventPlatform.NotificationProvider/EventPlatform.Notifications.csproj", "EventPlatform.NotificationProvider/"]
COPY ["EventPlatform.PasswordHasher/EventPlatform.PasswordHash.csproj", "EventPlatform.PasswordHasher/"]
COPY ["EventPlatform.Payments/EventPlatform.Payments.csproj", "EventPlatform.Payments/"]
COPY ["EventPlatform.RandomCodeGeneration/EventPlatform.RandomCodeGeneration.csproj", "EventPlatform.RandomCodeGeneration/"]
RUN dotnet restore "./EventPlatform.WebApi/EventPlatform.WebApi.csproj"
COPY . .
WORKDIR "/src/EventPlatform.WebApi"
RUN dotnet build "./EventPlatform.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EventPlatform.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventPlatform.WebApi.dll"]