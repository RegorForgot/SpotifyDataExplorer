using SpotifyDataExplorer.Models;

namespace SpotifyDataExplorer.Extensions;

public static class EnumExtensions
{
    public static PlayReason ConvertToPlayReason(this string playReasonString)
    {
        return playReasonString.ToLower() switch
        {
            "unknown" => PlayReason.Unknown,
            "backbtn" => PlayReason.BackBtn,
            "playbtn" => PlayReason.PlayBtn,
            "fwdbutton" => PlayReason.FwdBtn,
            "trackdone" => PlayReason.TrackDone,
            "endplay" => PlayReason.EndPlay,
            "clickrow" => PlayReason.ClickRow,
            "appload" => PlayReason.AppLoad,
            "remote" => PlayReason.Remote,
            "logout" => PlayReason.Logout,
            "unexpected-exit" => PlayReason.UnexpectedExit,
            "unexpected-exit-while-paused" => PlayReason.UnexpectedExitWhilePaused,
            "trackerror" => PlayReason.TrackError,
            _ => PlayReason.Unknown
        };
    }
}