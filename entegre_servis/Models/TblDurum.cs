using System;
using System.Collections.Generic;

namespace entegre_servis.Models
{
    public partial class TblDurum
    {
        public TblDurum()
        {
            TblUruns = new HashSet<TblUrun>();
        }

        public int DurumId { get; set; }
        public string? Durum { get; set; }

        public virtual ICollection<TblUrun> TblUruns { get; set; }
    }
}
