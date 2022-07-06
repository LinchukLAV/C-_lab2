using System;
using System.Collections.Generic;

namespace Model
{
    public class DistrictHouseConnection
    {
        /// <summary>
        /// Шифр району
        /// </summary>
        public int IdDistrict { get; init; }

        /// <summary>
        /// Шифр будинку
        /// </summary>
        public List<int> IdHouses { get; init; }

    }
}
