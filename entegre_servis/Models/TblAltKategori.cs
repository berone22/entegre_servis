﻿using System;
using System.Collections.Generic;

namespace entegre_servis.Models
{
    public partial class TblAltKategori
    {
        public TblAltKategori()
        {
            TblKategoris = new HashSet<TblKategori>();
        }

        public int AltKategoriId { get; set; }
        public string? AltKategori { get; set; }

        public virtual ICollection<TblKategori> TblKategoris { get; set; }
    }
}
