using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services
{
    /// <summary>
    /// Service for managing diagnoses and their related operations.
    /// </summary>
    public class DiagnosisService
    {
        private FileService _fileService;

        /// <summary>
        /// Reads diagnosis data from a file and populates the provided list of diagnoses.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="Diagnoses"></param>
        public void ReadDiagnosesFromFile(string filename, List<Diagnosis> Diagnoses)
        {
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines.Where(l => !string.IsNullOrWhiteSpace(l)))
            {
                var parts = line.Split(',');
                if (parts.Length >= 3)
                {
                    var diagnosis = new Diagnosis(
                        parts[0].Trim(),
                        int.Parse(parts[1].Trim()),
                        parts[2].Trim());
                    Diagnoses.Add(diagnosis);
                }
            }
        }

        /// <summary>
        /// Adds a new diagnosis to the list and appends it to the diagnoses file.
        /// </summary>
        /// <param name="diagnosesFile"></param>
        /// <param name="diagnosis"></param>
        /// <param name="Diagnoses"></param>
        public void AddNewDiagnosis(string diagnosesFile, Diagnosis diagnosis, List<Diagnosis> Diagnoses)
        {
            Diagnoses.Add(diagnosis);
            string diagnosisData = $"{diagnosis.Name}, {diagnosis.TreatmentDuration}, {diagnosis.Department}";
            _fileService.AppendToFile(diagnosesFile, diagnosisData);
        }
    }
}
