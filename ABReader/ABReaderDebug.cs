using System.IO;
using UnityEngine;

namespace ABReader.Debug
{
    public class ABReaderDebug
    {
        public void LogMessage(string message)
        {
            UnityEngine.Debug.Log($"[ABReader] {message}");
        }

        public void LogBundleHashcode(AssetBundle bundle)
        {
            UnityEngine.Debug.Log($"[ABReader] Bundle hashcode:{bundle.GetHashCode()}");
        }

        public void LogBundleType(AssetBundle bundle)
        {
            UnityEngine.Debug.Log($"[ABReader] Bundle type:{bundle.GetType()}");
        }

        public void LogBundleElementData(AssetBundle bundle)
        {
            UnityEngine.Debug.Log($"[ABReader][Bundle type:{bundle.GetType()}][Bundle hashcode:{bundle.GetHashCode()}][Bundle instance ID:{bundle.GetInstanceID()}]");
        }

        public void LogAllBundleData(AssetBundle bundle)
        {
            UnityEngine.Debug.Log($"[ABReader][Asset names:{bundle.GetAllAssetNames()}]" +
                $"[Scene paths:{bundle.GetAllScenePaths()}]" +
                $"[Bundle type:{bundle.GetType()}]" +
                $"[Is Streamed:{bundle.isStreamedSceneAssetBundle}]" +
                $"[Bundle hashcode:{bundle.GetHashCode()}]" +
                $"[Bundle instance ID:{bundle.GetInstanceID()}]");
        }

        public void LogWarningIfBundleIsNull(Object context)
        {
            UnityEngine.Debug.LogWarning($"<color=yellow>[ABReader] Loaded asset bundle is returing null!</color>", context);
        }

        public void LogErrorIfPathEmpty(string path)
        {
            UnityEngine.Debug.LogError($"<color=red>[ABReader] Provided path:{path} is null or empty!</color>");
        }

        public void LogFolderPaths(string[] files)
        {
            foreach (string s in files)
            {
                string fPath = Path.GetFullPath(s);

                UnityEngine.Debug.Log($"[ABReader] Asset folder path: {fPath}");
            }
        }

        public void LogBundleAssetNames(string[] files)
        {
            foreach(string a in files)
            {
                UnityEngine.Debug.Log($"[ABReader] Asset name: {a}");
            }
        }

        public void LogBundleScenePaths(string[] files)
        {
            foreach (string a in files)
            {
                UnityEngine.Debug.Log($"[ABReader] Scene path: {a}");
            }
        }
    }
}