using System;
using System.ComponentModel;

class Program
{
    static void Main()
    {
        // Palavras disponíveis no jogo
        string[] palavras = { "programacao", "computador", "desenvolvimento", "openai", "linguagem" };

        // Escolha aleatória de uma palavra
        Random random = new Random();
        int indicePalavra = random.Next(0, palavras.Length);
        string palavraSelecionada = palavras[indicePalavra];

        // Inicialização do jogo
        char[] letrasDescobertas = new char[palavraSelecionada.Length];
        for (int i = 0; i < letrasDescobertas.Length; i++)
        {
            letrasDescobertas[i] = '_';
        }

        int tentativasRestantes = 6;
        string letrasTentadas = "";

        // Loop principal do jogo
        while (true)
        {
            DesenharForca(tentativasRestantes);

            // Exibir status do jogo
            status(letrasDescobertas, tentativasRestantes, letrasTentadas);

            // Pedir ao jogador para fazer uma tentativa
            Console.Write("Digite uma letra: ");
            char tentativa = Console.ReadKey().KeyChar;
            Console.WriteLine();

            // Verificar se a letra já foi tentada
            if (letrasTentadas.Contains(tentativa))
            {
                Console.WriteLine("Você já tentou essa letra. Tente novamente.");
                continue;
            }

            // Adicionar a letra às letras tentadas
            letrasTentadas += tentativa + " ";

            // Verificar se a letra está na palavra
            bool letraEncontrada = false;
            for (int i = 0; i < palavraSelecionada.Length; i++)
            {
                if (palavraSelecionada[i] == tentativa)
                {
                    letrasDescobertas[i] = tentativa;
                    letraEncontrada = true;
                }
            }

            // Verificar se o jogador ganhou
            if (ganhou(letrasDescobertas, palavraSelecionada)) break;

            // Reduzir o número de tentativas se a letra não estiver na palavra
            if (!letraEncontrada)
            {
                tentativasRestantes--;
                Console.WriteLine("Letra incorreta. Tente novamente.");
            }

            // Verificar se o jogador perdeu
            if (tentativasRestantes == 0)
            {
                DesenharForca(tentativasRestantes);
                Console.WriteLine("Você perdeu! A palavra correta era: " + palavraSelecionada);
                break;
            }
        }
    }
    static void DesenharForca(int tentativasRestantes)
    {
        Console.Clear();

        Console.WriteLine("Tentativas restantes: " + tentativasRestantes);

        // Aqui você desenha a forca com base no número de tentativas restantes
        switch (tentativasRestantes)
        {
            case 6:
                Console.WriteLine("  _______");
                Console.WriteLine(" |       |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |__________");
                break;
            case 5:
                Console.WriteLine("  _______");
                Console.WriteLine(" |       |");
                Console.WriteLine(" |       O");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |__________");
                break;
            case 4:
                Console.WriteLine("  _______");
                Console.WriteLine(" |       |");
                Console.WriteLine(" |       O");
                Console.WriteLine(" |       |");
                Console.WriteLine(" |");
                Console.WriteLine(" |__________");
                break;
            case 3:
                Console.WriteLine("  _______");
                Console.WriteLine(" |       |");
                Console.WriteLine(" |       O");
                Console.WriteLine(" |      /|");
                Console.WriteLine(" |");
                Console.WriteLine(" |__________");
                break;
            case 2:
                Console.WriteLine("  _______");
                Console.WriteLine(" |       |");
                Console.WriteLine(" |       O");
                Console.WriteLine(" |      /|\\");
                Console.WriteLine(" |");
                Console.WriteLine(" |__________");
                break;
            case 1:
                Console.WriteLine("  _______");
                Console.WriteLine(" |       |");
                Console.WriteLine(" |       O");
                Console.WriteLine(" |      /|\\");
                Console.WriteLine(" |      /");
                Console.WriteLine(" |__________");
                break;
            case 0:
                Console.WriteLine("  _______");
                Console.WriteLine(" |       |");
                Console.WriteLine(" |       O");
                Console.WriteLine(" |      /|\\");
                Console.WriteLine(" |      / \\");
                Console.WriteLine(" |__________");
                break;
            
        }

        Console.WriteLine();
    }

    static void status(char[] letrasDescobertas, int tentativasRestantes, string letrasTentadas )
    {
        Console.WriteLine("Palavra: " + string.Join(" ", letrasDescobertas));
        Console.WriteLine("Tentativas restantes: " + tentativasRestantes);
        Console.WriteLine("Letras tentadas: " + letrasTentadas);
    }

    static bool ganhou(char[] letrasDescobertas,string palavraSelecionada)
    {
        if (!letrasDescobertas.Contains('_'))
        {
            Console.WriteLine("Parabéns! Você acertou a palavra: " + palavraSelecionada);
            return true;
        }
        return false;
    }
 }
