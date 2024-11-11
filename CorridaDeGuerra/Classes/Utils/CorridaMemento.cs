using System.Collections.Generic;
using CorridaDeGuerra.Classes.Carros;

namespace CorridaDeGuerra.Classes.Utils
{
    public class CorridaMemento
    {
        public List<Carro> EstadoCarros { get; }

        public CorridaMemento(List<Carro> estadoCarros)
        {
            EstadoCarros = new List<Carro>(estadoCarros);
        }
    }
}
