using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services
{
    /// <summary>
    /// Service for managing patient data and operations.
    /// </summary>
    public class PatientService
    {
        private FileService _fileService;

        /// <summary>
        /// Reads patient data from a file and populates the provided list of patients.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="Patients"></param>
        public void ReadPatientsFromFile(string filename, List<Patient> Patients)
        {
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines.Where(l => !string.IsNullOrWhiteSpace(l)))
            {
                var parts = line.Split(',');
                if (parts.Length >= Patient.fileParts)
                {
                    var patient = new Patient
                    {
                        LastName = parts[0].Trim(),
                        Age = int.Parse(parts[1].Trim()),
                        AdmissionDate = DateTime.Parse(parts[2].Trim()),
                        DischargeDate = DateTime.Parse(parts[3].Trim()),
                        Diagnosis = parts[4].Trim()
                    };
                    Patients.Add(patient);
                }
            }
        }

        /// <summary>
        /// Prints a formatted list of patients grouped by their department.
        /// </summary>
        /// <param name="Patients"></param>
        public void PrintPatientsByDepartment(List<Patient> Patients)
        {
            var departments = Patients.Select(p => p.Department).Distinct().OrderBy(d => d);

            foreach (var department in departments)
            {
                Console.WriteLine($"\n{department}");
                Console.WriteLine(new string('-', 80));
                Console.WriteLine("|#   |Last Name      |Diagnosis            |Stay Duration|Age   |");
                Console.WriteLine(new string('-', 80));

                int counter = 1;
                foreach (var patient in Patients.Where(p => p.Department == department))
                {
                    Console.WriteLine($"|{counter,-4}|{patient.LastName,-15}|{patient.Diagnosis,-20}|{patient.StayDuration,12} |{patient.Age,6}|");
                    counter++;
                }
                Console.WriteLine(new string('-', 80));
            }
        }

        /// <summary>
        /// Adds a new patient to the list and appends their data to the specified file.
        /// </summary>
        /// <param name="patientsFile"></param>
        /// <param name="patient"></param>
        /// <param name="Patients"></param>
        public void AddNewPatient(string patientsFile, Patient patient, List<Patient> Patients)
        {
            Patients.Add(patient);
            string patientData = $"{patient.LastName}, {patient.Age}, {patient.AdmissionDate:yyyy-MM-dd}, {patient.DischargeDate:yyyy-MM-dd}, {patient.Diagnosis}";
            _fileService.AppendToFile(patientsFile, patientData);
        }

        /// <summary>
        /// Calculates and displays the average age of all patients.
        /// </summary>
        /// <param name="patients">List of patients</param>
        public void PrintAverageAge(List<Patient> patients)
        {
            if (patients == null || patients.Count == 0)
            {
                Console.WriteLine("No patients available to calculate average age.");
                return;
            }

            double averageAge = patients.Average(p => p.Age);
            Console.WriteLine($"\nAverage age of patients: {averageAge:F1} years");
        }

        /// <summary>
        /// Displays patients with the specified diagnosis.
        /// </summary>
        /// <param name="patients">List of patients</param>
        /// <param name="diagnosis">Diagnosis to filter by</param>
        public void PrintPatientsWithDiagnosis(List<Patient> patients, string diagnosis)
        {
            var filteredPatients = patients
                .Where(p => p.Diagnosis.Equals(diagnosis, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (filteredPatients.Count == 0)
            {
                Console.WriteLine($"\nNo patients found with diagnosis: {diagnosis}");
                return;
            }

            Console.WriteLine($"\nPatients with diagnosis '{diagnosis}':");
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("|#   |Last Name      |Admission Date |Discharge Date |Age   |Department   |");
            Console.WriteLine(new string('-', 80));

            int counter = 1;
            foreach (var patient in filteredPatients)
            {
                Console.WriteLine($"|{counter,-4}|{patient.LastName,-15}|{patient.AdmissionDate:yyyy-MM-dd}  |{patient.DischargeDate:yyyy-MM-dd}  |{patient.Age,6}|{patient.Department,-12}|");
                counter++;
            }
            Console.WriteLine(new string('-', 80));
        }

        /// <summary>
        /// Displays patients who have been in the hospital longer than the specified number of days.
        /// </summary>
        /// <param name="patients">List of patients</param>
        /// <param name="days">Minimum number of days in hospital</param>
        public void PrintPatientsWithLongStay(List<Patient> patients, int days)
        {
            var filteredPatients = patients
                .Where(p => p.StayDuration > days)
                .OrderByDescending(p => p.StayDuration)
                .ToList();

            if (filteredPatients.Count == 0)
            {
                Console.WriteLine($"\nNo patients found staying longer than {days} days");
                return;
            }

            Console.WriteLine($"\nPatients staying longer than {days} days:");
            Console.WriteLine(new string('-', 90));
            Console.WriteLine("|#   |Last Name      |Diagnosis            |Admission Date |Discharge Date |Stay Duration|");
            Console.WriteLine(new string('-', 90));

            int counter = 1;
            foreach (var patient in filteredPatients)
            {
                Console.WriteLine($"|{counter,-4}|{patient.LastName,-15}|{patient.Diagnosis,-20}|{patient.AdmissionDate:yyyy-MM-dd}  |{patient.DischargeDate:yyyy-MM-dd}  |{patient.StayDuration,12} |");
                counter++;
            }
            Console.WriteLine(new string('-', 90));
        }
    }
}
