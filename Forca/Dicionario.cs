using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forca
{
    public class Dicionario
    {
        private List<String> bancoDePalavras = new  List<string>();

        private string caminhoDoArquivo = "./dados.txt";


        public Dicionario() {
            try
            {
                // Lê todas as linhas do arquivo
                var palavras = File.ReadAllLines(this.caminhoDoArquivo);

                foreach(var palavra in palavras)
                {
                   this.bancoDePalavras.Add(palavra);    
                }
                Console.WriteLine("Palavras carregadas com sucesso!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao ler o arquivo: {ex.Message}");
            }
        
        } 
        
        public string sorteiaPalavra()
        {
            Random random = new Random();
            int indicePalavra = random.Next(0, this.bancoDePalavras.Count());
            string palavraSelecionada = bancoDePalavras[indicePalavra-1];
            return palavraSelecionada;

        }


    }
}
