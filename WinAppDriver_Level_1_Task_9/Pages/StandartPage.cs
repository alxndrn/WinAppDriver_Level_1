using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;

namespace WinAppDriver_Level_1_Task_9.Pages
{
    public class StandartPage : BasePage
    {
        public StandartPage(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }
        public WindowsElement ClearButton => _driver.FindElementByName("Clear entry");
        public WindowsElement ClearButton2 => _driver.FindElementByName("Clear");
        public WindowsElement TogglePaneButton => _driver.FindElementByAccessibilityId("TogglePaneButton");
        public WindowsElement TemperatureButton => _driver.FindElementByAccessibilityId("Temperature");
        public WindowsElement AreaButton => _driver.FindElementByAccessibilityId("Area");
        public WindowsElement ScientificButton => _driver.FindElementByAccessibilityId("Scientific");
        public WindowsElement OneButton => _driver.FindElementByName("One");
        public WindowsElement ThreeButton => _driver.FindElementByName("Three");
        public WindowsElement ZeroButton => _driver.FindElementByName("Zero");

        public string GetResultText()
        {
            var results = _driver.FindElementByAccessibilityId("CalculatorResults");
            Assert.IsNotNull(results);

            return results.Text
                .Replace("Display is", string.Empty)
                .Trim();
        }

        public void PickNumericValue(string numberCharacter)
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
