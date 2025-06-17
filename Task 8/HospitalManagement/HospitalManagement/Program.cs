using HospitalManagement.Models;
using HospitalManagement.Services;
using System;

namespace HospitalManagement;

/// <summary>
/// Main entry point for the Hospital Management application.
/// </summary>
class Program
{
    /// <summary>
    /// Main method to run the hospital management system.
    /// </summary>
    static void Main()
    {
        HospitalManager manager = new HospitalManager();
        manager.Run();
    }
}