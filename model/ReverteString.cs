using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetSistemas.model
{
    public class ReverteString
    {
        public string? palavra { get; set; }
        public char[]? charPalavra;

        public void reverterCaracteres(){
           
            charPalavra = palavra?.ToCharArray();
            List<char> charReverso = new List<char>();

            for (int i = charPalavra.Length - 1; i >= 0; i--)
            {

                charReverso.Add(charPalavra[i]);
            }
            
            foreach (var item in charReverso)
            {
                Console.Write(item);
            }
        }
    }
}