using System.Windows;
using System.Windows.Controls;
using DependencyResolution;
using Itk.Explorer.Core;
using Itk.Explorer.Core.Hello;

namespace Itk.Explorer.Ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private IEventBus _eventBus;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (_eventBus == null && sender is Button button)
            {
                _eventBus = button.RequestInstance<IEventBus>();
            }
            if (Equals(sender, Hello))
                _eventBus?.Publish(new HelloEvent());
            if (Equals(sender, GoodBye))
                _eventBus?.Publish(new GoodByeEvent());
        }
    }
}