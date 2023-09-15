// HWK Task 2
// MIS 3033
// Abigail Pidgeon 113515288
// september 15 2023

Dictionary<string,double> fruitsdic = new Dictionary<string,double>();

fruitsdic.Add("apples", 0.99);
fruitsdic.Add("oranges", 0.5);
fruitsdic.Add("bananas", 0.5);
fruitsdic.Add("grapes", 2.99);
fruitsdic.Add("blueberries", 1.99);

Console.WriteLine("Fruit Names: ");

for (int i = 0; i < fruitsdic.Count; i++)
{
    Console.WriteLine(fruitsdic.Keys.ElementAt(i)+" ");
}

Console.WriteLine("\n");
Console.WriteLine("Input the name of the fruit: ");
string answer = Console.ReadLine();

if (fruitsdic.ContainsKey(answer))
{
    string outmes = string.Format($"The price of {answer} is {fruitsdic[answer]:C2}");
    Console.WriteLine(outmes);
}
else
{
    Console.WriteLine("Sorry that fruit is not found!");
}

Console.WriteLine();