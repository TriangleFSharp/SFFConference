dotnet restore build.proj
:: fake build
:: fake build -t watch
@mkdir %~dp0\public
dotnet fake %*
