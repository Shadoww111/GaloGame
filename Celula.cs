using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaloJogo
{
    public class Celula
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        public string Valor { get; set; }

        public Celula() {
            this.Valor = " ";
        }
        public Celula(int linha, int coluna, string valor)
        {
            this.Linha = linha;
            this.Coluna = coluna;
            this.Valor = valor;
        }
        public bool IsCelulavazia()
        {
            if (Valor == " ") return true;
            else return false;
        }

    }
}
