using CurseCase;
using NUnit.Framework;

namespace ConsoleApp1Test;

public class GenTreeToDotTest
{
    
   
    [Test]
    public void toDot__validTrees_writesToFile()
    {
        GenTree myTree = GenTreeFixture.GetFixtureGenTree();
        myTree.ToDot();
    }
    
   
    
    
}