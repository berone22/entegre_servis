using System;
using System.Collections.Generic;

namespace entegre_servis.Models
{
    public partial class TblFirma
    {
        public TblFirma()
        {
            TblFaturas = new HashSet<TblFatura>();
        }

        public int FirmaId { get; set; }
        public decimal? Vkn { get; set; }
        public string? VergiDairesi { get; set; }
        public string? Alias { get; set; }
        public string? FirmaAdi { get; set; }
        public string? Il { get; set; }
        public string? Ilce { get; set; }
        public string? Adres { get; set; }
        public string? Mail { get; set; }
        public decimal? Tel { get; set; }
        public string? SabitSiparisNotu { get; set; }

        public virtual ICollection<TblFatura> TblFaturas { get; set; }
    }
}
