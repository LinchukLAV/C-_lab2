namespace Extra_classes
{
    public class DistrictDensity
    {
        /// <summary>
        /// Назва району
        /// </summary>
        public string DistrictName { get; init; } = string.Empty;

        /// <summary>
        /// Плотність населення
        /// </summary>
        public double Density { get; init; }

        public override string ToString()
        {
            return $"{DistrictName} => {Density} люд./км^2";
        }
    }
}