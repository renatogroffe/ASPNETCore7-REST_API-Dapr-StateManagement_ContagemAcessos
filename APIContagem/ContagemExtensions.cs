using System.Runtime.InteropServices;

namespace APIContagem;

public static class ContagemExtensions
{
    public static string Local { get; }
    public static string Kernel { get; }
    public static string Framework { get; }

    static ContagemExtensions()
    {
        Local = Environment.MachineName;
        Kernel = Environment.OSVersion.VersionString;
        Framework = RuntimeInformation.FrameworkDescription;
    }
}