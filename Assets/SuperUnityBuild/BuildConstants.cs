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
    }

    public enum Distribution
    {
        None,
    }

    public static class BuildConstants
    {
        public static readonly DateTime buildDate = new DateTime(638689386136030080);
        public const string version = "1.0.0.1";
        public const ReleaseType releaseType = ReleaseType.Release;
        public const Platform platform = Platform.Linux;
        public const ScriptingBackend scriptingBackend = ScriptingBackend.Mono;
        public const Architecture architecture = Architecture.Linux_x64;
        public const Distribution distribution = Distribution.None;
    }
}

