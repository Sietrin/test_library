namespace UtilityLibraries;

using System;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Car
{
    public string Date { get; set; }
    public string BrandName { get; set; }
    public int Price { get; set; }
}
public static class XmlLibrary
{

    public class Document
    {
        [XmlElement("Car")]
        public Car[] Cars { get; set; }
    }

    public class XmlDeserializer
    {
        private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(Document));

        public static Document DeserializeXml(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                return (Document)Serializer.Deserialize(fileStream);
            }
        }

        public static void SerializeXml(string filePath, Document document)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                Serializer.Serialize(fileStream, document);
            }
        }

        public static void AddCar(string filePath, Car car)
        {
            Document document = DeserializeXml(filePath);
            var carList = document.Cars != null ? document.Cars.ToList() : new List<Car>();
            carList.Add(car);
            document.Cars = carList.ToArray();
            SerializeXml(filePath, document);
        }

        public static void DeleteCar(string filePath, int index)
        {
            Document document = DeserializeXml(filePath);
            var carList = document.Cars != null ? document.Cars.ToList() : new List<Car>();
            if (index >= 0 && index < carList.Count)
            {
                carList.RemoveAt(index);
                document.Cars = carList.ToArray();
                SerializeXml(filePath, document);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }
        }

        public static void ModifyCar(string filePath, int index, Car updatedCar)
        {
            Document document = DeserializeXml(filePath);
            var carList = document.Cars != null ? document.Cars.ToList() : new List<Car>();
            if (index >= 0 && index < carList.Count)
            {
                carList[index] = updatedCar;
                document.Cars = carList.ToArray();
                SerializeXml(filePath, document);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }
        }
    }
}

public class JsonLibrary
{
    public static List<Car> DeserializeJson(string filePath)
    {
        string jsonContent = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Car>>(jsonContent);
    }

    public static void SerializeJson(string filePath, List<Car> cars)
    {
        string jsonContent = JsonSerializer.Serialize(cars);
        File.WriteAllText(filePath, jsonContent);
    }

    public static void AddCar(string filePath, Car car)
    {
        List<Car> cars = DeserializeJson(filePath);
        cars.Add(car);
        SerializeJson(filePath, cars);
    }

    public static void DeleteCar(string filePath, int index)
    {
        List<Car> cars = DeserializeJson(filePath);
        if (index >= 0 && index < cars.Count)
        {
            cars.RemoveAt(index);
            SerializeJson(filePath, cars);
        }
        else
        {
            throw new ArgumentOutOfRangeException("Invalid index");
        }
    }

    public static void ModifyCar(string filePath, int index, Car updatedCar)
    {
        List<Car> cars = DeserializeJson(filePath);
        if (index >= 0 && index < cars.Count)
        {
            cars[index] = updatedCar;
            SerializeJson(filePath, cars);
        }
        else
        {
            throw new ArgumentOutOfRangeException("Invalid index");
        }
    }
}