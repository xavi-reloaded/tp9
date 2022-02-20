using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using CurseCase;
using NUnit.Framework;

namespace ConsoleApp1Test;

public class SuspectsTest
{
    [Test]
    public void constructor__fixture_tuplaWellFormed()
    {
        GenTree myTree = GenTreeFixture.GetFixtureGenTree();
        Suspects sut = new Suspects(myTree, 7);
        Assert.NotNull(sut);
        Assert.AreEqual(sut.Data.Length,7);
    } 
    
    [Test]
    public void HeapSort__fixture_tuplaWellFormed()
    {
        GenTree myTree = GenTreeFixture.GetFixtureGenTree();
        Suspects sut = new Suspects(myTree, 7);
        sut.HeapSort();
        var expected = "CINQUE";
        var actual = sut.Data[0].Item1;
        
        Assert.AreEqual(expected, actual);
    } 
}