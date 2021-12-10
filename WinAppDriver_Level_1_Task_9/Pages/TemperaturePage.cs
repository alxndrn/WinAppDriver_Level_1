using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;

namespace WinAppDriver_Level_1_Task_9.Pages
{
    public class TemperaturePage : BasePage
    {
        public TemperaturePage(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }
        public WindowsElement FirstUnitDropdown => _driver.FindElementByAccessibilityId("Units1");
        public WindowsElement SecondUnitDropdown => _driver.FindElementByAccessibilityId("Units2");
        public WindowsElement CelsiusButton => _driver.FindElementByName("Celsius");
        public WindowsElement FarenheitButton => _driver.FindElementByName("Fahrenheit");

        public string GetResultText()
        {
            WindowsElement results = _driver.FindElementByAccessibilityId("Value2");
            Assert.IsNotNull(results);
            
            return results.Text
                .Replace("Converts into ", string.Empty)
                .Replace("Fahrenheit", string.Empty)
                .Trim();
        }
    }
}
