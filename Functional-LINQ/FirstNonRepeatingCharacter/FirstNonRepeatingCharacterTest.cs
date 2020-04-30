using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Functional_LINQ.FirstNonRepeatingCharacter
{
    public class FirstNonRepeatingCharacterTest
    {
        [Fact]
        public void FirstNonRepeatingCharacterThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => 
            new FirstNonRepeatingCharacter(null));
        }

        [Fact]
        public void FNRCReturnsValidCharForSingleCharacter()
        {
            var FNRC = new FirstNonRepeatingCharacter("a");
            Assert.Equal('a', FNRC.FirstNonRepChar);
        }

        [Fact]
        public void FNRCReturnsCharForValidInput()
        {
            var FNRC = new FirstNonRepeatingCharacter("aba");
            Assert.Equal('b', FNRC.FirstNonRepChar);
        }

        [Fact]
        public void FNCRReturnsCharForValidLongerInput()
        {
            var FNRC = new FirstNonRepeatingCharacter("halelujah");
            Assert.Equal('e', FNRC.FirstNonRepChar);
        }

        [Fact]
        public void FNCRReturnsCharForValidLongerInputSecond()
        {
            var FNRC = new FirstNonRepeatingCharacter("FirstSecFirst");
            Assert.Equal('S', FNRC.FirstNonRepChar);
        }

        [Fact]
        public void FNCRReturnsCharForValidLongerInputThird()
        {
            var FNRC = new FirstNonRepeatingCharacter("FirstLast");
            Assert.Equal('F', FNRC.FirstNonRepChar);
        }

        [Fact]
        public void FNCRReturnsCharForValidInputAsNumber()
        {
            var FNRC = new FirstNonRepeatingCharacter("1348231");
            Assert.Equal('4', FNRC.FirstNonRepChar);
        }
    }
}
