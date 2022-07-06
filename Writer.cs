using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Model;

namespace XML_Work
{
    public class Writer
    {
        public void WriteDistricts(string fileName, List<District> districts)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(fileName, settings);

            writer.WriteStartDocument();
            writer.WriteStartElement("Districts");

            foreach (District district in districts)
            {
                writer.WriteStartElement("District");

                writer.WriteElementString("Id", district.IdDistrict.ToString());
                writer.WriteElementString("District", district.NameOfDistrict);
                writer.WriteElementString("AddressAdmin", district.AddressOfDistrictAdmin);
                writer.WriteElementString("Inabitants", district.NumberOfInabitants.ToString());
                writer.WriteElementString("Area", district.Area.ToString());

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.Dispose();
        }
        public void WriteHouses(string fileName, List<House> houses)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(fileName, settings);

            writer.WriteStartDocument();
            writer.WriteStartElement("Houses");

            foreach (House house in houses)
            {
                writer.WriteStartElement("House");

                writer.WriteElementString("Id", house.IdHouse.ToString());
                writer.WriteElementString("TypeHouse", house.TypeHouse.ToString());
                writer.WriteElementString("Entrances", house.NumOfEntrances.ToString());
                writer.WriteElementString("Floors", house.NumOfFloors.ToString());
                writer.WriteElementString("DateOfConstruction", house.DateOfConstruction.ToString());

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.Dispose();
        }
        public void WriteDistrictHouseConnections(string fileName, List<DistrictHouseConnection> connections)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(fileName, settings);

            writer.WriteStartDocument();
            writer.WriteStartElement("DistrictsHouses");

            foreach (DistrictHouseConnection distrHouseConnection in connections)
            {
                writer.WriteStartElement("DistrictHouseConnection");

                writer.WriteElementString("IdDistrict", distrHouseConnection.IdDistrict.ToString());

                writer.WriteStartElement("IdHouses");

                foreach (int houseId in distrHouseConnection.IdHouses)
                {
                    writer.WriteElementString("IdHouse", houseId.ToString());
                }

                writer.WriteEndElement();

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.Dispose();
        }
    }
}



