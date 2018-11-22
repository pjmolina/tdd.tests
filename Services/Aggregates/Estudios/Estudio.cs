using System.Collections.Generic;

namespace Unir.Aggregates.Estudios
{

    public class Estudio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public bool AprobadoAneca { get;set; }

        public virtual ICollection<TraduccionEstudio> Traducciones { get; set; }
    }

}