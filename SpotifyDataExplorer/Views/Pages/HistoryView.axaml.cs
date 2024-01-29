using Avalonia.Controls;
using Avalonia.Interactivity;

namespace SpotifyDataExplorer.Views.Pages;

public partial class HistoryView : UserControl
{
    public HistoryView()
    {
        InitializeComponent();
    }
    
    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        ItemControlScrollViewer?.ScrollToHome();
    }
}