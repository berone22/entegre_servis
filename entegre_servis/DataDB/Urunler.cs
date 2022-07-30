using System;
using System.Collections.Generic;

namespace entegre_servis.DataDB
{
    public partial class Urunler
    {
        public int Id { get; set; }
        public string? UrunIsim { get; set; }
        public string? UrunFiyati { get; set; }
        public string? UrunAdeti { get; set; }
    }
}
