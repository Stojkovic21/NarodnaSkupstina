using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarodnaSkupstina.Entiteti
{
    public class Organizacija
    {
        public virtual int Id { get; protected set; }
        public virtual int BrojClanova { get; set; }
        public virtual string Tip { get; set; }
        public virtual string Ime { get; set; }
        public virtual NarodniPoslanik IdPredsednika{ get; set; }
        public virtual NarodniPoslanik IdZamenikaPredsednika { get; set; }
        public virtual IList<NarodniPoslanik>NarodniPoslanici { get; set; }
        public virtual IList<SluzbeneProstorije> SluzbeneProstorije{ get; set; }
        public Organizacija() 
        {
                NarodniPoslanici=new List<NarodniPoslanik>();
                SluzbeneProstorije=new List<SluzbeneProstorije>();
        }
    }
}
