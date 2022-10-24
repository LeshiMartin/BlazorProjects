namespace FormField.Models.FormControls;
public class TextFormControl:AbstractControl, FormControl
{
  public TextFormControl (string name)
  {
    Name = name;
  }
  private string? _value;

  public string? Value
  {
    get { return _value; }
    set
    {
      _value = value;
      Validate ();
    }
  }

  public string Name { get;private set; }
  public string Label { get; set; }
  public bool IsValid => Errors.Count == 0;
  public string State => IsValid ? "VALID" : "INVALID";

  public  object? GetValue () => Value;
}
