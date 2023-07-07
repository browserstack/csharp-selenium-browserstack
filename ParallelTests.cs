using System.Threading;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace csharp_selenium_browserstack
{
    class ParallelTests
    {
        public static void execute()
        {
            Thread device1 = new Thread(obj => sampleTestCase("Safari", "latest", null, "14", "iPhone 12 Pro Max", "true", "BStack parallel test", "browserstack build"));
            Thread device2 = new Thread(obj => sampleTestCase("Chrome", "latest", null, null, "Samsung Galaxy S20", "true", "BStack parallel test", "browserstack build"));
            Thread device3 = new Thread(obj => sampleTestCase("Firefox", "latest", "OSX", "Monterey", null, null, "BStack parallel test", "browserstack build"));
            Thread device4 = new Thread(obj => sampleTestCase("Safari", "latest", "OSX", "Big Sur", null, null, "BStack parallel test", "browserstack build"));
            Thread device5 = new Thread(obj => sampleTestCase("Edge", "latest", "Windows", "10", null, null, "BStack parallel test", "browserstack build"));

            //Executing the methods
            device1.Start();
            device2.Start();
            device3.Start();
            device4.Start();
            device5.Start();
            device1.Join();
            device2.Join();
            device3.Join();
            device4.Join();
            device5.Join();
        }

        static void sampleTestCase(String browser, String browser_version, String os, String os_version, String device, String realmobile, String test_name, String build_name)
        {
            // Update your credentials
            String? BROWSERSTACK_USERNAME = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
            if (BROWSERSTACK_USERNAME is null)
                BROWSERSTACK_USERNAME = "BROWSERSTACK_USERNAME";

            String? BROWSERSTACK_ACCESS_KEY = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");
            if (BROWSERSTACK_ACCESS_KEY is null)
                BROWSERSTACK_ACCESS_KEY = "BROWSERSTACK_ACCESS_KEY";
            switch (browser)
            {
                case "Safari": //If browser is Safari, following capabilities will be passed to 'executetestwithcaps' function
                    OpenQA.Selenium.Safari.SafariOptions safariCapability = new OpenQA.Selenium.Safari.SafariOptions();
                    safariCapability.AddAdditionalCapability("os_version", os_version);
                    safariCapability.AddAdditionalCapability("browser", browser);
                    safariCapability.AddAdditionalCapability("browser_version", browser_version);
                    safariCapability.AddAdditionalCapability("os", os);
                    safariCapability.AddAdditionalCapability("device", device);
                    safariCapability.AddAdditionalCapability("realMobile", realmobile);
                    safariCapability.AddAdditionalCapability("name", test_name); // test name
                    safariCapability.AddAdditionalCapability("build", build_name); // Your tests will be organized within this build
                    safariCapability.AddAdditionalCapability("browserstack.source", "csharp:sample-selenium-3:v1.0");
                    safariCapability.AddAdditionalCapability("browserstack.user", BROWSERSTACK_USERNAME);
                    safariCapability.AddAdditionalCapability("browserstack.key", BROWSERSTACK_ACCESS_KEY);
                    executetestwithcaps(safariCapability);
                    break;
                case "Chrome": //If browser is Chrome, following capabilities will be passed to 'executetestwithcaps' function
                    OpenQA.Selenium.Chrome.ChromeOptions chromeCapability = new OpenQA.Selenium.Chrome.ChromeOptions();
                    chromeCapability.AddAdditionalCapability("os_version", os_version, true);
                    chromeCapability.AddAdditionalCapability("browser", browser, true);
                    chromeCapability.AddAdditionalCapability("browser_version", browser_version, true);
                    chromeCapability.AddAdditionalCapability("os", os, true);
                    chromeCapability.AddAdditionalCapability("device", device, true);
                    chromeCapability.AddAdditionalCapability("realMobile", realmobile, true);
                    chromeCapability.AddAdditionalCapability("name", test_name, true);
                    chromeCapability.AddAdditionalCapability("build", build_name, true);
                    chromeCapability.AddAdditionalCapability("browserstack.source", "csharp:sample-selenium-3:v1.0");
                    chromeCapability.AddAdditionalCapability("browserstack.user", BROWSERSTACK_USERNAME, true);
                    chromeCapability.AddAdditionalCapability("browserstack.key", BROWSERSTACK_ACCESS_KEY, true);
                    executetestwithcaps(chromeCapability);
                    break;
                case "Firefox": //If browser is Firefox, following capabilities will be passed to 'executetestwithcaps' function
                    OpenQA.Selenium.Firefox.FirefoxOptions firefoxCapability = new OpenQA.Selenium.Firefox.FirefoxOptions();
                    firefoxCapability.AddAdditionalCapability("os_version", os_version, true);
                    firefoxCapability.AddAdditionalCapability("browser", browser, true);
                    firefoxCapability.AddAdditionalCapability("browser_version", browser_version, true);
                    firefoxCapability.AddAdditionalCapability("os", os, true);
                    firefoxCapability.AddAdditionalCapability("name", test_name, true);
                    firefoxCapability.AddAdditionalCapability("build", build_name, true);
                    firefoxCapability.AddAdditionalCapability("browserstack.source", "csharp:sample-selenium-3:v1.0");
                    firefoxCapability.AddAdditionalCapability("browserstack.user", BROWSERSTACK_USERNAME, true);
                    firefoxCapability.AddAdditionalCapability("browserstack.key", BROWSERSTACK_ACCESS_KEY, true);
                    executetestwithcaps(firefoxCapability);
                    break;
                case "Edge": //If browser is Edge, following capabilities will be passed to 'executetestwithcaps' function
                    OpenQA.Selenium.Edge.EdgeOptions edgecapability = new OpenQA.Selenium.Edge.EdgeOptions();
                    edgecapability.AddAdditionalCapability("os_version", os_version);
                    edgecapability.AddAdditionalCapability("browser", browser);
                    edgecapability.AddAdditionalCapability("browser_version", browser_version);
                    edgecapability.AddAdditionalCapability("os", os);
                    edgecapability.AddAdditionalCapability("name", test_name);
                    edgecapability.AddAdditionalCapability("build", build_name);
                    edgecapability.AddAdditionalCapability("browserstack.source", "csharp:sample-selenium-3:v1.0");
                    edgecapability.AddAdditionalCapability("browserstack.user", BROWSERSTACK_USERNAME);
                    edgecapability.AddAdditionalCapability("browserstack.key", BROWSERSTACK_ACCESS_KEY);
                    executetestwithcaps(edgecapability);
                    break;
                default: //If browser is IE, following capabilities will be passed to 'executetestwithcaps' function
                    OpenQA.Selenium.IE.InternetExplorerOptions ieCapability = new OpenQA.Selenium.IE.InternetExplorerOptions();
                    ieCapability.AddAdditionalCapability("os_version", os_version, true);
                    ieCapability.AddAdditionalCapability("browser", browser, true);
                    ieCapability.AddAdditionalCapability("browser_version", browser_version, true);
                    ieCapability.AddAdditionalCapability("os", os, true);
                    ieCapability.AddAdditionalCapability("name", test_name, true);
                    ieCapability.AddAdditionalCapability("build", build_name, true);
                    ieCapability.AddAdditionalCapability("browserstack.source", "csharp:sample-selenium-3:v1.0");
                    ieCapability.AddAdditionalCapability("browserstack.user", BROWSERSTACK_USERNAME, true);
                    ieCapability.AddAdditionalCapability("browserstack.key", BROWSERSTACK_ACCESS_KEY, true);
                    executetestwithcaps(ieCapability);
                    break;
            }
        }
        //executetestwithcaps function takes capabilities from 'sampleTestCase' function and executes the test
        static void executetestwithcaps(DriverOptions capability)
        {
            IWebDriver driver = new RemoteWebDriver(new Uri("https://hub-cloud.browserstack.com/wd/hub/"), capability);
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.Navigate().GoToUrl("https://bstackdemo.com/");
                // getting name of the product
                String product_on_page = wait.Until(driver => driver.FindElement(By.XPath("//*[@id=\"1\"]/p"))).Text;
                // clicking the 'Add to Cart' button
                IWebElement cart_btn = driver.FindElement(By.XPath("//*[@id='1']/div[4]"));
                wait.Until(driver => cart_btn.Displayed);
                cart_btn.Click();
                // waiting for the Cart pane to appear
                wait.Until(driver => driver.FindElement(By.ClassName("float-cart__content")).Displayed);
                // getting name of the product in the cart
                String product_in_cart = driver.FindElement(By.XPath("//*[@id='__next']/div/div/div[2]/div[2]/div[2]/div/div[3]/p[1]")).Text;
                if (product_on_page == product_in_cart)
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" Product has been successfully added to the cart!\"}}");
                }
            }
            catch
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" Some elements failed to load.\"}}");
            }
            driver.Quit();
        }
    }
}
