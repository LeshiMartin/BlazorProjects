using BlazorForm.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm;
public partial class SubFormGroupComponent : ComponentBase
{

  [CascadingParameter]
  public FormGroup? FormGroup { get; set; }

  [Parameter]
  public string FormControlName { get; set; } = string.Empty;

  [Parameter]
  public RenderFragment? Controls { get; set; }

  internal FormGroup? SubGroup { get; set; }


  protected override void OnParametersSet ()
  {
    if ( FormGroup == null )
    {
      throw new ArgumentNullException ("FormGroup");
    }
    if ( string.IsNullOrEmpty (FormControlName) )
    {
      throw new ArgumentNullException ("FormControlName");
    }
    base.OnParametersSet ();
    SubGroup = FormGroup!.Controls![ FormControlName ]! as FormGroup;
  }
}
