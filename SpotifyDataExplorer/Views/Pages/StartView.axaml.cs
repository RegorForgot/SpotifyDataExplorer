using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using SpotifyDataExplorer.ViewModels.Pages;
using FilePickerFileTypes = SpotifyDataExplorer.Utilities.FilePickerFileTypes;

namespace SpotifyDataExplorer.Views.Pages;

public partial class StartView : UserControl
{
    public StartView()
    {
        InitializeComponent();
    }

    private async void JsonImportOnClick(object? sender, RoutedEventArgs e)
    {
        TopLevel? topLevel = TopLevel.GetTopLevel(this);
        
        var files = await topLevel?.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Open endsong JSON files",
            AllowMultiple = true,
            FileTypeFilter = new[] { FilePickerFileTypes.JsonOnly, }
        })!;

        if (files.Count < 1)
        {
            return;
        }

        (DataContext as StartViewModel)?.GetJsonFilesCmd.Execute(files);
    }
}