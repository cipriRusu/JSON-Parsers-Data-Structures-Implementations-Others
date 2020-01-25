using Xunit;

namespace JSONValidatorAlternativeVersion
{
    public class ChoiceTest
    {
        [Fact]
        public static void MatchReturnsTrueForValidInput()
        {
            var choiceTestObject =
                new Choice(new Character('0'),
                    new Range('1', '9'));
            Assert.True(choiceTestObject.Match("012").Success());
        }

        [Fact]
        public static void MatchReturnsFalseForInvalidInput()
        {
            var choiceTestObject =
                new Choice(new Character('0'),
                new Range('1', '9'));
            Assert.False(choiceTestObject.Match("a9").Success());
        }

        [Fact]
        public static void MatchReturnsFalseForNullInput()
        {
            var choiceTestObject = new Choice(new Character('0'),
                new Range('1', '9'));
            Assert.False(choiceTestObject.Match(null).Success());
        }

        [Fact]
        public static void MatchReturnsFalseForEmptyInput()
        {
            var choiceTestObject = new Choice(
                new Character('0'),
                new Range('1', '9'));
            Assert.False(choiceTestObject.Match("").Success());
        }

        [Fact]
        public static void MatchReturnsTrueForValidHexadecimalValue()
        {
            var choiceDigitObject = new Choice(
                new Character('0'),
                new Range('1', '9'));

            var choiceTestObject = new Choice(choiceDigitObject,

                new Choice(
                    new Range('a', 'f'),
                                new Range('A', 'F')));

            Assert.True(choiceTestObject.Match("012").Success());
        }

        [Fact]
        public static void MatchReturnsTrueForSecondValidHexadecimalValue()
        {
            var choiceDigitObject = new Choice(
                new Character('0'),
                new Range('1', '9'));

            var choiceTestObject = new Choice(choiceDigitObject,
                new Choice(new Range('a', 'f'),
                    new Range('A', 'F')));

            Assert.True(choiceTestObject.Match("a9").Success());
        }

        [Fact]
        public static void MatchReturnsFalseForInvalidHexadecimalValue()
        {
            var choiceDigitObject =
                new Choice(
                    new Character('0'),
                    new Range('1', '9'));

            var choiceTestObject = new Choice(choiceDigitObject,
                new Choice(new Range('a', 'f'),
                    new Range('A', 'F')));

            Assert.False(choiceTestObject.Match("g8").Success());
        }

        [Fact]
        public static void MatchReturnsFalseForSecondInvalidHexadecimalValue()
        {
            var choiceDigitObject =
                new Choice(
                    new Character('0'),
                    new Range('1', '9'));

            var choiceTestObject = new Choice(choiceDigitObject,
                new Choice(new Range('a', 'f'),
                    new Range('A', 'F')));

            Assert.False(choiceTestObject.Match("G8").Success());
        }

        [Fact]
        public void ChoiceReturnsValidSequenceForHexadecimalRangeChoiceInvalidString()
        {
            var hexadecimalRangeChoice = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F'));

            Assert.Equal("XB12", hexadecimalRangeChoice.Match("XB12").RemainingText());
        }

        [Fact]
        public void ChoiceReturnsValidSequenceForHexadecimalRangeChoiceValidString()
        {
            var hexadecimalRangeChoice = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F'));

            Assert.Equal("bc", hexadecimalRangeChoice.Match("1bc").RemainingText());
        }

        [Fact]
        public void ChoiceReturnsValidSequenceForSequenceAndCharNestedInChoiceValidString()
        {
            var range = new Range('0', '9');
            var character = new Character('z');

            var demochoiceSequence =
                new Choice(
                    range,
                    character);

            Assert.Equal("z", demochoiceSequence.Match("2z").RemainingText());
        }

        [Fact]
        public void ChoiceReturnsValidSequenceForSequenceAndCharNestedInChoiceInvalidString()
        {
            var range = new Range('0', '9');
            var character = new Character('z');

            var demoChoiceSequence =
                new Choice(
                    range,
                    character);

            Assert.Equal("az", demoChoiceSequence.Match("az").RemainingText());
        }

        [Fact]
        public void ChoiceReturnsValidOutputForValidSequenceNestedInChoice()
        {
            var range = new Range('0', '5');
            var sequenceNestedInChoice =
                new Choice(new Sequence(range, range, range));

            Assert.Equal("", sequenceNestedInChoice.Match("032").RemainingText());
        }

        [Fact]
        public void ChoiceReturnsValidOutputForInValidSequenceAndCharNestedInChoice()
        {
            var range = new Range('0', '5');
            var character = new Character('b');
            var sequenceAndCharNestedInChoice =
                new Choice(new Sequence(range), character);

            Assert.Equal("6b", sequenceAndCharNestedInChoice.Match("6b").RemainingText());
        }

        [Fact]
        public void ChoiceReturnValidOutputForValidSequenceAndCharNestedInChoice()
        {
            var range = new Range('0', '5');
            var character = new Character('b');
            var sequenceAndCharNestedInChoice =
                new Choice(new Sequence(range, range, character));

            Assert.Equal("", sequenceAndCharNestedInChoice.Match("55b").
                RemainingText());
        }


    }
}