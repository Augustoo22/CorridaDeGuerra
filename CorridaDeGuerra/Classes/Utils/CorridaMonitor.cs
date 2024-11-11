using System;

namespace CorridaDeGuerra.Classes.Utils
{
    public class CorridaMonitor : IObservador
    {
        public void Atualizar(string mensagem)
        {
            Console.WriteLine($"[Notificação] {mensagem}");
        }
    }
}
