# 地號標準化工具

地號標準是8碼，例如 0001-0000、0213-0001。

但使用者常常輸入神奇的格式，例如 1、00010000、213-1、１２３－４５６...等神奇字串。

使用者輸入的字串，需要經過許多前置處理，例如去除空白、全形轉半形、補零，等步驟。

此工具將多個步驟包裝成一個 `Normalize()` 函式，無痛解決地號正規化的問題。

使用 `Builder Pattern` ，可依需要單獨呼叫函式。

## 使用說明

### Normalize()

```csharp
var landString = "  25 -１ ";
var normalizedLands = new LandNoTool(landString).Normalize().Build();
// "0025-0001"
```

```csharp
public interface ILandNoTool
{
    /// <summary>
    /// 取得標準化地號列表
    /// </summary>
    List<LandNoResult> Build();
    /// <summary>
    /// 正規化(包含以下全部)
    /// </summary>
    LandNoTool Normalize();

    /// <summary>
    /// 去除空白
    /// </summary>
    LandNoTool Trim();
    /// <summary>
    /// 全形轉半形
    /// </summary>
    LandNoTool FullToHalf();
    /// <summary>
    /// 驗證地號正確性
    /// </summary>
    LandNoTool Verify();
    /// <summary>
    /// 補Dash
    /// </summary>
    LandNoTool PadDash();
    /// <summary>
    /// 補零
    /// </summary>
    LandNoTool PadZero();
}

/// <summary>
/// 地號標準化結果Model
/// </summary>
public class LandNoResult
{
    /// <summary>
    /// 地號
    /// </summary>
    public string LandNo { get; set; } = "";
    /// <summary>
    /// 是否為自定義地號
    /// </summary>
    public bool IsCustom { get; set; } = false;
    /// <summary>
    /// 是否成功標準化
    /// </summary>
    public bool IsNormalized { get; set; } = false;
    /// <summary>
    /// 錯誤訊息
    /// </summary>
    public string ErrorMsg { get; set; } = "";
    /// <summary>
    /// 參照用的ID
    /// </summary>
    public int ID { get; set; } = 0;
}
```