using System;
using Xunit;

namespace Functional_LINQ.CountVowelsAndConsonants
{
    public class LINQStringMethodsTest
    {
        [Fact]
        public void CounterThrowsArgumentNullExceptionForNullValue()
        {
            Assert.Throws<ArgumentNullException>(() =>
            new LINQStringMethods().ConsonantAndVowelCount(null));
        }

        [Fact]
        public void CounterReturnsZeroForEmptyInput()
        {
            LINQStringMethods LINQCounter = new LINQStringMethods();
            LINQCounter.ConsonantAndVowelCount("");

            Assert.Equal(0, LINQCounter.VowelCount);
            Assert.Equal(0, LINQCounter.ConsonantCount);
        }

        [Fact]
        public void CounterReturnsFullLengthForVowelOnlyWord()
        {
            var LINQCounter = new LINQStringMethods();
            LINQCounter.ConsonantAndVowelCount("aaaoaai");

            Assert.Equal(7, LINQCounter.VowelCount);
            Assert.Equal(0, LINQCounter.ConsonantCount);
        }

        [Fact]
        public void CounterReturnsFullLengthForConsonantOnlyWord()
        {
            var LINQCounter = new LINQStringMethods();
            LINQCounter.ConsonantAndVowelCount("cccsst");

            Assert.Equal(0, LINQCounter.VowelCount);
            Assert.Equal(6, LINQCounter.ConsonantCount);
        }

        [Fact]
        public void CounterReturnsFullLengthForBothTypesWord()
        {
            var LINQCounter = new LINQStringMethods();
            LINQCounter.ConsonantAndVowelCount("abracadabra");

            Assert.Equal(5, LINQCounter.VowelCount);
            Assert.Equal(6, LINQCounter.ConsonantCount);
        }

        [Fact]
        public void CounterReturnsFullLengthForStringWithNumbersIncluded()
        {
            var LINQCounter = new LINQStringMethods();
            LINQCounter.ConsonantAndVowelCount("abc1");

            Assert.Equal(1, LINQCounter.VowelCount);
            Assert.Equal(2, LINQCounter.ConsonantCount);
        }

        [Fact]
        public void CounterReturnsZeroValuesForStringWithOnlyNumbers()
        {
            var LINQCounter = new LINQStringMethods();
            LINQCounter.ConsonantAndVowelCount("12394382983749823432");

            Assert.Equal(0, LINQCounter.VowelCount);
            Assert.Equal(0, LINQCounter.ConsonantCount);
        }

        [Fact]
        public void CounterReturnsZeroValuesForSymbolsOnly()
        {
            var LINQCounter = new LINQStringMethods();
            LINQCounter.ConsonantAndVowelCount("$&&% &$#&&#&#*@*@@@$");

            Assert.Equal(0, LINQCounter.VowelCount);
            Assert.Equal(0, LINQCounter.ConsonantCount);
        }

        [Fact]
        public void CounterReturnsFullLengthForLongStringWithRandomCharacters()
        {
            var LINQCounter = new LINQStringMethods();
            LINQCounter.ConsonantAndVowelCount("...?  a..x&&aMNnnnMmnmo");

            Assert.Equal(3, LINQCounter.VowelCount);
            Assert.Equal(10, LINQCounter.ConsonantCount);
        }

        [Fact]
        public void FirstNonRepeatingCharacterThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            new LINQStringMethods().FindFirstNonRepeatingCharacter(null));
        }

        [Fact]
        public void FNRCReturnsValidCharForSingleCharacter()
        {
            var FirstChar = new LINQStringMethods();
            FirstChar.FindFirstNonRepeatingCharacter("a");
            Assert.Equal('a', FirstChar.FirstNonRepetitiveCharacter);
        }

        [Fact]
        public void FNRCReturnsCharForValidInput()
        {
            var FirstChar = new LINQStringMethods();
            FirstChar.FindFirstNonRepeatingCharacter("aba");
            Assert.Equal('b', FirstChar.FirstNonRepetitiveCharacter);
        }

        [Fact]
        public void FNCRReturnsCharForValidLongerInput()
        {
            var FirstChar = new LINQStringMethods();
            FirstChar.FindFirstNonRepeatingCharacter("halelujah");
            Assert.Equal('e', FirstChar.FirstNonRepetitiveCharacter);
        }

        [Fact]
        public void FNCRReturnsCharForValidLongerInputSecond()
        {
            var FirstChar = new LINQStringMethods();
            FirstChar.FindFirstNonRepeatingCharacter("FirstSecFirst");
            Assert.Equal('S', FirstChar.FirstNonRepetitiveCharacter);
        }

        [Fact]
        public void FNCRReturnsCharForValidLongerInputThird()
        {
            var FirstChar = new LINQStringMethods();
            FirstChar.FindFirstNonRepeatingCharacter("FirstLast");
            Assert.Equal('F', FirstChar.FirstNonRepetitiveCharacter);
        }

        [Fact]
        public void FNCRReturnsCharForValidInputAsNumber()
        {
            var FirstChar = new LINQStringMethods();
            FirstChar.FindFirstNonRepeatingCharacter("1348231");
            Assert.Equal('4', FirstChar.FirstNonRepetitiveCharacter);
        }

        [Fact]
        public void StringToIntegerConverterThrowsArgumentNullExceptionForNullInput()
        {
            var StringToInteger = new LINQStringMethods();
            Assert.Throws<ArgumentNullException>(() => StringToInteger.ConvertToInteger(null));
        }

        [Fact]
        public void StringToIntegerConverterWorksForSingleFigureNumber()
        {
            var StringToInteger = new LINQStringMethods();
            StringToInteger.ConvertToInteger("3");
            Assert.Equal(3, StringToInteger.ConvertedStringToInteger);
        }

        [Fact]
        public void StringToIntegerConverterWorksForTwoFiguresNumber()
        {
            var StringToInteger = new LINQStringMethods();
            StringToInteger.ConvertToInteger("13");
            Assert.Equal(13, StringToInteger.ConvertedStringToInteger);
        }

        [Fact]
        public void StringToIntegerConverterWorksForMultipeFiguresNumber()
        {
            var StringToInteger = new LINQStringMethods();
            StringToInteger.ConvertToInteger("13443110");
            Assert.Equal(13443110, StringToInteger.ConvertedStringToInteger);
        }

        [Fact]
        public void MaxApparitionCharThrowsArgumentNullExceptionForNullInput()
        {
            var MaxApparition = new LINQStringMethods();
            Assert.Throws<ArgumentNullException>(() => MaxApparition.MaxApparitionChar(null));
        }

        [Fact]
        public void MaxApparitionCharReturnsOnlyCharacterIfStringIsSingleChar()
        {
            var MaxApparition = new LINQStringMethods();
            MaxApparition.MaxApparitionChar("a");
            Assert.Equal('a', MaxApparition.MaximumAparitionCharacter);
        }

        [Fact]
        public void MaxApparitionCharReturnsValidCharacterForMultipleChars()
        {
            var MaxApparition = new LINQStringMethods();
            MaxApparition.MaxApparitionChar("aba");
            Assert.Equal('a', MaxApparition.MaximumAparitionCharacter);
        }

        [Fact]
        public void MaxApparitionCharReturnsValidCharacterForMultipleCharsTwoChars()
        {
            var MaxApparition = new LINQStringMethods();
            MaxApparition.MaxApparitionChar("abab");
            Assert.Equal('a', MaxApparition.MaximumAparitionCharacter);
        }

        [Fact]
        public void MaxApparitionCharsReturnsValidCharacterForLargeString()
        {
            var MaxApparition = new LINQStringMethods();
            MaxApparition.MaxApparitionChar("trinitrotoluen");
            Assert.Equal('t', MaxApparition.MaximumAparitionCharacter);
        }

        [Fact]
        public void PalindromesThrowsArgumentNullExceptionForNullInput()
        {
            var PalindromesGenerator = new LINQStringMethods();
            Assert.Throws<ArgumentNullException>(() => 
            PalindromesGenerator.GetPalindromes(null));
        }

        [Fact]
        public void PalindromesReturnsValidOutputForPalindromeInput()
        {
            var PalindromesGenerator = new LINQStringMethods();
            var res = "a,aerisirea,e,erisire,r,risir,i,isi,s,i,r,e,a";
            PalindromesGenerator.GetPalindromes("aerisirea");
            Assert.Equal(res, PalindromesGenerator.Palindromes);
        }

        [Fact]
        public void PalindromesReturnsValidOutputForNoPresentPalindrome()
        {
            var PalindromesGenerator = new LINQStringMethods();
            var res = "a,b,c";
            PalindromesGenerator.GetPalindromes("abc");
            Assert.Equal(res, PalindromesGenerator.Palindromes);
        }

        [Fact]
        public void PalindromesReturnsValidOutput()
        {
            var PalindromesGenerator = new LINQStringMethods();
            var res = "a,aa,aabaa,a,aba,b,a,aa,a,c";
            PalindromesGenerator.GetPalindromes("aabaac");
            Assert.Equal(res, PalindromesGenerator.Palindromes);
        }
    }
}