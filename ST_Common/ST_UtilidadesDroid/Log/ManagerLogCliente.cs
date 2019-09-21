using ST_Utilidades.Comunicaciones;
using ST_UtilidadesDroid.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ST_Utilidades.Log
{
    public class ManagerLogCliente
    {
        private FileManager m_fileManager = new FileManager();
        private static string m_logsFolder;

        private string m_logsDirectoryName = "logs";
        /// <summary>
        /// The directory in the local file system where the log files will be stored. Defaults to "logs".
        /// </summary>
        public string LogsDirectoryName
        {
            get { return m_logsDirectoryName; }
            set { m_logsDirectoryName = value; }
        }

        private string m_logFileNameTemplate = "LOG_{0}.txt";
        /// <summary>
        /// A template for the generated log files. Needs a placeholder {0} for the timestamp. Must have an extension. Defaults to "LOG_{0}.log".
        /// </summary>
        public string LogFileNameTemplate
        {
            get { return m_logFileNameTemplate; }
            set { m_logFileNameTemplate = value; }
        }

        private string m_fileNameTimestampFormat = "yyyyMMdd";
        /// <summary>
        /// A datetime format string used to create a timestamp for the file names. Defaults to "yyyyMMdd". This conditions the granularity of the log files:<br/>
        /// If set to "yyyy_MM", it will create a log file per month. 
        /// </summary>
        public string FileNameTimestampFormat
        {
            get { return m_fileNameTimestampFormat; }
            set { m_fileNameTimestampFormat = value; }
        }

        private string m_logZipFileNameTemplate = "LOGS_{0}.zip";
        /// <summary>
        /// A default template for the exported zipped log files, the user may change this name. Needs a placeholder {0} for the timestamp. 
        /// Must have zip extension extension. Defaults to "LOGS_{0}.zip".
        /// </summary>
        public string LogZipFileNameTemplate
        {
            get { return m_logZipFileNameTemplate; }
            set { m_logZipFileNameTemplate = value; }
        }

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
                result = await NetHelper.PostFile(await m_fileManager.ReadBytes(filePath), Path.GetFileName(filePath), uploadUrl, uriParameters, userName, password);

            }
            catch (Exception ex)
            {
                throw new Exception("Logger was unable to upload the log files.", ex);
            }
            finally
            {
                // Delete the temporary zip
                if (!string.IsNullOrEmpty(filePath))
                    await m_fileManager.DeleteFileIfExist(filePath);
            }

            return result;
        }

        /// <summary>
        /// Gets the folder that stores the log files. Creates it if necessary.
        /// </summary>
        /// <returns></returns>
        private async Task<string> GetLogsFolder()
        {
            if (m_logsFolder == null)
            {
                m_logsFolder = await m_fileManager.CreateFolderIfNotExist(LogsDirectoryName);
            }

            return m_logsFolder;
        }

        /// <summary>
        /// Gets the current log folder that stores the log files. Creates it if necessary.
        /// </summary>
        /// <returns></returns>
        private async Task<IEnumerable<string>> GetLogFiles()
        {
            string logFileExtension = Path.GetExtension(LogFileNameTemplate);
            var logsFolder = await GetLogsFolder();

            return await m_fileManager.ListFiles(logsFolder, string.Format(@".*\{0}$", logFileExtension));
        }

        /// <summary>
        /// Compresses the logs to a temporary zip file in the local folder
        /// </summary>
        /// <returns></returns>
        private async Task<string> CreateTempZipFile()
        {
            string zipFileName = Path.Combine(await GetLogsFolder(), GetZipFileName(DateTime.Now));

            await m_fileManager.ZipFiles(zipFileName, await GetLogFiles());

            return zipFileName;
        }

        public string GetZipFileName(DateTime dateTime)
        {
            return string.Format(LogZipFileNameTemplate, dateTime.ToString(FileNameTimestampFormat));
        }
    }
}
