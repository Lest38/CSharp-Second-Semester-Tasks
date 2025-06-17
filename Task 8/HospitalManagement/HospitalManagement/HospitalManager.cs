using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Models;
using HospitalManagement.Services;

namespace HospitalManagement
{
    /// <summary>
    /// Main class for managing the hospital system.
    /// </summary>
    public class HospitalManager
    {
        private readonly string _filePathPatients = Path.Combine(AppContext.BaseDirectory, "patients.txt");
        private readonly string _filePathDiagnoses = Path.Combine(AppContext.BaseDirectory, "diagnoses.txt");

        /// <summary>
        /// Initializes a new instance of the <see cref="HospitalManager"/> class.
        /// </summary>
        public void Run()
        {
            var hospitalService = new HospitalService();
            var patientService = new PatientService();

            try
            {
                hospitalService.LoadData(_filePathPatients, _filePathDiagnoses);

                while (true)
                {
                    Console.WriteLine("\nHospital Management System");
                    Console.WriteLine("1. View patients by department");
                    Console.WriteLine("2. View average age of patients");
                    Console.WriteLine("3. View patients by diagnosis");
                    Console.WriteLine("4. View patients with long stays");
                    Console.WriteLine("5. Change diagnosis");
                    Console.WriteLine("6. Exit");
                    Console.Write("Select an option: ");

                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            patientService.PrintPatientsByDepartment(hospitalService.Patients);
                            break;
                        case "2":
                            patientService.PrintAverageAge(hospitalService.Patients);
                            break;
                        case "3":
                            Console.Write("Enter diagnosis to search: ");
                            var diagnosis = Console.ReadLine();
                            patientService.PrintPatientsWithDiagnosis(hospitalService.Patients, diagnosis);
                            break;
                        case "4":
                            Console.Write("Enter minimum number of days: ");
                            if (int.TryParse(Console.ReadLine(), out int days))
                            {
                                patientService.PrintPatientsWithLongStay(hospitalService.Patients, days);
                            }
                            else
                            {
                                Console.WriteLine("Invalid number of days entered.");
                            }
                            break;
                        case "5":
                            ChangeDiagnosis(hospitalService);
                            break;
                        case "6":
                            return;
                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Changes the diagnosis of a patient and updates the related information.
        /// </summary>
        /// <param name="service"></param>
        static void ChangeDiagnosis(HospitalService service)
        {
            Console.WriteLine("\nDiagnosis list:");
            for (int i = 0; i < service.Diagnoses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {service.Diagnoses[i].Name}");
            }

            Console.Write("\nChoose diagnosis number to change it: ");
            int choice = int.Parse(Console.ReadLine()!) - 1;

            if (choice >= 0 && choice < service.Diagnoses.Count)
            {
                var selectedDiagnosis = service.Diagnoses[choice];

                Console.Write($"\nCurrent department for {selectedDiagnosis.Name}: {selectedDiagnosis.Department}\nInput a new department: ");
                selectedDiagnosis.Department = Console.ReadLine()!;

                Console.Write($"\nCurrent treatment duration for {selectedDiagnosis.Name}: {selectedDiagnosis.TreatmentDuration} days\nnInput a new treatment duration: ");
                selectedDiagnosis.TreatmentDuration = int.Parse(Console.ReadLine()!);

                Console.WriteLine("\nNew information:");
                var affectedPatients = service.Patients.Where(p => p.Diagnosis == selectedDiagnosis.Name);
                foreach (var patient in affectedPatients)
                {
                    patient.PrintInfo();
                }
            }
            else
            {
                Console.WriteLine("Wrong diagnosis choise.");
            }
        }
    }
}
