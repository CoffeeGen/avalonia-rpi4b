using Avalonia.Controls;

namespace SmartHome.Gui.Interfaces;

public interface IModelBase
{
    IControl? Control { get; set; }
}