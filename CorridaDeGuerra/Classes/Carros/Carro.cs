using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorridaDeGuerra.Classes.Carros
{
    public abstract class Carro
    {
        public string Nome { get; protected set; }
        public int Velocidade { get; protected set; }   
        public int Resistencia { get; protected set; }
        public int Posicao { get; protected set; }
        public int Vida { get; protected set; }  

        protected Carro(string nome, int velocidade, int resistencia, int vida,){
            Nome = nome;
            Velocidade = velocidade;
            Resistencia = resistencia;
            Vida = vida;
            Posicao = 0;
        }

        public virtual void Acelerar(){
            Posicao += Velocidade;
            Console.WriteLine($"{Nome} acelerou e avançou para a posição {Posicao}");
        }

        public virtual void Defender(){
            Resistencia += 5;
            Console.WriteLine($"{Nome} ativou a defesa! Resistência aumentada para {Resistencia}.");
        }
        
        public abstract void UsarHabilidadeEspecial(Carro oponente);

        public virtual void ReceberAtaque(int dano){
            int danoRecebido = Math.Max(0, dano - Resistencia);
            Vida -= danoRecebido;
            Console.WriteLine($"{Nome} foi atacado e recebeu {danoRecebido} de dano! Vida restante: {Vida}");

            Resistencia -= 5;
        }

        public bool EstaNaCorrida(){
            return Vida > 0;
        }

        public void ReduzirVelocidadeTemporariamente(int reducao)
        {
            Velocidade = Math.Max(0, Velocidade - reducao);
        }

        public void RestaurarVelocidade(int aumento)
        {
            Velocidade += aumento;
        }
    }
}
