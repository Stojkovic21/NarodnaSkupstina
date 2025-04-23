using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarodnaSkupstina.Entiteti
{
    public class SluzbeneProstorije
    {
        public virtual int BrojProstorije { get; set; }
        public virtual int Sprat { get; set; }
        public virtual Organizacija IdOrganizacije { get; set; }
    }
}
