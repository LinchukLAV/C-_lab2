using System;
using Model;
using System.Collections.Generic;
using XML_Work;
using Presentation_Layer;
using Model_Work;

namespace Комп_ютерний_практикум___2
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            ModelObjectCreater objectCreate = new ModelObjectCreater();

            bool isSaveSelected = false;

            List<District> districtsNew = new List<District>();
            List<House> houseNew = new List<House>();
            List<DistrictHouseConnection> distrHouseNew = new List<DistrictHouseConnection>();

            List<MenuElement> elements = new List<MenuElement>()
            {
                new MenuElement("1. Використовувати існуючі таблиці", () =>
                {
                    DataLists dataLists = new DataLists();
                    districtsNew = dataLists.Districts;
                    houseNew = dataLists.Houses;
                    distrHouseNew = dataLists.DistrictsHouses;
                    }),
                new MenuElement("2. Створити район", () => districtsNew.Add(objectCreate.CreateDistrict())),
                new MenuElement("3. Створити будинок", () => houseNew.Add(objectCreate.CreateHouse())),
                new MenuElement("4. Створіть зв'язок між будинком та районом", () => distrHouseNew.Add(objectCreate.ConnectionDistrHouse())),
                new MenuElement("5. Вихід", () => isSaveSelected = true)
            };

            while (isSaveSelected == false)
            {
                foreach (MenuElement element in elements)
                {
                    element.Display();
                }

                int choise;
                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    continue;
                }

                elements[choise - 1].ExecuteElement();
                Console.Clear();
            }

            Writer writer = new Writer();

            writer.WriteDistricts("Districts.xml", districtsNew);
            writer.WriteHouses("Houses.xml", houseNew);
            writer.WriteDistrictHouseConnections("DistrictHousesConnection.xml", distrHouseNew);

            Reader reader = new Reader();

            reader.HousesMoreSomeFloorsAndBuildAfterSomeYear("Houses.xml", 2000, 7)
                .WriteConsole("Вивести на екран будинки, де більше 7 поверхів і побудований після 2000 року:");

            reader.HouseOrderByEntrancAndMoreThenSomeFloors("Houses.xml", 5)
                .WriteConsole("Вивести на екран будинки, де більше 5 поверхів:");

            reader.HousesLocatedInAreaRank3rdOfMagnified("Districts.xml", "DistrictHousesConnection.xml", "Houses.xml")
                .WriteConsole("Вивести список будинків, які знаходяться у третьому районі по площі:");

            reader.DistrictWhereInhabitMoreThanAverage("Districts.xml")
                .WriteConsole("Вивести райони, де кількість мешканців більше середньої:");

            reader.GroupHousesByProjectType("Houses.xml")
                .WriteConsole("Вивести тип будівлі та всі його будинки:");

            reader.InfoAboutHouseAndItsDistrictName("Districts.xml", "DistrictHousesConnection.xml", "Houses.xml")
                .WriteConsole("Вивести на екран інформацію про будинок та назву його району:");

            reader.HousesInDistrWithTheLargestArea("Districts.xml", "DistrictHousesConnection.xml", "Houses.xml")
                .WriteConsole("Вивести на екран будинки, які знаходяться у районі з найбільшою площею");

            reader.HouseWithSomeTypeBuildAndTheLowestDensityArea("Districts.xml", "DistrictHousesConnection.xml", "Houses.xml", HouseType.Малосімейка)
                .WriteConsole("Інформація про будинок з типом будівлі Малосімейка, який знаходится в районі з найменшою плотністю населення:");

            reader.HousesInTheAreaWhereAdminInAvenue("Districts.xml", "DistrictHousesConnection.xml", "Houses.xml")
                .WriteConsole("Виводить будинки, які знаходяться в районі з адміністрацією на проспекті:");

            reader.GetDistrictMaxMinInabitants("Districts.xml")
                .WriteConsole("Вивести інформацію про райони з найбільшою та найменшою населеністю:");

            reader.DistrictAndItsDensity("Districts.xml")
                .WriteConsole("Вивести назву району та його щільність населення:");

            reader.TheNewestHouse("Districts.xml", "DistrictHousesConnection.xml", "Houses.xml")
                .WriteConsole("Інформація про найновіший будинок:");

            reader.AllInfoAboutHouses("Houses.xml")
                .WriteConsole("Інформація про будинки");

            reader.AllInfoAboutDistrict("Districts.xml")
                .WriteConsole("Інформація про райони:");

            reader.AllInfoAboutHousesAndDistrictConnection("DistrictHousesConnection.xml")
                .WriteConsole("Інформація про зв'язок будинку з районом:");
        }

    }

}
