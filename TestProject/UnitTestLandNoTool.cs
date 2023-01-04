using LandStandardLibrary;

namespace LandNoToolTests
{
    public class LandNoToolTests
    {
        #region TestTrim
        [Fact]
        public void TestTrim_1()
        {
            // Arrange 
            string testLandno = " 4 5 6 7 ";
            string expectedResult = "4567";

            // Act 
            var actualResult = new LandNoTool(testLandno).Trim().Build().FirstOrDefault();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
        #endregion TestTrim

        #region TestFullToHalf
        [Fact]
        public void TestFullToHalf_1()
        {
            // Arrange 
            string testLandno = "¢°¢±¢²¢³";
            string expectedResult = "1234";

            // Act 
            var actualResult = new LandNoTool(testLandno).FullToHalf().Build().FirstOrDefault();            

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
        #endregion TestFullToHalf

        #region TestPadZero
        [Fact]
        public void TestPadZero_1()
        {
            // Arrange 
            string testLandno = "34-78";
            string expectedResult = "0034-0078";

            // Act 
            var actualResult = new LandNoTool(testLandno).PadZero().Build().FirstOrDefault();

            // Assert
            Assert.Equal(expectedResult, actualResult);            
        }

        [Fact]
        public void TestPadZero_2()
        {
            // Arrange 
            string testLandno = "34";
            string expectedResult = "0034-0000";

            // Act 
            var actualResult = new LandNoTool(testLandno).PadZero().Build().FirstOrDefault();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
        #endregion TestPadZero
    }
}