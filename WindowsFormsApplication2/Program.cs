using System;
using System.Windows.Forms;
using SymulatorLotniska;
using SymulatorLotniska.AirportManagement;
using SymulatorLotniska.OperationManagement;
using SymulatorLotniska.NotificationManagement;

namespace SymulatorLotniska
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppWindow appWindow = new AppWindow();

            PlaneImagesCollection.init();
            AirportManager.init(appWindow);
            OperationManager.init(appWindow);
            PlaneCreationManager.init(appWindow);

            Application.Run(appWindow);
        }
    }
}
