// Classes/Utils/GameManager.cs
namespace CorridaDeGuerra.Classes.Utils
{
    public class GameManager
    {
        private static GameManager _instancia;
        public int Pontuacao { get; private set; }

        // Construtor privado para garantir que a classe só pode ser instanciada internamente
        private GameManager() 
        { 
            Pontuacao = 0; 
        }

        // Propriedade para acessar a única instância de GameManager
        public static GameManager Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new GameManager();
                return _instancia;
            }
        }

        // Método para adicionar pontos ao estado global de pontuação
        public void AdicionarPontuacao(int pontos)
        {
            Pontuacao += pontos;
        }
    }
}
