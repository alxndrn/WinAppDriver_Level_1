using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;

namespace WinAppDriver_Level_1_Task_9.Pages
{
    public class AreaPage : BasePage
    {
        public AreaPage(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }
        public WindowsElement FirstUnitsDropdown => _driver.FindElementByAccessibilityId("Units1");
        public WindowsElement SecondUnitsDropdown => _driver.FindElementByAccessibilityId("Units2");
        public WindowsElement SquareCentimetersButton => _driver.FindElementByName("Square centimeters");
        public WindowsElement SquareFeetButton => _driver.FindElementByName("Square feet");
        public string GetResultText()
        {
            WindowsElement results = _driver.FindElementByAccessibilityId("Value2");
            Assert.IsNotNull(results);

            return results.Text
                .Replace("Converts into ", string.Empty)
                .Replace("Square feet", string.Empty)
                .Trim();
        }
    }
}
