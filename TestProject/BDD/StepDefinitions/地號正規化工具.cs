using LandStandardLibrary;
using TechTalk.SpecFlow;

namespace TestProject.BDD.StepDefinitions
{
    [Binding]
    public class �a�����W�Ƥu��
    {
        private LandNoTool _tool;
        private List<LandNoResult> _results;

        #region Given

        [Given(@"��J�a�� ""([^""]*)""")]
        public void Give��J�a��(string landNo)
        {
            _tool = new LandNoTool(landNo);
        }

        #endregion Given

        #region When

        [When(@"�h���ť�")]
        public void When�h���ť�()
        {
            _tool = _tool.Trim();
        }

        [When(@"������b��")]
        public void When������b��()
        {
            _tool = _tool.FullToHalf();
        }

        [When(@"��������")]
        public void When��������()
        {
            _tool = _tool.Verify();
        }

        [When(@"�����Dash")]
        public void When�����Dash()
        {
            _tool = _tool.PadDash();
        }


        [When(@"����ɹs")]
        public void When����ɹs()
        {
            _tool = _tool.PadZero();
        }

        [When(@"���楿�W��")]
        public void When���楿�W��()
        {
            _tool = _tool.Normalize();
        }

        #endregion When

        #region Then

        [Then(@"���ҡ]�P�_�O�_���i���W�ƪ��a���^���G�� ""([^""]*)""")]
        public void Then���ҧP�_�O�_���i���W�ƪ��a�����G��(bool isNormalized)
        {
            _results = _tool.Build();
            _results[0].IsNormalized.Should().Be(isNormalized);
        }

        [Then(@"���ҡ]�P�_�O�_���۩w�q�a���^���G�� ""([^""]*)""")]
        public void Then���ҧP�_�O�_���۩w�q�a�����G��(bool isCustom)
        {
            _results[0].IsCustom.Should().Be(isCustom);
        }

        [Then(@"�a���^�ǵ��G�� ""([^""]*)""")]
        public void Then�a���^�ǵ��G��(string expectedLandNo)
        {
            _results = _tool.Build();
            _results[0].LandNo.Should().Be(expectedLandNo);
        }

        [Then(@"���W�Ƶ��G�� ""([^""]*)""")]
        public void Then���W�Ƶ��G��(bool normalization_status)
        {
            _results = _tool.Build();
            _results[0].IsNormalized.Should().Be(normalization_status);
        }

        [Then(@"�S�����~�T��")]
        public void Then�S�����~�T��()
        {
            _results = _tool.Build();
            _results[0].ErrorMsg.Should().BeEmpty();
        }


        [Then(@"���~�T���� ""([^""]*)""")]
        public void Then���~�T����(string expectedErrorMsg)
        {
            _results = _tool.Build();
            _results[0].ErrorMsg.Should().Be(expectedErrorMsg);
        }

        #endregion Then
    }
}
