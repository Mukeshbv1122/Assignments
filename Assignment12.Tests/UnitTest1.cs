using NUnit.Framework;
using Assignment12;
using System.Collections.Generic;
namespace Assignment12.Tests
{
    [TestFixture]
    public class NumericFunctionsTests
    {
        private NumericFunctions nf;
        [SetUp]
        public void Setup()
        {
            nf = new NumericFunctions();
        }
        [Test] public void Add_1_2_3_Returns6() => Assert.That(nf.Add(1, 2, 3), Is.EqualTo(6));
        [Test] public void Add_5_6_9_Returns20() => Assert.That(nf.Add(5, 6, 9), Is.EqualTo(20));
        [Test] public void Subtract_2_3_ReturnsNegative1() => Assert.That(nf.Subtract(2, 3), Is.EqualTo(-1));
        [Test] public void Multiply_10_9_Returns90() => Assert.That(nf.Multiply(10, 9), Is.EqualTo(90));
        [Test] public void Divide_10By4_Returns2Point5() => Assert.That(nf.Divide(10f, 4f), Is.EqualTo(2.5f));
        [Test] public void MaxTest() => Assert.That(nf.Max(1, 2, 3, 4, 5, 10, 12), Is.EqualTo(12));
        [Test] public void MinTest() => Assert.That(nf.Min(1, 2, 3, 4, 5, 10, 12), Is.EqualTo(1));
        [Test] public void IsEven_10_ReturnsTrue() => Assert.That(nf.IsEven(10), Is.True);
        [Test] public void IsOdd_7_ReturnsTrue() => Assert.That(nf.IsOdd(7), Is.True);
        [Test] public void IsPrime_11_ReturnsTrue() => Assert.That(nf.IsPrime(11), Is.True);
        [Test] public void IsPrime_10_ReturnsFalse() => Assert.That(nf.IsPrime(10), Is.False);
        [Test]
        public void EvenInRange_1To20() =>
            Assert.That(nf.EvenInRange(1, 20), Is.EqualTo(new List<int> { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 }));
        [Test]
        public void OddInRange_1To20() =>
            Assert.That(nf.OddInRange(1, 20), Is.EqualTo(new List<int> { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 }));
        [Test]
        public void PrimesInRange_1To20() =>
            Assert.That(nf.PrimesInRange(1, 20), Is.EqualTo(new List<int> { 2, 3, 5, 7, 11, 13, 17, 19 }));
        [Test]
        public void DisplayTable_5() =>
            Assert.That(nf.DisplayTable(5), Is.EqualTo(new List<string>
            {
                "5 x 1 = 5", "5 x 2 = 10", "5 x 3 = 15", "5 x 4 = 20", "5 x 5 = 25",
                "5 x 6 = 30", "5 x 7 = 35", "5 x 8 = 40", "5 x 9 = 45", "5 x 10 = 50"
            }));
        [Test]
        public void Reverse_897_Returns798() => Assert.That(nf.Reverse(897), Is.EqualTo(798));
    }
    [TestFixture]
    public class StringFunctionsTests
    {
        private StringFunctions sf;
        [SetUp]
        public void Setup()
        {
            sf = new StringFunctions();
        }
        [Test]
        public void CharacterCount_HelloWorld_Returns11() =>
            Assert.That(sf.CharacterCount("Hello World"), Is.EqualTo(11));
        [Test]
        public void IsPalindrome_Madam_ReturnsTrue() =>
            Assert.That(sf.IsPalindrome("Madam"), Is.True);
        [Test]
        public void IsPalindrome_Manav_ReturnsFalse() =>
            Assert.That(sf.IsPalindrome("manav"), Is.False);
        [Test]
        public void ReverseSentence_ThisIsABook_ReturnskooBAsIsihT() =>
            Assert.That(sf.ReverseSentence("this is a book"), Is.EqualTo("koob a si siht"));
        [Test]
        public void AnalyzeString_MixedInput_ReturnsCorrectCounts()
        {
            var result = sf.AnalyzeString("Hello123@!");
            Assert.That(result.vowels, Is.EqualTo(2));
            Assert.That(result.consonants, Is.EqualTo(3));
            Assert.That(result.digits, Is.EqualTo(3));
            Assert.That(result.specialChars, Is.EqualTo(2));
        }
        [Test]
        public void ToUpperCase_Hello_ReturnsHELLO() =>
            Assert.That(sf.ToUpperCase("hello"), Is.EqualTo("HELLO"));
        [Test]
        public void ToProperCase_HelloWorld_ReturnsHelloWorld() =>
            Assert.That(sf.ToProperCase("hello world"), Is.EqualTo("Hello World"));
        [Test]
        public void CombineSentences_ReturnsCombined() =>
            Assert.That(sf.CombineSentences("Hello", "World"), Is.EqualTo("Hello World"));
        [Test]
        public void RemoveExtraSpaces_RemovesAllExtras() =>
            Assert.That(sf.RemoveExtraSpaces("  Hello   World  "), Is.EqualTo("Hello World"));
        [Test]
        public void WordCount_ValidSentence_Returns2() =>
            Assert.That(sf.WordCount("Hello World"), Is.EqualTo(2));
        [Test]
        public void ContainsSubstring_Found_ReturnsTrue() =>
            Assert.That(sf.ContainsSubstring("This is a test", "test"), Is.True);
        [Test]
        public void SubstringOccurrences_TwoTimes_Returns2() =>
            Assert.That(sf.SubstringOccurrences("Hello Hello World", "Hello"), Is.EqualTo(2));
    }
}