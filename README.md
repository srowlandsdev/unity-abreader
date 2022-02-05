# ABReader
ABReader is a Unity plugin written in C# and intended as a validation tool that can be used during development to validate the contents of generated asset bundles for releases. It
can be used to point at an individual asset bundle or collection by selecting the parent folder then retrieve information from them. The tool uses Unity standard API calls to meet this goal. In addition, it has custom functionality to export the data into JSON and also add a custom logging class to provide user feedback in the editor and the log file

# Project Features:
- Read an array of Unity asset bundles by way of passing a folder path or single file path where they are
located on disk
- Export the asset bundle(s) available data into the JSON data structure format
- Custom debug logging class and methods to provide detailed output for the ABReader system
- Read asset bundles from within an archive (OBB, APK, ZIP) and also extract them to a local directory
- Export the asset bundle entry data from an archive (OBB, APK, ZIP)

# Installation
Installation is simple and you can either opt to install by importing the .unitypackage I have provided in the releases or download, extract and add the source code into the Editor folder on your Unity project.

Once you have installed the tool then refer to the in editor toolbar for a new header called ABReader, click it and the options are presented in a list
