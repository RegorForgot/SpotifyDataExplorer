using SpotifyDataExplorer.ViewModels.Pages;

namespace SpotifyDataExplorer.ViewModels;

public class MainWindowViewModel : AbstractViewModel
{
    public StartViewModel StartViewModel { get; }
    
    public MainWindowViewModel(StartViewModel startViewModel)
    {
        StartViewModel = startViewModel;
    }
}