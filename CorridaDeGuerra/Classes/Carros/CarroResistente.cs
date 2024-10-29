using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorridaDeGuerra.Classes.Carros
{
    public class CarroResistente : Carro
    {
        private int bonusResistencia;

        public CarroResistente(string nome) : base(nome, velocidade: 6, resistencia: 8, vida: 120){
            bonusResistencia = 5;
        }

        public override void Defender()
        {
            int resistenciaTotal = Resistencia + bonusResistencia;
            Console.WriteLine($"{Nome} ativou o Escudo, aumentando sua resistência para {resistenciaTotal} temporiamente!");
            Resistencia += bonusResistencia;
        }

        public override void UsarHabilidadeEspecial(Carro oponente)
        {
            Console.WriteLine($"{Nome} usou sua habilidade especial de Escudo!");
            bonusResistencia += 3;
            Defender();
            bonusResistencia -= 3;
        }

        public override void ReceberAtaque(int dano)
        {
            int danoRecebido = Math.Max(0, dano - Resistencia);
            Vida -= danoRecebido;
            Console.WriteLine($"{Nome} recebeu um ataque e reduziu o dano com sua resistencia! Dano recebido: {danoRecebido}. Vida restante: {Vida}");

            Resistencia -= bonusResistencia;
        }
    }
}