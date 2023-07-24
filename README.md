# Capmonster.cloud Library for .NET Core
![Nuget](https://img.shields.io/nuget/dt/CapMonster.Cloud?style=for-the-badge) ![Nuget](https://img.shields.io/nuget/v/CapMonster.Cloud?style=for-the-badge) ![GitHub last commit](https://img.shields.io/github/last-commit/alperensert/CapMonster.Cloud?style=for-the-badge) ![GitHub Release Date](https://img.shields.io/github/release-date/alperensert/CapMonster.Cloud?style=for-the-badge) ![GitHub Repo stars](https://img.shields.io/github/stars/alperensert/CapMonster.Cloud?style=for-the-badge)

[Capmonster.cloud](https://capmonster.cloud) Library for .NET Core.

### Installation
via Package Manager:
```
NuGet\Install-Package CapMonster.Cloud -Version 1.0.0
```
This command is intended to be used within the Package Manager Console in Visual Studio, as it uses the NuGet module's version of Install-Package.

via .NET CLI:
```ssh
dotnet add package CapMonster.Cloud --version 1.0.0
```

via adding PackageReference:
```xml
<PackageReference Include="CapMonster.Cloud" Version="1.0.0-alpha" />
```
For projects that support PackageReference, copy this XML node into the project file to reference the package.

### Supported Captcha Types
- Image to text
- ReCaptcha V2
- ReCaptcha V2 Enterprise
- ReCaptcha V3
- HCaptcha
- FunCaptcha
- Turnstile
- GeeTest

### Usage Examples
---
### Creating a client
```csharp
var client = new CapMonsterClient("apikey");
```
### Get balance
```csharp
var client = new CapMonsterClient("apikey");
await client.GetBalanceAsync();
```
#### ReCaptchaV2 Task
```csharp
var client = new CapMonsterClient("apikey", false);
var task = new ReCaptchaV2Task("recaptcha-site", "recaptcha-site-key");
string id = await client.CreateTask(task);
var response = await client.JoinTaskResult<ReCaptchaV2Response>(id);
```

#### FunCaptcha Task
```csharp
var client = new CapMonsterClient("apikey", false);
var task = new FunCaptchaTask("funcaptcha-site", "funcaptcha-key", "funcaptcha-js-source");
string id = await client.CreateTask(task);
var response = await client.JoinTaskResult<FunCaptchaTaskResponse>(id);
```

For other examples and api documentation please visit [wiki](https://zennolab.atlassian.net/wiki/spaces/APIS/pages/491575/English+Documentation)