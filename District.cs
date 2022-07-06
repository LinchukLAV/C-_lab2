using System.Collections.Generic;

namespace Model
{
    public class District
    {
        /// <summary>
        /// Назва району
        /// </summary>
        public string NameOfDistrict { get; init; } = string.Empty;

        /// <summary>
        /// Адреса районної адміністрації
        /// </summary>
        public string AddressOfDistrictAdmin { get; init; } = string.Empty;

        /// <summary>
        /// Кількість жителів
        /// </summary>
        public int NumberOfInabitants { get; init; }

        /// <summary>
        /// Площа
        /// </summary>
        public double Area { get; init; }

        /// <summary>
        /// Шифр району
        /// </summary>
        public int IdDistrict { get; init; }

        /// <summary>
        /// Приведення до строкового типу
        /// </summary>
        public override string ToString()
        {
            return $"Шифр: {IdDistrict}. Район {NameOfDistrict}, адрес районної адміністрації " +
                $"{AddressOfDistrictAdmin}." + $"\nНаселення {NumberOfInabitants}, площа {Area}";
        }
    }
}
