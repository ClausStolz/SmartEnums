using System;
using NUnit.Framework;
using System.Linq;
using SmartEnums.Tests.Enums;

namespace SmartEnums.Tests;

public class EnumTagTests
{
    [Test]
    [TestCase(EnumTag.First, new[] { "test", "predicate" })]
    [TestCase(EnumTag.Second, new[] { "test" })]
    [TestCase(EnumTag.Third, null)]
    public void TestGetEnumTags(Enum obj, string[] expectedResult)
    {
        foreach (var element in obj.GetEnumTags()!)
        {
            Assert.True(expectedResult.Contains(element));
        }
    }
    
    [Test]
    [TestCase("test", new[] { EnumTag.First, EnumTag.Second })]
    [TestCase("predicate", new[] { EnumTag.First })]
    [TestCase("undefined", null)]
    public void TestFindBySingleTag(string tag, EnumTag[] expectedResult)
    {
        foreach (var element in SmartEnum.FindByTag<EnumTag>(tag))
        {
            Assert.True(expectedResult.Contains(element));
        }
    }
    
    [Test]
    [TestCase(new[] { "test" }, new[] { EnumTag.First, EnumTag.Second })]
    [TestCase(new[] { "test", "predicate" }, new[] { EnumTag.First })]
    [TestCase(new[] { "test", "undefined" }, null)]
    public void TestFindByAllTags(string[] tags, EnumTag[] expectedResult)
    {
        foreach (var element in SmartEnum.FindByTag<EnumTag>(tags, TagSearchingFlag.All))
        {
            Assert.True(expectedResult.Contains(element));
        }
    }
    
    [Test]
    [TestCase(new[] { "test" }, new[] { EnumTag.First, EnumTag.Second })]
    [TestCase(new[] { "test", "predicate" }, new[] { EnumTag.First, EnumTag.Second })]
    [TestCase(new[] { "test", "undefined" }, new[] { EnumTag.First, EnumTag.Second })]
    public void TestFindByAnyTags(string[] tags, EnumTag[] expectedResult)
    {
        foreach (var element in SmartEnum.FindByTag<EnumTag>(tags, TagSearchingFlag.All))
        {
            Assert.True(expectedResult.Contains(element));
        }
    }
    
    [Test]
    [TestCase("test", new[] { EnumTag.Third })]
    [TestCase("predicate", new[] { EnumTag.Second, EnumTag.Third })]
    [TestCase("undefined", new[] { EnumTag.First, EnumTag.Second, EnumTag.Third })]
    public void TestFindExcludingBySingleTag(string tag, EnumTag[] expectedResult)
    {
        foreach (var element in SmartEnum.FindExcludingByTag<EnumTag>(tag))
        {
            Assert.True(expectedResult.Contains(element));
        }
    }
    
    [Test]
    [TestCase(new[] { "test" }, new[] { EnumTag.Third })]
    [TestCase(new[] { "test", "predicate" }, new[] { EnumTag.Second, EnumTag.Third })]
    [TestCase(new[] { "test", "undefined" }, new[] { EnumTag.First, EnumTag.Second, EnumTag.Third })]
    public void TestFindExcludingByAllTags(string[] tags, EnumTag[] expectedResult)
    {
        foreach (var element in SmartEnum.FindExcludingByTag<EnumTag>(tags, TagSearchingFlag.All))
        {
            Assert.True(expectedResult.Contains(element));
        }
    }
    
    [Test]
    [TestCase(new[] { "test" }, new[] { EnumTag.Third })]
    [TestCase(new[] { "test", "predicate" }, new[] { EnumTag.Third })]
    [TestCase(new[] { "predicate", "undefined" }, new[] { EnumTag.Second, EnumTag.Third })]
    public void TestFindExcludingByAnyTags(string[] tags, EnumTag[] expectedResult)
    {
        foreach (var element in SmartEnum.FindExcludingByTag<EnumTag>(tags, TagSearchingFlag.Any))
        {
            Assert.True(expectedResult.Contains(element));
        }
    }
}