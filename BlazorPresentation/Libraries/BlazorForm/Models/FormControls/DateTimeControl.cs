namespace BlazorForm.Models.FormControls;
public class DateTimeControl : AbstractControl
{
  public DateTimeControl (
    DateTime? value = null,
    string label = "",
    bool isDisabled = false )
  {
    Value = value.HasValue ? new DateTime (value!.Value.Year,
      value.Value.Month,
      value.Value.Day,
      value.Value.Hour,
      value.Value.Minute,
      0) : null;
    Label = label;
    IsDisabled = isDisabled;
  }


  private DateTime? _value;

  public DateTime? Value
  {
    get { return _value; }
    set
    {
      _value = value;
      ValueChanged (value);
    }
  }


  public override string GetValue () => $"\"{Value}\"";
}
