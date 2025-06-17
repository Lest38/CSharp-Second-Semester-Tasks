namespace HospitalManagement.Models;

/// <summary>
/// Represents a medical diagnosis with treatment duration and department.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="Diagnosis"/> class with the specified name, treatment duration, and department.
/// </remarks>
/// <param name="name"></param>
/// <param name="duration"></param>
/// <param name="department"></param>
public class Diagnosis(string name, int duration, string department) : ISubject
{
    public string Name { get; private set; } = name;
    private int _treatmentDuration = duration;
    private string _department = department;
    private List<IObserver> _observers = [];
    public static readonly int fileParts = 3;

    /// <summary>
    /// Gets or sets the treatment duration in days.
    /// </summary>
    public int TreatmentDuration
    {
        get => _treatmentDuration;
        set
        {
            if (_treatmentDuration != value)
            {
                _treatmentDuration = value;
                NotifyDischargeDateChange();
            }
        }
    }

    /// <summary>
    /// Gets or sets the department associated with the diagnosis.
    /// </summary>
    public string Department
    {
        get => _department;
        set
        {
            if (_department != value)
            {
                _department = value;
                NotifyDepartmentChange();
            }
        }
    }

    /// Registers an observer to be notified of changes in the diagnosis.
    /// </summary>
    /// <param name="observer"></param>
    public void RegisterObserver(IObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
    }

    /// <summary>
    /// Removes an observer from the list of observers for this diagnosis.
    /// </summary>
    /// <param name="observer"></param>
    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    /// <summary>
    /// Notifies all registered observers of a change in the department associated with this diagnosis.
    /// </summary>
    public void NotifyDepartmentChange()
    {
        foreach (var observer in _observers)
        {
            observer.UpdateDepartment(Department);
        }
    }

    /// <summary>
    /// Notifies all registered observers of a change in the treatment duration, which affects the discharge date.
    /// </summary>
    public void NotifyDischargeDateChange()
    {
        foreach (var observer in _observers)
        {
            observer.UpdateDischargeDate(TreatmentDuration);
        }
    }
}