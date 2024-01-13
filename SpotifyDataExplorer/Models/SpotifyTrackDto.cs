using Newtonsoft.Json;

namespace SpotifyDataExplorer.Models;

public record SpotifyTrackDto
{
    [JsonProperty("ts")]
    public string UTCTimestamp { get; init; }

    [JsonProperty("ms_played")]
    public int TimePlayed { get; init; }

    [JsonProperty("master_metadata_track_name")]
    public string TrackName { get; init; }

    [JsonProperty("master_metadata_album_artist_name")]
    public string ArtistName { get; init; }

    [JsonProperty("master_metadata_album_album_name")]
    public string AlbumName { get; init; }

    [JsonProperty("spotify_track_uri")]
    public string SpotifyURI { get; init; }

    [JsonProperty("reason_start")]
    public string StartReason { get; init; }

    [JsonProperty("reason_end")]
    public string EndReason { get; init; }

    [JsonProperty("incognito_mode")]
    public bool Incognito { get; init; }

    public bool IsValid => !string.IsNullOrEmpty(SpotifyURI);
}