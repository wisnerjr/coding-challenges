using System;

namespace KingSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console/Main somente para testes rápidos

            // Há existência da classe de testes
            KingSort kingSort = new KingSort();
            string[] kings = new string[] {"Carlos I", "Carlos X", "Carlos II", "Carlos XX", "Carlos III", "Carlos XXX"};

            var list = kingSort.getSortedList(kings);

            list.ForEach(i => Console.Write("{0}\t", i));

            Console.ReadLine();
        }
    }
}
