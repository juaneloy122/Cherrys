using ST.Utilidades.Comunicaciones;
using ST.UtilidadesDroid.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ST.Utilidades.Log
{
    public class ManagerLogCliente
    {
        private FileManager _FileManager = new FileManager();
        private static string _DirectorioLogs;

        /// <summary>
        /// El nombre del directorio por defecto donde se almacenarán los logs, por defecto "logs".
        /// </summary>
        public string LogsDirectoryName { get; set; } = "logs";

        /// <summary>
        /// El nombre que se usa por defecto para el archivo de log. (Log_20190911.txt).
        /// </summary>
        public string LogFileNameTemplate { get; set; } = "Log_{0}.txt";


        /// <summary>
        /// Por defecto consideramos que almacena un fichero al día
        /// </summary>
        public string FileNameTimestampFormat { get; set; } = "yyyyMMdd";

        /// <summary>
        ///  El nombre que se usa por defecto para el archivo de log. (Log_20190911.zip).
        /// </summary>
        public string LogZipFileNameTemplate { get; set; } = "LOGS_{0}.zip";

        /// <summary>
        /// Posts the logs zipped to an url with the specified query parameters.
        /// </summary>
        /// <param name="uploadUrl"></param>
        /// <param name="file"></param>
        /// <param name="uriParameters">Additional url query string</param>
        /// <param name="userName">Basic authentication username</param>
        /// <param name="password">Basic authentication password</param>
        /// <returns></returns>
        public async Task<string> UploadLogs(string uploadUrl, string uriParameters = null, string userName = null, string password = null)
        {
            string result = null;
            string filePath = null;
            try
            {
                // Create a temporary zip file
                filePath = await CreateTempZipFile();
                result = await NetHelper.PostFile(await _FileManager.ReadBytes(filePath), Path.GetFileName(filePath), uploadUrl, uriParameters, userName, password);

            }
            catch (Exception ex)
            {
                throw new Exception("Logger was unable to upload the log files.", ex);
            }
            finally
            {
                // Delete the temporary zip
                if (!string.IsNullOrEmpty(filePath))
                    await _FileManager.DeleteFileIfExist(filePath);
            }

            return result;
        }

        /// <summary>
        /// Devuelve todos los archivos dentro de un directorio de tipo .txt en este caso
        /// </summary>
        /// <returns></returns>
        private async Task<IEnumerable<string>> GetLogFiles()
        {
            string logFileExtension = Path.GetExtension(LogFileNameTemplate);

            return await _FileManager.ListFiles(_DirectorioLogs, string.Format(@".*\{0}$", logFileExtension));
        }

        /// <summary>
        /// Comprime los archivos de log en un fichero Log_20190911.zip
        /// </summary>
        /// <returns></returns>
        private async Task<string> CreateTempZipFile()
        {
            string zipFileName = Path.Combine(LogsDirectoryName, GetZipFileName(DateTime.Now));

            await _FileManager.ZipFiles(zipFileName, await GetLogFiles());

            return zipFileName;
        }

        public string GetZipFileName(DateTime dateTime)
        {
            return string.Format(LogZipFileNameTemplate, dateTime.ToString(FileNameTimestampFormat));
        }
    }
}
