using Avalonia.Platform.Storage;

namespace SpotifyDataExplorer.Utilities;

public static class FilePickerFileTypes
{
    public static FilePickerFileType JsonOnly = new FilePickerFileType("JSON")
    {
        Patterns = new[] { "*.json" },
        AppleUniformTypeIdentifiers = new[] { "public.json" },
        MimeTypes = new[] { "application/json" }
    };
}