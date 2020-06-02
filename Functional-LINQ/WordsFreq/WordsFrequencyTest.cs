using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Functional_LINQ.WordsFreq
{
    public class WordsFrequencyTest
    {
        [Fact]
        public void WordsFrequencyReturnsOnlyWordFromSentence()
        {
            var freq = new WordsFrequency();

            var expected = new Dictionary<string, int>()
            {
                {"test", 1 }
            };

            Assert.Equal(expected, freq.WordFrequency("Test"));
        }

        [Fact]
        public void WordsFrequencyReturnsValueForDuplicateWordsInSentence()
        {
            var freq = new WordsFrequency();

            var expected = new Dictionary<string, int>()
            {
                {"test", 2 }
            };

            Assert.Equal(expected, freq.WordFrequency("test test"));
        }

        [Fact]
        public void WordsFrequencyReturnsValuesForDifferentWordsInSentence()
        {
            var freq = new WordsFrequency();

            var expected = new Dictionary<string, int>()
            {
                {"first", 1 },
                {"second", 1 },
                {"third", 1 }
            };

            Assert.Equal(expected, freq.WordFrequency("first second third"));
        }

        [Fact]
        public void WordsFrequencyReturnsValuesForDifferentWordsRepeatingInSentence()
        {
            var freq = new WordsFrequency();

            var expected = new Dictionary<string, int>()
            {
                {"first", 2 },
                {"second", 1 },
                {"third", 1 },
                {"last", 1 }
            };

            Assert.Equal(expected, freq.WordFrequency("First Second Third First Last"));
        }

        [Fact]
        public void WordsFrequencyReturnsValuesForDifferentWordsAndPunctuationPresent()
        {
            var freq = new WordsFrequency();

            var expected = new Dictionary<string, int>()
            {
                {"first", 1 },
                {"second", 1 },
                {"third", 1 }
            };

            Assert.Equal(expected, freq.WordFrequency("First, second third ?"));
        }

        [Fact]
        public void WordsFrequencyReturnsValuesForDifferentWordsExtraPunctuationsAndLargeWhiteSpaces()
        {
            var freq = new WordsFrequency();

            var expected = new Dictionary<string, int>()
            {
                {"i", 2 },
                {"am", 1 },
                {"coding", 1 },
                {"and", 1 },
                {"like", 1 },
                {"computers", 1 }
            };

            Assert.Equal(expected, freq.WordFrequency("I am coding,, and i    like computers !"));
        }

        [Fact]
        public void WordsFrequencyReturnsValuesForLargerTextBlock()
        {
            var freq = new WordsFrequency();

            var input = "A first demo text as text as input. This is Another Text\n" +
                "And another line in input   ,,. Third input contains this line as input!!";

            var expected = new Dictionary<string, int>()
            {
                {"input", 4},
                {"text", 3},
                {"as", 3 },
                {"this", 2 },
                {"another", 2 },
                {"line", 2 },
                {"a", 1 },
                {"first", 1 },
                {"demo", 1 },
                {"is", 1 },
                {"and", 1 },
                {"in", 1 },
                {"third", 1 },
                {"contains", 1 }
            };

            Assert.Equal(expected, freq.WordFrequency(input));
        }
    }
}