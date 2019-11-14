using Microsoft.VisualStudio.TestTools.UnitTesting;

using StringCalculatorNS;
namespace StringCalculatorUnitTest
{
    [TestClass]
    public class StringCalculatorUnitTest
    {
        
        public void StringCalculator_Addition_Valid_WithTwoNumber()
        {

            StringCalculator cal = new StringCalculator();
            string testString = "-3,4";
            int actual = cal.Addition(testString);
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringCalculator_Addition_Valid_WithEmpty()
        {

            StringCalculator cal = new StringCalculator();
            string testString =  "";
            int actual = cal.Addition(testString);
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringCalculator_Addition_Valid_WithNumberAndLetters()
        {

            StringCalculator cal = new StringCalculator();
            string testString = "5,tytyt";
            int actual = cal.Addition(testString);
            int expected = 5;

            Assert.AreEqual(expected, actual);
        }
/// <summary>
/// req1 
/// </summary>
        public void StringCalculator_Addition_Invalid_WithMoreThanTwoNumbers()
        {
            // Arrange
            StringCalculator cal = new StringCalculator();
            string testString = "1,2,3,4,5,6,7,8,9,10,11,12";

            // Act
            try
            {
                cal.Addition(testString);
            }
            catch (System.ArgumentException e)
            {
                // Assert
                StringAssert.Contains(e.Message, StringCalculator.MaximumTwoNumberMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void StringCalculator_Addition_Valid_WithMoreThanTwoNumbers()
        {
            
            StringCalculator cal = new StringCalculator();
            string testString = "1,2,3,4,5,6,7,8,9,10,11,12";
            int actual = cal.Addition(testString);
            int expected = 78;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringCalculator_Addition_Valid_NewlineAsdelimiter()
        {

            StringCalculator cal = new StringCalculator();
            string testString = "1\n2,5";
            int actual = cal.Addition(testString);
            int expected = 8;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringCalculator_Addition_Invalid_NoNegativeNumberAllowed()
        {
            // Arrange
            StringCalculator cal = new StringCalculator();
            string testString = "1,-1,-2,-4,5";

            // Act
            try
            {
                cal.Addition(testString);
            }
            catch (System.ArgumentException e)
            {
                // Assert
                StringAssert.Contains(e.Message, StringCalculator.NotAllowNegativeNumberMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }


        [TestMethod]
        public void StringCalculator_Addition_Valid_GreaterThanMaxIsZero()
        {

            StringCalculator cal = new StringCalculator();
            string testString = "2,1001,6";
            int actual = cal.Addition(testString);
            int expected = 8;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringCalculator_Addition_Valid_PassSingleCustomDelimiter()
        {

            StringCalculator cal = new StringCalculator();
            string testString = "//,\n2,ff,100";
            int actual = cal.Addition(testString);
            int expected = 102;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringCalculator_Addition_Valid_PassSingleCustomDelimiterAnyLength()
        {

            StringCalculator cal = new StringCalculator();
            string testString = "//[***]\n11***22***33";
            int actual = cal.Addition(testString);
            int expected = 66;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringCalculator_Addition_Valid_PassSingleCustomDelimiterMoreThanOneChar()
        {

            StringCalculator cal = new StringCalculator();
            string testString = "//[***]\n11***22***33";
            int actual = cal.Addition(testString);
            int expected = 66;

            Assert.AreEqual(expected, actual);
        }
    }

}
