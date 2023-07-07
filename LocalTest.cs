using System;
using System.Collections.Generic;
using BrowserStack;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
namespace csharp_selenium_browserstack
{
    class LocalTest
    {
        public static void execute()
        {
            // Update your credentials
            String? BROWSERSTACK_USERNAME = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
            if (BROWSERSTACK_USERNAME is null)
                BROWSERSTACK_USERNAME = "BROWSERSTACK_USERNAME";

            String? BROWSERSTACK_ACCESS_KEY = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");
            if (BROWSERSTACK_ACCESS_KEY is null)
                BROWSERSTACK_ACCESS_KEY = "BROWSERSTACK_ACCESS_KEY";
            IWebDriver driver;
            OpenQA.Selenium.Safari.SafariOptions capability = new OpenQA.Selenium.Safari.SafariOptions();
            capability.AddAdditionalCapability("browser", "iPhone");
            capability.AddAdditionalCapability("device", "iPhone 11");
            capability.AddAdditionalCapability("realMobile", "true");
            capability.AddAdditionalCapability("browserstack.local", "true");
            capability.AddAdditionalCapability("os_version", "14.0");
            capability.AddAdditionalCapability("name", "BStack local test"); // test name
            capability.AddAdditionalCapability("build", "browserstack build"); // CI/CD job or build name
            capability.AddAdditionalCapability("browserstack.source", "csharp:sample-selenium-3:v1.0");
            capability.AddAdditionalCapability("browserstack.user", BROWSERSTACK_USERNAME);
            capability.AddAdditionalCapability("browserstack.key", BROWSERSTACK_ACCESS_KEY);
            capability.AddAdditionalCapability("browserstack.local", "true");
            // Creates an instance of Local
            Local local = new Local();

            // You can also set an environment variable - "BROWSERSTACK_ACCESS_KEY".
            List<KeyValuePair<string, string>> bsLocalArgs = new List<KeyValuePair<string, string>>();
            // Starts the Local instance with the required arguments
            bsLocalArgs.Add(new KeyValuePair<string, string>("key", BROWSERSTACK_ACCESS_KEY));

            // Starts the Local instance with the required arguments
            local.start(bsLocalArgs);
            driver = new RemoteWebDriver(new Uri("https://hub.browserstack.com/wd/hub/"), capability);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           
            try
            {
                driver.Navigate().GoToUrl("http://bs-local.com:45691/check");
                // getting body content
                String body_text = driver.FindElement(By.TagName("body")).Text;
                if (body_text == "Up and running")
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \"Local test ran successful\"}}");
                }
            }
            catch
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" Issues connecting local\"}}");
            }
            driver.Quit();
            local.stop();

        }
    }
}
