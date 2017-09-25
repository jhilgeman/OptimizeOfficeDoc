using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizeOfficeDoc
{
    public static class Compression
    {
        public static void CreateZIPFile(string zipFileName, string fromFolder)
        {
            List<string> files = Directory.EnumerateFiles(fromFolder, "*", SearchOption.AllDirectories).ToList<string>();
            Console.WriteLine("Creating new package: " + zipFileName + "...");

            List<string> createdFolders = new List<string>();
            if(File.Exists(zipFileName))
            {
                File.Delete(zipFileName);
            }
            using (FileStream zipToOpen = new FileStream(zipFileName, FileMode.CreateNew))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    foreach (string file in files)
                    {
                        string zipEntryRelativeFilename = file.Substring(fromFolder.Length).TrimStart(new char[] { '\\' }).Replace('\\', '/');

                        // Create any sub-folder entries if need be
                        if (zipEntryRelativeFilename.Contains("/"))
                        {
                            StringBuilder sbFolderPath = new StringBuilder();
                            string[] folderPieces = zipEntryRelativeFilename.Split(new char[] { '/' });
                            for (int i = 0; i < folderPieces.Length - 1; i++)
                            {
                                // Incrementally create sub-folder entries
                                // E.g. original file entry is foo\bar\image.jpg
                                //      1. Add foo\ (Folder)
                                //      2. Add foo\bar\ (Folder)
                                //      3. Finally add foo\bar\image.jpg (File)
                                sbFolderPath.Append(folderPieces[i] + "/");
                                string tmpPath = sbFolderPath.ToString(); // .TrimEnd(new char[] { '/' })
                                if (!createdFolders.Contains(tmpPath))
                                {
                                    Console.WriteLine("  Adding " + tmpPath + "...");
                                    archive.CreateEntry(tmpPath);
                                    createdFolders.Add(tmpPath);
                                }
                            }
                        }
                        Console.WriteLine("  Adding " + zipEntryRelativeFilename + "...");
                        ZipArchiveEntry zipEntry = archive.CreateEntry(zipEntryRelativeFilename);
                        using (BinaryWriter writer = new BinaryWriter(zipEntry.Open()))
                        {
                            writer.Write(File.ReadAllBytes(file));
                        }
                    }
                }
            }
        }

        public static void UnZIPFile(string zipFileName, string toFolder)
        {
            if(!File.Exists(zipFileName)) { throw new FileNotFoundException("", zipFileName);  }

            using (FileStream zipToOpen = new FileStream(zipFileName, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
                {
                    archive.ExtractToDirectory(toFolder);
                }
            }
        }
    }
}
