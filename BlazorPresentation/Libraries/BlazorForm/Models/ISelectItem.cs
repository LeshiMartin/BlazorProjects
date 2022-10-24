namespace BlazorForm.Models;
public interface ISelectItem
{
  public string Value { get; set; }
  public string Text { get; set; }
  public bool IsDisabled { get; set; }
  public bool IsChecked { get; set; }
}
