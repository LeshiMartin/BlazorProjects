namespace ControlModels;
public abstract class AbstractControl<T>
{
    private bool _isDisabled { get; set; }

    public void Enable () => _isDisabled = false;
    public void Disable () => _isDisabled = true;
    public bool IsDisabled () => _isDisabled;
    public abstract T GetValue ();

    protected HashSet<Func<T, bool>> _validators { get; set; } = new ();

    public void AddValidation ( Func<T, bool> validator )
    {
        _validators.Add (validator);
    }

    public abstract void Validate ();
    private bool _isValid { get; set; } = true;

    public bool IsValid () => _isValid;

    protected void SetValidState ( bool state ) => _isValid = state;
}

public class TextControl : AbstractControl<string>
{
    public TextControl ( string value )
    {
        _value = value;
    }

    private string _value { get; set; }

    public override string GetValue () => _value;
    public override void Validate ()
    {
        SetValidState (true);
        foreach ( var validator in _validators )
        {
            if ( !validator (_value) )
            {
                SetValidState (false);
            }
        }
    }
}
