using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LAB4;

namespace Lab4.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void deletePosTest()
        {
            Vector a = new Vector(1, -2, 3);
            Vector expected = new Vector(0, -2, 0);
            a.deletePos();
            Assert.AreEqual(expected.X, a.X);
        }

        [TestMethod]
        public void cutStrTest()
        {
            string a = "hello world";
            string expected = "world";
            string actual = a.cutStr(6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OverloadTest_Vector_plus()
        {
            Vector a = new Vector(60, 6.86F, 18);
            Vector b = new Vector(40, 3.14F, 9);
            Vector expected = new Vector(100, 10, 27);
            Vector actual = a + b;
            Assert.AreEqual(expected.X, actual.X);
        }

        [TestMethod]
        public void OverloadTest_Vector_less()
        {
            Vector a = new Vector(20, 1, 8);
            Vector b = new Vector(40, 3, 9);
            bool expected = true;

            Assert.AreEqual(expected, a < b);
        }

        [TestMethod]
        public void OverloadTest_Vector_copy()
        {
            Vector a = new Vector(20, 1, 8.2F);
            Vector b = new Vector(0, 0, 0);
            Vector expected = new Vector(0, 0, 0);
            Vector actual = a == b;
            Assert.AreEqual(expected.X, actual.X);
        }

        [TestMethod]
        public void OverloadTest_Vector_true()
        {
            Vector a = new Vector(20, 1, 8.2F);
            bool expected = true;
            bool actual;
            if (a)
                actual = true;
            else
                actual = false;
            Assert.AreEqual(expected, actual);
        }
    }
}
