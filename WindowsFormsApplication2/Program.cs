using System;
using System.Windows.Forms;
using SymulatorLotniska;
using SymulatorLotniska.Planes;
using SymulatorLotniska.AirportManagement;
using SymulatorLotniska.OperationManagement;
using SymulatorLotniska.NotificationManagement;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using SymulatorLotniska.Properties;

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
            FormaTestowa TESTGRAFIKI = new FormaTestowa();
            

            PlaneImagesCollection.init();
            AirportManager.init(appWindow);
            OperationManager.init(appWindow);
            PlaneCreationManager.init(appWindow);

            Application.Run(appWindow);
            //Application.Run(TESTGRAFIKI);
        }

        static public int howManyInFile()
        {
            XmlDocument xDoc = new XmlDocument();

            xDoc.LoadXml(Resources.DefinedPlanes);
            return Int32.Parse(xDoc.SelectSingleNode("Planes/NumberOfPlanes").InnerText);
        }
        static public Plane readFromFile(int id)
        {
            XmlDocument xDoc = new XmlDocument();
            
            xDoc.LoadXml(Resources.DefinedPlanes);

            Plane loadedPlane;

            XmlNodeList planeNodes = xDoc.SelectNodes("Planes/Plane");
            foreach(XmlNode node in planeNodes)
            {
                if(Int32.Parse(node.Attributes.GetNamedItem("id").Value) == id)
                {
                    string type = node.SelectSingleNode("Type").InnerText;

                    if (type == "PassengerPlane")
                    {
                        loadedPlane = new PassengerPlane();
                        ((PassengerPlane)loadedPlane).setMaxNumberOfPassengers(Int32.Parse(node.SelectSingleNode("MaxPassengers").InnerText));
                    }
                    else if (type == "MilitaryPlane")
                    {
                        loadedPlane = new MilitaryPlane();
                        ((MilitaryPlane)loadedPlane).setMaxAmmo(Int32.Parse(node.SelectSingleNode("MaxAmmo").InnerText));
                        ((MilitaryPlane)loadedPlane).setWeaponType(node.SelectSingleNode("WeaponType").InnerText);

                    }
                    else if (type == "TransportPlane")
                    {
                        loadedPlane = new TransportPlane();
                        ((TransportPlane)loadedPlane).setMaxStorageCapacity(Int32.Parse(node.SelectSingleNode("MaxStorage").InnerText));
                    }
                    else return null;

                    loadedPlane.setModel(node.SelectSingleNode("Model").InnerText);
                    loadedPlane.setMaxFuelLevel(Int32.Parse(node.SelectSingleNode("MaxFuelLevel").InnerText));
                    loadedPlane.setFuelUsage(Int32.Parse(node.SelectSingleNode("FuelUsage").InnerText));
                    loadedPlane.setTakeoffTime(Int32.Parse(node.SelectSingleNode("TakeoffInterval").InnerText));
                    loadedPlane.setPlaneImage(node.SelectSingleNode("Image").InnerText);

                    return loadedPlane;
                }
                

            }

            return null;
            
        }
        
    }
}
