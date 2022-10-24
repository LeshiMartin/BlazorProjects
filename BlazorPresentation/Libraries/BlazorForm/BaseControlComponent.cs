using BlazorForm.Models;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo ("BlazorFormTests")]
namespace BlazorForm;
public class BaseControlComponent : ComponentBase
{
  [Parameter]
  public Appereances Appereance { get; set; } = Appereances.Standard;
  protected string AppereanceClass => Appereance.ToString ().ToLower ();

  [Parameter]
  public Colors Color { get; set; } = Colors.Primary;
  protected string ColorClass => Color.ToString ().ToLower ();
  [Parameter]
  public AbstractControl? AbstractControl { get; set; }
  [CascadingParameter]
  public FormGroup? FormGroup { get; set; }
  [Parameter]
  public string? FormControlName { get; set; }
  protected bool ControlIsValid ()
  {
    return AbstractControl is not null ||
      (FormGroup is not null && !string.IsNullOrEmpty (FormControlName));
  }
}


public enum Appereances
{
  Standard = 10,
  Filled = 20,
  Outline = 30,
}

public enum Colors
{
  Primary = 10,
  Accent = 20,
  Warn = 30,
}

public enum Orientation
{
  Horizontal = 10,
  Vertical = 20,
}