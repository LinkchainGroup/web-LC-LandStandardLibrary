@LandNoTool
@地號正規化工具
Feature: LandNoTool

標準化地號工具
驗證輸入的地號字串，確認是否正規化

#=============================================================================

Scenario: 地號正規化(輸入格式正確)
	Given 輸入地號 "<input>"
	When 執行正規化
	Then 地號回傳結果為 "<result>"
	And 正規化結果為 "<normalization_status>"
	And 沒有錯誤訊息

Examples:
	| input   | result    | normalization_status |
	| １２３－４５６ | 0123-0456 | true                 |

#=============================================================================

Scenario: 地號正規化(輸入格式無法正規化)
	Given 輸入地號 "<input>"
	When 執行正規化
	Then 正規化結果為 "<normalization_status>"
	And 錯誤訊息為 "<error_message>"

Examples:
	| input       | normalization_status | error_message |
	| 123-456-789 | false                | 非標準地號         |

#=============================================================================

Scenario Outline: 地號驗證
	Given 輸入地號 "<input>"
	When 執行驗證
	Then 正規化結果為 "<normalization_status>"
	And 錯誤訊息為 "<error_message>"

Examples:
	| input     | normalization_status | error_message |
	| 123-456   | true                 |               |
	| 12345     | false                | 非標準地號         |
	| 123-45678 | false                | 非標準地號         |
	| abc-def   | false                | 非標準地號         |
	|           | false                | 地號不可為空        |
	| (自訂)      | false                |               |

#=============================================================================

Scenario: 地號補零
	Given 輸入地號 "<input>"
	When 執行補零
	Then 地號回傳結果為 "<expected_landNo>"

Examples:
	| input  | expected_landNo |
	| 123-45 | 0123-0045      |

#=============================================================================