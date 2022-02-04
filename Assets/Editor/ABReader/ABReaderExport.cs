using System;
using System.Collections.Generic;

namespace ABReader.Export
{
    [Serializable]
    public class Bundles
    {
        public List<BundleData> bundles = new();
    }

    [Serializable]
    public class BundleData
    {
        public int hashcode;
        public int instanceId;
        public Type type;
        public bool isStreamedSceneBundle;
        public string[] assetNames;
        public string[] scenePaths;
    }

    [Serializable]
    public class Archive
    {
        public List<Entry> entries = new();
    }

    [Serializable]
    public class Entry
    {
        public string name;
        public DateTimeOffset lastWrite;
        public long compressionLength;
    }
}
