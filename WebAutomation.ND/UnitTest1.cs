using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace WebAutomation.ND
{
    public class Tests
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com/index.html");
            var Link = driver.FindElement(By.Id("signin2"));
            Assert.That(Link, Is.Not.Null);
            Link.Click();

            var username = driver.FindElement(By.Id("sign-username"));
            username.SendKeys("Testas74");

            var password = driver.FindElement(By.Id("sign-password"));
            password.SendKeys("Testas74");

            var SignUp = driver.FindElement(By.XPath("(//button[@class='btn btn-primary'])[2]"));
            Assert.That(SignUp, Is.Not.Null);
            SignUp.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IAlert SignUpAlert = wait.Until(ExpectedConditions.AlertIsPresent());
            Console.WriteLine(SignUpAlert.Text);
            Assert.That(SignUpAlert.Text, Is.EqualTo("Sign up successful."));
            SignUpAlert.Accept();
        }

        [Test]
        public void Test2()
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com/index.html");
            var Link = driver.FindElement(By.Id("login2"));
            Assert.That(Link, Is.Not.Null);
            Link.Click();

            var username = driver.FindElement(By.Id("loginusername"));
            username.SendKeys("Testas74");

            var password = driver.FindElement(By.Id("loginpassword"));
            password.SendKeys("Testas74");

            var LogIn = driver.FindElement(By.XPath("(//button[@class='btn btn-primary'])[3]"));
            Assert.That(LogIn, Is.Not.Null);
            LogIn.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Welcome Testas74")));

            var confirmation = driver.FindElement(By.Id("nameofuser"));
            Assert.That(confirmation.Text, Is.EqualTo("Welcome Testas74"));
            Console.WriteLine("Login successful");
        }

        [Test]
        public void Test3()
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com/index.html");
            var Laptops = driver.FindElement(By.LinkText("Laptops"));
            Assert.That(Laptops, Is.Not.Null);
            Laptops.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("MacBook air"))).Click();

            var wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait2.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Add to cart"))).Click();

            var wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IAlert AddToCartAlert = wait.Until(ExpectedConditions.AlertIsPresent());
            Console.WriteLine(AddToCartAlert.Text);
            Assert.That(AddToCartAlert.Text.Contains("Product added"));
            AddToCartAlert.Accept();
        }

        [Test]
        public void Test4()
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com/cart.html#");
            var Cart = driver.FindElement(By.LinkText("Cart"));
            Assert.That(Cart, Is.Not.Null);
            Cart.Click();

            var cart = driver.FindElement(By.LinkText("Cart"));
            Assert.That(cart, Is.Not.Null);
            cart.Click();

            var wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait4.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button[class='btn btn-success'"))).Click();

            var Name = driver.FindElement(By.Id("name"));
            Name.SendKeys("Vardenis");

            var Country = driver.FindElement(By.Id("country"));
            Country.SendKeys("Salis");

            var City = driver.FindElement(By.Id("city"));
            City.SendKeys("Miestas");

            var CreditCard = driver.FindElement(By.Id("card"));
            CreditCard.SendKeys("1234567");

            var Month = driver.FindElement(By.Id("month"));
            Month.SendKeys("Menuo");

            var Year = driver.FindElement(By.Id("year"));
            Year.SendKeys("Metai");

            var wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait5.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//button[@class='btn btn-primary'])[3]"))).Click();

            var wait6 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait6.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h2[text()='Thank you for your purchase!']")));

            var OrderPlaced = driver.FindElement(By.XPath("//h2[text()='Thank you for your purchase!']"));
            Assert.That(OrderPlaced.Text, Is.EqualTo("Thank you for your purchase!"));
            Console.WriteLine("Order placed");

            var buttonOK = driver.FindElement(By.CssSelector("button[class='confirm btn btn-lg btn-primary'"));
            Assert.That(buttonOK, Is.Not.Null);
            buttonOK.Click();
        }
    }
}