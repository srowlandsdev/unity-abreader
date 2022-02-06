using System.IO.Compression;
using System.Diagnostics;
using ABReader.Debug;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace ABReader.Export
{
    public class ABReaderUnzipper
    {
        ABReaderDebug logger = new();
        public void ReadEntriesInArchive(string source)
        {
            Stopwatch timer = new();
            timer.Start();

            logger.LogMessage($"Beginning unzip process from archive: {source}");
            using (ZipArchive archive = ZipFile.OpenRead(source))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    logger.LogMessage($"Entry found: {entry.FullName}");
                }
            }

            timer.Stop();
            logger.LogMessage($"Archive entries checked, process complete in {timer.ElapsedMilliseconds} milliseconds");
            timer.Reset();
        }

        public void ReadEntriesFromArchiveToJson(string source)
        {
            Archive jsonArchive = new();

            Stopwatch timer = new();
            timer.Start();

            logger.LogMessage($"Beginning JSON read from archive: {source}");
            using (ZipArchive archive = ZipFile.OpenRead(source))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    Entry newJsonEntry = new()
                    {
                        name = entry.FullName,
                        lastWrite = entry.LastWriteTime,
                        compressionLength = entry.CompressedLength
                    };

                    jsonArchive.entries.Add(newJsonEntry);
                }
            }

            string json = JsonUtility.ToJson(jsonArchive, true);
            string savePath = EditorUtility.SaveFilePanel("Please Choose Where to Save the JSON Data", "", "archive_read_data", "json");

            File.WriteAllText(savePath, json);

            timer.Stop();
            logger.LogMessage($"Archive entries output to JSON, process complete in {timer.ElapsedMilliseconds} milliseconds");
            timer.Reset();
        }

        public void CopyArchiveToLocalDisk(string source, string outputPath)
        {
            Stopwatch timer = new();
            timer.Start();

            logger.LogMessage($"Beginning extract process from archive: {source} to {outputPath}");

            ZipFile.ExtractToDirectory(source, outputPath);

            timer.Stop();
            logger.LogMessage($"Archive entries extracted, process complete in {timer.ElapsedMilliseconds} milliseconds");
            timer.Reset();
        }
    }
}