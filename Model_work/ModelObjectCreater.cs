using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using Extra_classes;

using Model;
namespace Model_Work
{
    class ModelObjectCreater
    {

        public HouseAndItsDistrictName CreateHouseDistrictName(XElement district, XElement house)
        {
            return new HouseAndItsDistrictName()
            {
                NameOfDistrict = district.Element("District").Value,
                HouseInfo = CreateHouse(house)
            };
        }

        public District CreateDistrict(XElement district)
        {
            return new District()
            {
                IdDistrict = Convert.ToInt32(district.Element("Id").Value),
                NameOfDistrict = district.Element("District").Value,
                AddressOfDistrictAdmin = district.Element("AddressAdmin").Value,
                Area = Convert.ToInt32(district.Element("Area").Value),
                NumberOfInabitants = Convert.ToInt32(district.Element("Inabitants").Value)
            };
        }

        public District CreateDistrict()
        {
            EnterData enterData = new EnterData();
            return new District()
            {
                IdDistrict = enterData.EnterNumber("Введіть шифр району:"),
                NameOfDistrict = enterData.EnterString("Введіть назву району"),
                AddressOfDistrictAdmin = enterData.EnterString("Введіть адрес районної адміністрації: "),
                Area = enterData.EnterNumber("Введіть площу:"),
                NumberOfInabitants = enterData.EnterNumber("Введіть  кількість жителів:"),
            };
        }

        public District CreateDistrict(XmlNode element)
        {
            return new District()
            {
                IdDistrict = Convert.ToInt32(element["Id"].Value),
                NameOfDistrict = element["District"].Value,
                AddressOfDistrictAdmin = element["AddressAdmin"].Value,
                Area = Convert.ToInt32(element["Area"].Value),
                NumberOfInabitants = Convert.ToInt32(element["Inabitants"].Value)
            };
        }

        public House CreateHouse(XElement house)
        {
            return new House()
            {
                IdHouse = Convert.ToInt32(house.Element("Id").Value),
                NumOfEntrances = Convert.ToInt32(house.Element("Entrances").Value),
                NumOfFloors = Convert.ToInt32(house.Element("Floors").Value),
                DateOfConstruction = Convert.ToDateTime(house.Element("DateOfConstruction").Value),
                TypeHouse = (HouseType)Enum.Parse(typeof(HouseType),
                    house.Element("TypeHouse").Value)
            };
        }

        public House CreateHouse()
        {
            EnterData enterData = new EnterData();
            return new House()
            {
                IdHouse = enterData.EnterNumber("Введіть шифр будинку:"),
                NumOfEntrances = enterData.EnterNumber("Введіть кількість під'їздів:"),
                NumOfFloors = enterData.EnterNumber("Введіть кількість поверхів:"),
                DateOfConstruction = new DateTimeOffset(new DateTime
                (enterData.EnterNumber("Введіть рік побудови:"),
                enterData.EnterNumber("Введіть місяць:"),
                enterData.EnterNumber("Введіть день:"))),
                TypeHouse = (HouseType)Enum.Parse(typeof(HouseType),
                    enterData.EnterString("Введіть тип будинку:"))
            };
        }

        public DistrictDensity CreateDistrictAndItsDensity(XElement district)
        {
            return new DistrictDensity()
            {
                DistrictName = district.Element("District").Value,
                Density = Convert.ToDouble(district.Element("Inabitants").Value) /
                     (Convert.ToInt32(district.Element("Area").Value) / 100)
            };
        }

        public DistrictHouseConnection ConnectionDistrHouse()
        {
            EnterData enterData = new EnterData();
            int idDistrict = enterData.EnterNumber("Введіть шифр району: ");
            List<int> idHouses = new List<int>();
            while (true)
            {
                int idHouse = enterData.EnterNumber("Введіть шифр будинку (для виходу від'ємне число): ");
                if (idHouse < 0)
                {
                    break;
                }
                idHouses.Add(idHouse);
            }
            return new DistrictHouseConnection()
            {
                IdDistrict = idDistrict,
                IdHouses = idHouses
            };
        }

        public DistrictHouseConnection ConnectionDistrHouse(XElement distrHouse)
        {
            return new DistrictHouseConnection()
            {
                IdDistrict = Convert.ToInt32(distrHouse.Element("IdDistrict").Value),
                IdHouses = distrHouse.Element("IdHouses")
                .Elements("IdHouse")
                .Select(x => Convert.ToInt32(x.Value)).ToList()
            };
        }
    }
}
