#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OrderProcessing.Product/OrderProcessing.Product.csproj", "OrderProcessing.Product/"]
RUN dotnet restore "OrderProcessing.Product/OrderProcessing.Product.csproj"
COPY . .
WORKDIR "/src/OrderProcessing.Product"
RUN dotnet build "OrderProcessing.Product.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderProcessing.Product.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderProcessing.Product.dll"]