using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorridaDeGuerra.Classes.Carros
{
    public class CarroAtaque : Carro
    {
        private int danoImpacto;
        private int reducaoVelocidade;

        public CarroAtaque(string nome) : base(nome, velocidade: 8, resistencia: 5, vida: 110)
        {
            danoImpacto = 10;
            reducaoVelocidade = 2;
        }

        public override void UsarHabilidadeEspecial(Carro oponente)
        {
            Console.WriteLine($"{Nome} usou sua habilidade especial de Impacto de Choque contra {oponente.Nome}!");
            
            // Aplica dano direto ao oponente
            oponente.ReceberAtaque(danoImpacto);
            
            // Reduz temporariamente a velocidade do oponente usando o método novo
            oponente.ReduzirVelocidadeTemporariamente(reducaoVelocidade);
            Console.WriteLine($"{oponente.Nome} teve sua velocidade reduzida temporariamente!");

            // Restaura a velocidade do oponente no próximo turno
            oponente.RestaurarVelocidade(reducaoVelocidade);
        }

        public override void Acelerar()
        {
            Console.WriteLine($"{Nome} está pronto para atacar e avançou com velocidade de {Velocidade}!");
            base.Acelerar();
        }
    }
}
