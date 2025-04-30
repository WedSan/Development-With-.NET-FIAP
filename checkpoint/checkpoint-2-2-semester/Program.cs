using checkpoint_5;

internal class Program
{
    public static async Task Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Escolha uma opção para executar:");
            Console.WriteLine("1 - Sender 1 (Frutas da Época)");
            Console.WriteLine("2 - Sender 2 (Dados do Usuário)");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Executando Sender 1...");
                    var sender1 = new FruitsSender();
                    sender1.Send();
                    break;

                case "2":
                    Console.WriteLine("Executando Sender 2...");
                    var sender2 = new PersonSender();
                    sender2.Send();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Finalizando o programa.");
                    break;
            }

            Console.WriteLine("Programa finalizado."); 
        }
    }
}
