using CurseCase;

namespace ConsoleApp1Test;

public class GenTreeFixture
{
    
    public static GenTree GetFixtureGenTree()
    {   
        GenTree sise = new GenTree("SISE", 3, null, null);
        GenTree septa = new GenTree("SEPTA", 2, null, null);
        GenTree quart = new GenTree("QUART", 5, null, null);
        GenTree cinque = new GenTree("CINQUE", 6, null, null);
        GenTree seguns = new GenTree("SEGUNS", 0, quart, cinque);
        GenTree tercers = new GenTree("TERCERS", 1, sise, septa);
        GenTree myTree = new GenTree("PRIMENS", 2, seguns, tercers);

        return myTree;
    }
    
}