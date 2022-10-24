namespace BlazorForm.Models.FormControls;
public class TimeOnlyControl : AbstractControl
{
  public TimeOnlyControl ( DateTime? value = null, string label = "", bool isDisabled = false )
  {
    Value = value.HasValue ? new TimeOnly (value.Value.Hour, value.Value.Minute) : null;
    Label = label;
    IsDisabled = isDisabled;
  }

  private TimeOnly? _value;

  public TimeOnly? Value
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
