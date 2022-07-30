using System;
using System.Collections.Generic;

namespace entegre_servis.DataDB
{
    public partial class Siparisler
    {
        public int SiparisId { get; set; }
        public string? MasaNo { get; set; }
        public string? SiparisIsmi { get; set; }
        public string? SiparisTutarı { get; set; }
        public string? SiparisAcıklama { get; set; }
        public string? GarsonAdi { get; set; }
    }
}
