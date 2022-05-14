using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SmartHome.Gui.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow( )
        {
            InitializeComponent( );
        }
        
        private void InitializeComponent( )
        {
            AvaloniaXamlLoader.Load( this );
        }
    }
}