﻿using System;
using System.Globalization;
using SpotifyDataExplorer.Extensions;

namespace SpotifyDataExplorer.Models;

public record SpotifyTrack
{
    public SpotifyTrack(SpotifyTrackDto spotifyTrackDto)
    {
        Timestamp = DateTime.Parse(spotifyTrackDto.UTCTimestamp, styles: DateTimeStyles.AdjustToUniversal);
        TimePlayed = TimeSpan.FromMilliseconds(spotifyTrackDto.TimePlayed);
        TrackName = spotifyTrackDto.TrackName;
        ArtistName = spotifyTrackDto.ArtistName;
        AlbumName = spotifyTrackDto.AlbumName;

        string uriIdentifier = spotifyTrackDto.SpotifyURI.Split(":")[2];
        TrackURL = $"https://open.spotify.com/track/{uriIdentifier}";

        StartReason = spotifyTrackDto.StartReason.ConvertToPlayReason();
        EndReason = spotifyTrackDto.EndReason.ConvertToPlayReason();

        Incognito = spotifyTrackDto.Incognito;
    }

    public DateTime Timestamp { get; init; }
    public TimeSpan TimePlayed { get; init; }
    public string TrackName { get; init; }
    public string ArtistName { get; init; }
    public string AlbumName { get; init; }
    public string TrackURL { get; init; }
    public PlayReason StartReason { get; init; }
    public PlayReason EndReason { get; init; }
    public bool Incognito { get; init; }
}