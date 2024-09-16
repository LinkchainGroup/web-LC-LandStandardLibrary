using LandStandardLibrary;
using TechTalk.SpecFlow;

namespace LandNoToolXunitTest
{
    [Binding]
    public class LandNoToolStepDefinitions
    {
        private LandNoTool _tool;
        private List<LandNoResult> _results;


        [Given(@"��J�a�� ""([^""]*)""")]
        public void GivenALandNumber(string landNo)
        {
            _tool = new LandNoTool(landNo);
        }

        [When(@"���楿�W��")]
        public void WhenExecNormalize()
        {
            _results = _tool.Normalize().Build();
        }

        [Then(@"�a���^�ǵ��G�� ""([^""]*)""")]
        public void ThenTheResultShouldBe(string expectedLandNo)
        {
            _results[0].LandNo.Should().Be(expectedLandNo);
        }

        [Then(@"���W�Ƶ��G�� ""([^""]*)""")]
        public void ThenTheLandNumberShouldBeMarkedAsNormalized(bool normalization_status)
        {
            _results[0].IsNormalized.Should().Be(normalization_status);
        }

        [Then(@"�S�����~�T��")]
        public void ThenThereShouldBeNoErrorMessage()
        {
            _results[0].ErrorMsg.Should().BeEmpty();
        }


        [Then(@"���~�T���� ""([^""]*)""")]
        public void ThenTheErrorMessageShouldBe(string expectedErrorMsg)
        {
            _results[0].ErrorMsg.Should().Be(expectedErrorMsg);
        }

        [When(@"��������")]
        public void WhenIVerifyTheLandNumber()
        {
            _results = _tool.Verify().Build();
        }

        [When(@"����ɹs")]
        public void WhenIPadZerosToTheLandNumber()
        {
            _results = _tool.Verify().PadZero().Build();
        }
    }
}
