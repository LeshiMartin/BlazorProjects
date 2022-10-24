using BlazorForm;
using Xunit;

namespace BlazorFormTests;
public class BaseControlComponentTest
{
  [Fact]
  public void AppereanceClass_Should_Be_Standard ()
  {
    var cl = new MoxkClass ();
    var app = cl.GetAppClass();
    Assert.Equal ("standard", app);
  }
}


class MoxkClass : BaseControlComponent
{
  public string GetAppClass () => AppereanceClass;
}