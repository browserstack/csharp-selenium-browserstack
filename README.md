# csharp-selenium-browserstack

## Prerequisite
Visual Studio - IDE <br/>
https://visualstudio.microsoft.com/

Go over browserstack doc to setup visual studio <br/>
https://www.browserstack.com/docs/automate/selenium/getting-started/c-sharp#introduction

## Steps to run test sessions

1. Configure the capabilites and use your credentials
(To run a single test, navigate to Single.cs)

```csharp
capability.AddAdditionalCapability("browser", "iPhone");
capability.AddAdditionalCapability("device", "iPhone 11");
capability.AddAdditionalCapability("realMobile", "true");
capability.AddAdditionalCapability("os_version", "14.0");
capability.AddAdditionalCapability("name", "BStack-[C_sharp] Sample Test"); // test name
capability.AddAdditionalCapability("build", "BStack Build Number 1"); // CI/CD job or build name
capability.AddAdditionalCapability("browserstack.user", "Username"); // IMP: Use your browserstack username
capability.AddAdditionalCapability("browserstack.key", "AccessKey"); // IMP: Use your browserstack accesskey
```

2. Run your tests <br/>
<img width="224" alt="image" src="https://user-images.githubusercontent.com/97675949/158065684-1e40e851-0c49-4f8f-84e8-28165c7435e1.png">
