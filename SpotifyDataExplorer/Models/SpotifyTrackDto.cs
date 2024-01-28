using System.Text.Json.Serialization;

namespace SpotifyDataExplorer.Models;

public record SpotifyTrackDto
{
    [JsonPropertyName("ts")]
    public string UTCTimestamp { get; init; }

    [JsonPropertyName("ms_played")]
    public int TimePlayed { get; init; }

    [JsonPropertyName("master_metadata_track_name")]
    public string TrackName { get; init; }

    [JsonPropertyName("master_metadata_album_artist_name")]
    public string ArtistName { get; init; }

    [JsonPropertyName("master_metadata_album_album_name")]
    public string AlbumName { get; init; }

    [JsonPropertyName("spotify_track_uri")]
    public string SpotifyURI { get; init; }

    [JsonPropertyName("reason_start")]
    public string StartReason { get; init; }

    [JsonPropertyName("reason_end")]
    public string EndReason { get; init; }

    [JsonPropertyName("incognito_mode")]
    public bool Incognito { get; init; }

    public bool IsValid => !string.IsNullOrEmpty(SpotifyURI);
}