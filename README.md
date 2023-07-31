# docker-k8s
1 on 1 with Docker and Kubernetes as a concepts. Examples (on **.NET 8**) of what have been learnd from the article [Containerized Docker Application Lifecycle with Microsoft Platform and Tools](https://learn.microsoft.com/en-us/dotnet/architecture/containerized-lifecycle/) and still going ;/

Check our [Wiki](https://github.com/BaiGanio/docker-k8s/wiki) for more **in-depth** examples.

---

# Getting Started

### Install Azure CLI 
- macOS: `brew update && brew install azure-cli`
- `az --version`
---

### Hosting over HTTPS
For Windows using Linux containers execute:
```
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\<APPNAME_PLACEHOLDER>.pfx -p <CREDENTIAL_PLACEHOLDER>
```
For macOS or Linux execute:
```
dotnet dev-certs https -ep ${HOME}/.aspnet/https/<APPNAME_PLACEHOLDER>.pfx -p <CREDENTIAL_PLACEHOLDER>
```
Finally run `dotnet dev-certs https --trust`

NOTE: In the preceding commands, replace <APPNAME_PLACEHOLDER> with the project name and <CREDENTIAL_PLACEHOLDER> with a password.

EXAMPLE (macOS): `dotnet dev-certs https -ep ${HOME}/.aspnet/https/simple-counter.pfx -p changeIt`
 - TODO: This example is not complete
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
