## Verificar versões SDK do .NET:
`dotnet --info`

## Remover SDK específico.NET:

Para Linux:

`sudo apt-get remove dotnet-sdk-<version>`

Para Windows:

`dotnet --uninstall -sdk <version>`

## Atualizar SDK:

Para Linux:

`./dotnet-install.sh --version latest`

Para Windows:

`dotnet --version` (Verifica e atualiza)

## Atualiza versão específica:
`./dotnet-install.sh --channel 7.`