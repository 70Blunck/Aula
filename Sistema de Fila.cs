using System;               

namespace SistemaFilaAtendimento
{
    // Struct para representar um cliente na fila
    struct Cliente                                     
    {
        public string CPF;                                  //Caio Wingler e Pedro Henrique de Paula
        public string Nome;
        public int Senha;
    }

    class Program
    {
        static Cliente[] fila = new Cliente[10]; // Tamanho máximo da fila
        static int tamanhoFila = 0; // Variável para rastrear o tamanho atual da fila

        static void Main(string[] args)                         
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("Sistema de Fila de Atendimento");                    //Menu
                Console.WriteLine("1. Cadastrar Cliente");
                Console.WriteLine("2. Listar Fila de Atendimento");
                Console.WriteLine("3. Atender Cliente");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");

                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)                                                      //opções do menu
                {
                    case 1:
                        CadastrarCliente();
                        break;
                    case 2:
                        ListarFila();
                        break;
                    case 3:
                        AtenderCliente();
                        break;
                    case 4:
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void CadastrarCliente()                                          //Função para cadastrar o cliente
        {
            if (tamanhoFila < fila.Length)
            {
                Cliente cliente = new Cliente();

                Console.Write("CPF do Cliente: ");
                cliente.CPF = Console.ReadLine();

                Console.Write("Nome do Cliente: ");
                cliente.Nome = Console.ReadLine();

                cliente.Senha = tamanhoFila + 1; // Senha sequencial

                fila[tamanhoFila] = cliente;
                tamanhoFila++;

                Console.WriteLine("Cliente cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("A fila de atendimento está cheia. Aguarde atendimento.");
            }
        }

        static void ListarFila()                                             //Função para cadastrar um cliente na fila
        {
            Console.WriteLine("Fila de Atendimento:");
            foreach (var cliente in fila)
            {
                if (!string.IsNullOrEmpty(cliente.CPF))
                {
                    Console.WriteLine($"CPF: {cliente.CPF}, Nome: {cliente.Nome}, Senha: {cliente.Senha}");
                }
            }
        }

        static void AtenderCliente()                            //Função para atender um cliente
        {
            if (tamanhoFila > 0)
            {
                Console.WriteLine($"Cliente {fila[0].Nome} com CPF {fila[0].CPF} foi atendido. Senha: {fila[0].Senha}");
                // Remova o cliente da fila (FIFO)
                for (int i = 0; i < tamanhoFila - 1; i++)
                {
                    fila[i] = fila[i + 1];
                }
                fila[tamanhoFila - 1] = new Cliente(); // Limpa o último elemento
                tamanhoFila--;
            }
            else
            {
                Console.WriteLine("A fila de atendimento está vazia.");
            }
        }
    }
}