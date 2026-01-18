// 🧠 O que é o Factory Method?

// O Factory Method é um padrão de projeto criacional que proporciona uma forma de encapsular a criação de objetos, 
// separando a lógica de criação da lógica de uso dos objetos.

// Ou seja:

// Em vez de usar "new" diretamente em vários lugares do seu código, você delegará essa criação a um método 
// especial chamado factory method.

// 🧩 Por que usar este padrão?

// Imagine que você tem um sistema que vai trabalhar com diferentes tipos de "transportes" — como caminhões e navios. 
// Sem o padrão, você escreveria isto:

var caminhao = new Caminhao();

var navio = new Navio();

// Esse código fica espalhado pela aplicação; quando você tiver novos tipos de transporte, vai precisar modificar tudo!

// Com o Factory Method:

// Você escreve a lógica de criação apenas uma vez;

// Facilita a extensão do sistema;

// Reduz o acoplamento entre classes.

// ------------------------------------------------------------------------------------------------------------------

// Estrutura Conceitual

// 🧱 Produto
// Define a interface que todos os produtos concretos devem implementar.

// 🚚 Produto Concreto
// Classes que implementam a interface do produto.

// 🏭 Criador
// Declara o factory method que retorna um produto abstrato.

// 🪄 Criador Concreto
// Sobrescreve o factory method para criar tipos específicos de produtos.

// Resumo:
// O cliente trabalha com produtos via a interface abstrata, sem saber qual classe concreta está sendo instanciada.

// ------------------------------------------------------------------------------------------------------------------

// 🔎 Quando usar Factory Method?

// Use o padrão quando:

// ✔ Você não sabe de início quais classes concretas serão necessárias.
// ✔ Deseja desacoplar a criação de objetos da sua lógica de uso.
// ✔ Quer facilitar a extensão do sistema ao adicionar novos tipos de produtos.

// ------------------------------------------------------------------------------------------------------------------

// 🧪 AGORA VAMOS PARTIR PARA A PRÁTICA!!!

// Passo 1: Defina a interface do produto.

public interface ITransporte
{
    void Entregar();
}

// Passo 2: Crie produtos concretos (classe que implementa ITransporte).

public class Caminhao : ITransporte
{
    public void Entregar()
    {
        Console.WriteLine("Entrega realizada por caminhão.");
    }
}

public class Navio : ITransporte
{
    public void Entregar()
    {
        Console.WriteLine("Entrega realizada por navio.");
    }
}

// Passo 3: Defina o criador abstrato com o factory method.

public abstract class Logistica
{
    // Método de fábrica
    public abstract ITransporte CriarTransporte();

    public void PlanejarEntrega()
    {
        var transporte = CriarTransporte();
        transporte.Entregar();
    }
}

// Passo 4: Crie criadores concretos que implementam o factory method.

public class LogisticaTerrestre : Logistica
{
    public override ITransporte CriarTransporte()
    {
        return new Caminhao();
    }
}

public class LogisticaMaritima : Logistica
{
    public override ITransporte CriarTransporte()
    {
        return new Navio();
    }
}

// Passo 5: Use o padrão Factory Method no código cliente.

class Exemplo
{
    static void Main(string[] args)
    {
        Logistica logistica;

        // Decidir o tipo de logística com base em alguma condição
        Console.Write("Digite o tipo de logística (Terrestre/Maritima): ");
        string tipoLogistica = Console.ReadLine() ?? "";

        switch(tipoLogistica.ToLower())
        {
            case "terrestre":
                logistica = new LogisticaTerrestre();
                break;
            case "maritima":
                logistica = new LogisticaMaritima();
                break;
            default:
                throw new Exception("Tipo de logística desconhecido.");
        }

        logistica.PlanejarEntrega();
    }
}

// 📌 Explicação do Código

// ✔ Logistica.PlanejarEntrega() chama o Factory Method CriarTransporte() para obter um produto.
// ✔ O cliente usa o produto através da interface ITransporte, sem depender de Caminhao ou Navio.