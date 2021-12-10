using OpenQA.Selenium.Appium.Windows;
using System;

namespace WinAppDriver_Level_1_Task_9.Pages
{
    public class BasePage
    {
        protected WindowsDriver<WindowsElement> _driver;
        public BasePage(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver ?? throw new ArgumentNullException("Driver cannot be null.");
        }
    }
}
