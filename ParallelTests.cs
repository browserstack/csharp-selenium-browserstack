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
            Thread device1 = new Thread(obj => sampleTestCase("Safari", "latest", null, "14", "iPhone 12 Pro Max", "true", "iPhone 12 Pro Max - safari latest", "Parallel-build-csharp"));
            Thread device2 = new Thread(obj => sampleTestCase("Chrome", "latest", null, null, "Samsung Galaxy S20", "true", "Samsung Galaxy S20 - Chrome latest", "Parallel-build-csharp"));
            Thread device3 = new Thread(obj => sampleTestCase("Firefox", "latest", "OSX", "Monterey", null, null, "macOS Monterey - Firefox latest", "Parallel-build-csharp"));
            Thread device4 = new Thread(obj => sampleTestCase("Safari", "latest", "OSX", "Big Sur", null, null, "macOS Big Sur - Safari latest", "Parallel-build-csharp"));
            Thread device5 = new Thread(obj => sampleTestCase("Edge", "latest", "Windows", "10", null, null, "Windows - Edge latest", "Parallel-build-csharp"));

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
            String BROWSERSTACK_USERNAME = "BROWSERSTACK_USERNAME";
            String BROWSERSTACK_ACCESS_KEY = "BROWSERSTACK_ACCESS_KEY";
            switch (browser)
            {
                case "Safari": //If browser is Safari, following capabilities will be passed to 'executetestwithcaps' function
                    SafariOptions capabilities = new SafariOptions();
                    Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
                    browserstackOptions.Add("osVersion", "14");
                    browserstackOptions.Add("deviceName", "iPhone 12");
                    browserstackOptions.Add("realMobile", "true");
                    browserstackOptions.Add("local", "false");
                    browserstackOptions.Add("userName", BROWSERSTACK_USERNAME);
                    browserstackOptions.Add("accessKey", BROWSERSTACK_ACCESS_KEY);
                    capabilities.AddAdditionalOption("bstack:options", browserstackOptions);
                    executetestwithcaps(capabilities);
                    break;
                case "Chrome": //If browser is Chrome, following capabilities will be passed to 'executetestwithcaps' function
                    ChromeOptions capabilities = new ChromeOptions();
                    capabilities.BrowserVersion = "99.0";
                    Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
                    browserstackOptions.Add("os", "Windows");
                    browserstackOptions.Add("osVersion", "10");
                    browserstackOptions.Add("local", "false");
                    browserstackOptions.Add("seleniumVersion", "3.14.0");
                    browserstackOptions.Add("userName", BROWSERSTACK_USERNAME);
                    browserstackOptions.Add("accessKey", BROWSERSTACK_ACCESS_KEY);
                    capabilities.AddAdditionalOption("bstack:options", browserstackOptions);
                    executetestwithcaps(capabilities);
                    break;
                case "Firefox": //If browser is Firefox, following capabilities will be passed to 'executetestwithcaps' function
                    FirefoxOptions capabilities = new FirefoxOptions();
                    capabilities.BrowserVersion = "98.0";
                    Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
                    browserstackOptions.Add("os", "Windows");
                    browserstackOptions.Add("osVersion", "10");
                    browserstackOptions.Add("local", "false");
                    browserstackOptions.Add("seleniumVersion", "3.10.0");
                    browserstackOptions.Add("userName", BROWSERSTACK_USERNAME);
                    browserstackOptions.Add("accessKey", BROWSERSTACK_ACCESS_KEY);
                    capabilities.AddAdditionalOption("bstack:options", browserstackOptions);
                    executetestwithcaps(capabilities);
                    break;
                case "Edge": //If browser is Edge, following capabilities will be passed to 'executetestwithcaps' function
                    EdgeOptions capabilities = new EdgeOptions();
                    capabilities.BrowserVersion = "latest";
                    Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
                    browserstackOptions.Add("os", "Windows");
                    browserstackOptions.Add("osVersion", "10");
                    browserstackOptions.Add("local", "false");
                    browserstackOptions.Add("seleniumVersion", "3.5.2");
                    browserstackOptions.Add("userName", BROWSERSTACK_USERNAME);
                    browserstackOptions.Add("accessKey", BROWSERSTACK_ACCESS_KEY);
                    capabilities.AddAdditionalOption("bstack:options", browserstackOptions);
                    executetestwithcaps(capabilities);
                    break;
                default: //If browser is IE, following capabilities will be passed to 'executetestwithcaps' function
                    ChromeOptions capabilities = new ChromeOptions();
                    capabilities.BrowserVersion = "99.0";
                    Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
                    browserstackOptions.Add("os", "Windows");
                    browserstackOptions.Add("osVersion", "10");
                    browserstackOptions.Add("local", "false");
                    browserstackOptions.Add("seleniumVersion", "3.14.0");
                    browserstackOptions.Add("userName", BROWSERSTACK_USERNAME);
                    browserstackOptions.Add("accessKey", BROWSERSTACK_ACCESS_KEY);
                    capabilities.AddAdditionalOption("bstack:options", browserstackOptions);
                    executetestwithcaps(capabilities);
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
                IWebElement product = driver.FindElement(By.XPath("//*[@id='1']/p"));
                wait.Until(driver => product.Displayed);
                String product_on_page = product.Text;
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
