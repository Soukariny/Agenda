namespace Agenda
{
    public class Node
    {
        public Contato data;
        public Node next;

        public Node(Contato c) 
        {
            data = c;
            next = null;
        }
    }
}