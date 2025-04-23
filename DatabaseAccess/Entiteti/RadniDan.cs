using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarodnaSkupstina.Entiteti
{
    public class RadniDan
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime Datum { get; set; }
        public virtual DateTime RadiOd { get; set; }
        public virtual DateTime RadiDo { get; set; }
        public virtual IList<OdrzavanjeSednice> OdrzavanjeSednice { get; set; }

        public RadniDan() 
        {
            OdrzavanjeSednice=new List<OdrzavanjeSednice>();
        }  
        public RadniDan(int id,DateTime datum, DateTime radiOd, DateTime radiDo)
        {
            Id = id;
            Datum = datum;
            RadiOd = radiOd;
            RadiDo = radiDo;
        }
    }
}
