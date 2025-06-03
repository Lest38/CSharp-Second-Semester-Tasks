using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TransportHandler.Modules;
using TransportHandler.Core;

namespace TransportHandler
{
    /// <summary>
    /// Main entry point for the TransportHandler application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method to run the TransportHandler application.
        /// </summary>
        static void Main()
        {
            var app = new TransportApp();
            app.Run();
        }
    }
}
