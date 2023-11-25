using System.Diagnostics;

namespace BinarySearch
{
    class Program
    {
        static int attempts = 1;

        static void Main()
        {
            var timer = new Stopwatch();

            int[] textConvertedIntoArray;

            // Path of the text file with numbers separated by commas
            var PathOfFileWithArrayOfNumbers = "../../../arrayOfNumbers.txt";

            using (var reader = new StreamReader(PathOfFileWithArrayOfNumbers))
            {
                var text = reader.ReadToEnd();

                textConvertedIntoArray = text.Split(",").Select(item => Convert.ToInt32(item)).ToArray();
            }

            var lowestIndex = 0;
            var highestIndex = textConvertedIntoArray.Length - 1;
            var targetNumber = 10000;

            timer.Start();
            Console.WriteLine(BinarySearch(textConvertedIntoArray, lowestIndex, highestIndex, targetNumber));
            timer.Stop();

            Console.WriteLine($"Time elapsed: {timer.ElapsedMilliseconds} milliseconds");

            Console.ReadLine();
        }

        static string BinarySearch(int[] arrayOfNumbers, int lowestIndex, int highestIndex, int targetNumber)
        {
            Console.WriteLine($"attempt {attempts}");
            attempts++;

            var middleIndex = (lowestIndex + highestIndex) / 2;
            var middleNumber = arrayOfNumbers[middleIndex];

            if (middleNumber == targetNumber)
            {
                return $"Number found in index {middleIndex}";
            }

            if (lowestIndex == highestIndex)
            {
                return "Number not found";
            }

            if (middleNumber > targetNumber)
            {
                highestIndex = middleIndex - 1;
            }
            else if (middleNumber < targetNumber)
            {
                lowestIndex = middleIndex + 1;
            }

            return BinarySearch(arrayOfNumbers, lowestIndex, highestIndex, targetNumber);
        }
    }
}
