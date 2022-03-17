using System;
using NUnit.Framework;
using System.Linq;
using SmartEnums.Tests.Enums;

namespace SmartEnums.Tests;

public class EnumTagTests
{
    [Test]
    [TestCase(TestEnumTag.First, new[] { "test", "predicate" })]
    [TestCase(TestEnumTag.Second, new[] { "test" })]
    [TestCase(TestEnumTag.Third, null)]
    public void TestGetEnumTags(Enum obj, string[] expectedResult)
    {
        foreach (var element in obj.GetEnumTags()!)
        {
            Assert.True(expectedResult.Contains(element));
        }
    }
    
    [Test]
    [TestCase("test", new[] { TestEnumTag.First, TestEnumTag.Second })]
    [TestCase("predicate", new[] { TestEnumTag.First })]
    [TestCase("undefined", null)]
    public void TestFindBySingleTag(string tag, TestEnumTag[] expectedResult)
    {
        foreach (var element in SmartEnum.FindByTag<TestEnumTag>(tag))
        {
            Assert.True(expectedResult.Contains(element));
        }
    }
    
    [Test]
    [TestCase(new[] { "test" }, new[] { TestEnumTag.First, TestEnumTag.Second })]
    [TestCase(new[] { "test", "predicate" }, new[] { TestEnumTag.First })]
    [TestCase(new[] { "test", "undefined" }, null)]
    public void TestFindByAllTags(string[] tags, TestEnumTag[] expectedResult)
    {
        foreach (var element in SmartEnum.FindByTag<TestEnumTag>(tags, TagSearchingFlag.All))
        {
            Assert.True(expectedResult.Contains(element));
        }
    }
    
    [Test]
    [TestCase(new[] { "test" }, new[] { TestEnumTag.First, TestEnumTag.Second })]
    [TestCase(new[] { "test", "predicate" }, new[] { TestEnumTag.First, TestEnumTag.Second })]
    [TestCase(new[] { "test", "undefined" }, new[] { TestEnumTag.First, TestEnumTag.Second })]
    public void TestFindByAnyTags(string[] tags, TestEnumTag[] expectedResult)
    {
        foreach (var element in SmartEnum.FindByTag<TestEnumTag>(tags, TagSearchingFlag.All))
        {
            Assert.True(expectedResult.Contains(element));
        }
    }
    
    [Test]
    [TestCase("test", new[] { TestEnumTag.Third })]
    [TestCase("predicate", new[] { TestEnumTag.Second, TestEnumTag.Third })]
    [TestCase("undefined", new[] { TestEnumTag.First, TestEnumTag.Second, TestEnumTag.Third })]
    public void TestFindExcludingBySingleTag(string tag, TestEnumTag[] expectedResult)
    {
        foreach (var element in SmartEnum.FindExcludingByTag<TestEnumTag>(tag))
        {
            Assert.True(expectedResult.Contains(element));
        }
    }
    
    [Test]
    [TestCase(new[] { "test" }, new[] { TestEnumTag.Third })]
    [TestCase(new[] { "test", "predicate" }, new[] { TestEnumTag.Second, TestEnumTag.Third })]
    [TestCase(new[] { "test", "undefined" }, new[] { TestEnumTag.First, TestEnumTag.Second, TestEnumTag.Third })]
    public void TestFindExcludingByAllTags(string[] tags, TestEnumTag[] expectedResult)
    {
        foreach (var element in SmartEnum.FindExcludingByTag<TestEnumTag>(tags, TagSearchingFlag.All))
        {
            Assert.True(expectedResult.Contains(element));
        }
    }
    
    [Test]
    [TestCase(new[] { "test" }, new[] { TestEnumTag.Third })]
    [TestCase(new[] { "test", "predicate" }, new[] { TestEnumTag.Third })]
    [TestCase(new[] { "predicate", "undefined" }, new[] { TestEnumTag.Second, TestEnumTag.Third })]
    public void TestFindExcludingByAnyTags(string[] tags, TestEnumTag[] expectedResult)
    {
        foreach (var element in SmartEnum.FindExcludingByTag<TestEnumTag>(tags, TagSearchingFlag.Any))
        {
            Assert.True(expectedResult.Contains(element));
        }
    }
}