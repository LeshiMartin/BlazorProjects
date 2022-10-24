using BlazorForm.Models;

namespace BlazorWasm;

public class TestSelectItem : ISelectItem
{
  public TestSelectItem (string value, string text)
  {
    Value = value;
    Text = text;
  }
  public string Value { get; set; } = string.Empty;
  public string Text { get; set; } = string.Empty;
  public bool IsDisabled { get; set; }
  public bool IsChecked { get; set; }
}
