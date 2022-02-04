using System;
using System.IO.Compression;
using System.Diagnostics;
using ABReader.Debug;
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

        public void CopyArchiveAndReadFromLocalDisk(string source, string outputPath)
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