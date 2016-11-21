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
    public class DetailViewModelTest
    {
        [TestMethod]
        public void TestCommandsLoaded()
        {
            DetailViewModel detailViewModel = new DetailViewModel(new Mocks.MockSessionService());
            Assert.IsNotNull(detailViewModel.BackCommand);
        }
    }
}
