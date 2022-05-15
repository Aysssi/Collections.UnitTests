using NUnit.Framework;
using System;
using System.Linq;

namespace Collections.UnitTests
{
    public class CollectionTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            var nums = new Collection<int>();

            Assert.AreEqual(0, nums.Count);
            Assert.That(nums, Is.Not.Null);
            Assert.That(nums.ToString() == "[]");
            Assert.AreEqual(16, nums.Capacity);

        }
        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            var nums = new Collection<int>(6);

            Assert.That(nums.Count == 1);
            Assert.AreEqual(16, nums.Capacity);
            Assert.That(nums.ToString() == "[6]");


        }
        [Test]
        public void Test_CollectionMultipleItems()
        {
            var nums = new Collection<int>(6, 7);


            Assert.That(nums.Count == 2);
            Assert.AreEqual(nums.Capacity, 16);
            Assert.That(nums.ToString() == "[6, 7]");

        }
        [Test]
        public void Test_Collection_Add()
        {
            var nums = new Collection<int>();

            nums.Add(8);

            Assert.That(nums.Count == 1);
            Assert.AreEqual(nums.Capacity, 16);
            Assert.That(nums.ToString() == "[8]");
        }
        [Test]
        public void Test_Collection_AddRange_WithThreeItems()
        {
            var nums = new Collection<int>();
            var items = new int[] { 7, 8, 9 };
            

            nums.AddRange(items);

            Assert.That(nums.Count == 3);
            Assert.AreEqual(nums.Capacity, 16);
            Assert.That(nums.ToString() == "[7, 8, 9]");

        }
        [Test]
        public void Test_Collection_AddWithGrow()
        {

            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            var colection = new Collection<int>(nums);
            colection.Add(16);

            Assert.AreEqual(16, colection[11]);
            Assert.AreEqual(nums.Length + 1, colection.Count);
            Assert.AreEqual(nums.Length * 2, colection.Capacity);

        }
        [Test]
        public void Test_Collection_GetByIndex()
        {
            var names = new Collection<string>("Alex", "Dimitur");

            var firstItem = names[0];
            var secondItem = names[1];

            Assert.AreEqual("Alex", firstItem);
            Assert.That(secondItem, Is.EqualTo("Dimitur"));

        }
        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            var names = new Collection<string>("Maria", "Petur");
            string name = "";

            Assert.That(() => { name = names[-1]; }, Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { name = names[2]; }, Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { name = names[500]; }, Throws.InstanceOf<ArgumentOutOfRangeException>());

        }
        [Test]
        public void Test_Collection_InsertAtStartTest()
        {
            var names = new Collection<string>("Teddy,Georgi,Maria");
            names.InsertAt(0, "Dimitur");

            Assert.That(names.ToString(), Is.EqualTo("[Dimitur, Teddy,Georgi,Maria]"));

        }
        [Test]
        public void Test_Collection_InsertAtEndTest()
        {

            var names = new Collection<string>("Arni", "Ari");

            int index = names.Count;
            names.InsertAt(index, "Chara");

            Assert.That(names.ToString(), Is.EqualTo("[Arni, Ari, Chara]"));

        }
        [Test]
        public void Test_Collection_InsertAtMiddle()
        {

            var nums = new Collection<int>(1, 2, 3, 5, 6, 7);


            nums.InsertAt(3, 4);


            Assert.That(nums.ToString(), Is.EqualTo("[1, 2, 3, 4, 5, 6, 7]"));

        }
        [Test]
        public void Test_Collection_ClearTest()
        {
            var nums = new Collection<int>(5, 6, 7);

            nums.Clear();

            Assert.That(nums.Count == 0);
            Assert.That(nums.ToString(), Is.EqualTo("[]"));

        }
        [Test]
        public void Test_Collection_RemoveAtEndTest()
        {
            var names = new Collection<string>("Arni", "Chara", "Ari");

            int lastIndex = names.Count - 1;
            int originalCount = names.Count;

            names.RemoveAt(lastIndex);

            Assert.That(names.Count == originalCount - 1);
            Assert.That(names.ToString(), Is.EqualTo("[Arni, Chara]"));

        }
        [Test]
        public void Test_Collection_RemoveAtStartTest()
        {
            var nums = new Collection<int>(7, 8, 9);
            int originalCount = nums.Count;

            nums.RemoveAt(0);

            Assert.That(nums.Count == originalCount - 1);
            Assert.That(nums.ToString(), Is.EqualTo("[8, 9]"));
        }
        [Test]
        public void Test_Collection_RemoveAtInvalidIndexTest()
        {
            var names = new Collection<string>("Maria", "Merry", "Bob");

            Assert.That(() => { names.RemoveAt(-1); }, Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { names.RemoveAt(5); }, Throws.InstanceOf<ArgumentOutOfRangeException>());

        }
        [Test]
        public void Test_Collection_ExchangeFirstLast()
        {
            var names = new Collection<string>("Chara", "Joe", "Merry");

            names.Exchange(0, names.Count - 1);

            Assert.That(names.ToString(), Is.EqualTo("[Merry, Joe, Chara]"));

        }
        [Test]
        public void Test_Collection_ExchangeInvalidIdexes()
        {
            var names = new Collection<string>("Chara", "Arni", "Merry");

            Assert.That(() => { names.Exchange(-1, 8); }, Throws.InstanceOf<ArgumentOutOfRangeException>());

        }
        [Test]
        public void Test_Collection_ExchangeMiddle()
        {
            var names = new Collection<string>("Merry", "Arni", "Chara");

            names.Exchange(names.Count / 2, names.Count - 1);

            Assert.That(names.ToString(), Is.EqualTo("[Merry, Chara, Arni]"));

        }
        [Test]
        public void Test_Collection_ToStringEmpty()
        {
            var names = new Collection<string>();

            string namesToString = names.ToString();
            Assert.That(namesToString, Is.EqualTo("[]"));
        }
        [Test]
        public void Test_Collection_ToStringNestedCollections()
        {
            var names = new Collection<string>("Ari", "Merry");
            var numbers = new Collection<int>(7, 8, 9);
            var dates = new Collection<DateTime>();

            var collection = new Collection<object>(names, numbers, dates);

            Assert.That(collection.ToString(), Is.EqualTo("[[Ari, Merry], [7, 8, 9], []]"));

        }
        [Test]
        public void Test_Collection_ToStringMultiple()
        {

            var collection = new Collection<int>(7, 8, 9);

            Assert.AreEqual(collection.ToString(), "[7, 8, 9]");

        }
        [Test]
        public void Test_Collection_ToStringSingle()
        {
            var nums = new Collection<int>(7);

            Assert.AreEqual(nums.ToString(), "[7]");
        }
        [Test]
        [Timeout(5000)]
        public void Tetst_Collection_1MilionItems()
        {
            const int itemsCount = 1000000;
            var nums = new Collection<int>();
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());

            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);

            for (int i = itemsCount - 1; i >= 0; i--)
            {
                nums.RemoveAt(i);
            }

            Assert.That(nums.ToString() == "[]");
            Assert.That(nums.Capacity >= nums.Count);

        }


    }
}