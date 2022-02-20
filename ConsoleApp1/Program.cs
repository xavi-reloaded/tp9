
namespace CurseCase
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            GenTree sise = new GenTree("SISE", 3, null, null);
            GenTree septa = new GenTree("SEPTA", 2, null, null);
            GenTree quart = new GenTree("QUART", 5, null, null);
            GenTree cinque = new GenTree("CINQUE", 6, null, null);
            GenTree seguns = new GenTree("SEGUNS", 0, quart, cinque);
            GenTree tercers = new GenTree("TERCERS", 1, sise, septa);
            GenTree myTree = new GenTree("PRIMENS", 2, seguns, tercers);
            
            Console.WriteLine("ChangeName when false = " + GenTree.ChangeName(myTree, "DOS", "TRES"));
            Console.WriteLine("ChangeName when true = " + GenTree.ChangeName(myTree, "QUART", "QUARTER"));
            Console.WriteLine("FindParentName of SEPTA is  = " + GenTree.FindParentName(myTree, "SEPTA"));
            
            List<string> emptyList = new List<string>();
            GenTree.FindPath(myTree, "SEPTA", emptyList);
            Console.WriteLine("FindPath of SEPTA is  = " + string.Join<string>(" | ", emptyList));

            Console.WriteLine("LowestCommonDescendant of SISE / SEPTA is  = " + GenTree.LowestCommonDescendant(myTree, "SISE", "SEPTA"));

            myTree.ToDot();
            Console.WriteLine("ToDot executed (please check  PRIMENS.dot)");
            
            Suspects suspects = new Suspects(myTree, 7);
            Console.WriteLine("Suspects initialized");
            suspects.HeapSort();
            Console.WriteLine("HeapSort first ordered= " + suspects.Data[0].Item1);
            
            
        }
    }
}
