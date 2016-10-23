using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using EntMob_Uni.ViewModel;
using EntMob_Uni.Utility;

namespace Jogging.Test
{
    [TestClass]
    public class LoginViewModelTest
    {

        [TestMethod]
        public void Execute_Always_SendsYourMessageType()
        {
            // arrange
            var systemUnderTest = new LoginViewModel();

            // Set the action to store the message that was sent
            string actual = systemUnderTest.Username;
            Messenger.Default.Register<string>(this, t => actual = t);


            // act
            systemUnderTest.LoginCommand.Execute(null);


            // assert
            string expected = "Jonas"/* set up your expected message */;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void UsernameLength()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            string count = loginViewModel.Username;
            Assert.IsTrue(count.Length >= 3);
        }

    }
}
