using System;
using Xunit;

namespace Functional_LINQ.CountVowelsAndConsonants
{
    public class CountVowelsAndConsonantsTest
    {
        [Fact]
        public void CounterThrowsArgumentNullExceptionForNullValue()
        {
            Assert.Throws<ArgumentNullException>(() => 
            new CountVowelsAndConsonants(null));
        }

        [Fact]
        public void CounterReturnsZeroForEmptyInput()
        {
            var counter = new CountVowelsAndConsonants("");

            Assert.Equal(0, counter.VowelCount);
            Assert.Equal(0, counter.ConsonantCount);
        }

        [Fact]
        public void CounterReturnsFullLengthForVowelOnlyWord()
        {
            var counter = new CountVowelsAndConsonants("aaaoaai");

            Assert.Equal(7, counter.VowelCount);
            Assert.Equal(0, counter.ConsonantCount);
        }

        [Fact]
        public void CounterReturnsFullLengthForConsonantOnlyWord()
        {
            var counter = new CountVowelsAndConsonants("cccsst");

            Assert.Equal(0, counter.VowelCount);
            Assert.Equal(6, counter.ConsonantCount);
        }

        [Fact]
        public void CounterReturnsFullLengthForBothTypesWord()
        {
            var counter = new CountVowelsAndConsonants("abracadabra");

            Assert.Equal(5, counter.VowelCount);
            Assert.Equal(6, counter.ConsonantCount);
        }

        [Fact]
        public void CounterReturnsFullLengthForStringWithNumbersIncluded()
        {
            var counter = new CountVowelsAndConsonants("abc1");

            Assert.Equal(1, counter.VowelCount);
            Assert.Equal(2, counter.ConsonantCount);
        }

        [Fact]
        public void CounterReturnsZeroValuesForStringWithOnlyNumbers()
        {
            var counter = new CountVowelsAndConsonants("12394382983749823432");

            Assert.Equal(0, counter.VowelCount);
            Assert.Equal(0, counter.ConsonantCount);
        }

        [Fact]
        public void CounterReturnsZeroValuesForSymbolsOnly()
        {
            var counter = new CountVowelsAndConsonants("$&&%&$#&&#&#*@*@@@$");

            Assert.Equal(0, counter.VowelCount);
            Assert.Equal(0, counter.ConsonantCount);
        }

        [Fact]
        public void CounterReturnsFullLengthForLongStringWithRandomCharacters()
        {
            var counter = new CountVowelsAndConsonants("...?  a..x&&aMNnnnMmnmo");

            Assert.Equal(3, counter.VowelCount);
            Assert.Equal(10, counter.ConsonantCount);
        }
    }
}
