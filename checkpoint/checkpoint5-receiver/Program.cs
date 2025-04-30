using checkpoint_5;

internal class Program
{
    public static void Main(string[] args)
    {

            Console.WriteLine("Escolha uma opção para executar:");
            Console.WriteLine("1 - Receiver 1 (Frutas da Época)");
            Console.WriteLine("2 - Receiver 2 (Dados do Usuário)");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Executando Receiver 1...");
                    var receiver = new FruitsReceiver();
                    receiver.Receive();
                    break;

                case "2":
                    Console.WriteLine("Executando Receiver 2...");
                    var receiver2 = new PersonReceiver();
                    receiver2.Receive();
                    break;

                default:
                    Console.WriteLine("Opção inválida. Finalizando o programa.");
                    break;
            }

            Console.WriteLine("Programa finalizado.");
        }
}