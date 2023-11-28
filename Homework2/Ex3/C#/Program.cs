public class Ex3
{
    static double[] GenerateRandomVariates(int n)
    {
        Random random = new Random();
        double[] randomVariates = new double[n];
        for (int i = 0; i < n; i++)
        {
            randomVariates[i] = random.NextDouble();
        }
        return randomVariates;
    }

    static void CalculateIntervalsFrequency(double[] randomVariates, int[] intervalsFrequency, int k)
    {
        foreach (var variate in randomVariates)
        {
            int j = (int)(variate * k);
            intervalsFrequency[j]++;
        }
    }

    static void Main()
    {
        int n = 1000;
        double[] randomVariates = GenerateRandomVariates(n);

        int k = 20;
        int[] intervalsFrequency = new int[k];
        CalculateIntervalsFrequency(randomVariates, intervalsFrequency, k);

        for (int i = 0; i < k; i++)
        {
            double lowerBound = (double)i / k;
            double upperBound = (double)(i + 1) / k;
            Console.WriteLine($"[{lowerBound:F1}, {upperBound:F1}): {intervalsFrequency[i]}");
        }

    }
}