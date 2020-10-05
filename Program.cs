using System;

namespace Agenda
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaCircular lista = new  ListaCircular();

            lista.Recuperar();
            int op;
            
            do
            {
                Console.Clear();
                Console.WriteLine("Qual tarefa deseja realizar?");
                Console.WriteLine("1- Cadastrar.");
                Console.WriteLine("2- Pesquisar.");
                Console.WriteLine("3- Sair.");
                op =  Convert.ToInt32(Console.ReadLine());

                switch(op)
                {
                    case 1:
                        Console.Clear();
                        lista.Cadastro();                                              
                        break;
                    case 2:
                        Console.Clear();
                        Node node = lista.head;
                        bool empty = lista.vazio();
                        ConsoleKeyInfo input;
                        if (node != null)
                        {
                            ListaCircular.Exibir(node.data);
                        } else
                        {
                            Console.Clear();
                            Console.WriteLine("Você não possui contatos, pressione ESQ.");
                            Console.ReadKey();
                            break;
                        }
                        input = Console.ReadKey();
                        lista.Avancar(input, node, lista);
                        break;
                    case 3:
                        Console.Clear();
                        lista.Manter();
                        break;

                }
            }while (op != 3);
            
        }
    }
}
