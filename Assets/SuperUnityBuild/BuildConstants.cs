using System;

// This file is auto-generated. Do not modify or move this file.

namespace SuperUnityBuild.Generated
{
    public enum ReleaseType
    {
        None,
        Release,
    }

    public enum Platform
    {
        None,
        Linux,
        PC,
        macOS,
    }

    public enum ScriptingBackend
    {
        None,
        Mono,
    }

    public enum Architecture
    {
        None,
        Linux_x64,
        Windows_x86,
        macOS,
    }

    public enum Distribution
    {
        None,
    }

    public static class BuildConstants
    {
        public static readonly DateTime buildDate = new DateTime(638689326140107980);
        public const string version = "1.0.0.1";
        public const ReleaseType releaseType = ReleaseType.Release;
        public const Platform platform = Platform.macOS;
        public const ScriptingBackend scriptingBackend = ScriptingBackend.Mono;
        public const Architecture architecture = Architecture.macOS;
        public const Distribution distribution = Distribution.None;
    }
}

