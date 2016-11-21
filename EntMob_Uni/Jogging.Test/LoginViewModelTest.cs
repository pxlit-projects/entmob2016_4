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
        public void TestCommandLoaded()
        {
            LoginViewModel loginViewModel = new LoginViewModel(new Mocks.MockUserService());
            Assert.IsNotNull(loginViewModel.LoginCommand);
        }

    }
}
