using Avalonia.Controls;

namespace SmartHome.Gui.Interfaces;

public interface IViewBase
{
    IModelBase? Model { get; set; }
}