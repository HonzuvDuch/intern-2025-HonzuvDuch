//Author: Jan Krahula
//More info in README.md

var inputString = Console.ReadLine();
long finalSum = 0;

// Queue for storing numbers to evaluate
Queue<long> numQueue = new Queue<long>();

while (inputString != null)
{
    //List containing each number from input
    var inputList = ParseInputString(inputString);
    var numToCalculate = inputList[0];

    //Add first number after ':' to queue
    numQueue.Enqueue(inputList[1]);
    var inputIndex = 2;

    while (numQueue.Count != 0)
    {
        var currentQueueLength = numQueue.Count;
        for (int i = 0; i < currentQueueLength; i++)
        {
            // Get top of queue
            var numToEvaluate = numQueue.Dequeue();

            if (inputIndex >= inputList.Count)
                break;

            // Get next number in input
            var nextNumber = inputList[inputIndex];

            // Multiply current and next number, if its lower or equal than wanted number, add it to queue
            var multipliedNum = numToEvaluate * nextNumber;
            if (multipliedNum <= numToCalculate)
                numQueue.Enqueue(multipliedNum);

            // Add current and next number, if its lower or equal than wanted number, add it to queue
            var addedNum = numToEvaluate + nextNumber;
            if (addedNum <= numToCalculate)
                numQueue.Enqueue(addedNum);

            // If either the first or second calculation found numToCalculate and inputList is at the end
            if ((multipliedNum == numToCalculate || addedNum == numToCalculate) && inputIndex == inputList.Count-1)
            {
                finalSum += numToCalculate;
                break;
            }

        }

        inputIndex++;
    }

    // Empty queue and get next input
    numQueue.Clear();
    inputString = Console.ReadLine();
}

Console.WriteLine(finalSum);

//Takes string in format (num: num num ...) and converts it to list containing these nums
List<long> ParseInputString(string inputString)
{
    List<long> returnList = new List<long>();

    var firstSplit = inputString.Split(":");
    returnList.Add(Convert.ToInt64(firstSplit[0]));

    var secondSplit = firstSplit[1][1..].Split(" ");
    foreach (var rightNums in secondSplit)
        returnList.Add(Convert.ToInt64(rightNums));

    return returnList;
}
