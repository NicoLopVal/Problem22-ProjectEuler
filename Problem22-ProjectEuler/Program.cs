string path = @"C:\Users\Nicolas Lopez\Documents\Zoom\inputNames.txt";
string[] names = File.ReadAllText(path).Split("|");
List<string> sortedNames = new List<string>();

Dictionary<string, int> letterValue = new Dictionary<string, int>();
letterValue.Add("A", 1);
letterValue.Add("B", 2);
letterValue.Add("C", 3);
letterValue.Add("D", 4);
letterValue.Add("E", 5);
letterValue.Add("F", 6);
letterValue.Add("G", 7);
letterValue.Add("H", 8);
letterValue.Add("I", 9);
letterValue.Add("J", 10);
letterValue.Add("K", 11);
letterValue.Add("L", 12);
letterValue.Add("M", 13);
letterValue.Add("N", 14);
letterValue.Add("O", 15);
letterValue.Add("P", 16);
letterValue.Add("Q", 17);
letterValue.Add("R", 18);
letterValue.Add("S", 19);
letterValue.Add("T", 20);
letterValue.Add("U", 21);
letterValue.Add("V", 22);
letterValue.Add("W", 23);
letterValue.Add("X", 24);
letterValue.Add("Y", 25);
letterValue.Add("Z", 26);
//letterValue.Add(",", 0);
//letterValue.Add(@"\", 0);

int maxIndex = 0;
List<int> letterValues = new List<int>();
List<int> maxletterValues = new List<int>();
string maxName = "";

while (names.Length > 0)
{
    maxIndex = 0;
    maxletterValues.Clear();
    for (int i = 0; i < 10; i++)
        maxletterValues.Add(27);
    for (int i = 0; i < names.Length; i++)
    {
        letterValues.Clear();
        foreach (char c in names[i])
        {
            letterValues.Add(letterValue[c.ToString()]);
        }

        for (int j = 0; j < Math.Min(letterValues.Count, maxletterValues.Count); j++)
        {
            if (letterValues[j] < maxletterValues[j])
            {
                maxletterValues.Clear();
                for (int k = 0; k < letterValues.Count; k++)
                {
                    maxletterValues.Add(letterValues[k]);
                }
                maxIndex = i;
                maxName = names[i];
                break;
            }
            else if (letterValues[j] > maxletterValues[j])
                break;
            if (j == Math.Min(letterValues.Count, maxletterValues.Count) - 1 && maxletterValues.Count > letterValues.Count)
            {
                maxletterValues.Clear();
                for (int k = 0; k < letterValues.Count; k++)
                {
                    maxletterValues.Add(letterValues[k]);
                }
                maxIndex = i;
                maxName = names[i];
                break;
            }
        }
    }
    sortedNames.Add(maxName);
    names = names.Where((source, index) => index != maxIndex).ToArray();
}




double totalSum = 0;

for (double i = 0; i < sortedNames.Count; i++)
{
    double localSum = 0;
    foreach (char c in sortedNames[(int)i])
    {
        localSum = localSum + letterValue[c.ToString()];
    }
    totalSum = totalSum + (localSum * (i + 1));
}

Console.WriteLine("The total of all the name scores in the file is: " + totalSum);