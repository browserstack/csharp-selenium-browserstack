# csharp-selenium-browserstack

## Prerequisite
---
<b>Dotnet CLI</b> must be installed on your system. Check the installation exists before running script.

```
dotnet --version
```
## Steps to run test sessions
---
### CLone and build the project
```
git clone https://github.com/browserstack/csharp-selenium-browserstack.git
cd csharp-selenium-browserstack
dotnet build
```
### Configure Credentials in each test files (SingleTest.cs, LocalTest.cs, Paralleltest.cs)
```c#
 // Update your credentials
String BROWSERSTACK_USERNAME = "BROWSERSTACK_USERNAME";
String BROWSERSTACK_ACCESS_KEY = "BROWSERSTACK_ACCESS_KEY";
```
---
### Run Sigle Test
i. Navigate to Single.cs </br>
ii. Configure the capabilites

```csharp
capability.AddAdditionalCapability("browser", "iPhone");
capability.AddAdditionalCapability("device", "iPhone 11");
capability.AddAdditionalCapability("realMobile", "true");
capability.AddAdditionalCapability("os_version", "14.0");
capability.AddAdditionalCapability("name", "BStack-[C_sharp] Sample Test"); // test name
capability.AddAdditionalCapability("build", "BStack Build Number 1"); // CI/CD job or build name
```
iii. Run your test <br/>
```
dotnet run Program.cs single
```
---
### Run Local Test
i. Navigate to Local.cs </br>
ii. Configure the capabilites

```csharp
capability.AddAdditionalCapability("browser", "iPhone");
capability.AddAdditionalCapability("device", "iPhone 11");
capability.AddAdditionalCapability("realMobile", "true");
capability.AddAdditionalCapability("os_version", "14.0");
capability.AddAdditionalCapability("name", "BStack-[C_sharp] Sample Test"); // test name
capability.AddAdditionalCapability("build", "BStack Build Number 1"); // CI/CD job or build name
```
iii. Run your test <br/>
```
dotnet run Program.cs local
```
---
### Run Parallel Test
i. Navigate to Parallel.cs </br>
ii. Configure the capabilites

```csharp
capability.AddAdditionalCapability("browser", "iPhone");
capability.AddAdditionalCapability("device", "iPhone 11");
capability.AddAdditionalCapability("realMobile", "true");
capability.AddAdditionalCapability("os_version", "14.0");
capability.AddAdditionalCapability("name", "BStack-[C_sharp] Sample Test"); // test name
capability.AddAdditionalCapability("build", "BStack Build Number 1"); // CI/CD job or build name
```
iii. Run your test <br/>
```
dotnet run Program.cs parallel
```