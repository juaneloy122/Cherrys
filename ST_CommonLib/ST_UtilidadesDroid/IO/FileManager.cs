using Android.App;
using Android.Content;
using Android.Support.V4.Content;
using Android.Webkit;
using Java.Util.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ST.UtilidadesDroid.IO
{

    /// <summary>
    /// Funciones comunes sobre ficheros en moviles Android
    /// </summary>
    public class FileManager //: AMF.IO.AMF_FileManager
    {

        private string m_rootFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);


        private string ToFullPathIfNeeded(string nameOrPath)
        {
            var result = nameOrPath;

            if (!nameOrPath.StartsWith(m_rootFolder))
            {
                result = Path.Combine(m_rootFolder, nameOrPath);
            }

            return result;
        }

        public async Task<string> ReadText(string filename)
        {
            var filePath = ToFullPathIfNeeded(filename);
            return File.ReadAllText(filePath);
        }

        public async Task<byte[]> ReadBytes(string filename)
        {
            var filePath = ToFullPathIfNeeded(filename);
            return File.ReadAllBytes(filePath);
        }

        public async Task WriteText(string filename, string text)
        {
            var filePath = ToFullPathIfNeeded(filename);
            File.WriteAllText(filePath, text);
        }

        public async Task AppendText(string filename, string text)
        {
            var filePath = ToFullPathIfNeeded(filename);
            File.AppendAllText(filePath, text);
        }

        public async Task<string> CreateFileIfNotExist(string filename)
        {
            var filePath = ToFullPathIfNeeded(filename);
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            return filePath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns>The full path</returns>
        public async Task<string> CreateFolderIfNotExist(string directoryName)
        {
            var directoryPath = ToFullPathIfNeeded(directoryName);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            return directoryPath;
        }

        public async Task<IEnumerable<string>> ListFiles(string directoryName, string searchRegEx = ".*")
        {
            var directoryPath = ToFullPathIfNeeded(directoryName);

            if (!Directory.Exists(directoryPath))
                return null;

            Regex reSearchPattern = new Regex(searchRegEx, RegexOptions.IgnoreCase);
            return Directory.EnumerateFiles(directoryPath).Where(file => reSearchPattern.IsMatch(file)).ToList();
        }

        public async Task<IEnumerable<ST.Utilidades.IO.FileAttributes>> ListFileAttributes(string directoryName, string searchRegEx = ".*")
        {
            var filePaths = await ListFiles(directoryName, searchRegEx);

            if (filePaths == null)
                return null;

            var result = new List<ST.Utilidades.IO.FileAttributes>();

            foreach (var file in filePaths)
            {
                result.Add(new ST.Utilidades.IO.FileAttributes
                {
                    CreationDate = File.GetCreationTime(file),
                    FullPath = file,
                    Name = Path.GetFileName(file)
                });
            }

            return result;
        }

        public async Task<bool> DeleteFileIfExist(string fileName)
        {
            var filePath = ToFullPathIfNeeded(fileName);
            if (!File.Exists(filePath))
                return false;

            File.Delete(filePath);

            return true;
        }


        /// <summary>
        /// Compresses the specified log files to the specified zip file
        /// </summary>
        /// <param name="zipFile"></param>
        /// <param name="filePathsToInclude"></param>
        /// <returns></returns>
        public async Task ZipFiles(string zipFile, IEnumerable<string> filePathsToInclude)
        {
            FileStream fNewZipFileStream;
            ZipOutputStream zos;

            try
            {
                var zipFilePath = ToFullPathIfNeeded(zipFile);
                fNewZipFileStream = File.Create(zipFilePath);
                zos = new ZipOutputStream(fNewZipFileStream);

                foreach (string filePath in filePathsToInclude)
                {
                    ZipEntry entry = new ZipEntry(Path.GetFileName(filePath));
                    zos.PutNextEntry(entry);

                    byte[] fileContents = File.ReadAllBytes(filePath);
                    zos.Write(fileContents);
                    zos.CloseEntry();
                }
                zos.Close();
                fNewZipFileStream.Close();
            }
            finally
            {
                fNewZipFileStream = null;
                zos = null;
            }
        }

        /// <summary>
        /// Shares a file after copying it to external storage.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileTypeDescription"></param>
        /// <returns></returns>
        public async Task SaveFileAs(string fileName, string fileTypeDescription = null)
        {
            var folder = Path.Combine(global::Android.OS.Environment.ExternalStorageDirectory.Path, "Download");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var externalPath = Path.Combine(folder, Path.GetFileName(fileName));

            File.Copy(ToFullPathIfNeeded(fileName), externalPath, true);

            var uri = Android.Net.Uri.FromFile(new Java.IO.File(externalPath));

            string extension = MimeTypeMap.GetFileExtensionFromUrl(fileName);

            string mimeType = MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);

            var intent = new Intent(Intent.ActionSend);
            intent.SetType(mimeType);
            intent.PutExtra(Intent.ExtraStream, uri);
            intent.PutExtra(Intent.ExtraSubject, Path.GetFileName(fileName));
            intent.PutExtra(Intent.ExtraText, fileTypeDescription);
            intent.SetFlags(ActivityFlags.GrantReadUriPermission | ActivityFlags.GrantWriteUriPermission);

            var chooserIntent = Intent.CreateChooser(intent, "Share File");
            chooserIntent.SetFlags(ActivityFlags.NewTask);

            Application.Context.StartActivity(chooserIntent);


        }

        /// <summary>
        /// Descarga el fichero apk en la carpeta externa descargas y trata de instalarlo
        /// </summary>
        /// <param name="fileUri"></param>
        /// <param name="appPackageName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Wether or not the file was downloaded</returns>
        public async Task<bool> DownloadAndInstallApk(Uri fileUri, string appPackageName, string userName, string password)
        {
            bool result = false;

            var folder = Path.Combine(global::Android.OS.Environment.ExternalStorageDirectory.Path, "Download");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var filePath = Path.Combine(folder, fileUri.Segments.Last());

            using (var webClient = new WebClient())
            {
                if (!string.IsNullOrEmpty(userName))
                    webClient.Credentials = new NetworkCredential(userName, password);

                await webClient.DownloadFileTaskAsync(fileUri, filePath);
            }

            if (File.Exists(filePath))
            {
                result = true;

                Java.IO.File file = new Java.IO.File(filePath);

                try
                {
                    if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.N)
                    {
                        Android.Net.Uri uri = FileProvider.GetUriForFile(Application.Context, appPackageName, file);
                        Intent promptInstall = new Intent(Intent.ActionInstallPackage);
                        promptInstall.SetData(uri);
                        promptInstall.AddFlags(ActivityFlags.GrantReadUriPermission);
                        Application.Context.StartActivity(promptInstall);
                    }
                    else
                    {
                        Intent intent = new Intent(Intent.ActionView);
                        Android.Net.Uri uri = Android.Net.Uri.FromFile(file);
                        intent.SetDataAndType(uri, "application/vnd.android.package-archive");
                        intent.SetFlags(ActivityFlags.NewTask);
                        Application.Context.StartActivity(intent);
                    }

                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error tratando de descargar e instalar APK: {0}", e);
                    return result;
                }
            }

            return result;
        }



        /// <summary>
        /// Descarga un fichero
        /// </summary>
        /// <param name="fileUri"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>File bytes</returns>
        public async Task<bool> DownloadFile(Uri fileUri, string localFileName, string userName = null, string password = null)
        {

            try
            {
                var filePath = ToFullPathIfNeeded(localFileName);

                using (var webClient = new WebClient())
                {
                    if (!string.IsNullOrEmpty(userName))
                        webClient.Credentials = new NetworkCredential(userName, password);

                    await webClient.DownloadFileTaskAsync(fileUri, filePath);
                }

                if (File.Exists(filePath))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }
    }
}
