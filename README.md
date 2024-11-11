
---

# Corrida de Guerra

### Índice

- [Ideia do Jogo](#ideia-do-jogo)
- [Como Funciona o Jogo](#como-funciona-o-jogo)
- [Objetivo do Jogo](#objetivo-do-jogo)
- [Carros e Habilidades Especiais](#carros-e-habilidades-especiais)
- [Padrões de Design Usados](#padrões-de-design-usados)
- [Exemplo de Código com Padrões de Design](#exemplo-de-código-com-padrões-de-design)
- [Instruções para Jogar](#instruções-para-jogar)
- [Possíveis Expansões Futuras](#possíveis-expansões-futuras)

---

## Ideia do Jogo

"Corrida de Guerra" é um jogo de corrida por turnos, onde cada jogador controla um carro com habilidades especiais. Cada tipo de carro possui atributos únicos, como velocidade, resistência e habilidades especiais que podem ser usadas para ganhar vantagem sobre os oponentes. O jogo foi projetado para ser jogado em um ambiente de console, e o jogador pode escolher entre ações como acelerar, defender ou usar uma habilidade especial a cada turno. 

## Como Funciona o Jogo

O jogo é baseado em turnos. Em cada turno, o jogador pode:
- **Acelerar**: Mover o carro adiante na pista com base em sua velocidade.
- **Defender**: Aumentar temporariamente a resistência para reduzir o dano dos ataques recebidos.
- **Usar Habilidade Especial**: Ativar a habilidade especial única do carro, que pode afetar o jogador ou o oponente.

A corrida continua até que um carro alcance a linha de chegada ou que apenas um carro permaneça ativo (caso os demais sejam eliminados).

### Objetivo do Jogo

O objetivo do jogo é ser o primeiro a alcançar a linha de chegada (distância predefinida) ou eliminar todos os carros adversários. A cada ação, o jogador decide a melhor estratégia para alcançar a vitória, seja acelerando, defendendo-se ou atacando oponentes com habilidades especiais.

## Carros e Habilidades Especiais

Existem quatro tipos principais de carros, cada um com uma habilidade especial única:

1. **Carro Veloz**
   - **Velocidade Base**: Alta
   - **Habilidade Especial (Turbo)**: Aumenta temporariamente a velocidade, permitindo cobrir uma distância maior em um único turno.

2. **Carro Resistente**
   - **Resistência Base**: Alta
   - **Habilidade Especial (Escudo)**: Aumenta temporariamente a resistência, reduzindo o dano recebido de ataques dos oponentes.

3. **Carro de Ataque**
   - **Força de Ataque Base**: Moderada
   - **Habilidade Especial (Impacto de Choque)**: Ataca o oponente causando dano e reduz temporariamente a velocidade dele.

4. **Carro Estratégico**
   - **Habilidade Tática Base**: Boa
   - **Habilidade Especial (Armadilha de Óleo)**: Reduz temporariamente a velocidade do oponente, dificultando sua movimentação.

## Padrões de Design Usados

Este projeto usa cinco padrões de design para estruturar o código, facilitar a manutenção e melhorar a extensibilidade.

### 1. Factory (Fábrica)

**Descrição**: O padrão Factory é usado para criar diferentes tipos de carros, encapsulando o processo de criação em uma classe separada. Isso simplifica a criação de novos tipos de carros e facilita a expansão do jogo.

**Implementação**: A classe `CarroFactory` implementa o padrão Factory. O método `CriarCarro` aceita um tipo de carro (`"veloz"`, `"resistente"`, etc.) e retorna uma instância da subclasse correta.

**Trecho do Código**:
```csharp
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
```

**Por que foi usado?**: Simplifica o processo de criação de novos tipos de carros, centralizando a lógica de criação em uma classe.

---

### 2. Strategy (Estratégia)

**Descrição**: O padrão Strategy permite definir uma família de algoritmos e torná-los intercambiáveis. No contexto do jogo, cada tipo de carro tem uma habilidade especial diferente, representando uma "estratégia" única.

**Implementação**: Cada subclasse de `Carro` implementa sua própria versão do método `UsarHabilidadeEspecial`, representando a habilidade especial do carro.

**Trecho do Código**:
```csharp
public class CarroAtaque : Carro
{
    public override void UsarHabilidadeEspecial(Carro oponente)
    {
        oponente.ReceberAtaque(danoImpacto);
        oponente.ReduzirVelocidadeTemporariamente(reducaoVelocidade);
    }
}
```

**Por que foi usado?**: Permite que cada carro tenha uma habilidade especial única, facilitando a adição de novas habilidades no futuro.

---

### 3. Observer (Observador)

**Descrição**: O padrão Observer permite que um objeto (sujeito) notifique outros objetos (observadores) sobre mudanças em seu estado. No jogo, isso é útil para exibir atualizações e notificações ao jogador sobre o andamento da corrida.

**Implementação**: `IObservador` é uma interface que define o método `Atualizar`. A classe `CorridaMonitor` implementa essa interface para exibir notificações.

**Trecho do Código**:
```csharp
public interface IObservador
{
    void Atualizar(string mensagem);
}

public class CorridaMonitor : IObservador
{
    public void Atualizar(string mensagem)
    {
        Console.WriteLine($"[Notificação] {mensagem}");
    }
}
```

**Por que foi usado?**: Torna o jogo mais dinâmico e informativo, fornecendo notificações ao jogador.

---

### 4. Singleton (Instância Única)

**Descrição**: O padrão Singleton garante que uma classe tenha apenas uma única instância e fornece um ponto de acesso global. Aqui, `GameManager` é implementado como Singleton para gerenciar a pontuação global do jogo.

**Implementação**: `GameManager` usa um construtor privado e uma propriedade estática `Instancia` para garantir que apenas uma instância exista.

**Trecho do Código**:
```csharp
public class GameManager
{
    private static GameManager _instancia;
    public int Pontuacao { get; private set; }

    private GameManager() { Pontuacao = 0; }

    public static GameManager Instancia
    {
        get
        {
            if (_instancia == null)
                _instancia = new GameManager();
            return _instancia;
        }
    }
}
```

**Por que foi usado?**: Centraliza o controle do estado global do jogo, como pontuação, permitindo fácil acesso e gerenciamento.

---

### 5. Memento (Registro de Estado)

**Descrição**: O padrão Memento permite capturar e restaurar o estado de um objeto. No jogo, `CorridaMemento` armazena o estado dos carros para possibilitar salvamento e carregamento da corrida.

**Implementação**: `CorridaMemento` armazena uma cópia do estado dos carros e permite restaurar esse estado na classe `Corrida`.

**Trecho do Código**:
```csharp
public class CorridaMemento
{
    public List<Carro> EstadoCarros { get; }

    public CorridaMemento(List<Carro> estadoCarros)
    {
        EstadoCarros = new List<Carro>(estadoCarros);
    }
}
```

**Por que foi usado?**: Permite que o jogador salve e recarregue o progresso, fornecendo uma funcionalidade de continuidade para o jogo.

---

## Instruções para Jogar

1. **Configurar o `Program.cs`**:
   - Configure o ponto de entrada do jogo em `Program.cs` para criar a instância de `Corrida`, adicionar os carros e observadores, e iniciar a corrida.

2. **Compilar e Executar**:
   - Compile e execute o projeto em um ambiente de console.
   
3. **Interação**:
   - Escolha ações para cada carro em cada turno (Acelerar, Defender ou Usar Habilidade Especial).
   - Receba notificações no console sobre o andamento da corrida e ações dos carros.

## Possíveis Expansões Futuras

1. **Modo de Jogo PvE (Player vs. Environment)**: Adicionar uma IA simples para jogar contra o computador.
2. **Sistema de Salvamento e Carregamento Avançado**: Salvar o estado do jogo em um arquivo para ser carregado posteriormente.
3. **Mais Tipos de Carros e Habilidades**: Adicionar novos tipos de carros e habilidades para aumentar a diversidade.

Esse README fornece uma visão abrangente do projeto, desde a ideia

 do jogo até os padrões de design implementados, trechos de código exemplares, e sugestões para futuras expansões.