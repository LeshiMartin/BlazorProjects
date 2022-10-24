namespace FormField.Models;

public interface IAbstractControl
{
  IList<ValidationFormError> Errors { get; }
  bool IsDisabled { get; set; }

  event Action ValidationChange;

  void Disable ();
  void Enable ();
}