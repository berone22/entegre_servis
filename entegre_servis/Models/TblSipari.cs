using System;
using System.Collections.Generic;

namespace entegre_servis.Models
{
    public partial class TblSipari
    {
        public int SiparisId { get; set; }
        public bool? TeslimEdilen { get; set; }
        public bool? TeslimEdilmeyen { get; set; }
        public bool? IptalEdilen { get; set; }
        public bool? StoktaOlmayan { get; set; }
    }
}
