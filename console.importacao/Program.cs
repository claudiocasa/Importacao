using biblioteca.importacao;
using entity.sql.importacao.Models;
using leitura.nfe.importacao;
using repository.importacao.repository;
using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace importacao
{
    class Program
    {
        private static int _IdNfe = 0;
        
        static void Main(string[] args)
        {
            string caminho = "NFe15191214160456000123650010001934431309290735.xml";

            using (Importar obj = new Importar(new EFContext()))
            {
                if (obj.Gravar(caminho))
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("");
                    Console.WriteLine("===================================");
                    Console.WriteLine("Importação realizada com sucesso !!");
                    Console.WriteLine("===================================");
                    Console.WriteLine("");
                    _IdNfe = obj.IdNfe;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ocorreu um erro ao tentar importar nota fiscal eletronica !!");
                }
            }

            
            if (_IdNfe != 0)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("");
                Console.WriteLine("==============================================");
                Console.WriteLine("Xml Recuperado diretamente da base de dados !!");
                Console.WriteLine("==============================================");
                Console.WriteLine("");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                using (Exportar obj = new Exportar(new EFContext()))
                {
                    Console.WriteLine(obj.ObterXmlNFe(_IdNfe));
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Tecle a tecla [Enter] para sair");
            Console.ReadKey();
        }
    }
}
