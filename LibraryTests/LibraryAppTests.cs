using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Library;

namespace LibraryTests
{
    [TestClass]
    public class LibraryAppTests
    {

        [TestMethod]
        [DataRow("2020,01,01", true), DataRow("2010,3,6", true), DataRow("20104,3,69", false)]
        [DataRow("2000,01,1", true), DataRow("2010.30,6", false), DataRow("2020,3,80", false)]
        public void IsDateInRightFormatTest(string date, bool expected)
        {
            LibraryApp app = new LibraryApp();

            bool result = app.IsDateInRightFormat(date);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("2", true), DataRow("34", true), DataRow("d", false)]
        [DataRow("95", true), DataRow("258", true), DataRow("hfdh", false)]
        public void IsDigitsOnlyFormatTest(string number, bool expected)
        {
            LibraryApp app = new LibraryApp();


            bool result = app.IsDigitsOnly(number);
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        [DataRow("kalle", true), DataRow("fismunk", true), DataRow("#¤", false)]
        [DataRow("stor", true), DataRow("kille", true), DataRow("134", false)]
        public void ValidateStringTest(string input, bool expected)
        {
            LibraryApp app = new LibraryApp();


            bool result = app.ValidateString(input);

            Assert.AreEqual(expected, result);
        }


    }
}
