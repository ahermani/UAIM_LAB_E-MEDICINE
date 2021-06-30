#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebKlient/ZsutPwPatterns.WebApplication.BlazorServer/ZsutPwPatterns.WebApplication.BlazorServer.csproj", "WebKlient/ZsutPwPatterns.WebApplication.BlazorServer/"]
COPY ["WebKlient/ZsutPwPatterns.Application.Utilities/ZsutPwPatterns.Application.Utilities.csproj", "WebKlient/ZsutPwPatterns.Application.Utilities/"]
COPY ["WebKlient/ZsutPwPatterns.Application.Tests/ZsutPwPatterns.Application.Tests.csproj", "WebKlient/ZsutPwPatterns.Application.Tests/"]
COPY ["WebKlient/ZsutPwPatterns.Application.Model/ZsutPwPatterns.Application.Model.csproj", "WebKlient/ZsutPwPatterns.Application.Model/"]
COPY ["WebKlient/ZsutPwPatterns.Application.Controller/ZsutPwPatterns.Application.Controller.csproj", "WebKlient/ZsutPwPatterns.Application.Controller/"]
RUN dotnet restore "WebKlient/ZsutPwPatterns.WebApplication.BlazorServer/ZsutPwPatterns.WebApplication.BlazorServer.csproj"
COPY . .
WORKDIR "/src/WebKlient/ZsutPwPatterns.WebApplication.BlazorServer"
RUN dotnet build "ZsutPwPatterns.WebApplication.BlazorServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ZsutPwPatterns.WebApplication.BlazorServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZsutPwPatterns.WebApplication.BlazorServer.csproj.dll"]