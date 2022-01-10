using NUnit.Framework;
using ClassLibrary;

namespace TextManager_Tests
{
    public class Tests
    {
        private string _path1 = @"C:\Users\Andri\source\repos\CarHomeworkProgram\CarCountCombinationProgram.Tests\Texts\Text1.txt";

        [Test]
        public void GetWordsWithLengthMoreThan3_TextWith2Words_ReturnStringArrayWithLength2()
        {
            //Arrange
            int expectedLength = 2;
            //Act
            int actualLength = TextManager.getWordsWithLengthMoreThan3(_path1).Length;
            //Assert
            Assert.AreEqual(expectedLength, actualLength);
        }

        [Test]
        public void GetCombinationsFrom_TextWith12Combinations_ReturnDictionaryWithLength12()
        {
            //Arrange
            int expectedLength = 12;
            string[] words = TextManager.getWordsWithLengthMoreThan3(_path1);
            //Act
            int actualLength = TextManager.GetCombinationsFrom(words).Values.Count;
            //Assert
            Assert.AreEqual(expectedLength, actualLength);
        }

        [Test]
        public void GetDictionaryToCompareFrom_TextWith12Combinations_ReturnDictionaryWithLength10()
        {
            //Arrange
            int expectedLength = 10;
            var words = TextManager.getWordsWithLengthMoreThan3(_path1);
            var combinations = TextManager.GetCombinationsFrom(words);
            //Act
            int actualLength = TextManager.GetDictionaryToCompareFrom(combinations).Values.Count;
            //Assert
            Assert.AreEqual(expectedLength, actualLength);
        }

        [Test]
        public void dd()
        {
            string expectedResult = "***\t***\t***\t***\t***\t***\t***\t***\t***\t***\t1\n* *\t* *\t* *\t* *\t* *\t* *\t* *\t* *\t* *\t* *\t0\nhel \thell \thello \tell \tello \tllo \twor \tworl \tworld \torl \t\n8.33%\t8.33%\t8.33%\t8.33%\t8.33%\t8.33%\t8.33%\t8.33%\t8.33%\t8.33%\t";
            var words = TextManager.getWordsWithLengthMoreThan3(_path1);
            var combinations = TextManager.GetCombinationsFrom(words);
            var combinationsToCompare = TextManager.GetDictionaryToCompareFrom(combinations);
            string actualResult = TextManager.GetTable(combinationsToCompare);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}