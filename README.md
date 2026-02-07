<table align="left">
 <tr><th>
  <h2 align="left">ℜ𝔢𝔩𝔦𝔠𝔰 𝔒𝔣 𝔗𝔥𝔢 𝔄𝔫𝔠𝔦𝔢𝔫𝔱𝔰</h2>
 </th></tr>
 <tr><td>
  <p align="center">
  <a href="https://raw.githubusercontent.com/BaiGanio/docker-k8s/refs/heads/master/src/files/geography.sql">𝔤𝔢𝔬𝔤𝔯𝔞𝔭𝔥𝔶.𝔰𝔮𝔩</a>
  <br>
  <a href="https://raw.githubusercontent.com/BaiGanio/docker-k8s/refs/heads/master/src/files/geography.sql">𝔠𝔬𝔪𝔭𝔞𝔫𝔶.𝔰𝔮𝔩</a>
</p>
 </td></tr>
</table>

<table align="right">
 <tr><th>
  <h2 align="left">ℜ𝔢𝔩𝔦𝔠𝔰 𝔒𝔣 𝔗𝔥𝔢 𝔄𝔫𝔠𝔦𝔢𝔫𝔱𝔰</h2>
 </th></tr>
 <tr><td>
  <p align="center">
  <a href="https://raw.githubusercontent.com/BaiGanio/docker-k8s/refs/heads/master/src/files/geography.sql">𝔤𝔢𝔬𝔤𝔯𝔞𝔭𝔥𝔶.𝔰𝔮𝔩</a>
  <br>
  <a href="https://raw.githubusercontent.com/BaiGanio/docker-k8s/refs/heads/master/src/files/geography.sql">𝔠𝔬𝔪𝔭𝔞𝔫𝔶.𝔰𝔮𝔩</a>
</p>
 </td></tr>
</table>
<p><p>
<br>
<br>
<br>
<br>
<br>
<br>
 
# docker-k8s (1 on 1 with Docker and Kubernetes)

Examples on **.NET** of what have been learnd so far and still going **;/**

The main goal is to be shown how quickly to create and **containerize .NET** applications.
Examples shown are suitable for **rapid** development

 ✔ Check our **[Wiki](https://github.com/BaiGanio/docker-k8s/wiki)** for more **in-depth** examples.

---

 


## Getting Started

### Check The System
- Run `dotnet --info` command to determine which .NET SDK you're using.
- Run `docker info` for basic Docker system info
  - Shows version, storage driver, container count, network config, and more.
- Run `docker version` for version details
  - Displays client and server versions, API versions, build details.
- Run `docker ps` to check if Docker is running
  - If this errors out, Docker daemon might not be running.

---

### Check your MS SQL Server
- Download latest image
```
docker pull mcr.microsoft.com/azure-sql-edge
```
- Create  contauner and run the image
```
docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=s3cr3tP@$$' -p 1433:1433 --name azuresqledge -d mcr.microsoft.com/azure-sql-edge
```
### Install Azure CLI 
- macOS: `brew update && brew install azure-cli`
- `az --version`
---



### Build and Test
For Windows using Linux containers:
```
docker-compose up
```
For macOS (tested on MacBook Pro with M1 Pro chip): 
```
docker-compose -f docker-compose.yml -f docker-compose.mac.override.yml up
```

NOTE: This will start and restart all the services defined in `docker-compose.yml` for Windows and respecrespectively `docker-compose.mac.override.yml` for macOS.

---

### TODO
### Register the Solution in an Azure Container Registry (ACR)
```powershell
az acr create --name codejams --resource-group free-resource-group --sku basic --admin-enabled
```

---

### Resources
 - Check the official articles
   - [Containerized Docker Application Lifecycle with Microsoft Platform and Tools](https://learn.microsoft.com/en-us/dotnet/architecture/containerized-lifecycle/)
   - [Tutorial: Containerize a .NET app](https://learn.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=windows)
