using System;
namespace Agenda
{
    public class ListaCircular
    {
        public Node head;

        public ListaCircular()
        {
            head = null;
            }
        public void Recuperar()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Kariny Sampaio\Desktop\Estrutura de Dados\EstruturaDeDados\Agenda\agenda.txt");
            
                int l = 0;

                while (l < lines.Length)
                { 
                    Contato contato = new Contato();

                    string[] aux = lines[l].Split("-");
                    contato.nome = aux[0];
                    contato.numero = Convert.ToInt32(aux[1]); 
                    contato.email = aux[2];
                    this.Adicinar(contato);
                l++;
                }
            } 
            catch (System.IO.FileNotFoundException e)
            {     
            }
        }
        
        public void Cadastro()
        {   
            
            Console.WriteLine("Cadastrar\n");
            Contato c = new Contato();
            Console.Write("Nome: ");
            c.nome = Console.ReadLine();
            Console.Write("Numero: ");
            c.numero = Convert.ToInt32(Console.ReadLine());
            Console.Write("Email: ");
            c.email = Console.ReadLine();
            this.Adicinar(c);
        }

        public void Adicinar(Contato c)
        {   
            var newNode = new Node(c);
            Node aux = head;
            
            if (head != null)
            {    
                while(aux.next != head)
                {
                    aux = aux.next;
                }
            aux.next = newNode; 
            newNode.next = head;
            }
            
            else
            {               
                aux = newNode;
                aux.next = aux;
                head = aux;
            }
        }

        public bool vazio() 
        {
            return (head == null);
        }

        public void Manter()
        {
            if (!this.vazio()){
            Node node = head;
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Kariny Sampaio\Desktop\Estrutura de Dados\EstruturaDeDados\Agenda\agenda.txt", false);
            do{
                file.WriteLine($"{node.data.nome}-{node.data.email}-{node.data.numero}");
                node = node.next; 
            }while (node != head);
            file.Close();
            } else {
                System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Kariny Sampaio\Desktop\Estrutura de Dados\EstruturaDeDados\Agenda\agenda.txt", false);
                file.Close();
            }
        }
    
        public static void Exibir(Contato contato)
        {
            Console.WriteLine("Pesquisar");
            Console.WriteLine("Baixo: Transitar entre contatos.");
            Console.WriteLine("A: Atualizar contato.");
            Console.WriteLine("D: Deletar contato.");
            Console.WriteLine("ESC: Sair da navegação");
            
            Console.WriteLine($"Nome: {contato.nome}");
            Console.WriteLine($"E-mail: {contato.email}");
            Console.WriteLine($"Numero: {contato.numero}");       
        }
    
        public void Avancar(ConsoleKeyInfo input, Node node, ListaCircular lista )
        {   bool vazio = lista.vazio();
            while(input.Key != ConsoleKey.Escape)
            {
                switch(input.Key)
                {
                    case ConsoleKey.DownArrow:
                        node = node.next;
                        Console.Clear();
                        ListaCircular.Exibir(node.data);
                        break;
                    case ConsoleKey.A:
                        Console.Clear();
                        Console.WriteLine("Atualize o contato.");
                        lista.Att(node);
                        Console.Clear();
                        Console.WriteLine("Atualização completa.");
                        ListaCircular.Exibir(node.data);
                        break;
                    case ConsoleKey.D:
                        node = lista.Del(node);
                        if (node != null)
                        {
                        Console.Clear();
                        Console.WriteLine("Contato Deletado.");
                        ListaCircular.Exibir(node.data);
                        } else {
                            Console.Clear();
                            Console.WriteLine("Lista vazia, aperte ESC.");
                            vazio = true;
                        }
                        break;
                }
                input = Console.ReadKey();
            }
         }
    
        public void Att(Node node)
        {   
            string[] att = new string[3];
            Console.Write("Nome: ");
            att[0] = Console.ReadLine();
            Console.Write("Numero: ");
            att[1] = Console.ReadLine();
            Console.Write("Email: ");
            att[2] = Console.ReadLine();

            if (att[0] != "")
            {
                node.data.nome = att[0];
            }
            if (att[1] != "")
            {
                node.data.numero = Convert.ToInt32(att[1]); 
            }
            if (att[2] != "")
            {
                node.data.email = att[2];
            }
        }
    
        public Node Del(Node no)
        {   
            if (no == head && no.next == head)
            {
                head = null;
                return null;
            }

            bool flag = false;
            if (no == head)
            {
                flag = true;
            }
            
            Node next = no.next;
            
            if (flag)
            {
                head = next;
            }

            return next;
        }
    } 
}