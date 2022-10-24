namespace BlazorForm.Models;
public abstract class AbstractControl
{

  private string _label = string.Empty;

  public string Label
  {
    get { return Validators.Any () ? $"{_label} *" : _label; }
    set { _label = value; }
  }


  public ICollection<ControlErrors> Errors { get; private set; } = new HashSet<ControlErrors> ();
  public ICollection<ValidationFunc> Validators { get; private set; } = new HashSet<ValidationFunc> ();
  public virtual bool IsValid => Errors.Count == 0;
  public string IsValidStr => IsValid ? "VALID" : "INVALID";
  public bool IsDisabled { get; protected set; }
  public virtual void Disable () => IsDisabled = true;
  public virtual void Enable () => IsDisabled = false;
  public bool IsTouched { get; private set; }
  public virtual void MarkAsTouched ()
  {
    IsTouched = true;
    OnTouched ();
  }
  public event Action OnTouched = delegate { };
  public event Action OnValidation = delegate { };
  public event Action<object?> OnValueChanged = delegate { };
  protected void ValueChanged ( object? value )
  {
    OnValueChanged (value);
  }
  public abstract string GetValue ();
  public void AddError ( ControlErrors error )
  {
    Errors.Add (error);
  }
  public void AddValidation ( ValidationFunc validation ) => Validators.Add (validation);
  public virtual void Validate ()
  {
    Errors.Clear ();
    foreach ( var validation in Validators )
    {
      var error = validation (this);
      if ( error is not null )
      {
        AddError (error);
      }
    }
    OnValidation ();
  }


}

public delegate ControlErrors? ValidationFunc ( AbstractControl control );

public class ControlErrors
{
  public ControlErrors ( string name, string message )
  {
    Name = name;
    Message = message;
  }
  public string Name { get; private set; } = string.Empty;
  public string Message { get; private set; } = string.Empty;
}
