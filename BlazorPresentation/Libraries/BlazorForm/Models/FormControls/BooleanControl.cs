namespace BlazorForm.Models.FormControls;
public class BooleanControl : AbstractControl
{
  public BooleanControl ( 
    bool value = false,
    string label = "",
    bool isDisabled = false )
  {
    Value = value;
    Label = label;
    IsDisabled = isDisabled;
  }


  private bool _value;

  public bool Value
  {
    get { return _value; }
    set
    {
      _value = value;
      ValueChanged (value);
    }
  }
  public override string GetValue () => $"{Value}";
}
