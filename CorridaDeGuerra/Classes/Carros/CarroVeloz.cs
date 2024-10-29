using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorridaDeGuerra.Classes.Carros
{
    public class CarroVeloz : Carro
    {
        private int bonusVelocidade;

        public CarroVeloz(string nome) : base(nome, velocidade: 10, resistencia: 3, vida: 100){
            bonusVelocidade = 5;
        }

        public override void Acelerar()
        {
            int velocidadeTotal = Velocidade + bonusVelocidade;
            Posicao += velocidadeTotal;
            Console.WriteLine($"{Nome} ativou o Turbo e avançou para a posição {Posicao} com velocidade {velocidadeTotal}!");
        }

        public override void UsarHabilidadeEspecial(Carro oponente)
        {
            Console.WriteLine($"{Nome} usou habilidade especial de Turbo");
            bonusVelocidade += 5;
            Acelerar();
            bonusVelocidade -= 5;
        }
    }
}