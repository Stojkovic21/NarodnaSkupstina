using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarodnaSkupstina.Entiteti
{
    public class PravniAkt
    {
        public virtual int Id { get; protected set; }
        public virtual string Tema { get; set; }
        public virtual string KoPredlaze { get; set; }
        public virtual int BrojBiraca { get; set; }
        public virtual IList<PredlaganjeAkta> PredlazuAkt { get; set; }
        public PravniAkt() 
        {
            PredlazuAkt=new List<PredlaganjeAkta>();
        }
    }
}
