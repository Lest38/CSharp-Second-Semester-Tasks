using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HospitalManagement.Services;

/// <summary>
/// Service class for managing hospital operations including patient and diagnosis management.
/// </summary>
public class HospitalService
{
    private readonly DiagnosisService _diagnosisService = new();
    private readonly PatientService _patientService = new();
    private readonly FileService _fileService = new();
    public List<Patient> Patients { get; } = [];
    public List<Diagnosis> Diagnoses { get; } = [];
    private readonly string _defaultPatientsFileContent = """
        Smith, 25, 2025-01-10, 2025-01-22, Flu
        Johnson, 40, 2025-02-15, 2025-02-20, Angina
        Williams, 30, 2025-03-01, 2025-03-04, Diabetes
        Brown, 45, 2025-03-10, 2025-03-25, Obesity
        """;
    private readonly string _defaultDiagnosesFileContent = """
        Flu, 12, Therapy
        Angina, 5, ENT
        Diabetes, 3, Endocrinology
        Obesity, 15, Endocrinology
        """;

    /// <summary>
    /// Initializes the hospital service with default data files for patients and diagnoses.
    /// </summary>
    /// <param name="patientsFile"></param>
    /// <param name="diagnosesFile"></param>
    public void LoadData(string patientsFile, string diagnosesFile)
    {
        _fileService.InitializeDataFile(patientsFile, _defaultPatientsFileContent);
        _fileService.InitializeDataFile(diagnosesFile, _defaultDiagnosesFileContent);
        _patientService.ReadPatientsFromFile(patientsFile, Patients);
        _diagnosisService.ReadDiagnosesFromFile(diagnosesFile, Diagnoses);
        LinkPatientsWithDiagnoses();
    }

    /// <summary>
    /// Links patients with their diagnoses and sets the department and discharge date based on the diagnosis.
    /// </summary>
    private void LinkPatientsWithDiagnoses()
    {
        foreach (var patient in Patients)
        {
            var diagnosis = Diagnoses.FirstOrDefault(d => d.Name.Equals(patient.Diagnosis, StringComparison.OrdinalIgnoreCase));
            if (diagnosis != null)
            {
                diagnosis.RegisterObserver(patient);
                patient.Department = diagnosis.Department;
                patient.DischargeDate = patient.AdmissionDate.AddDays(diagnosis.TreatmentDuration);
            }
        }
    }
}