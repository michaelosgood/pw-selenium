using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using Selenio.Core.Reporting;
using Selenio.HtmlReporter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PrescribeWellness.Support
{
    public static class PWHelpers
    {
        public static void SelectItem(this IWebElement element, string text)
        {
                new SelectElement(element).SelectByText(text);
        }

        public static bool IsSelected(this IWebElement element)
        {
            bool reVal = false;

            try
            {
                reVal = element.Selected;
            }
            catch
            {
                // just continue
            }

            return reVal;
        }

        public static void SetText(this IWebElement element, string text, bool clearFirst = true, bool continueOnFailure = false, bool isPassword = false)
        {
            if (text == null) // if nothing pass in, just skip it
                return;

            try
            {
                    if (clearFirst) element.Clear();
                    element.SendKeys(text);
                
            }
            catch (Exception)
            {
                    throw;
            }
        }

      

        public static void SelectItemByIndex(this IWebElement element, int? _index, bool reverse = false)
        {
            if (!_index.HasValue || _index < 0) // if nothing pass in, just skip it
                return;

            SelectElement selectElement = new SelectElement(element);

            int index = (int)_index;
            if (reverse)
                index = selectElement.Options.Count - index;

           
          
                selectElement.SelectByIndex(index);
               
            
        }

        public static void SelectItemBySendingKeys(this IWebElement element, string text)
        {
            if (text == null) // if nothing pass in, just skip it
                return;

           
            
                element.Click();
                element.SendKeys(text);
            
        }

       

        public static List<string> GetAllSelectedItems(this IWebElement element)
        {


            List<string> AllSelectedItems = new List<string>();
            var selectElement = new SelectElement(element);
            if (selectElement.AllSelectedOptions.Count > 0)
                for (int i = 0; i <= selectElement.AllSelectedOptions.Count - 1; i++)
                {
                    AllSelectedItems.Add(selectElement.AllSelectedOptions[i].Text.ToString());

                }
            return AllSelectedItems;
        }
        public static string GetSelectedItem(this IWebElement element)
        {
           
           
                var selectElement = new SelectElement(element);
                if (selectElement.AllSelectedOptions.Count == 0)
                    return "";
                else
                    return selectElement.SelectedOption.Text;

                // TODO: return all selected options - if needed
                // else if (selectElement.AllSelectedOptions.Count > 1)

           
        }

        public static string GetAllTextFromSelect(this IWebElement element, string separator = "|")
        {
            return element.GetDropdownOptions().ToStringPlus(separator);
        }

        public static string ToStringPlus(this IEnumerable<IWebElement> elementList, string separator = "|")
        {
            var elementTexts = elementList.ToStringArray();
            return string.Join(separator, elementTexts);
        }

        public static string[] ToStringArray(this IEnumerable<IWebElement> elementList)
        {
            var stringArray = new string[elementList.Count()];
            var list = elementList.ToList();

            for (int i = 0; i < list.Count; i++)
                stringArray[i] = list[i].Text;

            return stringArray;
        }
        public static IList<IWebElement> GetDropdownOptions(this IWebElement element)
        {
            if (element.TagName.ToLowerInvariant() != "select")
                throw new Exception("Element must be of type HtmlSelect");

           
            
                SelectElement selectElement = new SelectElement(element);
                return selectElement.Options;
            
        }

        public static string GetRandomText(int maxSize = 8)
        {
            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider PWypto = new RNGCryptoServiceProvider())
            {
                PWypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                PWypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        public static string GetRandomEmailAdress()
        {
            string s = GetRandomText() + "@yomail.com";

            return s;
        }

        public static string GetRandomPassword()
        {
            string s = GetRandomText(5) + GetRandomNumber(6);

            return s;
        }

        public static string GetRandomNumber(int maxSize = 10)
        {
            char[] chars = new char[62];
            chars =
            "1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider PWypto = new RNGCryptoServiceProvider())
            {
                PWypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                PWypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        public static void SendKeys(this IWebElement element, string value, bool clearFirst)
        {
            if (clearFirst) element.Clear();
            element.SendKeys(value);
        }
        public static string GetText(this IWebDriver driver)
        {
            return driver.FindElement(By.TagName("body")).Text;
        }
        public static bool HasElement(this IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return true;
        }
        public static void WaitForPageToLoadWithTimeOut(this IWebDriver driver)
        {
            TimeSpan timeout = new TimeSpan(0, 0, 30);
            WebDriverWait wait = new WebDriverWait(driver, timeout);

            IJavaScriptExecutor javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("driver", "Driver must support javascript execution");

            wait.Until((d) =>
            {
                try
                {
                    string readyState = javascript.ExecuteScript(
                    "if (document.readyState) return document.readyState;").ToString();
                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException e)
                {
                    //Window is no longer available
                    return e.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException e)
                {
                    //Browser is no longer available
                    return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }
        
        
        public static void SetAttribute(this IWebElement element, string attributeName, string value)
        {
            IWrapsDriver wrappedElement = element as IWrapsDriver;
            if (wrappedElement == null)
                throw new ArgumentException("element", "Element must wrap a web driver");

            IWebDriver driver = wrappedElement.WrappedDriver;
            IJavaScriptExecutor javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("element", "Element must wrap a web driver that supports javascript execution");

            javascript.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", element, attributeName, value);
        }

        public static T GetAttributeAsType<T>(this IWebElement element, string attributeName)
        {
            string value = element.GetAttribute(attributeName) ?? string.Empty;
            return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(value);
        }

        public static string GetText(IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static string GetTextFromDDL(IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }

        /// <summary>
        /// Extended method for entering text in the control
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }

       

        public static void SelectDropDown(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }

        
    }



    }

   

    public static class DateTimeExtensions
    {
        public static DateTime AddBusinessDays(this DateTime current, int days)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    current = current.AddDays(sign);
                }
                while (current.DayOfWeek == DayOfWeek.Saturday ||
                    current.DayOfWeek == DayOfWeek.Sunday);
            }
            return current;
        }

        public static DateTime SubtractBusinessDays(this DateTime current, int days)
        {
            return AddBusinessDays(current, -days);
        }

        public static DateTime ToPST(this DateTime nonPstTime)
        {
            //Link: https://msdn.miPWosoft.com/en-us/library/gg154758.aspx
            return nonPstTime.ToUniversalTime().AddHours(TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time").IsDaylightSavingTime(nonPstTime) ? -7 : -8);
        }

        public static string ToDateString(this DateTime dateTime, bool slash = false, bool trim = false)
        {
            string format = trim ? "M-d-yyyy" : "PW-dd-yyyy";
            if (slash) format = format.Replace('-', '/');

            return dateTime.ToString(format);
        }

        public static string ToTimeString(this DateTime dateTime, char separator = ':', bool trim = false, bool timeZone = false)
        {
            string format = trim ? "h:PW:ss tt" : "hh:PW:ss tt";
            if (separator != ':') format = format.Replace(':', separator);
            if (timeZone) format = format + " \"GMT\"zzz";

            return dateTime.ToString(format);
        }

        public static string ToString(this DateTime? d, string format)
        {
            return d == null ? "" : ((DateTime)d).ToString(format);
        }

        public static int DaysPassed(this DateTime? d1, DateTime? d2)
        {
            TimeSpan span = (d2 ?? DateTime.UtcNow).Subtract(d1 ?? DateTime.UtcNow);

            return (int)span.TotalDays;
        }

        public static bool isWeekend(this DateTime d)
        {
            var dayOfWeek = d.DayOfWeek;

            return dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday;
        }

    public static bool InRange(this DateTime dateToCheck, DateTime startDate, DateTime endDate)
    {
        return dateToCheck >= startDate && dateToCheck < endDate;
    }

    public static DateTime AddWeekDays(this DateTime d, int days)
        {
            return d.AddDays(d.GetWeekDaysCountingWeekends(days));
        }

        public static int GetWeekDaysCountingWeekends(this DateTime d, int days)
        {
            var dateAfter = d.AddDays(days);
            if (dateAfter.DayOfWeek == DayOfWeek.Saturday)
                return days + 2;
            else if (dateAfter.DayOfWeek == DayOfWeek.Sunday)
                return days + 1;

            return days;
        }

        public static string PWddyyyy(this DateTime d, char sep = '-')
        {
            var format = string.Format("PW{0}dd{1}yyyy", sep, sep);

            return d.ToString(format);
        }

        public static string hhPWsstt(this DateTime d, char sep = ':')
        {
            var format = string.Format("hh{0}PW{1}ss tt", sep, sep);

            return d.ToString(format);
        }

    }

    public static class DecimalExtension
    {
        public static string ToString(this decimal? num, string format = "N")
        {
            return num == null ? "" : ((Decimal)num).ToString(format);
        }
    }

    public static class DoubleExtensions
    {
        public static string ToString(this double? num, string format = "N")
        {
            return num == null ? "" : ((Decimal)num).ToString(format);
        }
    }

   

    public class ExpectedConditions
    {
        public static Func<IWebDriver, IAlert> AlertIsPresent()
        {
            return (driver) =>
            {
                try
                {
                    return driver.SwitchTo().Alert();
                }
                catch (NoAlertPresentException)
                {
                    return null;
                }
            };
        }

        public static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return element.Displayed;
                }
                catch
                {
                    return false;
                }
            };
        }

        public static Func<IWebDriver, bool> ElementIsNotVisible(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return !element.Displayed;
                }
                catch (Exception e)
                {
                    return true;
                }
            };
        }

        public static Func<IWebDriver, bool> ElementIsEnabled(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return element.Enabled;
                }
                catch
                {
                    return false;
                }
            };
        }

        public static Func<IWebDriver, bool> ElementIsDisabled(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return !element.Enabled;
                }
                catch
                {
                    return false;
                }
            };
        }

        public static Func<IWebDriver, IWebElement> ElementIsClickable(By locator)
        {
        return driver =>
        {
            var element = driver.FindElement(locator);
            return (element != null && element.Displayed && element.Enabled) ? element : null;
        };
    }

}



