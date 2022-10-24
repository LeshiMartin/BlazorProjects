using FormField.Models;
using FormField.Models.FormControls;
using System.Text.Json;
using Xunit;

namespace FormFieldTests;
public class FormGroupTests
{
  [Fact]
  public void GetValue_Should_Return_Instance ()
  {
    var fg = new FormGroup ();
    var c = new MockClass ();
    var str = JsonSerializer.Serialize (c);
    fg.Controls.Add (new TextFormControl ("Name") { Value = "Test" });
    var val = fg.GetValue<MockClass> ();

    Assert.NotNull (val);
  }
}


class MockClass
{
  public string Name { get; set; } = string.Empty;
}