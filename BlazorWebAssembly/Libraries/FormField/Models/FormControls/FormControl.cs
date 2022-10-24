namespace FormField.Models.FormControls;
public interface FormControl: IAbstractControl
{

  public string Name { get;  }

  public string Label { get; set; } 

  public abstract object? GetValue ();
 
  public bool IsValid { get; } //
  public string State { get; } //;
}
