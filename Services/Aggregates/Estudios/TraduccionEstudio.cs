namespace Unir.Aggregates.Estudios
{

    public class TraduccionEstudio
    {
        public int Id { get; set; }
        public string Locale { get; set; }
        public string Traduccion { get; set; }

        public virtual Estudio Estudio { get; set; }
    }

}