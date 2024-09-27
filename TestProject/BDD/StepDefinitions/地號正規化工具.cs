using LandStandardLibrary;
using TechTalk.SpecFlow;

namespace TestProject.BDD.StepDefinitions
{
    [Binding]
    public class 地號正規化工具
    {
        private LandNoTool _tool;
        private List<LandNoResult> _results;

        #region Given

        [Given(@"輸入地號 ""([^""]*)""")]
        public void Give輸入地號(string landNo)
        {
            _tool = new LandNoTool(landNo);
        }

        #endregion Given

        #region When

        [When(@"去除空白")]
        public void When去除空白()
        {
            _tool = _tool.Trim();
        }

        [When(@"全形轉半形")]
        public void When全形轉半形()
        {
            _tool = _tool.FullToHalf();
        }

        [When(@"執行驗證")]
        public void When執行驗證()
        {
            _tool = _tool.Verify();
        }

        [When(@"執行補Dash")]
        public void When執行補Dash()
        {
            _tool = _tool.PadDash();
        }


        [When(@"執行補零")]
        public void When執行補零()
        {
            _tool = _tool.PadZero();
        }

        [When(@"執行正規化")]
        public void When執行正規化()
        {
            _tool = _tool.Normalize();
        }

        #endregion When

        #region Then

        [Then(@"驗證（判斷是否為可正規化的地號）結果為 ""([^""]*)""")]
        public void Then驗證判斷是否為可正規化的地號結果為(bool isNormalized)
        {
            _results = _tool.Build();
            _results[0].IsNormalized.Should().Be(isNormalized);
        }

        [Then(@"驗證（判斷是否為自定義地號）結果為 ""([^""]*)""")]
        public void Then驗證判斷是否為自定義地號結果為(bool isCustom)
        {
            _results[0].IsCustom.Should().Be(isCustom);
        }

        [Then(@"地號回傳結果為 ""([^""]*)""")]
        public void Then地號回傳結果為(string expectedLandNo)
        {
            _results = _tool.Build();
            _results[0].LandNo.Should().Be(expectedLandNo);
        }

        [Then(@"正規化結果為 ""([^""]*)""")]
        public void Then正規化結果為(bool normalization_status)
        {
            _results = _tool.Build();
            _results[0].IsNormalized.Should().Be(normalization_status);
        }

        [Then(@"沒有錯誤訊息")]
        public void Then沒有錯誤訊息()
        {
            _results = _tool.Build();
            _results[0].ErrorMsg.Should().BeEmpty();
        }


        [Then(@"錯誤訊息為 ""([^""]*)""")]
        public void Then錯誤訊息為(string expectedErrorMsg)
        {
            _results = _tool.Build();
            _results[0].ErrorMsg.Should().Be(expectedErrorMsg);
        }

        #endregion Then
    }
}
