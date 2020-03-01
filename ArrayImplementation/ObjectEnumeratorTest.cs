using Xunit;

namespace ArrayImplementation
{
    public class ObjectEnumeratorTest
    {
        [Fact]
        public void MoveNextReturnsFalseIfItReachesEndOfArray()
        {
            var objectarray = new ObjectArray();
            objectarray.Add("test");

            var objenum = objectarray.GetEnumerator();

            objenum.MoveNext();

            Assert.False(objenum.MoveNext());
        }

        [Fact]
        public static void MoveNextReturnsFirstElementAfterOneInvocation()
        {
            var objectarray = new ObjectArray { 7, 4, "test" };

            var objenum = objectarray.GetEnumerator();

            objenum.MoveNext();

            Assert.Equal(7, objenum.Current);
        }

        [Fact]
        public static void MoveNextReturnsSecondElementAfterTwoInvocations()
        {
            var objectarray = new ObjectArray { 7, 4, "test" };

            var objenum = objectarray.GetEnumerator(); 

            objenum.MoveNext();
            objenum.MoveNext();

            Assert.Equal(4, objenum.Current);
        }

        [Fact]
        public static void MoveNextReturnsThirdElementAfterTwoInvocations()
        {
            var objectarray = new ObjectArray { 7, 4, "test" };

            var objenum = objectarray.GetEnumerator();

            objenum.MoveNext();
            objenum.MoveNext();
            objenum.MoveNext();

            Assert.Equal("test", objenum.Current);
        }
    }
}
