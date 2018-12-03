using PrescribeWellness.Support;
using NUnit.Framework;
using System.Collections.ObjectModel;
using System;
using PrescribeWellness.Driver;

namespace PrescribeWellness.Script
{
    [TestFixture]
    public class Prescribewellness : MasterTestClass
    {

        [Test]
        
        public void ValidatePWBusinessPage()

            
        {
            try
            {
                Reporter.TestDescription = "Validate BusinessPage";

                Reporter.TestStep = "Go to Business Page";
                PWDriver.BusinessPage.Open(AutoConfig.PWBusinessPage);
               
                Reporter.TestStep = "Validate PWLogo is present";
                Assert.AreEqual(true, PWDriver.BusinessPage.PWLogo.Displayed, "PWLogo is not in display.");

                Reporter.TestStep = "Validate PageImage is present";
                Assert.AreEqual(true, PWDriver.BusinessPage.PageImage.Displayed, "PageImage is not in display.");

                Reporter.TestStep = "Validate Solution Tab is present and enabled";
                Assert.AreEqual(true, PWDriver.BusinessPage.SolutionTab.Displayed, "SolutionTab is not in display.");
                Assert.AreEqual(true, PWDriver.BusinessPage.SolutionTab.Enabled, "SolutionTab is not in display.");

                Reporter.TestStep = "Validate Company Tab is present and enabled";
                Assert.AreEqual(true, PWDriver.BusinessPage.CompanyTab.Displayed, "CompanyTab is not in display.");
                Assert.AreEqual(true, PWDriver.BusinessPage.CompanyTab.Enabled, "CompanyTab is not in display.");

                Reporter.TestStep = "Validate Contact Tab is present and enabled";
                Assert.AreEqual(true, PWDriver.BusinessPage.ContactTab.Displayed, "ContactTab is not in display.");
                Assert.AreEqual(true, PWDriver.BusinessPage.ContactTab.Enabled, "ContactTab is not in display.");

                Reporter.TestStep = "Validate Blog Tab is present and enabled";
                Assert.AreEqual(true, PWDriver.BusinessPage.BlogTab.Displayed, "BlogTab is not in display.");
                Assert.AreEqual(true, PWDriver.BusinessPage.BlogTab.Enabled, "BlogTab is not in display.");

                Reporter.TestStep = "Validate SignIn Tab is present and enabled";
                Assert.AreEqual(true, PWDriver.BusinessPage.SignInTab.Displayed, "SignInTab is not in display.");
                Assert.AreEqual(true, PWDriver.BusinessPage.SignInTab.Enabled, "SignInTab is not in display.");

                Reporter.TestStep = "Click SignIn Tab";
                PWDriver.BusinessPage.SignInTab.Click();
                
                

            }

            catch (Exception ex)

            {
                Reporter.StatusUpdate("Test Fail",false);
                               
               
            }
            
             
        }

        [Test]
        public void ValidateContactPage()


        {
            try
            {
                Reporter.TestDescription = "ValidateContactPageUI and performce a valid contact iput";

                Reporter.TestStep = "Go to ContactPage";
                PWDriver.Contact.Open(AutoConfig.PWContactPage);

                #region Verify UI

                Reporter.TestStep = "Validate PWLogo is present";
                Assert.AreEqual(true, PWDriver.BusinessPage.PWLogo.Displayed, "PWLogo is not in display.");

                Reporter.TestStep = "Validate Solution Tab is present and enabled";
                Assert.AreEqual(true, PWDriver.Contact.SolutionTab.Displayed, "SolutionTab is not in display.");
                Assert.AreEqual(true, PWDriver.Contact.SolutionTab.Enabled, "SolutionTab is not in display.");

                Reporter.TestStep = "Validate Company Tab is present and enabled";
                Assert.AreEqual(true, PWDriver.Contact.CompanyTab.Displayed, "CompanyTab is not in display.");
                Assert.AreEqual(true, PWDriver.Contact.CompanyTab.Enabled, "CompanyTab is not in display.");

                Reporter.TestStep = "Validate Contact Tab is present and enabled";
                Assert.AreEqual(true, PWDriver.Contact.ContactTab.Displayed, "ContactTab is not in display.");
                Assert.AreEqual(true, PWDriver.Contact.ContactTab.Enabled, "ContactTab is not in display.");

                Reporter.TestStep = "Validate Blog Tab is present and enabled";
                Assert.AreEqual(true, PWDriver.Contact.BlogTab.Displayed, "BlogTab is not in display.");
                Assert.AreEqual(true, PWDriver.Contact.BlogTab.Enabled, "BlogTab is not in display.");

                Reporter.TestStep = "Validate SignIn Tab is present and enabled";
                Assert.AreEqual(true, PWDriver.Contact.SignInTab.Displayed, "SignInTab is not in display.");
                Assert.AreEqual(true, PWDriver.Contact.SignInTab.Enabled, "SignInTab is not in display.");

                Reporter.TestStep = "Validate ReasonForContactingLabel is present and enabled";
                Assert.AreEqual(true, PWDriver.Contact.ReasonForContactingLabel.Displayed, "ReasonForContactingDropBox is not in display.");

                Reporter.TestStep = "Validate ReasonForContactingDropBox is present and enabled";
                Assert.AreEqual(true, PWDriver.Contact.ReasonForContactingDropBox.Displayed, "ReasonForContactingDropBox is not in display.");
                Assert.AreEqual(true, PWDriver.Contact.ReasonForContactingDropBox.Enabled, "ReasonForContactingDropBox is not in display.");

                Reporter.TestStep = "Validate YourInformationLabel is present and enabled";
                Assert.AreEqual(true, PWDriver.Contact.YourInformationLabel.Displayed, "YourInformationLabel is not in display.");

                Reporter.TestStep = "Validate YourMessageLabel is present and enabled";
                Assert.AreEqual(true, PWDriver.Contact.YourMessageLabel.Displayed, "YourMessageLabel is not in display.");

                Reporter.TestStep = "Validate ReasonForContactingDropBox is present and enabled";
                Assert.AreEqual(true, PWDriver.Contact.MessageTextBox.Displayed, "MessageTextBox is not in display.");
                Assert.AreEqual(true, PWDriver.Contact.MessageTextBox.Enabled, "MessageTextBox is not in display.");

                #endregion

                #region Performace a valid contact input

                Reporter.TestStep = "Select Sale as reason for contacting";
                PWDriver.Contact.ReasonForContactingDropBox.SelectItemBySendingKeys("Sales");
                
                Reporter.TestStep = "Enter a random name into YourNameTextBox ";
                PWDriver.Contact.YourNameTextBox.SendKeys(PWHelpers.GetRandomText(5).ToUpper() + " " + PWHelpers.GetRandomText(6).ToUpper());

                Reporter.TestStep = "Enter a random email into YourNameTextBox ";
                PWDriver.Contact.EmailTextBox.SendKeys(PWHelpers.GetRandomText().ToLower() + "@yomail.com");

                Reporter.TestStep = "Enter a random phone into YourNameTextBox ";
                PWDriver.Contact.PhoneTextBox.SendKeys("123354");

                Reporter.TestStep = "Enter a random pharmacy name into YourNameTextBox ";
                PWDriver.Contact.PharmacyNameTextBox.SendKeys(PWHelpers.GetRandomText(10).ToUpper());

                Reporter.TestStep = "Enter a message into YourNameTextBox ";
                PWDriver.Contact.MessageTextBox.SendKeys("This is QA Testing, do not respone....Test Message follow by a ramdom string: " + PWHelpers.GetRandomText(100).ToLower());

                Reporter.TestStep = "Click Submit Button ";
                PWDriver.Contact.Submit.Click();
                PWDriver.Contact.WaitForScreenToLoad(PWDriver.Contact.ThankYouMessage);

                Reporter.TestStep = "Validate ThankYouMessage Text";
                Assert.AreEqual(true, PWDriver.Contact.ThankYouMessage.Text.Contains("Thank you! We’ll respond to your message as soon as possible."), "ThankYouMessage is not in display.");
               

                #endregion

            }

            catch (Exception ex)

            {
                Reporter.StatusUpdate("Test Fail", false);
            }


        }

        [Test]
        public void ValidateContactFormErrorMessage()


        {
            try
            {
               

                Reporter.TestDescription = "Performace an invalid contact inputs and ValidateContactFormErrorMessage";

               
                Reporter.TestStep = "Go to ContactPage";
                PWDriver.Contact.Open(AutoConfig.PWContactPage);

                Reporter.TestStep = "Click on Submit with an empty form ";
                PWDriver.Contact.Submit.Click();
                PWDriver.Contact.WaitForScreenToLoad(PWDriver.Contact.ErrorMessage);

                Reporter.TestStep = "Validate ErrorMessage Text";
                Assert.AreEqual(true, PWDriver.Contact.ErrorMessage.Text.Contains("Please fill out all required fields.ihithihtewh"));

                             
            }

            catch (Exception ex)

            {
                Reporter.StatusUpdate("Test Fail", false);
            }


        }

       
    }
}