namespace FormField.Models;
public delegate ValidationFormError? AbstractFormValidator ( AbstractControl control, params string[] controls );
public abstract class AbstractControl : IAbstractControl
{
  public bool IsDisabled { get; set; }

  public virtual void Disable () => IsDisabled = true;
  public virtual void Enable () => IsDisabled = false;
  private IEnumerable<AbstractFormValidator> Validators { get; set; } = new HashSet<AbstractFormValidator> ();

  public IList<ValidationFormError> Errors { get; private set; } = new List<ValidationFormError> ();

  public event Action ValidationChange = delegate { };

  protected void Validate ()
  {
    Errors.Clear ();
    foreach ( var item in Validators )
    {
      var response = item (this);
      if ( response is not null )
        Errors.Add (response);
    }
    ValidationChange ();
  }
}
