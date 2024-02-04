# Installer image
FROM mcr.microsoft.com/windows/servercore:ltsc2022  AS installer
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

# Retrieve .NET Core Runtime
# USER ContainerAdministrator
USER ContainerAdministrator
RUN $dotnet_version = '6.0.26'; \
    Invoke-WebRequest -OutFile dotnet-installer.exe https://download.visualstudio.microsoft.com/download/pr/7d3cdd04-9db8-41db-bc86-4af63f9edd4a/8899ff776eed41b3f5376bfc09913c36/dotnet-runtime-6.0.26-win-x64.exe; \
    $dotnet_sha512 = '3ca5c85db44c19e8b96cb7d1e40cc6cd8303c81450fac7e1036823bd2321dba0e5cb184642b396ae9d41abd10b4c048daf69c5b9632e39c8e93768bb65d97bf7'; \
    if ((Get-FileHash dotnet-installer.exe -Algorithm sha512).Hash -ne $dotnet_sha512) { \
        Write-Host 'CHECKSUM VERIFICATION FAILED!'; \
        exit 1; \
    }; \    
    ./dotnet-installer.exe /S 
RUN dir 

# Runtime image 
FROM mcr.microsoft.com/windows/nanoserver:ltsc2022  as base
WORKDIR /app
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV DOTNET_VERSION=6.0.26

# In order to set system PATH, ContainerAdministrator must be used
USER ContainerAdministrator
RUN setx /M PATH "%PATH%;C:\Program Files\dotnet"
USER ContainerUser
COPY --from=installer ["/Program Files/dotnet", "/Program Files/dotnet"]

FROM mcr.microsoft.com/dotnet/sdk:6.0-nanoserver-ltsc2022  AS build
WORKDIR /src
COPY . .

WORKDIR /src/Expectativas_de_Mercado_Mensais.WPF
RUN dotnet build "Expectativas_de_Mercado_Mensais.WPF.csproj" -c Release -o /app/build --restore

FROM build AS publish
RUN dotnet publish "Expectativas_de_Mercado_Mensais.WPF.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /Program Files/dotnet
RUN dir 
WORKDIR /app
COPY --from=publish ./app/publish .
ENTRYPOINT ["dotnet", "Expectativas_de_Mercado_Mensais.WPF.dll"]
