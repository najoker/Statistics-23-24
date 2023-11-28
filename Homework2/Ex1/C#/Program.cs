public class Exercise1
{
    public static Dictionary<T, int> CalculateAbsoluteFrequency<T>(IEnumerable<T> data)
    {
        Dictionary<T, int> frequency = new Dictionary<T, int>();

        foreach (T item in data)
        {
            if (frequency.ContainsKey(item))
            {
                frequency[item]++;
            }
            else
            {
                frequency[item] = 1;
            }
        }

        return frequency;
    }

    public static Dictionary<T, double> CalculateRelativeFrequency<T>(IEnumerable<T> data)
    {
        Dictionary<T, int> absoluteFrequency = CalculateAbsoluteFrequency(data);
        Dictionary<T, double> frequency = new Dictionary<T, double>();

        int dataLength = data.Count();

        foreach (var item in absoluteFrequency)
        {
            frequency[item.Key] = (double)item.Value / dataLength;
        }

        return frequency;
    }

    public static Dictionary<T, double> CalculatePercentageFrequency<T>(IEnumerable<T> data)
    {
        Dictionary<T, int> absoluteFrequency = CalculateAbsoluteFrequency(data);
        Dictionary<T, double> frequency = new Dictionary<T, double>();

        int dataLength = data.Count();

        foreach (var item in absoluteFrequency)
        {
            frequency[item.Key] = (double)item.Value / dataLength * 100;
        }

        return frequency;
    }

    public static Dictionary<string, int> CalculateJointFrequency<T, E>(IEnumerable<T> data1, IEnumerable<E> data2)
    {
        Dictionary<string, int> frequency = new Dictionary<string, int>();

        foreach (var x in data1)
        {
            foreach (var y in data2)
            {
                string label = $"x: {x}, y: {y}";
                if (frequency.ContainsKey(label))
                {
                    frequency[label]++;
                }
                else
                {
                    frequency[label] = 1;
                }
            }
        }

        return frequency;
    }

    public static void PrintData<K, V>(Dictionary<K, V> data)
    {
        foreach (var item in data)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }

    public static List<String> getColumnData(String columnName)
    {
        string tsvFileName = "./Professional Life.tsv";
        int targetColumnIndex = -1;
        List<String> results = new List<String>();

        // Check if the file exists
        if (!File.Exists(tsvFileName))
        {
            Console.WriteLine("File not found.");
            return null;
        }

        bool isFirstTime = true;
        // Read the TSV file and extract the desired column
        using (StreamReader reader = new StreamReader(tsvFileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                List<String> columns = new List<string>(line.Split('\t'));
                if (isFirstTime)
                {
                    targetColumnIndex = columns.IndexOf(columnName);
                    isFirstTime = false;
                }
                else
                {
                    if (targetColumnIndex < columns.Count)
                    {
                        results.Add(columns[targetColumnIndex]);
                    }
                }
            }
        }

        return results;
    }

    static void Main()
    {

        List<String> columns = new List<String>();
        columns.Add("Hard Worker (0-5)");
        columns.Add("Main Interests");
        columns.Add("Age");

        List<List<String>> data = new List<List<string>>();

        foreach (var column in columns)
        {
            var values = getColumnData(column);
            data.Add(values);
            Console.WriteLine(column);
            Console.WriteLine("absolute");
            PrintData(CalculateAbsoluteFrequency(values));
            Console.WriteLine("relative");
            PrintData(CalculateRelativeFrequency(values));
            Console.WriteLine("percentage");
            PrintData(CalculatePercentageFrequency(values));
            Console.WriteLine("\n\n\n");
        }

        Console.WriteLine("joint distribution");
        var result = CalculateJointFrequency(data[0], data[1]);
        PrintData(result);
    }
}