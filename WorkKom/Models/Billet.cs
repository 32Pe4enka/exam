using System;
using System.Collections.Generic;

namespace WorkKom.Models
{
    public partial class Billet
    {
        public int IdB { get; set; }
        public DateTime BillDv { get; set; }
        public DateTime BillDp { get; set; }
        public int NomerM { get; set; }
    }
}
