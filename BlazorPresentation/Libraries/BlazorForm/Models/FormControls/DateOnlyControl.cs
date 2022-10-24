namespace BlazorForm.Models.FormControls;
public class DateOnlyControl : AbstractControl
{
  public DateOnlyControl ( 
    DateTime? value = null,
    string label = "",
    bool isDisabled = false )
  {
    Value = value.HasValue ? DateOnly.FromDateTime (value.Value) : null;
    Label = label;
    IsDisabled = isDisabled;
  }


  private DateOnly? _value;

  public DateOnly? Value
  {
    get { return _value; }
    set
    {
      _value = value;
      ValueChanged (value);
    }
  }


  public override string GetValue () => $"\"{Value?.ToString ()}\"";
}
