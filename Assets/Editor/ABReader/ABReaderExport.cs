using System;
using System.Collections.Generic;

namespace ABReader.Export
{
    [Serializable]
    public class Bundles
    {
        public List<BundleData> bundles = new List<BundleData>();
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
}
