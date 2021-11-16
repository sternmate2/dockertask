FROM mcr.microsoft.com/dotnet/core/sdk:3.1
RUN mkdir /App
COPY . ./App
WORKDIR /App/BootcapProject.WebService
RUN dotnet publish -c release -r ubuntu.16.04-x64 --self-contained
WORKDIR /App/BootcapProject.WebService/bin/release/netcoreapp3.1/ubuntu.16.04-x64
#CMD  ["dotnet", "BootcapProject.WebService"]
#RUN pwd
CMD ["/bin/sh", "-c", "./BootcapProject.WebService"]