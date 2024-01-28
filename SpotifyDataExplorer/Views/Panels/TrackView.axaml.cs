using Avalonia.Controls;
using Avalonia.Interactivity;

namespace SpotifyDataExplorer.Views.Panels;

public partial class TrackView : UserControl
{
    public TrackView()
    {
        InitializeComponent();
    }
    
    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        ItemControlScrollViewer?.ScrollToHome();
    }
}