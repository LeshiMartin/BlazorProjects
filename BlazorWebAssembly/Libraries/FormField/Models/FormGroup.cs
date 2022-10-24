using FormField.Models.FormControls;
using System.Text;
using System.Text.Json;

namespace FormField.Models;


public class FormGroup : AbstractControl
{
  public ICollection<FormControl> Controls { get; private set; } = new HashSet<FormControl> ();

  public T GetValue<T> ()
  {
    var sb = new StringBuilder ();
    sb.Append ("{");
    var strs = Controls.Select (x => $"\"{x.Name}\":\"{x.GetValue ()}\"");
    sb.Append (string.Join (",", strs));
    sb.Append ("}");
    var str = sb.ToString ();
    return JsonSerializer.Deserialize<T> (sb.ToString ())!;
  }

  public override void Disable ()
  {
    base.Disable ();
    foreach ( var item in Controls )
      item.Disable ();
  }

  public override void Enable ()
  {
    base.Enable ();
    foreach ( var item in Controls )
      item.Enable ();
  }
  public bool IsValid => Errors.Count == 0 && Controls.All (x => x.IsValid);
  public string State => IsValid ? "VALID" : "INVALID";
}

