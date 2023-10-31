using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
    public class VlProduto
    {
        public int idproduto { get; set; }
        public int idprincipio { get; set; }
        public string nome { get; set; }
        public int idunidade { get; set; }
        public string apresentacao { get; set; }
        public string codca { get; set; }
        public string registro { get; set; }
        public string dtvalidade { get; set; }
        public int idprocedencia { get; set; }
        public int idfabricante { get; set; }
        public decimal precofabrica { get; set; }
        public decimal pmvg { get; set; }
        public decimal convenioicms { get; set; }
        public decimal cap { get; set; }
        public int idclassificacaofiscal { get; set; }
        public string dtcadastro { get; set; }
        public int idusu { get; set; }
        public int idempresa { get; set; }
        public string statusprod { get; set; }
        public int idmarca { get; set; }
        public string validadeprod { get; set; }

    }
}
