using System;
using System.Linq;
using System.Reflection;

namespace Devs_GH_Pipeline;

/// <summary>
/// The Monoceros Pro configuration and constants.
/// </summary>
internal class Config
{

    internal static string VersionHint
    {
        get
        {
            var name = "";
            var version = "";
            var assembly = Assembly.Load(Assembly.GetExecutingAssembly().FullName);
            foreach (Attribute a in assembly.GetCustomAttributes(true).Cast<Attribute>())
            {
                if (a is AssemblyTitleAttribute attributeTitle)
                    name = attributeTitle.Title;

                if (a is AssemblyFileVersionAttribute attributeVersion)
                    version += " " + attributeVersion.Version;
            }
            return $"DEVS {name} {version}";
        }
    }

}
