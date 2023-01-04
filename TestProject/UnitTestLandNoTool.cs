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
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void TestTrim_2()
        {
            // Arrange 
            var testLandno = new List<string> { " 4 5 6 7 ", "34", "5 67", "ab c " };
            string expectedResult = "4567";

            // Act 
            var actualResult = new LandNoTool(testLandno).Trim().Build();

            // Assert            
            actualResult.Should().BeEquivalentTo(expectedResult);
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
            actualResult.Should().BeEquivalentTo(expectedResult);
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
            actualResult.Should().BeEquivalentTo(expectedResult);
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
            actualResult.Should().BeEquivalentTo(expectedResult);
        }
        #endregion TestPadZero

        #region TestNormalize
        [Fact]
        public void TestNormalize_1()
        {
            // Arrange 
            var testLandno = new List<string> { " 4 5 6 7 ", "34", "5 67", "ab c " };
            var expectedResult = new LandNoTool(testLandno).Trim().FullToHalf().PadZero().Build();

            // Act 
            var actualResult = new LandNoTool(testLandno).Normalize().Build();
            
            // Assert            
            actualResult.Should().BeEquivalentTo(expectedResult);
        }
        #endregion TestNormalize
    }
}