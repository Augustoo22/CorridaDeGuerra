using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorridaDeGuerra.Classes.Carros
{
    public class CarroEstrategico : Carro
    {
        private int reducaoVelocidadeOponente;

        public CarroEstrategico(string nome) : base(nome, velocidade: 7, resistencia: 6, vida: 100)
        {
            reducaoVelocidadeOponente = 3;
        }

        public override void UsarHabilidadeEspecial(Carro oponente)
        {
            Console.WriteLine($"{Nome} usou sua habilidade especial de Armadilha de Óleo contra {oponente.Nome}");

            oponente.ReduzirVelocidadeTemporariamente(reducaoVelocidadeOponente);
            Console.WriteLine($"{oponente.Nome} teve sua velocidade reduzida em {reducaoVelocidadeOponente} temporiamente!");
        
            oponente.RestaurarVelocidade(reducaoVelocidadeOponente);
        
        }
    }
}