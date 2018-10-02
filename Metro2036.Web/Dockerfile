ENV ASPNETCORE_ENVIRONMENT='Production'
ENV Metro2036Az = 'Server=sql,1433;Database=Metro2036;User Id=SA; Password='

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Metro2036.Web/Metro2036.Web.csproj", "Metro2036.Web/"]
COPY ["Metro2036.Services/Metro2036.Services.csproj", "Metro2036.Services/"]
COPY ["Metro2036.Data/Metro2036.Data.csproj", "Metro2036.Data/"]
COPY ["Metro2036.Models/Metro2036.Models.csproj", "Metro2036.Models/"]
COPY ["Metro2036.Common/Metro2036.Common.csproj", "Metro2036.Common/"]
RUN dotnet restore "Metro2036.Web/Metro2036.Web.csproj"
COPY . .
WORKDIR "/src/Metro2036.Web"
RUN dotnet build "Metro2036.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Metro2036.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Metro2036.Web.dll"]