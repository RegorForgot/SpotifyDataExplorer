﻿using SpotifyDataExplorer.ViewModels.Pages;

namespace SpotifyDataExplorer.ViewModels;

public class MainWindowViewModel : AbstractViewModel
{
    public UIContext UIContext { get; }

    public MainWindowViewModel(UIContext uiContext)
    {
        UIContext = uiContext;
        UIContext.AddPage(new StartPageViewModel(UIContext));
    }
}