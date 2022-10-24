using System.Text;

namespace BlazorForm.Models;
public class FormGroup : AbstractControl
{

  private FormGroup ( params (string name, AbstractControl control)[] controls )
  {
    Controls = controls.ToDictionary (x => x.name, x => x.control);
    foreach ( var item in Controls )
      item.Value.OnTouched += Control_OnTouched;
  }

  public static FormGroup Create ( params (string name, AbstractControl control)[] controls )
  {
    return new FormGroup (controls);
  }

  public IDictionary<string, AbstractControl> Controls { get; private set; } = new Dictionary<string, AbstractControl> ();
  public override string GetValue ()
  {
    var sb = new StringBuilder ();

    sb.Append ("{");
    var count = 0;
    foreach ( var control in Controls )
    {
      sb.Append ($"\"{control.Key}\": {control.Value.GetValue ()}");
      if ( count < Controls.Count - 1 )
        sb.Append (",");
      count++;
    }
    sb.Append ("}");
    return sb.ToString ();
  }

  public override bool IsValid => base.IsValid && Controls.All (c => c.Value.IsValid);
  public override void Disable ()
  {
    base.Disable ();
    foreach ( var item in Controls )
      item.Value.Disable ();
  }
  public override void Enable ()
  {
    base.Enable ();
    foreach ( var item in Controls )
      item.Value.Enable ();
  }
  public void AddControl ( string name, AbstractControl control )
  {
    Controls.Add (name, control);
    control.OnTouched += Control_OnTouched;
  }

  public override void Validate ()
  {

    foreach ( var item in Controls )
    {
      item.Value.Validate ();
    }
    base.Validate ();
  }

  private void Control_OnTouched () => MarkAsTouched ();

}
