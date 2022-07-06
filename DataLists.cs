using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Комп_ютерний_практикум___2
{
    class DataLists
    {
        // Лист з даними про житлові будинки.
        public List<House> Houses { get; set; } = new List<House>
        {
            new House()
            {
                IdHouse = 1,
                TypeHouse = HouseType.Малосімейка,
                NumOfFloors = 9,
                NumOfEntrances = 2,
                DateOfConstruction = new DateTimeOffset(new DateTime(2000, 9, 20))
            },
            new House()
            {
                IdHouse = 2,
                TypeHouse = HouseType.Хрущовка,
                NumOfFloors = 5,
                NumOfEntrances = 4,
                DateOfConstruction = new DateTimeOffset(new DateTime(1970, 7, 15))
            },
            new House()
            {
                IdHouse = 3,
                TypeHouse = HouseType.Сталінка,
                NumOfFloors = 3,
                NumOfEntrances = 4,
                DateOfConstruction = new DateTimeOffset(new DateTime(1950, 11, 11))
            },
            new House()
            {
                IdHouse = 4,
                TypeHouse = HouseType.Дореволюційна,
                NumOfFloors = 5,
                NumOfEntrances = 3,
                DateOfConstruction = new DateTimeOffset(new DateTime(1916, 12, 07))
            },
            new House()
            {
                IdHouse = 5,
                TypeHouse = HouseType.Високоповерхівка,
                NumOfFloors = 20,
                NumOfEntrances = 1,
                DateOfConstruction = new DateTimeOffset(new DateTime(2021, 12, 12))
            },
            new House()
            {
                IdHouse = 6,
                TypeHouse = HouseType.Новобудова,
                NumOfFloors = 15,
                NumOfEntrances = 2,
                DateOfConstruction = new DateTimeOffset(new DateTime(2018, 6, 8))
            },
            new House()
            {
                IdHouse = 7,
                TypeHouse = HouseType.Літівка,
                NumOfFloors = 9,
                NumOfEntrances = 4,
                DateOfConstruction = new DateTimeOffset(new DateTime(1990, 3, 10))
            },
            new House()
            {
                IdHouse = 8,
                TypeHouse = HouseType.Панель,
                NumOfFloors = 7,
                NumOfEntrances = 2,
                DateOfConstruction = new DateTimeOffset(new DateTime(1997, 4, 1))
            },
            new House()
            {
                IdHouse = 9,
                TypeHouse = HouseType.Хрущовка,
                NumOfFloors = 3,
                NumOfEntrances = 2,
                DateOfConstruction = new DateTimeOffset(new DateTime(1976, 1, 20))
            },
            new House()
            {
                IdHouse = 10,
                TypeHouse = HouseType.Малосімейка,
                NumOfFloors = 7,
                NumOfEntrances = 4,
                DateOfConstruction = new DateTimeOffset(new DateTime(1968, 8, 27))
            },
            new House()
            {
                IdHouse = 11,
                TypeHouse = HouseType.Малосімейка,
                NumOfFloors = 9,
                NumOfEntrances = 4,
                DateOfConstruction = new DateTimeOffset(new DateTime(1960, 5, 17))
            },
            new House()
            {
                IdHouse = 12,
                TypeHouse = HouseType.Новобудова,
                NumOfFloors = 17,
                NumOfEntrances = 1,
                DateOfConstruction = new DateTimeOffset(new DateTime(2017, 11, 19))
            },
            new House()
            {
                IdHouse = 13,
                TypeHouse = HouseType.Новобудова,
                NumOfFloors = 15,
                NumOfEntrances = 2,
                DateOfConstruction = new DateTimeOffset(new DateTime(2021, 9, 1))
            },
            new House()
            {
                IdHouse = 14,
                TypeHouse = HouseType.Новобудова,
                NumOfFloors = 15,
                NumOfEntrances = 1,
                DateOfConstruction = new DateTimeOffset(new DateTime(2017, 4, 12))
            },
             new House()
            {
                IdHouse = 15,
                TypeHouse = HouseType.Панель,
                NumOfFloors = 7,
                NumOfEntrances = 1,
                DateOfConstruction = new DateTimeOffset(new DateTime(2007, 1, 1))
            },
            new House()
            {
                IdHouse = 16,
                TypeHouse = HouseType.Малосімейка,
                NumOfFloors = 9,
                NumOfEntrances = 2,
                DateOfConstruction = new DateTimeOffset(new DateTime(1956, 12, 29))
            },
            new House()
            {
                IdHouse = 17,
                TypeHouse = HouseType.Високоповерхівка,
                NumOfFloors = 20,
                NumOfEntrances = 3,
                DateOfConstruction = new DateTimeOffset(new DateTime(2021, 2, 1))
            },
            new House()
            {
                IdHouse = 18,
                TypeHouse = HouseType.Новобудова,
                NumOfFloors = 15,
                NumOfEntrances = 4,
                DateOfConstruction = new DateTimeOffset(new DateTime(2020, 6, 23))
            },
            new House()
            {
                IdHouse = 19,
                TypeHouse = HouseType.Новобудова,
                NumOfFloors = 17,
                NumOfEntrances = 1,
                DateOfConstruction = new DateTimeOffset(new DateTime(2015, 10, 27))
            },
            new House()
            {
                IdHouse = 20,
                TypeHouse = HouseType.Літівка,
                NumOfFloors = 7,
                NumOfEntrances = 4,
                DateOfConstruction = new DateTimeOffset(new DateTime(1978, 1, 24))
            }
        };

        // Лист з даними про райони міста.
        public List<District> Districts { get; set; } = new List<District>
        {
            new District()
            {
                NameOfDistrict = "Тернівський",
                AddressOfDistrictAdmin = "вул. Короленка, буд. 1А",
                NumberOfInabitants = 82800,
                Area = 7754,
                IdDistrict = 1
            },
            new District()
            {
                NameOfDistrict = "Покровський",
                AddressOfDistrictAdmin = "вул. Шурупова, буд. 2",
                NumberOfInabitants = 126700,
                Area = 5953,
                IdDistrict = 2,
            },
            new District()
            {
                NameOfDistrict = "Саксаганський",
                AddressOfDistrictAdmin = "вул. Володимира Великого, буд. 32",
                NumberOfInabitants = 152235,
                Area = 3920,
                IdDistrict = 3,
            },
            new District()
            {
                NameOfDistrict = "Довгинцівський",
                AddressOfDistrictAdmin = "вул. Дніпровське шосе, 11",
                NumberOfInabitants = 100006,
                Area = 5305,
                IdDistrict = 4,
            },
            new District()
            {
                NameOfDistrict = "Центрально-Міський",
                AddressOfDistrictAdmin = "вул. Староярмарова, буд. 44",
                NumberOfInabitants = 81600,
                Area = 6642,
                IdDistrict = 5,
            },
            new District()
            {
                NameOfDistrict = "Інгулецький",
                AddressOfDistrictAdmin = "пр. Південний, буд. 1;",
                NumberOfInabitants = 59000,
                Area = 14800,
                IdDistrict = 6,
            },
            new District()
            {
                NameOfDistrict = "Металургійний",
                AddressOfDistrictAdmin = "вул. Хабаровська 6, буд. 4",
                NumberOfInabitants = 70378,
                Area = 5190,
                IdDistrict = 7,
            }
        };

        // Лист з даними зв'язку житловий будинок - район.
        public List<DistrictHouseConnection> DistrictsHouses { get; set; } = new List<DistrictHouseConnection>
        {
            new DistrictHouseConnection()
            {
                IdDistrict = 1,
                IdHouses = new List<int>()
                {
                    7,
                    18
                }
            },
            new DistrictHouseConnection()
            {
                IdDistrict = 2,
                IdHouses = new List<int>()
                {
                    2,
                    6,
                    12,
                    14
                }
            },
            new DistrictHouseConnection()
            {
                IdDistrict = 3,
                IdHouses = new List<int>()
                {
                    4,
                    5,
                    9,
                    16,
                }
            },
            new DistrictHouseConnection()
            {
                IdDistrict = 4,
                IdHouses = new List<int>()
                {
                    13,
                    17
                }
            },
            new DistrictHouseConnection()
            {
                IdDistrict = 5,
                IdHouses = new List<int>()
                {
                    11,
                    15,
                    20
                }
            },
            new DistrictHouseConnection()
            {
                IdDistrict = 6,
                IdHouses = new List<int>()
                {
                    19
                }
            },
            new DistrictHouseConnection()
            {
                IdDistrict = 7,
                IdHouses = new List<int>()
                {
                    3,
                    8,
                    10
                }
            },
        };
    }
}
