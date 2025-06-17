namespace HospitalManagement.Models;

/// <summary>
/// Interface for the Subject in the Observer pattern.
/// </summary>
public interface ISubject
{
    /// <summary>
    /// Registers an observer to receive notifications about changes in the subject.
    /// </summary>
    /// <param name="observer"></param>
    void RegisterObserver(IObserver observer);

    /// <summary>
    /// Removes an observer from the list of observers.
    /// </summary>
    /// <param name="observer"></param>
    void RemoveObserver(IObserver observer);

    /// <summary>
    /// Notifies all registered observers about a change in the department.
    /// </summary>
    void NotifyDepartmentChange();

    /// <summary>
    /// Notifies all registered observers about a change in the discharge date.
    /// </summary>
    void NotifyDischargeDateChange();
}