#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PatientAppMicroservice/PatientAppMicroservice/PatientAppMicroservice.csproj", "PatientAppMicroservice/"]
COPY ["XMLDatabase/XMLDatabase.csproj", "XMLDatabase/"]
COPY ["ModelClassLibrary/ModelClassLibrary.csproj", "ModelClassLibrary/"]
RUN dotnet restore "PatientAppMicroservice/PatientAppMicroservice.csproj"
COPY . .
WORKDIR "/src/PatientAppMicroservice/PatientAppMicroservice"
RUN dotnet build "PatientAppMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PatientAppMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ModelClassLibrary/schema.xsd .
COPY ModelClassLibrary/schema_guid.xsd .
COPY ModelClassLibrary/schema_model.xsd .
ENTRYPOINT ["dotnet", "PatientAppMicroservice.dll"]