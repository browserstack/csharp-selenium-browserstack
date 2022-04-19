using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
namespace csharp_selenium_browserstack
{
    class SingleTest
    {
        public static void execute()
        {
            IWebDriver driver;
            OpenQA.Selenium.Safari.SafariOptions capability = new OpenQA.Selenium.Safari.SafariOptions();
            capability.AddAdditionalCapability("browser", "iPhone");
            capability.AddAdditionalCapability("device", "iPhone 11");
            capability.AddAdditionalCapability("realMobile", "true");
            capability.AddAdditionalCapability("os_version", "14.0");
            capability.AddAdditionalCapability("name", "BStack-[C_sharp] Sample Test"); // test name
            capability.AddAdditionalCapability("build", "BStack Build Number 1"); // CI/CD job or build name
            capability.AddAdditionalCapability("browserstack.user", "Username");
            capability.AddAdditionalCapability("browserstack.key", "AccessKey");
            driver = new RemoteWebDriver(new Uri("https://hub-cloud.browserstack.com/wd/hub/"), capability);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
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