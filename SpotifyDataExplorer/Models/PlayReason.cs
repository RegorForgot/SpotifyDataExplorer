namespace SpotifyDataExplorer.Models;

public enum PlayReason
{
    Unknown = 0,
    BackBtn,
    PlayBtn,
    FwdBtn,
    TrackDone,
    EndPlay,
    ClickRow,
    AppLoad,
    Remote,
    Logout,
    UnexpectedExit,
    UnexpectedExitWhilePaused,
    TrackError
}