using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    /// <summary>
    /// Interface for Observer pattern implementation in the hospital management system.
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// Updates the patient's department and notifies observers of the change.
        /// </summary>
        /// <param name="newDepartment"></param>
        void UpdateDepartment(string newDepartment);

        /// <summary>
        /// Updates the discharge date based on the treatment duration provided by the diagnosis.
        /// </summary>
        /// <param name="treatmentDuration"></param>
        void UpdateDischargeDate(int treatmentDuration);
    }
}
