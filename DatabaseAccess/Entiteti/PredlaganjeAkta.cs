using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarodnaSkupstina.Entiteti
{
    public class PredlaganjeAkta
    {
        public virtual int Id { get; protected set; }
        public virtual NarodniPoslanik IdPoslanika { get;set;}
        public virtual PravniAkt IdAkta { get; set; }
    }
}
