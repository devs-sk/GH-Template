using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace Devs_GH_Pipeline;

internal static class Properties
{
    public static readonly Bitmap ShipIcon = GetBitmap("ship");


    public static Stream GetStream(string resourceName)
    {
        var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        return stream ?? throw new ArgumentException($"The embedded resource '{resourceName}' was not found.",
                                                     nameof(resourceName));
    }

    public static Bitmap GetBitmap(string resourceName)
    {
        return new Bitmap(GetStream(resourceName));
    }
}
