using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorridaDeGuerra.Classes.Carros
{
    public static class CarroFactory
    {
        public static Carro CriarCarro(string tipo, string nome)
        {
            return tipo.ToLower() switch
            {
                "veloz" => new CarroVeloz(nome),
                "resistente" => new CarroResistente(nome),
                "ataque" => new CarroAtaque(nome),
                "estrategico" => new CarroEstrategico(nome),
                _ => throw new ArgumentException("Tipo de carro inválido.")
            };
        }
    }
}