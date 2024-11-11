using System;
using CorridaDeGuerra.Classes.Corrida;
using CorridaDeGuerra.Classes.Carros;
using CorridaDeGuerra.Classes.Utils;

namespace CorridaDeGuerra
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define a distância da corrida
            int distanciaDaCorrida = 50;

            // Cria uma nova corrida
            Corrida corrida = new Corrida(distanciaDaCorrida);

            // Adiciona um monitor para receber notificações
            CorridaMonitor monitor = new CorridaMonitor();
            corrida.AdicionarObservador(monitor);

            // Cria alguns carros usando o CarroFactory
            Carro carro1 = CarroFactory.CriarCarro("veloz", "Speedster");
            Carro carro2 = CarroFactory.CriarCarro("resistente", "Tank");
            Carro carro3 = CarroFactory.CriarCarro("ataque", "Blaster");
            Carro carro4 = CarroFactory.CriarCarro("estrategico", "Strategist");

            // Adiciona os carros à corrida
            corrida.AdicionarCarro(carro1);
            corrida.AdicionarCarro(carro2);
            corrida.AdicionarCarro(carro3);
            corrida.AdicionarCarro(carro4);

            // Inicia a corrida
            corrida.Iniciar();

            Console.WriteLine("Fim do jogo! Obrigado por jogar.");
        }
    }
}
