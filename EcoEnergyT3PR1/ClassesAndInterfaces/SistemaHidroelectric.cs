namespace Eco
{
    public class SistemaHidroelectric : SistemaEnergia, ICalculEnergia //Hidroelèctric
    {
        public double CabalAigua { get; set; }
        public static double DefaultCabalAigua = 0; 
        public SistemaHidroelectric(double cabalAigua, string simulationType, DateTime simulationDate) : base(simulationType, simulationDate)
        {
            CabalAigua = cabalAigua;
        }
        public SistemaHidroelectric(string simulationType, DateTime simulationDate) : base(simulationType, simulationDate)
        {
            CabalAigua = DefaultCabalAigua;
        }
        public override double CalcularEnergia()
        {
            const int NumDecimals = 2;
            const int MinFlow = 20;
            if (CabalAigua >= MinFlow) //El cas contrari no es donarà perquè està gestionat al programa principal. Condicional present pel Unit testing
            {
                return Math.Round(CabalAigua * 9.8 * 0.8, NumDecimals);
            }
            else { return 0; }
        }
    }
}