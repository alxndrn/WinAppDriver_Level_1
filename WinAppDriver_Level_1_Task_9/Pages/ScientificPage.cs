using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;

namespace WinAppDriver_Level_1_Task_9.Pages
{
    public class ScientificPage : BasePage
    {
        public ScientificPage(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }
        public WindowsElement PiButton => _driver.FindElementByAccessibilityId("piButton");
        public WindowsElement PlusButton => _driver.FindElementByAccessibilityId("plusButton");
        public WindowsElement LogButton => _driver.FindElementByName("Log");
        public WindowsElement MinusButton => _driver.FindElementByName("Minus");
        public WindowsElement PowerButton => _driver.FindElementByAccessibilityId("powerButton");
        public WindowsElement EqualButton => _driver.FindElementByAccessibilityId("equalButton");
        public WindowsElement DegreeButton => _driver.FindElementByAccessibilityId("degButton");
        public WindowsElement TrigonometryDropdown => _driver.FindElementByName("Trigonometry");
        public WindowsElement SinButton => _driver.FindElementByName("Sine");
        public string GetResultText()
        {
            WindowsElement results = _driver.FindElementByAccessibilityId("CalculatorResults");
            Assert.IsNotNull(results);

            return results.Text
                .Replace("Display is", string.Empty)
                .Trim();
        }
    }
}
