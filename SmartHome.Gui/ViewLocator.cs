using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using SmartHome.Gui.Interfaces;
namespace SmartHome.Gui
{
    public class ViewLocator : IDataTemplate
    {
        public IControl Build( object data )
        {
            IControl? control = ( ( IModelBase ) data ).Control;
            return control ?? new TextBlock { Text = "Not Found: " + data.GetType( ).FullName };
        }

        public bool Match( object data )
        {
            return data is IModelBase;
        }
    }
}