using UnityEditor;
using ABReader.Logic;
using ABReader.Export;

namespace ABReader
{
    public class ABReaderTool : Editor
    {
        static readonly ABReaderLogic abLogic = new();

        [MenuItem("ABReader/Read From Folder")]
        static void ABReadFromFolderSync()
        {
            string path = EditorUtility.OpenFolderPanel("Select Asset Bundle Directory to Read from", "", "");
            abLogic.ReadBundleFiles(path);
        }

        [MenuItem("ABReader/Read From Folder Async")]
        static void ABReadFromFolderASync()
        {
            string path = EditorUtility.OpenFolderPanel("Select Asset Bundle Directory to Read from", "", "");
            abLogic.ReadBundleFilesAsync(path);
        }

        [MenuItem("ABReader/JSON Export From Folder")]
        static void ABJsonFromFolder()
        {
            string path = EditorUtility.OpenFolderPanel("Select Asset Bundle Directory to Read from", "", "");
            abLogic.JsonFromPath(path);
        }

        [MenuItem("ABReader/Read From File")]
        static void ABReadFromFileSync()
        {
            string path = EditorUtility.OpenFilePanel("Select Asset Bundle File to Read from", "", "");
            abLogic.ReadBundleFiles(path);
        }

        [MenuItem("ABReader/Read From File Async")]
        static void ABReadFromFileASync()
        {
            string path = EditorUtility.OpenFilePanel("Select Asset Bundle File to Read from", "", "");
            abLogic.ReadBundleFilesAsync(path);
        }

        [MenuItem("ABReader/JSON Export From File")]
        static void ABJsonFromFile()
        {
            string path = EditorUtility.OpenFilePanel("Select Asset Bundle File to Read from", "", "");
            abLogic.JsonFromPath(path);
        }

        [MenuItem("ABReader/Read From Zip Archive")]
        static void ABReadFromArchive()
        {
            ABReaderUnzipper unzipper = new();
            string inputPath = EditorUtility.OpenFilePanel("Select Compressed Archive to Read from", "", "");
            unzipper.ReadEntriesInArchive(inputPath);
        }

        [MenuItem("ABReader/Copy Zip Archive and Read")]
        static void ABCopyAndReadFromArchive()
        {
            ABReaderUnzipper unzipper = new();
            string inputPath = EditorUtility.OpenFilePanel("Select Compressed Archive to Read from", "", "");
            string outputPath = EditorUtility.OpenFolderPanel("Select Destination to Export to", "", "");
            unzipper.CopyArchiveAndReadFromLocalDisk(inputPath, outputPath);
        }
    }
}