namespace BlazorForm.Models.FormControls;
public class NumberControl : AbstractControl
{
  public NumberControl ( 
    int? value = null,
    string label = "",
    bool isDisabled = false )
  {
    Value = value;
    Label = label;
    IsDisabled = isDisabled;
  }

  private int? _value;

  public int? Value
  {
    get { return _value; }
    set
    {
      _value = value;
      ValueChanged (Value);
    }
  }


  public override string GetValue () => $"{Value}";
}
