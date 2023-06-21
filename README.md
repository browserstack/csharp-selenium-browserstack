# csharp-selenium-browserstack

## Prerequisite
<b>Dotnet CLI</b> must be installed on your system. Check the installation exists before running script.

```
dotnet --version
```
## Steps to run test sessions
### Clone and build the project
```
git clone https://github.com/browserstack/csharp-selenium-browserstack.git
cd csharp-selenium-browserstack
dotnet build
```
### Configure credentials in each test files (SingleTest.cs, LocalTest.cs, Paralleltest.cs)
```c#
String BROWSERSTACK_USERNAME = "BROWSERSTACK_USERNAME";
String BROWSERSTACK_ACCESS_KEY = "BROWSERSTACK_ACCESS_KEY";
```

### Run Parallel Test
i. Navigate to Parallel.cs </br>
ii. Configure the capabilites

```csharp
Thread device1 = new Thread(obj => sampleTestCase("Safari", "latest", null, "14", "iPhone 12 Pro Max", "true", "BStack parallel test", "browserstack build"));
Thread device2 = new Thread(obj => sampleTestCase("Chrome", "latest", null, null, "Samsung Galaxy S20", "true", "BStack parallel test", "browserstack build"));
Thread device3 = new Thread(obj => sampleTestCase("Firefox", "latest", "OSX", "Monterey", null, null, "BStack parallel test", "browserstack build"));
Thread device4 = new Thread(obj => sampleTestCase("Safari", "latest", "OSX", "Big Sur", null, null, "BStack parallel test", "browserstack build"));
Thread device5 = new Thread(obj => sampleTestCase("Edge", "latest", "Windows", "10", null, null, "BStack parallel test", "browserstack build"));
```
iii. Run your test <br/>
```
dotnet run Program.cs parallel
```
### Run Local Test
i. Navigate to Local.cs </br>
ii. Configure the capabilites

```csharp
capability.AddAdditionalCapability("browser", "iPhone");
capability.AddAdditionalCapability("device", "iPhone 11");
capability.AddAdditionalCapability("realMobile", "true");
capability.AddAdditionalCapability("os_version", "14.0");
capability.AddAdditionalCapability("name", "BStack local test"); // test name
capability.AddAdditionalCapability("build", "browserstack build"); // CI/CD job or build name
```
iii. Run your test <br/>
```
dotnet run Program.cs local
```
