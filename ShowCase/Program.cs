using UtilityLibraries;

using System;
using System.IO;
using System.Xml.Serialization;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        //These instructions invoke the methods for XML
        string xmlFilePath = "/home/setrin/Documents/file.xml";
        UtilityLibraries.Car newCar = new UtilityLibraries.Car // Creating a new car
        {
            Date = "20.08.2023",
            BrandName = "Tesla Model Pegasus",
            Price = 80000
        };
        UtilityLibraries.XmlLibrary.XmlDeserializer.AddCar(xmlFilePath, newCar); // Adding
        UtilityLibraries.Car modifiedCar = new UtilityLibraries.Car // Modifying 
        {
            Date = "25.08.2023",
            BrandName = "Toyota Knight",
            Price = 30000
        };
        UtilityLibraries.XmlLibrary.XmlDeserializer.ModifyCar(xmlFilePath, 0, modifiedCar);
        UtilityLibraries.XmlLibrary.XmlDeserializer.DeleteCar(xmlFilePath, 2);// Deleting 

        //Thise instructions invoke the methods for JSON
        string jsonFilePath = "/home/setrin/Documents/file.json";

        UtilityLibraries.Car newCar2 = new Car // Adding 
        {
            Date = "20.08.2023",
            BrandName = "ccccccccccccc",
            Price = 80000
        };
        UtilityLibraries.JsonLibrary.AddCar(jsonFilePath, newCar2);
        
        Car modifiedCar2 = new Car // Modifying 
        {
            Date = "25.08.2023",
            BrandName = "Toyota Wonder",
            Price = 30000
        };
        UtilityLibraries.JsonLibrary.ModifyCar(jsonFilePath, 0, modifiedCar2);
        //UtilityLibraries.JsonLibrary.DeleteCar(jsonFilePath, 1); // Deleting 
    }
}