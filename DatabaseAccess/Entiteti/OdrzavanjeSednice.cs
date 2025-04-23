using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarodnaSkupstina.Entiteti
{
    public class OdrzavanjeSednice
    {
        public virtual int Id { get; protected set; }
        public virtual Sednica IdSednice { get; set; }
        public virtual RadniDan IdDana { get; set; }
        public virtual int BrojPrisutnihPoslanika { get; set; }
    }
}
