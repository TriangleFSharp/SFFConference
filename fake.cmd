dotnet restore build.proj
:: fake build
:: fake build -t watch
dotnet fake %*
