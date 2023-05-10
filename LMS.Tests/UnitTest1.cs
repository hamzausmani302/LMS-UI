namespace LMS.Tests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

public class SuiteTests : IDisposable
{
    public IWebDriver driver { get; private set; }
    public IDictionary<String, Object> vars { get; private set; }
    public IJavaScriptExecutor js { get; private set; }
    public SuiteTests()
    {
       
        driver = new ChromeDriver();
        
        js = (IJavaScriptExecutor)driver;
        vars = new Dictionary<String, Object>();
    }
    public void Dispose()
    {
        driver.Quit();
    }
    [Fact]
    public void Lmsfrontend()
    {
        driver.Navigate().GoToUrl("https://lms-frontend-devops.azurewebsites.net");
        driver.Manage().Window.Size = new System.Drawing.Size(968, 1032);
        Assert.Equal(driver.FindElement(By.LinkText("Learning Management System")).Text, "Learning Management System");
        Assert.Equal(driver.FindElement(By.CssSelector("h1")).Text, "FAST NUCES");
        driver.FindElement(By.LinkText("Login as User")).Click();
        Assert.Equal(driver.FindElement(By.LinkText("Learning Management System")).Text, "Learning Management System");
        driver.FindElement(By.Id("form3Example3")).SendKeys("fast");
        driver.FindElement(By.Id("form3Example4")).Click();
        driver.FindElement(By.Id("form3Example4")).SendKeys("test");
        driver.FindElement(By.CssSelector(".w-50")).Click();
        Assert.Equal(driver.FindElement(By.CssSelector(".alert")).Text, "Incorrect username or Password");
    }
}