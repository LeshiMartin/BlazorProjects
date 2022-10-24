using BlazorForm.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorForm;
public partial class FormGroupComponent : ComponentBase
{
  [Parameter]
  public FormGroup? FormGroup { get; set; }

  [Parameter]
  public RenderFragment? Controls { get; set; }


  [Parameter]
  public RenderFragment? Buttons { get; set; }

  [Parameter]
  public EventCallback<FormGroup> OnValidSubmit { get; set; }

  [Parameter]
  public EventCallback<FormGroup> OnInvalidSubmit { get; set; }

  protected override void OnParametersSet ()
  {
    if ( FormGroup == null )
    {
      throw new ArgumentNullException (nameof (FormGroup));
    }
    if ( Controls == null )
    {
      throw new ArgumentNullException (nameof (Controls));
    }

    base.OnParametersSet ();
  }

  internal async Task OnSubmit ()
  {
    FormGroup!.Validate ();
    if ( FormGroup!.IsValid )
    {
      await OnValidSubmit.InvokeAsync (FormGroup);
    }
    else
    {
      await OnInvalidSubmit.InvokeAsync (FormGroup);
    }
  }
}
