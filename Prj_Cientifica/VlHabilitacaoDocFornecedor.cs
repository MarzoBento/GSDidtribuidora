﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public class VlHabilitacaoDocFornecedor
    {
        public int iddocfornecedor { get; set; }
        public int idfornecedor { get; set; }
        public int idtipodoc { get; set; }
        public int idedital { get; set; }
        public static Byte[] arq;
        public string nomearq { get; set; }
        public string extensao { get; set; }
        public string dtarquivo { get; set; }
        public int idusu { get; set; }

    }
}
