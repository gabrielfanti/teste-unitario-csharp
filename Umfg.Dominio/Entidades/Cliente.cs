using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umfg.Dominio.Entidades
{
    public sealed class Cliente
    {
        public string Documento { get; private set; }
        public string Nome { get; private set; }

        public Cliente(string documento, string nome)
        {
            Documento = documento 
                ?? throw new ArgumentNullException(nameof(documento));
            Nome = nome
                ?? throw new ArgumentNullException(nameof(nome));
        }
    }
}