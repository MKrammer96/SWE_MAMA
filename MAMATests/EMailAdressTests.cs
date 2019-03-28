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
    public class EMailAdressTests
    {
        [TestMethod()]
        public void MailGood0()
        {
            string adresse = "a.b@gmail.com";
            EMailAddress adress = new EMailAddress(adresse);
            Assert.IsTrue(adress.verifyEmailAddress(adresse));
        }

        [TestMethod()]
        public void MailGood1()
        {
            string adresse = "manuel.krammer@students.fh-wels.at";
            EMailAddress adress = new EMailAddress(adresse);
            Assert.IsTrue(adress.verifyEmailAddress(adresse));
        }

        [TestMethod()]
        public void MailFail0()
        {
            string adresse = "a@b.c@gmail.com";
            EMailAddress adress = new EMailAddress(adresse);
            Assert.IsFalse(adress.verifyEmailAddress(adresse));
        }

        [TestMethod()]
        public void MailFail1()
        {
            string adresse = "a@b.c@.gmail.com";
            EMailAddress adress = new EMailAddress(adresse);
            Assert.IsFalse(adress.verifyEmailAddress(adresse));
        }

        [TestMethod()]
        public void MailFail2()
        {
            string adresse = "c@d.e@gmail.net";
            EMailAddress adress = new EMailAddress(adresse);
            Assert.IsFalse(adress.verifyEmailAddress(adresse));
        }

        [TestMethod()]
        public void MailFail3()
        {
            string adresse = "fg.h@.yahoo.com";
            EMailAddress adress = new EMailAddress(adresse);
            Assert.IsFalse(adress.verifyEmailAddress(adresse));
        }

        [TestMethod()]
        public void MailFail4()
        {
            string adresse = "ij.k@.gmail.c";
            EMailAddress adress = new EMailAddress(adresse);
            Assert.IsFalse(adress.verifyEmailAddress(adresse));
        }

        [TestMethod()]
        public void MailFail5()
        {
            string adresse = "Lm.n.@opq.de";
            EMailAddress adress = new EMailAddress(adresse);
            Assert.IsFalse(adress.verifyEmailAddress(adresse));
        }

        [TestMethod()]
        public void MailFail6()
        {
            string adresse = "R.s@t.uvw.";
            EMailAddress adress = new EMailAddress(adresse);
            Assert.IsFalse(adress.verifyEmailAddress(adresse));
        }

        [TestMethod()]
        public void MailFail7()
        {
            string adresse = ".ab.dg@fh.wels.at";
            EMailAddress adress = new EMailAddress(adresse);
            Assert.IsFalse(adress.verifyEmailAddress(adresse));
        }

        [TestMethod()]
        public void MailFail8()
        {
            string adresse = null;
            EMailAddress adress = new EMailAddress(adresse);
            Assert.IsFalse(adress.verifyEmailAddress(adresse));
        }

        [TestMethod()]
        public void MailFail9()
        {
            string adresse = "manuel.krammer@at";
            EMailAddress adress = new EMailAddress(adresse);
            Assert.IsFalse(adress.verifyEmailAddress(adresse));
        }

        [TestMethod()]
        public void MailFail10()
        {
            string adresse = ".manuel.krammer@at";
            EMailAddress adress = new EMailAddress(adresse);
            Assert.IsFalse(adress.verifyEmailAddress(adresse));
        }

        [TestMethod()]
        public void MailFail11()
        {
            string adresse = "manuel.krammer@at.";
            EMailAddress adress = new EMailAddress(adresse);
            Assert.IsFalse(adress.verifyEmailAddress(adresse));
        }

        [TestMethod()]
        public void MailFail12()
        {
            string adresse = "manuel.krammer@";
            EMailAddress adress = new EMailAddress(adresse);
            Assert.IsFalse(adress.verifyEmailAddress(adresse));
        }
    }
}