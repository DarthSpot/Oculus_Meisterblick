namespace Oculus.Core;

internal static class Settings
{
    public static string AppFolder { get; } =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Oculus_Meisterblick");

    public static void EnsureAppFolderExists()
    {
        if (Directory.Exists(AppFolder))
            return;

        Directory.CreateDirectory(AppFolder);
    }
}