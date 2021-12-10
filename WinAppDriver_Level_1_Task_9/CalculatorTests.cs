/*
 * Refactor all existing tests to use page objects
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using WinAppDriver_Level_1_Task_9.Pages;

namespace WinAppDriver_Level_1_Task_9
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
            StandartPage standartPage = new StandartPage(_driver);
            TemperaturePage temperaturePage = new TemperaturePage(_driver);

            standartPage.ClearButton?.Click();

            standartPage.TogglePaneButton.Click();
            standartPage.TemperatureButton.Click();

            temperaturePage.FirstUnitDropdown.Click();
            temperaturePage.CelsiusButton.Click();
            temperaturePage.SecondUnitDropdown.Click();
            temperaturePage.FarenheitButton.Click();

            standartPage.ThreeButton.Click();
            standartPage.ZeroButton.Click();

            Assert.AreEqual("86", temperaturePage.GetResultText());
        }

        [TestMethod]
        public void ConvertSqareCentimetersToSquareFeet()
        {
            StandartPage standartPage = new StandartPage(_driver);
            AreaPage areaPage = new AreaPage(_driver);


            standartPage.ClearButton?.Click();

            standartPage.TogglePaneButton.Click();
            standartPage.AreaButton.Click();

            areaPage.FirstUnitsDropdown.Click();
            areaPage.SquareCentimetersButton.Click();
            areaPage.SecondUnitsDropdown.Click();
            areaPage.SquareFeetButton.Click();

            standartPage.OneButton.Click();
            standartPage.ZeroButton.Click();
            standartPage.ZeroButton.Click();

            Assert.AreEqual("0,107639", areaPage.GetResultText());
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
            StandartPage standartPage = new StandartPage(_driver);
            ScientificPage scientificPage = new ScientificPage(_driver);
            standartPage.ClearButton2?.Click();

            standartPage.TogglePaneButton.Click();
            standartPage.ScientificButton.Click();

            scientificPage.PiButton.Click();
            scientificPage.PlusButton.Click();
            standartPage.PickNumericValue(n);
            scientificPage.LogButton.Click();
            scientificPage.MinusButton.Click();
            standartPage.PickNumericValue(x);
            scientificPage.PowerButton.Click();
            standartPage.PickNumericValue(y);
            scientificPage.EqualButton.Click();

            double result = double.Parse(scientificPage.GetResultText());
            Assert.AreEqual(z, result);

            scientificPage.DegreeButton.Click();

            scientificPage.TrigonometryDropdown.Click();
            scientificPage.SinButton.Click();

            double new_result = double.Parse(scientificPage.GetResultText());
            Assert.AreEqual(Math.Sin(z), new_result);
        }
    }
}
