using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarodnaSkupstina.Entiteti
{
    public class SazivanjeSednice
    {
        public virtual string Id { get; protected set; }
        public virtual NarodniPoslanik IdPoslanika { get; set; }
        public virtual Sednica IdSednice{ get; set; }
    }
}
