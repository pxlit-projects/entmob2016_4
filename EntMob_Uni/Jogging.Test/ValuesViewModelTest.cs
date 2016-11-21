using EntMob_Uni.Services;
using EntMob_Uni.ViewModel;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogging.Test
{
    [TestClass]
    public class ValuesViewModelTest
    {

        [TestMethod]
        public void TestCommandsLoaded()
        {
            ValuesViewModel valuesViewModel = new ValuesViewModel(new Mocks.MockSessionService());
            Assert.IsNotNull(valuesViewModel.BackCommand);
            Assert.IsNotNull(valuesViewModel.NextCommand);
        }

    }
}
