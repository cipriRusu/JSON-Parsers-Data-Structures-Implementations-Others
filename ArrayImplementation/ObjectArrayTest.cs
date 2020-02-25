using Xunit;

namespace ArrayImplementation
{
    public class ObjectArrayTest
    {
        [Fact]
        public void ObjectArrayCreatesEmptyArrayWithNoElements()
        {
            var objarr = new ObjectArray();

            Assert.Equal(0, objarr.Count);
        }

        [Fact]
        public void ObjectArrayStaysEmptyForAddingNullElement()
        {
            var objarr = new ObjectArray();

            objarr.Add(null);

            Assert.Null(objarr[0]);
        }

        [Fact]
        public void ObjectArrayPopulatesArrayWithSingleObject()
        {
            var objarr = new ObjectArray();

            objarr.Add(new object());

            Assert.Equal(1, objarr.Count);
        }

        [Fact]
        public void ObjectArrayCreatesEmptyArrayNoElementsIndexer()
        {
            var objarr = new ObjectArray();

            objarr[0] = -1;

            Assert.Equal(-1, objarr[0]);
        }

        [Fact]
        public void ObjectArrayIndexerPopulatesWithMultipleValuesSameType()
        {
            var objarr = new ObjectArray();

            objarr[0] = 21;
            objarr[1] = 4;

            Assert.Equal(21, objarr[0]);
            Assert.Equal(4, objarr[1]);
        }

        [Fact]
        public void ObjectArrayIndexerPopulatesWithMultipleValuesHeterogenic()
        {
            var objarr = new ObjectArray();

            objarr[0] = 21;
            objarr[1] = "Something";

            Assert.Equal(21, objarr[0]);
            Assert.Equal("Something", objarr[1]);
        }

        [Fact]
        public void ObjectArrayAddValueAddsSingleValue()
        {
            var objarr = new ObjectArray();

            objarr.Add(21);

            Assert.Equal(21, objarr[0]);
        }

        [Fact]
        public void ObjectArrayAddValueAddsMultipleHomogenousValues()
        {
            var objarr = new ObjectArray();

            objarr.Add(21);
            objarr.Add(30);

            Assert.Equal(30, objarr[1]);
        }

        [Fact]
        public void ObjectArrayAddValueAddsMultipleHeterogenousValues()
        {
            var objarr = new ObjectArray();

            objarr.Add(21);
            objarr.Add("Something");

            Assert.Equal("Something", objarr[1]);
        }

        [Fact]
        public void ObjectArrayContainsReturnsMinusOneForEmptyArray()
        {
            var objarr = new ObjectArray();

            objarr.Contains(21);

            Assert.False(objarr.Contains(21));
        }

        [Fact]
        public void ObjectArrayContainsReturnsTrueForPresentElementInHomogenousArray()
        {
            var objarr = new ObjectArray();

            objarr.Add("one");
            objarr.Add(2);
            objarr.Add(3.0);

            Assert.True(objarr.Contains(2));
        }

        [Fact]
        public void ObjectArrayContainsReturnsFalseForAbsentElementInHomogenousArray()
        {
            var objarr = new ObjectArray();

            objarr.Add("one");
            objarr.Add(2);
            objarr.Add(3.0);

            Assert.False(objarr.Contains(5));
        }

        [Fact]
        public void ObjectArrayIndexOfReturnsIndexOfSingleElement()
        {
            var objarr = new ObjectArray();

            objarr.Add(21);

            Assert.Equal(0, objarr.IndexOf(21));
        }

        [Fact]
        public void ObjectArrayIndexOfReturnsIndexOfMultipleElements()
        {
            var objarr = new ObjectArray();

            objarr.Add(2);
            objarr.Add(24);
            objarr.Add(3);

            Assert.Equal(2, objarr.IndexOf(3));
        }

        [Fact]
        public void ObjectArrayIndexOfReturnsIndexOFSingleStringElement()
        {
            var objarr = new ObjectArray();

            objarr.Add("Something");

            Assert.Equal(0, objarr.IndexOf("Something"));
        }

        [Fact]
        public void ObjectArrayIndexOfReturnsIndexOfMultipleStringElement()
        {
            var objarr = new ObjectArray();

            objarr.Add("Something");
            objarr.Add("testString");

            Assert.Equal(1, objarr.IndexOf("testString"));
        }

        [Fact]
        public void ObjectArrayIndexOfReturnsIndexOfStringInHeterogenousArray()
        {
            var objarr = new ObjectArray();

            objarr.Add(2);
            objarr.Add(4);
            objarr.Add("testString");
            objarr.Add(6);
            objarr.Add(4);

            Assert.Equal(2, objarr.IndexOf("testString"));
        }

        [Fact]
        public void ObjectArrayIndexOfReturnsIndexOfIntegerInHeterogenousArray()
        {
            var objarr = new ObjectArray();

            objarr.Add("one");
            objarr.Add("two");
            objarr.Add(3.0);
            objarr.Add(4);

            Assert.Equal(3, objarr.IndexOf(4));
        }

        [Fact]
        public void ObjectArrayIndexOfReturnsMinusOneForAbsentIntegerValue()
        {
            var objarr = new ObjectArray();

            objarr.Add("one");
            objarr.Add("two");
            objarr.Add(3.0);
            objarr.Add(4);

            Assert.Equal(-1, objarr.IndexOf(3));
        }

        [Fact]
        public void ObjectArrayIndexOfReturnsMinusOneForNotIdenticalStringVAlue()
        {
            var objarr = new ObjectArray();

            objarr.Add(2);
            objarr.Add(3.0);
            objarr.Add("testValue");

            Assert.Equal(-1, objarr.IndexOf("testvalue"));
        }

        [Fact]
        public void ObjectArrayInsertInsertsIntegerIntoIntegerArray()
        {
            var objarr = new ObjectArray();

            objarr.Add(2);
            objarr.Add(7);
            objarr.Add(3);

            objarr.Insert(1, 1);

            Assert.Equal(1, objarr[1]);
        }

        [Fact]
        public void ObjectArrayInsertInsertsIntegerIntoStringArray()
        {
            var objarr = new ObjectArray();

            objarr.Add("first");
            objarr.Add("sec");
            objarr.Add("third");

            objarr.Insert(2, 3);

            Assert.Equal(3, objarr[2]);
        }

        [Fact]
        public void ObjectArrayInsertInsertsStringIntoStringArray()
        {
            var objarr = new ObjectArray();

            objarr.Add("first");
            objarr.Add("second");
            objarr.Add("third");
            objarr.Insert(1, "inserted");

            Assert.Equal("inserted", objarr[1]);
        }

        [Fact]
        public void ObjectArrayInsertInsertsStringIntoIntegerArray()
        {
            var objarr = new ObjectArray();

            objarr.Add(1);
            objarr.Add(2);
            objarr.Add(3);
            objarr.Insert(2, "inserted");

            Assert.Equal("inserted", objarr[2]);
        }

        [Fact]
        public void ObjectArrayInsertInsertsValueIntoHeterogenousArray()
        {
            var objarr = new ObjectArray();

            objarr.Add("first");
            objarr.Add(2);
            objarr.Add(3.0);
            objarr.Add(4F);
            objarr.Insert(2, 45.0);

            Assert.Equal(45.0, objarr[2]);
        }

        [Fact]
        public void ObjectArrayClearClearsHeterogenousArray()
        {
            var objarr = new ObjectArray();

            objarr.Add("first");
            objarr.Add(2);
            objarr.Add(3.0);
            objarr.Clear();

            Assert.Equal(0, objarr.Count);
        }

        [Fact]
        public void ObjectArrayRemoveRemovesSingleElement()
        {
            var objarr = new ObjectArray();

            objarr.Add("toRemove");
            objarr.Remove("toRemove");

            Assert.Equal(0, objarr.Count);
        }

        [Fact]
        public void ObjectArrayRemoveSkipsRemoveForIncorrectValue()
        {
            var objarr = new ObjectArray();

            objarr.Add("first");
            objarr.Add(2.4);
            objarr.Remove(2.5);

            Assert.Equal(2, objarr.Count);
        }

        [Fact]
        public void ObjectArrayRemoveAtRemovesIntegerFromIntegerArray()
        {
            var objarr = new ObjectArray();

            objarr.Add(34);
            objarr.Add(3);
            objarr.Add(21);
            objarr.RemoveAt(2);

            Assert.Null(objarr[objarr.Count]);
        }

        [Fact]
        public void ObjectArrayRemoveRemovesStringFromIntegerArray()
        {
            var objarray = new ObjectArray();

            objarray.Add(34);
            objarray.Add(21);
            objarray.Add("toRemove");
            objarray.Add(100);
            objarray.Remove("toRemove");

            Assert.NotEqual("toRemove", objarray[2]);
        }

        [Fact]
        public void ObjectArrayRemoveRemovesProperValueFromStringArray()
        {
            var objarray = new ObjectArray();

            objarray.Add("first");
            objarray.Add("FiRst");
            objarray.Add("First");
            objarray.Remove("fiRst");

            Assert.NotEqual("fiRst", objarray[1]);
        }

        [Fact]
        public void ObjectArrayRemoveAtRemovesStringFromStrings()
        {
            var objarr = new ObjectArray();

            objarr.Add("first");
            objarr.Add("second");
            objarr.Add("third");
            objarr.RemoveAt(1);

            Assert.Null(objarr[objarr.Count]);
        }

        [Fact]
        public void ObjectArrayRemoveAtRemovesIntegerFromHeterogenous()
        {
            var objarr = new ObjectArray();
            
            objarr.Add("one");
            objarr.Add(2);
            objarr.Add(3.0);
            objarr.RemoveAt(0);

            Assert.Null(objarr[objarr.Count]);
        }

        [Fact]
        public void ObjectArrayRemoveRemovesElementFromHeterogenous()
        {
            var objarr = new ObjectArray();

            objarr.Add(1.0);
            objarr.Add("two");
            objarr.Add(3F);
            objarr.Add(4.443E+2);
            objarr.Remove(3F);

            Assert.NotEqual(3F, objarr[2]);
        }
    }
}