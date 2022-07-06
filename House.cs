using System;
using System.Collections.Generic;

namespace Model
{
    public class House
    {
        /// <summary>
        /// Тип проекту
        /// </summary>
        public HouseType TypeHouse { get; init; }

        /// <summary>
        /// Число поверхів
        /// </summary>
        public int NumOfFloors { get; init; }

        /// <summary>
        /// Число під'їздів
        /// </summary>
        public int NumOfEntrances { get; init; }

        /// <summary>
        /// Дата побудови
        /// </summary>
        public DateTimeOffset DateOfConstruction { get; init; }

        /// <summary>
        /// Шифр будинку
        /// </summary>
        public int IdHouse { get; init; }

        /// <summary>
        /// Приведення до строкового типу
        /// </summary>
        public override string ToString()
        {
            return $"Шифр будинку - {IdHouse}. Тип поекту {TypeHouse} з {NumOfEntrances} під'їздами та" +
                $" {NumOfFloors} поверхами. Побудований у {DateOfConstruction.ToString("d")}";
        }
    }
}
