FROM mcr.microsoft.com/windows/servercore:ltsc2022 as base
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

# Retrieve .NET 6.0 Runtime (v6.0.26) - Windows x64 Installer
RUN $dotnet_version = '6.0.26'; 
RUN Invoke-WebRequest -OutFile dotnet-desktop-installer.exe https://download.visualstudio.microsoft.com/download/pr/3136e217-e5b7-4899-9b7e-aa52ecb8b108/d74134edaa75e3300f8692660b9fb7b5/windowsdesktop-runtime-6.0.26-win-x64.exe; \
    $dotnet_sha512 = '7dd45e746fb0b82c13b91559ac25a39b66b9c94c22e5f9bd91b1dceaff96922b1da2fed152ec36e15f2c7a38e0180508f81807930928c5d0aea225f117a108c4'; \
    if ((Get-FileHash dotnet-desktop-installer.exe -Algorithm sha512).Hash -ne $dotnet_sha512) { \
        Write-Host 'CHECKSUM VERIFICATION FAILED!'; \
        exit 1; \
    }; \    
    ./dotnet-desktop-installer.exe /S 

FROM mcr.microsoft.com/dotnet/sdk:6.0-nanoserver-ltsc2022 AS build
WORKDIR /src
COPY . .

WORKDIR /src/Expectativas_de_Mercado.WPF
RUN dotnet build "Expectativas_de_Mercado.WPF.csproj"  -o /app/build --restore

FROM build AS publish
RUN dotnet publish "Expectativas_de_Mercado.WPF.csproj" -c Release -o /app/publish

FROM base AS final
#USER ContainerAdministrator
#RUN setx /M PATH "%PATH%;'C:\Program Files\dotnet'"
#COPY --from=build ["/Program Files/dotnet/sdk", "/Program Files/dotnet/sdk"]

#USER ContainerUser
WORKDIR /app
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV DOTNET_VERSION=6.0.26
COPY --from=publish ./app/publish .

ENTRYPOINT ["dotnet", "Expectativas_de_Mercado.WPF.dll"]

# keep the container running
#CMD ["ping", "-t", "localhost"]

