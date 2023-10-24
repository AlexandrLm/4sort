using System.ComponentModel;
using System.Diagnostics;

void ShowMas(int[] mas)
{
    for (int i = 0; i < mas.Length; i++)
        Console.Write($"{mas[i]} ");
}
int[] BubbleSort(int[] mas)
{
    int temp = 0;
    int[] bmas = mas;
    for (int i = 0; i < bmas.Length; i++)
        for (int j = 1; j < bmas.Length; j++)
            if (bmas[j - 1] > bmas[j])
            {
                temp = bmas[j - 1];
                bmas[j - 1] = bmas[j];
                bmas[j] = temp;
            }
    return bmas;
}
int[] CountingSort(int[] mas)
{
    int count = 0;
    int[] smas = new int[mas.Length];
    for (int i = 0; i < mas.Length; i++)
    {
        count = 0;
        for (int j = 0; j < mas.Length; j++)
        {
            if (mas[i] > mas[j])
                count++;
        }
        smas[count] = mas[i];
    }
    for (int i = 1; i < smas.Length; i++)
        if (smas[i] == 0)
            smas[i] = smas[i - 1];

    return smas;
}
int[] VkluchSort(int[] mas)
{
    int count = 0;
    int temp;
    int[] vmas = mas;
    int[] vmas1 = mas;
    for (int i = 1; i < vmas.Length; i++) 
    {
        for(int j = i; j > 0 && vmas[j-1] > vmas1[j]; j--)
        {
            count++;
            temp = vmas[j - 1];
            vmas[j - 1] = vmas1[j];
            vmas1[j] = temp;
        }
    }


    return vmas;
}
int[] IzvlechSort(int[] mas)
{ 
    for (int i = 0; i < mas.Length; i++) 
    {
        int temp = mas[0];
        for (int min = i + 1; min < mas.Length; min++) 
        {
            if (mas[i] > mas[min])
            {
                temp = mas[i];
                mas[i] = mas[min];
                mas[min] = temp;
            }
        }
    }
    return mas;
}

Random rnd = new Random();
int n = 10000;
int[] mas = new int[n];
int[] bubblemas = new int[n];
int[] countingmas = new int[n];
int[] vkluchmas = new int[n];
int[] izvlmas = new int[n];
for (int i = 0; i < mas.Length; i++)
{
    int temp = rnd.Next(-n, n);
    mas[i] = temp;
    bubblemas[i] = temp;
    countingmas[i] = temp;
    vkluchmas[i] = temp;
    izvlmas[i] = temp;
}

Stopwatch stopwatch = new Stopwatch();

//Console.WriteLine("Original:");
//ShowMas(mas);

Console.WriteLine("\nBubble:");            stopwatch.Start();
BubbleSort(bubblemas);                     stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedTicks); stopwatch.Reset();

Console.WriteLine("\nCounting");           stopwatch.Start();
CountingSort(countingmas);                 stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedTicks); stopwatch.Reset();

Console.WriteLine("\nVkluch");             stopwatch.Start();
VkluchSort(vkluchmas);                     stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedTicks); stopwatch.Reset();

Console.WriteLine("\nIzvlechenie");        stopwatch.Start();
IzvlechSort(izvlmas);                      stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedTicks); stopwatch.Reset();


