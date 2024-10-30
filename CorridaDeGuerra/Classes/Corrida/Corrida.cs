using System;
using System.Collections.Generic;
using CorridaDeGuerra.Classes.Carros;

namespace CorridaDeGuerra.Classes.Corrida
{
    public class Corrida
    {
        private List<Carro> carrosParticipantes;
        private int distanciaDaCorrida;

        public Corrida(int distancia)
        {
            carrosParticipantes = new List<Carro>();
            distanciaDaCorrida = distancia;
        }

        public void AdicionarCarro(Carro carro)
        {
            carrosParticipantes.Add(carro);
            Console.WriteLine($"{carro.Nome} foi adicionado à corrida!");
        }

        public void Iniciar()
        {
            Console.WriteLine("A corrida começou!");

            bool corridaEmAndamento = true;

            while (corridaEmAndamento)
            {
                foreach (var carro in carrosParticipantes)
                {
                    if (carro.EstaNaCorrida())
                    {
                        ExibirOpcoes(carro);
                    }

                    if (carro.Posicao >= distanciaDaCorrida)
                    {
                        Console.WriteLine($"{carro.Nome} venceu a corrida!");
                        corridaEmAndamento = false;
                        break;
                    }
                }

                carrosParticipantes.RemoveAll(c => !c.EstaNaCorrida());
            }
        }

        private void ExibirOpcoes(Carro carro)
        {
            Console.WriteLine($"\nTurno de {carro.Nome}:");
            Console.WriteLine("1. Acelerar");
            Console.WriteLine("2. Defender");
            Console.WriteLine("3. Usar Habilidade Especial");
            Console.Write("Escolha uma ação: ");
            
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    carro.Acelerar();
                    break;
                case "2":
                    carro.Defender();
                    break;
                case "3":
                    UsarHabilidadeEspecial(carro);
                    break;
                default:
                    Console.WriteLine("Escolha inválida. Ação ignorada.");
                    break;
            }
        }

        private void UsarHabilidadeEspecial(Carro carro)
        {
            Console.WriteLine("Escolha um oponente para usar a habilidade especial:");
            for (int i = 0; i < carrosParticipantes.Count; i++)
            {
                if (carrosParticipantes[i] != carro && carrosParticipantes[i].EstaNaCorrida())
                {
                    Console.WriteLine($"{i + 1}. {carrosParticipantes[i].Nome}");
                }
            }

            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= carrosParticipantes.Count)
            {
                var oponente = carrosParticipantes[escolha - 1];
                carro.UsarHabilidadeEspecial(oponente);
            }
            else
            {
                Console.WriteLine("Escolha inválida. Habilidade especial não usada.");
            }
        }
    }
}
