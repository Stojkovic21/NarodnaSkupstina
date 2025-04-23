using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarodnaSkupstina.Entiteti
{
    public class Sednica 
    { 
        public virtual int Id { get; protected set; }
        public virtual DateTime? DatumPocetka { get; set; }
        public virtual DateTime? DatumZavrsetka { get; set; }
        public virtual int BrojZasedanja { get; set; }
        public virtual int BrojSaziva { get; set; }
        public virtual string Tip { get; set; }
        public virtual string KoSaziva { get; set; }
        public virtual IList<OdrzavanjeSednice> OdrzavanjeSednice { get; set; }
        public virtual IList<SazivanjeSednice> SazivaSednice{ get; set; }

        public Sednica() 
        {
            OdrzavanjeSednice = new List<OdrzavanjeSednice>();
        }
    }
}
