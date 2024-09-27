using LandStandardLibrary;

namespace TestProject.UnitTest
{
    public class 地號正規化工具
    {
        #region TestTrim
        [Fact]
        public void TestTrim_1()
        {
            // Arrange 
            string testLandno = " 4 5 6 7 ";
            string expectedResult = "4567";

            // Act 
            var actualResult = new LandNoTool(testLandno).Trim().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.LandNo.Should().BeEquivalentTo(expectedResult)
                );
            }
        }

        [Fact]
        public void TestTrim_2()
        {
            // Arrange 
            var testLandno = new List<string> { " 4 5 6 7 ", "34", "5 67", "ab c " };
            var expectedResult = new List<string> { "4567", "34", "567", "abc" };

            // Act 
            var actualResult = new LandNoTool(testLandno).Trim().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Select(a => a.LandNo).Should().BeEquivalentTo(expectedResult);
            }
        }
        #endregion TestTrim

        #region TestFullToHalf
        [Fact]
        public void TestFullToHalf_1()
        {
            // Arrange 
            string testLandno = "１２３４";
            string expectedResult = "1234";

            // Act 
            var actualResult = new LandNoTool(testLandno).FullToHalf().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.LandNo.Should().BeEquivalentTo(expectedResult)
                );
            }
        }

        [Fact]
        public void TestFullToHalf_2()
        {
            // Arrange 
            string testLandno = "１２３４－１";
            string expectedResult = "1234-1";

            // Act 
            var actualResult = new LandNoTool(testLandno).FullToHalf().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.LandNo.Should().BeEquivalentTo(expectedResult)
                );
            }
        }
        #endregion TestFullToHalf

        #region TestVerify
        [Fact]
        public void TestVerify_1()
        {
            // Arrange 
            string testLandno = "(河川地地號)";

            // Act 
            var actualResult = new LandNoTool(testLandno).Verify().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.IsCustom.Should().BeTrue()
                );
                actualResult.Should().AllSatisfy(x =>
                    x.IsNormalized.Should().BeFalse()
                );
                actualResult.Should().AllSatisfy(x =>
                    x.ErrorMsg.Should().BeEquivalentTo("")
                );
            }
        }

        [Fact]
        public void TestVerify_2()
        {
            // Arrange 
            string testLandno = "5-1(內)";

            // Act 
            var actualResult = new LandNoTool(testLandno).Verify().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.IsNormalized.Should().BeFalse()
                );
                actualResult.Should().AllSatisfy(x =>
                    x.ErrorMsg.Should().BeEquivalentTo("非標準地號")
                );
            }
        }


        [Fact]
        public void TestVerify_3()
        {
            // Arrange 
            string testLandno = "5-1-3";

            // Act 
            var actualResult = new LandNoTool(testLandno).Verify().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.IsNormalized.Should().BeFalse()
                );
                actualResult.Should().AllSatisfy(x =>
                    x.ErrorMsg.Should().BeEquivalentTo("非標準地號")
                );
            }
        }

        [Fact]
        public void TestVerify_4()
        {
            // Arrange 
            string testLandno = "五-二";

            // Act 
            var actualResult = new LandNoTool(testLandno).Verify().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.IsNormalized.Should().BeFalse()
                );
                actualResult.Should().AllSatisfy(x =>
                    x.ErrorMsg.Should().BeEquivalentTo("非標準地號")
                );
            }
        }

        [Fact]
        public void TestVerify_5()
        {
            // Arrange 
            string testLandno = "5";

            // Act 
            var actualResult = new LandNoTool(testLandno).Verify().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.IsNormalized.Should().BeTrue()
                );
                actualResult.Should().AllSatisfy(x =>
                    x.ErrorMsg.Should().BeEquivalentTo("")
                );
            }
        }

        [Fact]
        public void TestVerify_6()
        {
            // Arrange 
            string testLandno = "04-002";

            // Act 
            var actualResult = new LandNoTool(testLandno).Verify().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.IsNormalized.Should().BeTrue()
                );
                actualResult.Should().AllSatisfy(x =>
                    x.ErrorMsg.Should().BeEquivalentTo("")
                );
            }
        }

        [Fact]
        public void TestVerify_7()
        {
            // Arrange 
            string testLandno = "12345-2";

            // Act 
            var actualResult = new LandNoTool(testLandno).Verify().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.IsNormalized.Should().BeFalse()
                );
                actualResult.Should().AllSatisfy(x =>
                    x.ErrorMsg.Should().BeEquivalentTo("非標準地號")
                );
            }
        }

        [Fact]
        public void TestVerify_8()
        {
            // Arrange 
            string testLandno = "5-34860";

            // Act 
            var actualResult = new LandNoTool(testLandno).Verify().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.IsNormalized.Should().BeFalse()
                );
                actualResult.Should().AllSatisfy(x =>
                    x.ErrorMsg.Should().BeEquivalentTo("非標準地號")
                );
            }
        }

        [Fact]
        public void TestVerify_9()
        {
            // Arrange 
            string testLandno = "123456789";

            // Act 
            var actualResult = new LandNoTool(testLandno).Verify().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.IsNormalized.Should().BeFalse()
                );
                actualResult.Should().AllSatisfy(x =>
                    x.ErrorMsg.Should().BeEquivalentTo("非標準地號")
                );
            }
        }

        [Fact]
        public void TestVerify_10()
        {
            // Arrange 
            string testLandno = "12345678";

            // Act 
            var actualResult = new LandNoTool(testLandno).Verify().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.IsNormalized.Should().BeTrue()
                );
                actualResult.Should().AllSatisfy(x =>
                    x.ErrorMsg.Should().BeEquivalentTo("")
                );
            }
        }
        #endregion TestVerify

        #region TestPadDash
        [Fact]
        public void TestPadDash_1()
        {
            // Arrange 
            string testLandno = "00011234";
            string expectedResult = "0001-1234";

            // Act 
            var actualResult = new LandNoTool(testLandno).Verify().PadDash().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.LandNo.Should().BeEquivalentTo(expectedResult)
                );
            }
        }

        [Fact]
        public void TestPadDash_2()
        {
            // Arrange 
            string testLandno = "0001-1234";
            string expectedResult = "0001-1234";

            // Act 
            var actualResult = new LandNoTool(testLandno).Verify().PadDash().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.LandNo.Should().BeEquivalentTo(expectedResult)
                );
            }
        }

        [Fact]
        public void TestPadDash_3()
        {
            // Arrange 
            string testLandno = "0001123";
            string expectedResult = "0001123";

            // Act 
            var actualResult = new LandNoTool(testLandno).Verify().PadDash().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.LandNo.Should().BeEquivalentTo(expectedResult)
                );
            }
        }
        #endregion

        #region TestPadZero
        [Fact]
        public void TestPadZero_1()
        {
            // Arrange 
            string testLandno = "34-78";
            string expectedResult = "0034-0078";

            // Act 
            var actualResult = new LandNoTool(testLandno).Verify().PadZero().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.LandNo.Should().BeEquivalentTo(expectedResult)
                );
            }
        }

        [Fact]
        public void TestPadZero_2()
        {
            // Arrange 
            string testLandno = "34";
            string expectedResult = "0034-0000";

            // Act 
            var actualResult = new LandNoTool(testLandno).Verify().PadZero().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.LandNo.Should().BeEquivalentTo(expectedResult)
                );
            }
        }

        [Fact]
        public void TestPadZero_3()
        {
            // Arrange 
            string testLandno = "-56";
            string expectedResult = "0000-0056";

            // Act 
            var actualResult = new LandNoTool(testLandno).Verify().PadZero().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.LandNo.Should().BeEquivalentTo(expectedResult)
                );
            }
        }

        [Fact]
        public void TestPadZero_4()
        {
            // Arrange 
            string testLandno = "78-";
            string expectedResult = "0078-0000";

            // Act 
            var actualResult = new LandNoTool(testLandno).Verify().PadZero().Build();

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.LandNo.Should().BeEquivalentTo(expectedResult)
                );
            }
        }
        #endregion TestPadZero

        #region TestNormalize
        [Fact]
        public void TestNormalize_1()
        {
            // Arrange 
            var testLandno = new List<string> { " 4 5 6 7 ", "34", "5 67", "ab c " };
            var expectedResult = new LandNoTool(testLandno).Trim().FullToHalf().Verify().PadZero().Build();

            // Act 
            var actualResult = new LandNoTool(testLandno).Normalize().Build();

            // Assert            
            using (new AssertionScope())
            {
                actualResult.Should().BeEquivalentTo(
                    new List<LandNoResult>() {
                        new LandNoResult("") { LandNo = "4567-0000", IsNormalized = true, ErrorMsg = "" },
                        new LandNoResult("") { LandNo = "0034-0000", IsNormalized = true, ErrorMsg = "" },
                        new LandNoResult("") { LandNo = "0567-0000", IsNormalized = true, ErrorMsg = "" },
                        new LandNoResult("") { LandNo = "abc", IsNormalized = false, ErrorMsg = "非標準地號" },
                    }
                );
            }
        }


        [Fact]
        public void TestNormalize_Empty()
        {
            // Arrange 
            var testLandno = new List<string> { "", " ", "-" };
            var expectedResult = new LandNoTool(testLandno).Trim().FullToHalf().Verify().PadZero().Build();

            // Act 
            var actualResult = new LandNoTool(testLandno).Normalize().Build();

            // Assert            
            using (new AssertionScope())
            {
                actualResult.Should().BeEquivalentTo(
                    new List<LandNoResult>() {
                        new LandNoResult("") { LandNo = "", IsNormalized = false, ErrorMsg = "地號不可為空" },
                        new LandNoResult(" ") { LandNo = "", IsNormalized = false, ErrorMsg = "地號不可為空" },
                        new LandNoResult("-") { LandNo = "-", IsNormalized = false, ErrorMsg = "地號不可為空" },
                    }
                );
            }
        }

        [Fact]
        public void TestNormalize_2()
        {
            // Arrange 
            var testLandno = new List<string> { "１２３４－１" };
            var expectedResult = "1234-0001";

            // Act 
            var actualResult = new LandNoTool(testLandno).Normalize().Build();

            // Assert            
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.LandNo.Should().BeEquivalentTo(expectedResult)
                );
            }
        }

        [Fact]
        public void TestNormalize_3()
        {
            // Arrange 
            var testLandno = new List<string> { "一二" };
            var expectedResult = "一二";

            // Act 
            var actualResult = new LandNoTool(testLandno).Normalize().Build();

            // Assert            
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.LandNo.Should().BeEquivalentTo(expectedResult)
                );
            }
        }

        [Fact]
        public void TestNormalize_4()
        {
            // Arrange 
            var testLandno = new List<string> { "０４５９－１" };
            var expectedResult = "0459-0001";

            // Act 
            var actualResult = new LandNoTool(testLandno).Normalize().Build();

            // Assert            
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.LandNo.Should().BeEquivalentTo(expectedResult)
                );
            }
        }

        [Fact]
        public void TestNormalize_5()
        {
            // Arrange 
            var testLandno = new List<string> { "０4５ 8— １ " };
            var expectedResult = "0458-0001";

            // Act 
            var actualResult = new LandNoTool(testLandno).Normalize().Build();

            // Assert            
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.LandNo.Should().BeEquivalentTo(expectedResult)
                );
            }
        }

        [Fact]
        public void TestNormalize_6()
        {
            // Arrange 
            var testLandno = new List<string> { "00010021" };
            var expectedResult = "0001-0021";

            // Act 
            var actualResult = new LandNoTool(testLandno).Normalize().Build();

            // Assert            
            using (new AssertionScope())
            {
                actualResult.Should().AllSatisfy(x =>
                    x.LandNo.Should().BeEquivalentTo(expectedResult)
                );
            }
        }
        #endregion TestNormalize
    }
}