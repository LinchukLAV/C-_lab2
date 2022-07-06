using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Model;
using Model_Work;
using Extra_classes;

namespace XML_Work
{
    class Reader
    {
        private IEnumerable<XElement> GetDocumentElements(string fileName, string nameElement)
        {
            return XDocument.Load(fileName).Root.Elements(nameElement);
        }

        private ModelObjectCreater _objectCreater = new ModelObjectCreater();

        public IEnumerable<District> AllDistricts(string fileName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(fileName);
            XmlElement root = xDoc.DocumentElement;

            List<District> district = new List<District>();

            foreach (XmlNode element in root)
            {
                district.Add(_objectCreater.CreateDistrict(element));
            }
            return district;
        }

        public IEnumerable<HouseAndItsDistrictName> InfoAboutHouseAndItsDistrictName
            (string fileNameDistrict, string fileNameHouseDistr, string fileNameHouse)
        {
            return from districthouse in GetDocumentElements(fileNameHouseDistr, "DistrictHouseConnection")
                   join district in GetDocumentElements(fileNameDistrict, "District")
                   on Convert.ToInt32(districthouse.Element("IdDistrict").Value) equals Convert.ToInt32(district.Element("Id").Value)
                   join house in GetDocumentElements(fileNameHouse, "House")
                   on Convert.ToInt32(districthouse.Element("IdHouses").Value) equals Convert.ToInt32(house.Element("Id").Value)
                   select _objectCreater.CreateHouseDistrictName(district, house);
        }

        public Dictionary<string, List<House>> GroupHousesByProjectType
                  (string fileName)
        {
            return (from house in GetDocumentElements(fileName, "House")
                    group house by house.Element("TypeHouse").Value into info
                    select new
                    {
                        key = info.Key,
                        house = from groupInfo in info
                                select _objectCreater.CreateHouse(groupInfo)
                    })
                   .ToDictionary(info => info.key, info => info.house.ToList());
        }


        public IEnumerable<House> HousesMoreSomeFloorsAndBuildAfterSomeYear(string fileName, int year, int floors)
        {
            return GetDocumentElements(fileName, "House")
                .Where(house => Convert.ToInt32(house.Element("Floors").Value) > floors
                && Convert.ToDateTime(house.Element("DateOfConstruction").Value).Year > year)
                .Select(house => _objectCreater.CreateHouse(house));
        }

        public IEnumerable<District> DistrictWhereInhabitMoreThanAverage(string fileName)
        {
            double avgDistrictItsNumOfInabit = GetDocumentElements(fileName, "District")
                .Average(district => Convert.ToInt32(district.Element("Inabitants").Value));
            return GetDocumentElements(fileName, "District")
                .Where(district => Convert.ToInt32(district.Element("Inabitants").Value) > avgDistrictItsNumOfInabit)
                .OrderByDescending(district => Convert.ToInt32(district.Element("Area").Value))
                .Select(district => _objectCreater.CreateDistrict(district));
        }

        public House TheNewestHouse(string fileNameDistrict, string fileNameHouseDistr, string fileNameHouse)
        {
            return GetDocumentElements(fileNameHouse, "House")
                .OrderByDescending(infoHouse => Convert.ToDateTime(infoHouse
                .Element("DateOfConstruction").Value))
                .Select(house => _objectCreater.CreateHouse(house))
                .First();

        }

        public IEnumerable<House> HousesLocatedInAreaRank3rdOfMagnified
            (string fileNameDistrict, string fileNameHouseDistr, string fileNameHouse)
        {
            XElement districtTopOneArea = GetDocumentElements(fileNameDistrict, "District")
                     .Distinct()
                     .OrderByDescending(district => Convert.ToInt32(district.Element("Area").Value))
                     .ElementAt(2);

            IEnumerable<int> HousesId = GetDocumentElements(fileNameHouseDistr, "DistrictHouseConnection")
                .Where(connection => Convert.ToInt32(connection.Element("IdDistrict").Value)
                == Convert.ToInt32(districtTopOneArea.Element("Id").Value))
                .SelectMany(connection => connection.Element("IdHouses").Elements("IdHouse")
                .Select(x => Convert.ToInt32(x.Value)));

            return GetDocumentElements(fileNameHouse, "House")
                .Join(HousesId,
                house => Convert.ToInt32(house.Element("Id").Value),
                houseId => houseId,
                (house, houseId) => _objectCreater.CreateHouse(house));
        }

        public IEnumerable<HouseAndItsDistrictName> HousesInDistrWithTheLargestArea
            (string fileNameDistrict, string fileNameHouseDistr, string fileNameHouse)
        {
            double maxDistrictsArea = Convert.ToDouble(GetDocumentElements(fileNameDistrict, "District").Max(District => District.Element("Area").Value));
            return from districthouse in GetDocumentElements(fileNameHouseDistr, "DistrictHouseConnection")
                   join district in GetDocumentElements(fileNameDistrict, "District")
                   on Convert.ToInt32(districthouse.Element("IdDistrict").Value) equals Convert.ToInt32(district.Element("Id").Value)
                   join house in GetDocumentElements(fileNameHouse, "House")
                   on Convert.ToInt32(districthouse.Element("IdHouses").Value) equals Convert.ToInt32(house.Element("Id").Value)
                   where Convert.ToDouble(district.Element("Area").Value) == maxDistrictsArea
                   select _objectCreater.CreateHouseDistrictName(district, house);
        }

        public IEnumerable<House> HouseOrderByEntrancAndMoreThenSomeFloors(string fileName, int floors)
        {
            return GetDocumentElements(fileName, "House")
                  .OrderBy(house => house.Element("Entrances").Value)
                  .Where(house => Convert.ToInt32(house.Element("Floors").Value) > floors)
                  .Select(house => _objectCreater.CreateHouse(house));
        }

        public IEnumerable<DistrictDensity> DistrictAndItsDensity(string fileName)
        {
            return from district in GetDocumentElements(fileName, "District")
                   select _objectCreater.CreateDistrictAndItsDensity(district);
        }

        public IEnumerable<District> GetDistrictMaxMinInabitants(string fileName)
        {
            int maxInabitants = GetDocumentElements(fileName, "District").Max(district =>
                Convert.ToInt32(district.Element("Inabitants").Value));
            int minInabitants = GetDocumentElements(fileName, "District").Min(district =>
                Convert.ToInt32(district.Element("Inabitants").Value));

            IEnumerable<District> maxInabitantsDistricts = from district in GetDocumentElements(fileName, "District")
                                                           where Convert.ToInt32(district.Element("Inabitants").Value)
                                                           == maxInabitants
                                                           select _objectCreater.CreateDistrict(district);
            IEnumerable<District> minInabitantsDistricts = from district in GetDocumentElements(fileName, "District")
                                                           where Convert.ToInt32(district.Element("Inabitants").Value)
                                                           == minInabitants
                                                           select _objectCreater.CreateDistrict(district);
            return maxInabitantsDistricts.Concat(minInabitantsDistricts);
        }

        public IEnumerable<HouseAndItsDistrictName> HousesInTheAreaWhereAdminInAvenue
           (string fileNameDistrict, string fileNameHouseDistr, string fileNameHouse)
        {
            return GetDocumentElements(fileNameHouseDistr, "DistrictHouseConnection").Join(GetDocumentElements(fileNameDistrict, "District"),
                distrHouse => Convert.ToInt32(distrHouse.Element("IdDistrict").Value),
                district => Convert.ToInt32(district.Element("Id").Value),
                (distrHouse, district) => new
                {
                    distr = district,
                    id = Convert.ToInt32(distrHouse.Element("IdHouses").Value)
                })
                .Join(GetDocumentElements(fileNameHouse, "House"),
                infoDistrict => infoDistrict.id,
                house => Convert.ToInt32(house.Element("Id").Value),
                (infoDistrict, house) => new
                {
                    district = infoDistrict.distr,
                    house
                })
                .Where(infoDistrict => infoDistrict.district.Element("AddressAdmin").Value.Contains("пр."))
                .Select(info => _objectCreater.CreateHouseDistrictName(info.district, info.house));

        }

        public IEnumerable<HouseAndItsDistrictName> HouseWithSomeTypeBuildAndTheLowestDensityArea
            (string fileNameDistrict, string fileNameHouseDistr, string fileNameHouse, HouseType houseItsType)
        {
            double density = GetDocumentElements(fileNameDistrict, "District")
                            .Min(district => Convert.ToInt32(district.Element("Inabitants").Value) / Convert.ToInt32(district.Element("Area").Value) * 100);
            return from districthouse in GetDocumentElements(fileNameHouseDistr, "DistrictHouseConnection")
                   join district in GetDocumentElements(fileNameDistrict, "District")
                   on Convert.ToInt32(districthouse.Element("IdDistrict").Value) equals Convert.ToInt32(district.Element("Id").Value)
                   join house in GetDocumentElements(fileNameHouse, "House")
                   on Convert.ToInt32(districthouse.Element("IdHouses").Value) equals Convert.ToInt32(house.Element("Id").Value)
                   where Convert.ToInt32(district.Element("Inabitants").Value) / Convert.ToInt32(district.Element("Area").Value) * 100 == density
                   && house.Element("TypeHouse").Value == houseItsType.ToString()
                   select _objectCreater.CreateHouseDistrictName(district, house);
        }

        public IEnumerable<House> AllInfoAboutHouses(string fileName)
        {
            return from house in GetDocumentElements(fileName, "House")
                   select _objectCreater.CreateHouse(house);
        }

        public IEnumerable<District> AllInfoAboutDistrict(string fileName)
        {
            return from district in GetDocumentElements(fileName, "District")
                   select _objectCreater.CreateDistrict(district);
        }

        public IEnumerable<DistrictHouseConnection> AllInfoAboutHousesAndDistrictConnection(string fileName)
        {
            return from houseAndDistrictConnection in GetDocumentElements(fileName, "DistrictHouseConnection")
                   select _objectCreater.ConnectionDistrHouse(houseAndDistrictConnection);
        }
    }
}
