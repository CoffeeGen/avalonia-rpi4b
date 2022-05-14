using ReactiveUI;
using SmartHome.Gui.Interfaces;
using SmartHome.Gui.Layouts;

namespace SmartHome.Gui.Windows
{
    public class MainWindowViewModel : ModelBase
    {
        private IModelBase _activeLayout;

        public IModelBase ActiveLayout
        {
            get => _activeLayout;
            set => this.RaiseAndSetIfChanged(ref _activeLayout, value);
        }

        public MainWindowViewModel( )
        {
            ActiveLayout = new Default( );
        }
    }
}