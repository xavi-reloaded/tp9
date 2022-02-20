using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using CurseCase;
using NUnit.Framework;

namespace ConsoleApp1Test;

public class GenTreeTest
{
    
    
    [Test]
    public void Name__settedInConstructor__sameName()
    {
        GenTree sut = new GenTree("PRIMENS", 0, null, null);
        string actual = sut.Name;
        string expected = "PRIMENS";
        Assert.AreEqual(expected, actual );
    }

    [Test]
    public void ChangeName__nameDoesNotExists__false()
    {
        GenTree myTree = GenTreeFixture.GetFixtureGenTree();
        bool actual = GenTree.ChangeName(myTree, "DOS", "TRES");
        bool expected = false;
        Assert.AreEqual(expected, actual );
    }

    [Test]
    public void ChangeName__nameExists__true()
    {
        GenTree myTree = GenTreeFixture.GetFixtureGenTree();
        bool actual = GenTree.ChangeName(myTree, "PRIMENS", "TRES");
        bool expected = true;
        Assert.AreEqual(expected, actual );
    }


    [Test]
    public void ChangeName__rootExists__nameChanged()
    {
        GenTree myTree = GenTreeFixture.GetFixtureGenTree();
        GenTree.ChangeName(myTree, "PRIMENS", "TRES");
        string actual = myTree.Name;
        string expected = "TRES";
        Assert.AreEqual(expected, actual );
    }
    
    [Test]
    public void ChangeName__nameExists__nameChanged()
    {
        GenTree myTree = GenTreeFixture.GetFixtureGenTree();
        GenTree.ChangeName(myTree, "TERCERS", "CUATRAKEN");
        Assert.AreEqual("CUATRAKEN", myTree.Right.Name );
        bool result = GenTree.ChangeName(myTree, "SEGUNS", "NAAN");
        Assert.AreEqual("NAAN", myTree.Left.Name );
        Assert.AreEqual(result, true );
    }

    static object[] ParentCases =
    {
        new object[] { "QUART", "SEGUNS"},
        new object[] { "CINQUE", "SEGUNS"},
        new object[] { "SISE", "TERCERS"},
        new object[] { "SEPTA", "TERCERS"},
        new object[] { "SEGUNS", "PRIMENS"},
        new object[] { "TERCERS", "PRIMENS"}
    };
    [Test, TestCaseSource("ParentCases")]
    public void FindParent__name__parent(string child, string parent)
    {
        GenTree myTree = GenTreeFixture.GetFixtureGenTree();
        string actual = GenTree.FindParentName(myTree, child);
        Assert.AreEqual(actual, parent);
    }
    
    static object[] FindPathCases =
    {
        new object[] { "SISE", "PRIMENS","TERCERS"},
        new object[] { "SEPTA", "PRIMENS","TERCERS"},
        new object[] { "QUART", "PRIMENS","SEGUNS"},
        new object[] { "CINQUE", "PRIMENS","SEGUNS"},
    };
    [Test, TestCaseSource("FindPathCases")]
    public void FindPath__lastMemberOfFixedTree_correctList(string child, string firstInList, string secondInList)
    {
        GenTree myTree = GenTreeFixture.GetFixtureGenTree();
        List<string> emptyList = new List<string>();
        GenTree.FindPath(myTree, child, emptyList);
        Assert.AreEqual(emptyList[0], firstInList );
        Assert.AreEqual(emptyList[1], secondInList );
    }
    [Test]
    public void FindPath__secondMemberOfFixedTree_correctList()
    {
        GenTree myTree = GenTreeFixture.GetFixtureGenTree();
        List<string> emptyList = new List<string>();
        GenTree.FindPath(myTree, "TERCERS", emptyList);
        Assert.AreEqual(emptyList[0], "PRIMENS" );
        Assert.AreEqual(emptyList.Count, 1);
    }
    
    [Test]
    public void FindPath__nonValidName_falset()
    {
        GenTree myTree = GenTreeFixture.GetFixtureGenTree();
        List<string> emptyList = new List<string>();
        bool actual = GenTree.FindPath(myTree, "RATATUNGA", emptyList);
        Assert.False(actual);
    }
    
    [Test]
    public void FindPath__validName_true()
    {
        GenTree myTree = GenTreeFixture.GetFixtureGenTree();
        List<string> emptyList = new List<string>();
        bool actual = GenTree.FindPath(myTree, "CINQUE", emptyList);
        Assert.True(actual);
    } 
    
    static object[] LowestCommonDescendantCases =
    {
        new object[] {"","PRIMENS","TERCERS"},
        new object[] { "PRIMENS","SEPTA","TERCERS"},
        new object[] { "PRIMENS","QUART","SEGUNS"},
        new object[] { "PRIMENS","CINQUE","SEGUNS"},
        new object[] {"SEGUNS","CINQUE","QUART"},
        new object[] { "TERCERS","SEPTA","SISE"},
        new object[] { "PRIMENS","QUART","SISE"},
        new object[] { "PRIMENS","CINQUE","SEPTA"},
    };
    
    [Test]
    public void LowestCommonDescendant__validTrees_true()
    {
        GenTree myTree = GenTreeFixture.GetFixtureGenTree();
        string actual = GenTree.LowestCommonDescendant(myTree, "SISE", "SEPTA");
        string expected = "TERCERS";
        Assert.AreEqual(expected, actual);
    }
    
    [Test, TestCaseSource("LowestCommonDescendantCases")]
    public void LowestCommonDescendant__validTrees__validDescendant(string common,string ParentA, string ParentB)
    {
        GenTree myTree = GenTreeFixture.GetFixtureGenTree();
        string actual = GenTree.LowestCommonDescendant(myTree,ParentA,ParentB);
        string expected = common;
        Assert.AreEqual(expected, actual);
    }
    
    
    
}