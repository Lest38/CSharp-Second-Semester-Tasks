namespace HospitalManagement.Models;


/// <summary>
/// Represents a patient in the hospital management system.
/// </summary>
public class Patient : IObserver
{
    public string LastName { get; set; }
    public int Age { get; set; }
    public DateTime AdmissionDate { get; set; }
    public DateTime DischargeDate { get; set; }
    public string Diagnosis { get; set; }
    public string Department { get; set; }
    public static int fileParts = 5;
    public int StayDuration => (DischargeDate - AdmissionDate).Days;

    /// <summary>
    /// Initializes a new instance of the <see cref="Patient"/> class with the specified details.
    /// </summary>
    /// <param name="lastName"></param>
    /// <param name="age"></param>
    public void ChangePersonalDetails(string lastName, int age)
    {
        LastName = lastName;
        Age = age;
    }

    /// <summary>
    /// Prints the patient's information in a formatted manner.
    /// </summary>
    public void PrintInfo()
    {
        Console.WriteLine($"{LastName,-15} | {Age,5} | {AdmissionDate:yyyy-MM-dd} | {DischargeDate:yyyy-MM-dd} | {Diagnosis,-15} | {Department,-15} | {StayDuration,5} дней");
    }

    /// <summary>
    /// Updates the patient's diagnosis and notifies the department change observers.
    /// </summary>
    /// <param name="newDepartment"></param>
    public void UpdateDepartment(string newDepartment)
    {
        Department = newDepartment;
    }

    /// <summary>
    /// Updates the discharge date based on the treatment duration provided by the diagnosis.
    /// </summary>
    /// <param name="treatmentDuration"></param>
    public void UpdateDischargeDate(int treatmentDuration)
    {
        DischargeDate = AdmissionDate.AddDays(treatmentDuration);
    }
}