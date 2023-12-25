using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using Assert = Xunit.Assert;

public class GoogleSearch : IDisposable
{
    private IWebDriver driver;

    public GoogleSearch()
    {
        driver = new ChromeDriver();
    }

    [Fact]
    public void seleniumSearch()
    {
        driver.Navigate().GoToUrl("https://www.google.com");

        IWebElement searchField = driver.FindElement(By.Name("q"));
        searchField.SendKeys("Selenium");

        searchField.Submit();

        System.Threading.Thread.Sleep(3000);

        Assert.Contains("Selenium", driver.FindElement(By.TagName("body")).Text, StringComparison.Ordinal);

    }

    public void Dispose()
    {
        driver.Quit();
    }
}
