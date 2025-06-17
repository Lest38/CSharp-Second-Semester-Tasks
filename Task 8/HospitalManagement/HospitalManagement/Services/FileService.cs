using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services
{
    /// <summary>
    /// Service for managing file operations related to hospital data.
    /// </summary>
    public class FileService
    {
        /// <summary>
        /// Initializes a data file with default content if it does not exist or is empty.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="defaultContent"></param>
        public void InitializeDataFile(string filePath, string defaultContent)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
                AppendToFile(filePath, defaultContent);
            }
            else if (new FileInfo(filePath).Length == 0)
            {
                AppendToFile(filePath, defaultContent);
            }
        }

        /// <summary>
        /// Appends content to a file, creating the file if it does not exist.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="content"></param>
        public void AppendToFile(string filePath, string content)
        {
            try
            {
                using StreamWriter sw = File.AppendText(filePath);
                sw.WriteLine(content);
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }
    }
}
