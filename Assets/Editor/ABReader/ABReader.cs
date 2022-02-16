using UnityEditor;
using ABReader.Logic;
using ABReader.Export;
using ABReader.Debug;

namespace ABReader
{
    public class ABReaderTool : Editor
    {
        static ABReaderLogic abLogic = new();

        #region Folder
        [MenuItem("ABReader/Asset Bundle Folder/Read From Folder")]
        static public void ABReadFromFolderSync()
        {
            string path = EditorUtility.OpenFolderPanel("Select asset bundle directory to read from", "", "");
            abLogic.ReadBundleFiles(path);
        }

        [MenuItem("ABReader/Asset Bundle Folder/Read From Folder Async")]
        static public void ABReadFromFolderASync()
        {
            string path = EditorUtility.OpenFolderPanel("Select asset bundle directory to read from", "", "");
            abLogic.ReadBundleFilesAsync(path);
        }

        [MenuItem("ABReader/Asset Bundle Folder/JSON Export From Folder")]
        static public void ABJsonFromFolder()
        {
            string path = EditorUtility.OpenFolderPanel("Select asset bundle directory to read from", "", "");
            abLogic.JsonFromPath(path);
        }
        #endregion

        #region File
        [MenuItem("ABReader/Asset Bundle File/Read From File")]
        static public void ABReadFromFileSync()
        {
            string path = EditorUtility.OpenFilePanel("Select asset bundle file to read from", "", "");
            abLogic.ReadBundleFiles(path);
        }

        [MenuItem("ABReader/Asset Bundle File/Read From File Async")]
        static public void ABReadFromFileASync()
        {
            string path = EditorUtility.OpenFilePanel("Select asset bundle file to read from", "", "");
            abLogic.ReadBundleFilesAsync(path);
        }

        [MenuItem("ABReader/Asset Bundle File/JSON Export From File")]
        static public void ABJsonFromFile()
        {
            string path = EditorUtility.OpenFilePanel("Select asset bundle file to read from", "", "");
            abLogic.JsonFromPath(path);
        }
        #endregion

        #region Archive
        [MenuItem("ABReader/Compressed Archive/Read From Zip Archive")]
        static public void ABReadFromArchive()
        {
            ABReaderUnzipper unzipper = new();
            string inputPath = EditorUtility.OpenFilePanel("Select Compressed Archive to Read from", "", "");
            unzipper.ReadEntriesInArchive(inputPath);
        }

        [MenuItem("ABReader/Compressed Archive/Extract Archive Data")]
        static void ABExtractAndCopyArchiveData()
        {
            ABReaderUnzipper unzipper = new();
            string inputPath = EditorUtility.OpenFilePanel("Select compressed archive to read from", "", "");
            string outputPath = EditorUtility.OpenFolderPanel("Select folder to export data to", "", "");
            unzipper.CopyArchiveToLocalDisk(inputPath, outputPath);
        }

        [MenuItem("ABReader/Compressed Archive/JSON Export From Archive")]
        static public void ABJsonFromArchive()
        {
            ABReaderUnzipper unzipper = new();
            string inputPath = EditorUtility.OpenFilePanel("Select compressed archive to Read from", "", "");
            unzipper.ReadEntriesFromArchiveToJson(inputPath);
        }
        #endregion
    }
}