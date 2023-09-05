using System.Collections;                               //Caio Wingler e Pedro Henrique de Paula
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

produto[] produtos = new produto[5];            
bool existeProdutos = false;       
bool contMenu = true;
while (contMenu == true)
    {
        Console.WriteLine("----------->MENU<-----------");                      //Menu
        Console.WriteLine("Escolha a opção:\nOpção (1): Cadstrar produtos(cinco)\nOpção (2): Listar produtos\nOpção (3): Sair");
        string opcaoMenu = Console.ReadLine();
            
        switch (opcaoMenu)                                      //Opções do menu
        {
            case "1":
            existeProdutos = true;
            cadastrarProdutos();
            break;
            
            case "2":
                listarProdutos();
            break;
            
            case "3":
                Console.WriteLine("Até depois então :/");
                contMenu = false;
            break;

            default:
                Console.WriteLine("Opção não existe :|");
            break;  

            }
                
        } 
void cadastrarProdutos()                                //Função para cadastrar produtos
{
    for (int i = 0; i < produtos.Length; i++)
    {
        Console.WriteLine($"Informe o nome do {i + 1}º produto: ");
        produtos[i].nomeProduto = Console.ReadLine()!;

        Console.WriteLine($"Informe o preço do {i + 1}º produto: ");
        produtos[i].precoProduto = Console.ReadLine()!;

        Console.WriteLine($"Informe o código do {i + 1}º produto: ");
        produtos[i].codigoProduto = Console.ReadLine()!;
    
    
    }
}

void listarProdutos()                                   //Função para listar os produtos
{
    int numero = 1;
    if (existeProdutos == false)
    {
        Console.WriteLine("Ainda não há produtos cadastrados");
    }
    if (existeProdutos == true)
    {
        foreach(var produto in produtos)
        {
            Console.WriteLine($"Nome do {numero}º produto: {produto.nomeProduto}");
            Console.WriteLine($"Preço do {numero}º produto: {produto.precoProduto}");
            Console.WriteLine($"Código do {numero}º produto: {produto.codigoProduto}");
            numero++;
        }
    }
}

struct produto                          //Struct para representar um produto na fila
{
    public string nomeProduto;
    public string precoProduto;
    public string codigoProduto;
}

