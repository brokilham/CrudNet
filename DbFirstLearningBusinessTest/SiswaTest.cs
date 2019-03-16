using System;
using DbFirstLearningBusiness.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbFirstLearningBusinessTest
{
    [TestClass]
    public class SiswaTest
    {
        [TestMethod]
        public void GetAll()
        {
            SiswaBusiness siswaBusiness = new SiswaBusiness();
            var result =  siswaBusiness.GetAll();
        }
    }
}
