namespace BlazorForm.Models.FormControls;

public delegate string ValueConverter ( string value );
public class TextControl : AbstractControl
{
  public TextControl (
    string value = "",
    string label = "",
    bool isDisabled = false )
  {
    Value = value;
    Label = label;
    IsDisabled = isDisabled;
  }

 
  private string _value = string.Empty;

  public string Value
  {
    get { return _value; }
    set
    {
      _value = value;
      ValueChanged (value);
    }
  }

  private ValueConverter? ValueConverter;

  public override string GetValue ()
  {
    if ( ValueConverter != null )
    {
      return ValueConverter ( Value);
    }
    return $"\"{Value}\"";
  }

  public void AddValueConverter ( ValueConverter converter )
  {
    ValueConverter = converter;
  }

}
