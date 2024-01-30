using Avalonia.Controls;
using Avalonia.Media;
using SpotifyDataExplorer.Utilities;

namespace SpotifyDataExplorer.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        TransparencyLevelHint = new[] { WindowTransparencyLevel.Mica, WindowTransparencyLevel.None };

        if (RuntimeLocator.IsWindows11)
        {
            Background = new SolidColorBrush(Colors.Transparent);
        }
    }
}