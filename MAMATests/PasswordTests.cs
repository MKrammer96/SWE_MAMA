using Microsoft.VisualStudio.TestTools.UnitTesting;
using MAMA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMA.Tests
{
    [TestClass()]
    public class PasswordTests
    {
        [TestMethod()]
        public void GoodPasswordTest1()
        {
            Password.SetPassword("MAMA");
            Assert.IsTrue(Password.CheckPassword("MAMA"));
        }

        [TestMethod()]
        public void FalsePasswordTest1()
        {
            Password.SetPassword("MAMA");
            Assert.IsFalse(Password.CheckPassword("mama"));
        }

        [TestMethod()]
        public void FalsePasswordTest2()
        {
            Password.SetPassword("MAMA");
            Assert.IsFalse(Password.CheckPassword("papa"));
        }
    }
}