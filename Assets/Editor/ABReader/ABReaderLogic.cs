using System.IO;
using System.Diagnostics;
using System.Collections;
using UnityEngine;
using UnityEditor;
using ABReader.Debug;
using ABReader.Export;

namespace ABReader.Logic
{
    public class ABReaderLogic
    {
        ABReaderDebug abLogger = new();

        public void ReadBundleFiles(string path)
        {
            string[] files = Directory.GetFiles(path, ".", SearchOption.AllDirectories);

            Stopwatch timer = new();
            timer.Start();

            if (string.IsNullOrEmpty(path))
            {
                UnityEngine.Debug.LogError("[ABReader] No path given!");
            }
            else
            {
                abLogger.LogMessage($"[ABReader] Starting bundle read of directory {path}");
                abLogger.LogFolderPaths(files);
                foreach (string file in files)
                {
                    string fPath = Path.GetFullPath(file);
                    var myLoadedAssetBundle = AssetBundle.LoadFromFile(fPath);

                    if (myLoadedAssetBundle == null)
                    {
                        abLogger.LogWarningIfBundleIsNull(myLoadedAssetBundle);
                    }

                    abLogger.LogAllBundleData(myLoadedAssetBundle);
                    myLoadedAssetBundle.Unload(false);
                }
            }
            timer.Stop();
            UnityEngine.Debug.Log($"[ABReader] Return time in milliseconds: { timer.ElapsedMilliseconds}");
            timer.Reset();
        }

        public IEnumerator ReadBundleFilesAsync(string path)
        {
            string[] files = Directory.GetFiles(path, ".", SearchOption.AllDirectories);

            Stopwatch timer = new();
            timer.Start();

            if (string.IsNullOrEmpty(path))
            {
                UnityEngine.Debug.LogError("[ABReader] No path given!");
            }
            else
            {
                UnityEngine.Debug.Log($"[ABReader] Starting bundle read of directory {path}");
                foreach (string file in files)
                {
                    string fPath = Path.GetFullPath(file);

                    UnityEngine.Debug.Log($"[ABReader] Asset path: {fPath}");

                    var bundleLoadRequest = AssetBundle.LoadFromFileAsync(fPath);
                    yield return bundleLoadRequest;

                    var myLoadedAssetBundle = bundleLoadRequest.assetBundle;

                    if (myLoadedAssetBundle == null)
                    {
                        UnityEngine.Debug.Log($"[ABREADER] Failed to load AssetBundle from path {fPath}!");
                        yield break;
                    }

                    string[] assetNames = myLoadedAssetBundle.GetAllAssetNames();

                    foreach (string name in assetNames)
                    {
                        UnityEngine.Debug.Log(name);
                    }

                    myLoadedAssetBundle.Unload(false);
                }
            }
            timer.Stop();
            UnityEngine.Debug.Log($"[ABReader] Return time in milliseconds: { timer.ElapsedMilliseconds}");
            timer.Reset();
        }

        public void JsonFromPath(string path)
        {
            string[] files = Directory.GetFiles(path, ".", SearchOption.AllDirectories);
            Bundles bundles = new Bundles();

            Stopwatch timer = new();
            timer.Start();

            if (string.IsNullOrEmpty(path))
            {
                UnityEngine.Debug.LogError("[ABReader] No path given!");
            }
            else
            {
                abLogger.LogMessage($"[ABReader] Starting bundle read of directory {path}");
                abLogger.LogFolderPaths(files);
                foreach (string file in files)
                {
                    string fPath = Path.GetFullPath(file);
                    var myLoadedAssetBundle = AssetBundle.LoadFromFile(fPath);
                    BundleData bundleData = new();

                    string[] scenePaths = myLoadedAssetBundle.GetAllScenePaths();
                    string[] assetNames = myLoadedAssetBundle.GetAllAssetNames();

                    #region Data Empty Check
                    if (myLoadedAssetBundle.GetHashCode() != 0)
                    {
                        bundleData.hashcode = myLoadedAssetBundle.GetHashCode();
                    }

                    if (myLoadedAssetBundle.GetInstanceID() != 0)
                    {
                        bundleData.instanceId = myLoadedAssetBundle.GetInstanceID();
                    }

                    if (myLoadedAssetBundle.GetType() != null)
                    {
                        bundleData.type = myLoadedAssetBundle.GetType();
                    }

                    if (assetNames.Length != 0)
                    {
                        bundleData.assetNames = assetNames;
                    }

                    if (scenePaths.Length != 0)
                    {
                        bundleData.scenePaths = scenePaths;
                    }

                    bundleData.isStreamedSceneBundle = myLoadedAssetBundle.isStreamedSceneAssetBundle;

                    if (myLoadedAssetBundle == null)
                    {
                        abLogger.LogWarningIfBundleIsNull(myLoadedAssetBundle);
                    }
                    #endregion

                    bundles.bundles.Add(bundleData);

                    myLoadedAssetBundle.Unload(false);
                }

                string json = JsonUtility.ToJson(bundles, true);
                string savePath = EditorUtility.SaveFilePanel("Please Choose Where to Save the JSON Data", "", "asset_bundle_data", "json");

                File.WriteAllText(savePath, json);
            }
            timer.Stop();
            UnityEngine.Debug.Log($"[ABReader] Return time in milliseconds: { timer.ElapsedMilliseconds}");
            timer.Reset();
        }
    }
}
