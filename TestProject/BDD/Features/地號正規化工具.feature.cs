﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace TestProject.BDD.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class 地號正規化工具Feature : object, Xunit.IClassFixture<地號正規化工具Feature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "地號正規化工具.feature"
#line hidden
        
        public 地號正規化工具Feature(地號正規化工具Feature.FixtureData fixtureData, TestProject_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "BDD/Features", "地號正規化工具", @"=============================================================================

此工具可以驗證與修正輸入的字串
並輸出正規化的地號

Spec1. 正規化地號：共9碼，分為兩個部分，前4碼為母號，後4碼為子號，都是數字，前後用Dash(-)連結。
範例：0005-0001，0710-0200，0001-0000，1500-0020，0009-0005，0005-0001

Spec2. 使用者手動輸入地號容易發生錯誤。
範例：5-1，07100200，1，1500 - 0020，0009-000５，伍-壹

Spec3. 使用地號正規化工具，先修正（去除空白，全形轉半形），接著驗證是否為可正規化的地號，最後執行正規化（補Dash，補0）。

Spec4. 成功正規化後，回傳正規化地號，若無法正規化，則會回傳錯誤訊息。

Spec5. 自定義地號，常發生在林班地或河川地，用左右括號包起來，這種情況就不做正規化，而是標注自定義並直接回傳。
範例：(第187林班第129圖號)，(R0201-0000)，(尚德村成功事業區第16、17林班)

=============================================================================

前置作業函式：
Trim
FullToHalf
驗證函式：
Verify
修正函式：
PadDash
PadZero

正規化函式 = 前置作業函式 + 驗證函式 + 修正函式
Normalize

回傳結果
Build

=============================================================================", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="去除空白功能（Trim）")]
        [Xunit.TraitAttribute("FeatureTitle", "地號正規化工具")]
        [Xunit.TraitAttribute("Description", "去除空白功能（Trim）")]
        [Xunit.InlineDataAttribute("0 0 0 1 - 0 0 0 1", "0001-0001", new string[0])]
        [Xunit.InlineDataAttribute("ab c", "abc", new string[0])]
        [Xunit.InlineDataAttribute("xy- z", "xy-z", new string[0])]
        [Xunit.InlineDataAttribute("林 班地", "林班地", new string[0])]
        [Xunit.InlineDataAttribute("全形　空白", "全形空白", new string[0])]
        public void 去除空白功能Trim(string input, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("input", input);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("去除空白功能（Trim）", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 41
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 42
 testRunner.Given(string.Format("輸入地號 \"{0}\"", input), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 43
 testRunner.When("去除空白", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 44
 testRunner.Then(string.Format("地號回傳結果為 \"{0}\"", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="全形轉半形功能（FullToHalf）")]
        [Xunit.TraitAttribute("FeatureTitle", "地號正規化工具")]
        [Xunit.TraitAttribute("Description", "全形轉半形功能（FullToHalf）")]
        [Xunit.InlineDataAttribute("５６７８", "5678", new string[0])]
        [Xunit.InlineDataAttribute("xy－ z", "xy- z", new string[0])]
        [Xunit.InlineDataAttribute("（全形　空白與括號）", "(全形 空白與括號)", new string[0])]
        public void 全形轉半形功能FullToHalf(string input, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("input", input);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("全形轉半形功能（FullToHalf）", "以下為目前支援全形轉半形的字元\r\n１２３４５６７８９０ => 1234567890\r\n－— => -\r\n（） => ()", tagsOfScenario, argumentsOfScenario, featureTags);
#line 55
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 60
 testRunner.Given(string.Format("輸入地號 \"{0}\"", input), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 61
 testRunner.When("全形轉半形", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 62
 testRunner.Then(string.Format("地號回傳結果為 \"{0}\"", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="驗證功能（Verify）")]
        [Xunit.TraitAttribute("FeatureTitle", "地號正規化工具")]
        [Xunit.TraitAttribute("Description", "驗證功能（Verify）")]
        [Xunit.InlineDataAttribute("123-456", "true", "false", "", new string[0])]
        [Xunit.InlineDataAttribute("123 - 456", "false", "false", "非標準地號", new string[0])]
        [Xunit.InlineDataAttribute("123－456", "false", "false", "非標準地號", new string[0])]
        [Xunit.InlineDataAttribute("12345", "false", "false", "非標準地號", new string[0])]
        [Xunit.InlineDataAttribute("123-45678", "false", "false", "非標準地號", new string[0])]
        [Xunit.InlineDataAttribute("abc-def", "false", "false", "非標準地號", new string[0])]
        [Xunit.InlineDataAttribute("", "false", "false", "地號不可為空", new string[0])]
        [Xunit.InlineDataAttribute("(自訂)", "false", "true", "", new string[0])]
        [Xunit.InlineDataAttribute("（自訂）", "false", "false", "非標準地號", new string[0])]
        public void 驗證功能Verify(string input, string isNormalized, string isCustom, string error_Message, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("input", input);
            argumentsOfScenario.Add("IsNormalized", isNormalized);
            argumentsOfScenario.Add("IsCustom", isCustom);
            argumentsOfScenario.Add("error_message", error_Message);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("驗證功能（Verify）", "驗證（Verify）應在去除空白（Trim）與全形轉半形（FullToHalf）之後，才可做出準確的結果", tagsOfScenario, argumentsOfScenario, featureTags);
#line 71
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 73
 testRunner.Given(string.Format("輸入地號 \"{0}\"", input), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 74
 testRunner.When("執行驗證", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 75
 testRunner.Then(string.Format("驗證（判斷是否為可正規化的地號）結果為 \"{0}\"", isNormalized), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 76
 testRunner.And(string.Format("驗證（判斷是否為自定義地號）結果為 \"{0}\"", isCustom), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 77
 testRunner.And(string.Format("錯誤訊息為 \"{0}\"", error_Message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="補Dash功能（PadDash）")]
        [Xunit.TraitAttribute("FeatureTitle", "地號正規化工具")]
        [Xunit.TraitAttribute("Description", "補Dash功能（PadDash）")]
        [Xunit.InlineDataAttribute("123-456", "123-456", new string[0])]
        [Xunit.InlineDataAttribute("12300456", "1230-0456", new string[0])]
        [Xunit.InlineDataAttribute("abcdef", "abcdef", new string[0])]
        [Xunit.InlineDataAttribute("1230-0456", "1230-0456", new string[0])]
        public void 補Dash功能PadDash(string input, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("input", input);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("補Dash功能（PadDash）", "補Dash（PadDash）應在驗證（Verify）之後，才可做出準確的結果\r\n只有可正規化的地號，全部都為數字，且長度為8碼，才會執行補Dash", tagsOfScenario, argumentsOfScenario, featureTags);
#line 92
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 95
 testRunner.Given(string.Format("輸入地號 \"{0}\"", input), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 96
 testRunner.When("執行驗證", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 97
 testRunner.And("執行補Dash", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 98
 testRunner.Then(string.Format("地號回傳結果為 \"{0}\"", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="補零功能（PadZero）")]
        [Xunit.TraitAttribute("FeatureTitle", "地號正規化工具")]
        [Xunit.TraitAttribute("Description", "補零功能（PadZero）")]
        [Xunit.InlineDataAttribute("123-45", "0123-0045", new string[0])]
        [Xunit.InlineDataAttribute("12300456", "12300456", new string[0])]
        [Xunit.InlineDataAttribute("abcdef", "abcdef", new string[0])]
        [Xunit.InlineDataAttribute("1230-0456", "1230-0456", new string[0])]
        [Xunit.InlineDataAttribute("1", "0001-0000", new string[0])]
        [Xunit.InlineDataAttribute("5-6", "0005-0006", new string[0])]
        [Xunit.InlineDataAttribute("95270", "95270", new string[0])]
        public void 補零功能PadZero(string input, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("input", input);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("補零功能（PadZero）", "補零（PadZero）應在驗證（Verify）之後，才可做出準確的結果\r\n只有可正規化的地號，才會執行補零", tagsOfScenario, argumentsOfScenario, featureTags);
#line 108
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 111
 testRunner.Given(string.Format("輸入地號 \"{0}\"", input), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 112
 testRunner.When("執行驗證", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 113
 testRunner.And("執行補零", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 114
 testRunner.Then(string.Format("地號回傳結果為 \"{0}\"", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="地號正規化(輸入格式正確)")]
        [Xunit.TraitAttribute("FeatureTitle", "地號正規化工具")]
        [Xunit.TraitAttribute("Description", "地號正規化(輸入格式正確)")]
        [Xunit.InlineDataAttribute("１２３－４５６", "0123-0456", "true", "false", new string[0])]
        [Xunit.InlineDataAttribute("0 0 0 1 - 0 0 0 1", "0001-0001", "true", "false", new string[0])]
        [Xunit.InlineDataAttribute("５６７８", "5678-0000", "true", "false", new string[0])]
        [Xunit.InlineDataAttribute("（全形　空白與括號）", "(全形空白與括號)", "false", "true", new string[0])]
        [Xunit.InlineDataAttribute("（自訂）", "(自訂)", "false", "true", new string[0])]
        [Xunit.InlineDataAttribute("12300456", "1230-0456", "true", "false", new string[0])]
        [Xunit.InlineDataAttribute("1230 0 456", "1230-0456", "true", "false", new string[0])]
        [Xunit.InlineDataAttribute("1", "0001-0000", "true", "false", new string[0])]
        [Xunit.InlineDataAttribute("5-6", "0005-0006", "true", "false", new string[0])]
        public void 地號正規化輸入格式正確(string input, string result, string isNormalized, string isCustom, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("input", input);
            argumentsOfScenario.Add("result", result);
            argumentsOfScenario.Add("IsNormalized", isNormalized);
            argumentsOfScenario.Add("IsCustom", isCustom);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("地號正規化(輸入格式正確)", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 127
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 128
 testRunner.Given(string.Format("輸入地號 \"{0}\"", input), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 129
 testRunner.When("執行正規化", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 130
 testRunner.Then(string.Format("地號回傳結果為 \"{0}\"", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 131
 testRunner.And(string.Format("驗證（判斷是否為可正規化的地號）結果為 \"{0}\"", isNormalized), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 132
 testRunner.And(string.Format("驗證（判斷是否為自定義地號）結果為 \"{0}\"", isCustom), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 133
 testRunner.And("沒有錯誤訊息", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="地號正規化(輸入格式無法正規化)")]
        [Xunit.TraitAttribute("FeatureTitle", "地號正規化工具")]
        [Xunit.TraitAttribute("Description", "地號正規化(輸入格式無法正規化)")]
        [Xunit.InlineDataAttribute("123-456-789", "123-456-789", "false", "false", "非標準地號", new string[0])]
        [Xunit.InlineDataAttribute("ab c", "abc", "false", "false", "非標準地號", new string[0])]
        [Xunit.InlineDataAttribute("xy- z", "xy-z", "false", "false", "非標準地號", new string[0])]
        [Xunit.InlineDataAttribute("林 班地", "林班地", "false", "false", "非標準地號", new string[0])]
        [Xunit.InlineDataAttribute("", "", "false", "false", "地號不可為空", new string[0])]
        [Xunit.InlineDataAttribute("123-45678", "123-45678", "false", "false", "非標準地號", new string[0])]
        public void 地號正規化輸入格式無法正規化(string input, string result, string isNormalized, string isCustom, string error_Message, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("input", input);
            argumentsOfScenario.Add("result", result);
            argumentsOfScenario.Add("IsNormalized", isNormalized);
            argumentsOfScenario.Add("IsCustom", isCustom);
            argumentsOfScenario.Add("error_message", error_Message);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("地號正規化(輸入格式無法正規化)", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 149
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 150
 testRunner.Given(string.Format("輸入地號 \"{0}\"", input), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 151
 testRunner.When("執行正規化", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 152
 testRunner.Then(string.Format("地號回傳結果為 \"{0}\"", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 153
 testRunner.And(string.Format("驗證（判斷是否為可正規化的地號）結果為 \"{0}\"", isNormalized), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 154
 testRunner.And(string.Format("驗證（判斷是否為自定義地號）結果為 \"{0}\"", isCustom), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 155
 testRunner.And(string.Format("錯誤訊息為 \"{0}\"", error_Message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                地號正規化工具Feature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                地號正規化工具Feature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
