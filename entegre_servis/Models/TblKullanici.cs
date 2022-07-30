using System;
using System.Collections.Generic;

namespace entegre_servis.Models
{
    public partial class TblKullanici
    {
        public TblKullanici()
        {
            TblLogs = new HashSet<TblLog>();
        }

        public int KullaniciId { get; set; }
        public string? KAd { get; set; }
        public string? Sifre { get; set; }
        public bool? Tur { get; set; }

        public virtual ICollection<TblLog> TblLogs { get; set; }
    }
}
