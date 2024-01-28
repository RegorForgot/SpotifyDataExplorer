using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace SpotifyDataExplorer.Views;

public partial class PageView : UserControl
{
    public PageView()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        ItemControlScrollViewer?.ScrollToHome();
    }
}