using LandStandardLibrary;
using TechTalk.SpecFlow;

namespace LandNoToolXunitTest
{
    [Binding]
    public class LandNoToolStepDefinitions
    {
        private LandNoTool _tool;
        private List<LandNoResult> _results;


        [Given(@"輸入地號 ""([^""]*)""")]
        public void GivenALandNumber(string landNo)
        {
            _tool = new LandNoTool(landNo);
        }

        [When(@"執行正規化")]
        public void WhenExecNormalize()
        {
            _results = _tool.Normalize().Build();
        }

        [Then(@"地號回傳結果為 ""([^""]*)""")]
        public void ThenTheResultShouldBe(string expectedLandNo)
        {
            _results[0].LandNo.Should().Be(expectedLandNo);
        }

        [Then(@"正規化結果為 ""([^""]*)""")]
        public void ThenTheLandNumberShouldBeMarkedAsNormalized(bool normalization_status)
        {
            _results[0].IsNormalized.Should().Be(normalization_status);
        }

        [Then(@"沒有錯誤訊息")]
        public void ThenThereShouldBeNoErrorMessage()
        {
            _results[0].ErrorMsg.Should().BeEmpty();
        }


        [Then(@"錯誤訊息為 ""([^""]*)""")]
        public void ThenTheErrorMessageShouldBe(string expectedErrorMsg)
        {
            _results[0].ErrorMsg.Should().Be(expectedErrorMsg);
        }

        [When(@"執行驗證")]
        public void WhenIVerifyTheLandNumber()
        {
            _results = _tool.Verify().Build();
        }

        [When(@"執行補零")]
        public void WhenIPadZerosToTheLandNumber()
        {
            _results = _tool.Verify().PadZero().Build();
        }
    }
}
