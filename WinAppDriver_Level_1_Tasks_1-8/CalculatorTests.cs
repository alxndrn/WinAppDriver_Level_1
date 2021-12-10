/*
 * 1. Install Windows SDK and start inspect.exe
 * 2. Create a new desktop NUnit test projects and install all required
 * NuGet packages
 * 3. Create a new test starting and closing Windows Calculator app
 * 4. Create a new test converting given Celsius and asserting that the valid
 * Fahrenheit is calculated
 * 5. Create a new test converting square centimeters and asserting that
 * valid square feets are calculated
 * 6. Extend the above test to check whether about equal to measure are
 * right
 * 7. Create a new test changing the calculator to Scientific mode. Create a
 * data-driven test to calculate the following formula: Pi + log (n) - x ^ y
 * Use the following data:
 * N = 45, x = 5, y = 2
 * N = 6, x = 2, y = 6
 * N = 77, x = 9.12, y = 1.6
 * Verify that the correct results are displayed.
 * 8. Create tests for calculating sin and tan for the above answers
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;

namespace WinAppDriver_Level_1_Tasks_1_8
{
    [TestClass]
    public class CalculatorTests
    {
        private WindowsDriver<WindowsElement> _driver;
        [TestInitialize]
        public void TestInit()
        {
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            _driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver?.Quit();
        }

        [TestMethod]
        public void StartingAndClosingWindowsCalculatorApp()
        {
        }

        [TestMethod]
        public void ConvertCelsiusToFarenheit()
        {
            var clear = _driver.FindElementByName("Clear entry");
            clear?.Click();

            _driver.FindElementByAccessibilityId("TogglePaneButton").Click();
            _driver.FindElementByAccessibilityId("Temperature").Click();

            _driver.FindElementByAccessibilityId("Units1").Click();
            _driver.FindElementByName("Celsius").Click();
            _driver.FindElementByAccessibilityId("Units2").Click();
            _driver.FindElementByName("Fahrenheit").Click();

            _driver.FindElementByName("Three").Click();
            _driver.FindElementByName("Zero").Click();

            var results = _driver.FindElementByAccessibilityId("Value2");
            Assert.IsNotNull(results);
            Debug.WriteLine(results.Text);

            Assert.AreEqual("86", results.Text.Replace("Converts into ", string.Empty).Replace("Fahrenheit", string.Empty).Trim());
        }

        [TestMethod]
        public void ConvertSqareCentimetersToSquareFeet()
        {
            var clear = _driver.FindElementByName("Clear entry");
            clear?.Click();

            _driver.FindElementByAccessibilityId("TogglePaneButton").Click();
            _driver.FindElementByAccessibilityId("Area").Click();

            _driver.FindElementByAccessibilityId("Units1").Click();
            _driver.FindElementByName("Square centimeters").Click();
            _driver.FindElementByAccessibilityId("Units2").Click();
            _driver.FindElementByName("Square feet").Click();

            _driver.FindElementByName("One").Click();
            _driver.FindElementByName("Zero").Click();
            _driver.FindElementByName("Zero").Click();

            var results = _driver.FindElementByAccessibilityId("Value2");
            Assert.IsNotNull(results);
            Debug.WriteLine(results.Text);

            Assert.AreEqual("0,107639", results.Text.Replace("Converts into ", string.Empty).Replace("Square feet", string.Empty).Trim());
        }

        [DataTestMethod]
        [DataRow("45", "5", "2", -20.205194832634863082161039704935)]
        [DataRow("6", "2", "6", -60.080256096026563129028589818741)]
        [DataRow("77", "9.12", "1.6", -29.327058097306654607599619686994)]
        public void ScientificCalculatorTests(string n, string x, string y, double z)
        {
            //data - driven test to calculate the following formula: Pi + log(n) - x ^ y
            //Use the following data:
            //N = 45, x = 5, y = 2
            //N = 6, x = 2, y = 6
            //N = 77, x = 9.12, y = 1.6
            var clear = _driver.FindElementByName("Clear");
            clear?.Click();

            _driver.FindElementByAccessibilityId("TogglePaneButton").Click();
            _driver.FindElementByAccessibilityId("Scientific").Click();

            _driver.FindElementByAccessibilityId("piButton").Click();
            _driver.FindElementByAccessibilityId("plusButton").Click();
            PickNumericValue(n);
            _driver.FindElementByName("Log").Click();
            _driver.FindElementByName("Minus").Click();
            PickNumericValue(x);
            _driver.FindElementByAccessibilityId("powerButton").Click();
            PickNumericValue(y);
            _driver.FindElementByAccessibilityId("equalButton").Click();

            WindowsElement _calculatorResult = _driver.FindElementByAccessibilityId("CalculatorResults");
            Assert.IsNotNull(_calculatorResult);

            double result = double.Parse(_calculatorResult.Text.Replace("Display is", string.Empty).Trim());
            Assert.AreEqual(z, result);

            _driver.FindElementByAccessibilityId("degButton").Click();

            _driver.FindElementByName("Trigonometry").Click();
            _driver.FindElementByName("Sine").Click();

            double new_result = double.Parse(_calculatorResult.Text.Replace("Display is", string.Empty).Trim());
            Assert.AreEqual(Math.Sin(z), new_result);
        }

        private void PickNumericValue(string numberCharacter)
        {
            //assume "valid" input, it 77 or 9.12
            foreach (char item in numberCharacter)
            {
                if (char.IsDigit(item))
                {
                    switch (item)
                    {
                        case '0':
                            _driver.FindElementByName("Zero").Click();
                            break;
                        case '1':
                            _driver.FindElementByName("One").Click();
                            break;
                        case '2':
                            _driver.FindElementByName("Two").Click();
                            break;
                        case '3':
                            _driver.FindElementByName("Three").Click();
                            break;
                        case '4':
                            _driver.FindElementByName("Four").Click();
                            break;
                        case '5':
                            _driver.FindElementByName("Five").Click();
                            break;
                        case '6':
                            _driver.FindElementByName("Six").Click();
                            break;
                        case '7':
                            _driver.FindElementByName("Seven").Click();
                            break;
                        case '8':
                            _driver.FindElementByName("Eight").Click();
                            break;
                        case '9':
                            _driver.FindElementByName("Nine").Click();
                            break;
                        default:
                            break;
                    }
                }
                if (char.IsPunctuation(item))   //ie .
                {
                    _driver.FindElementByAccessibilityId("decimalSeparatorButton").Click();
                }
            }
        }
    }
}
