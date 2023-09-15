// HWK Task 1
// MIS 3033
// Abigail Pidgeon 113515288
// september 15 2023

string[] fruitname;
fruitname = new string[5];

double[] fruitprice;
fruitprice = new double[5];

fruitname[0] = "apples";
fruitname[1] = "oranges";
fruitname[2] = "bannanas";
fruitname[3] = "grapes";
fruitname[4] = "bluberries";

fruitprice[0] = 0.99;
fruitprice[1] = 0.5;
fruitprice[2] = 0.5;
fruitprice[3] = 2.99;
fruitprice[4] = 1.99;

Console.WriteLine("Fruit Avaliable");
for (int i = 0; i < fruitname.Length; i++)
{
    Console.WriteLine(fruitname[i]+" ");
}

Console.WriteLine("\n");
Console.WriteLine("Please input the fruit you would like: ");
string answer  = Console.ReadLine();

bool match = false;

for (int i = 0; i < fruitname.Length; i++)
{
	if (fruitname[i] == answer)
	{
		string outmesg = string.Format($"The price of {fruitname[i]} is {fruitprice[i]:C2}");
        Console.WriteLine(outmesg);
        match = true;
    }
}

if (match == false)
{
    Console.WriteLine("Sorry that is the wrong name!");
}

Console.WriteLine();