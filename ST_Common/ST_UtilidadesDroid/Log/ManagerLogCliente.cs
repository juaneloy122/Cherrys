using ST_Utilidades.Comunicaciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ST_Utilidades.Log
{
    public class ManagerLogCliente
    {
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
    }
}
