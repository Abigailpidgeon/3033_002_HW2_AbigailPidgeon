// HWK Task 1
// MIS 3033
// Abigail Pidgeon 113515288
// september 15 2023

string qreceipt = "Another Receipt? (y/n)";
Console.WriteLine(qreceipt);
string receiptanswer = Console.ReadLine();
receiptanswer = receiptanswer.ToLower();

string outmes;

List<Receipt> receiptlist = new List<Receipt>();

while (receiptanswer == "y" || receiptanswer == "yes")
{
    outmes = "Customer ID: ";
    Console.WriteLine(outmes);
    string custidS = Console.ReadLine();
    int custidI = Convert.ToInt32(custidS);

    Console.Write("Number of cogs: ");
    string numcogS = Console.ReadLine();
    int numcogI = Convert.ToInt32(numcogS);

    Console.Write("Number of gears: ");
    string numgearS = Console.ReadLine();
    int numgearI = Convert.ToInt32(numgearS);

    Receipt newRecipt = new Receipt(custidI, numcogI, numgearI);

    newRecipt.PrintReceipt();
    receiptlist.Add(newRecipt);

    Console.WriteLine();
    Console.WriteLine(qreceipt);
    receiptanswer = Console.ReadLine();
    receiptanswer = receiptanswer.ToLower();

}

receiptanswer = "1";
while (receiptanswer == "1"|| receiptanswer == "2"|| receiptanswer == "3")
{
    Console.WriteLine("Please choose from the options: ");
    Console.WriteLine("1: Print all receipt of one customer");
    Console.WriteLine("2: Print all receipt for today");
    Console.WriteLine("3: Print the highest total receipt");
    Console.WriteLine("Press other keys to end");

    receiptanswer = Console.ReadLine();
    receiptanswer = receiptanswer.ToLower();

    if (receiptanswer == "1")
    {
        Console.Write("Input customer id: ");
        string inputcustidS = Console.ReadLine();
        int inputcustidI = Convert.ToInt32(inputcustidS);

        for (int i = 0; i < receiptlist.Count; i++)
        {
            if (receiptlist[i].CustomerID == inputcustidI)
            {
                receiptlist[i].PrintReceipt();
            }
        }
    }
    else if (receiptanswer == "2") 
    {
        DateTime tdDT = DateTime.Now;

        for (int i = 0; i < receiptlist.Count; i++)
        {
            if (receiptlist[i].SaleDate.ToString("d") == tdDT.ToString("d")) ;
            {
                receiptlist[i].PrintReceipt();
            }
        }
    }else if (receiptanswer == "3")
    {
        if(receiptlist.Count > 0)
        {
            Receipt highestR = receiptlist[0];
            for (int i = 0; i < receiptlist.Count; i++)
            {
                if (receiptlist[i].CalculateTotal() > highestR.CalculateTotal())
                {
                    highestR = receiptlist[i];
                }
            }

            Console.WriteLine("HIGHEST:");
            highestR.PrintReceipt();

        }

    
    }
}
Console.ReadLine();
public class Receipt
{
    public int CustomerID;
    public int CogQuantity;
    public int GearQuantity;
    public DateTime SaleDate;
    private double SalesTaxPercent;
    private double CogPrice;
    private double GearPrice;

    public Receipt()
    {
        this.SalesTaxPercent = 8.9 / 100;
        this.CogPrice = 79.99;
        this.GearPrice = 250.00;
        this.SaleDate = DateTime.Now;
    }

    public Receipt(int id, int cog, int gear)
    {
        this.SalesTaxPercent = 8.9 / 100;
        this.CogPrice = 79.99;
        this.GearPrice = 250.00;
        this.CustomerID = id;
        this.CogQuantity = cog;
        this.GearQuantity = gear;
        this.SaleDate = DateTime.Now;
    }  

    public void PrintReceipt()
    {
        Console.WriteLine("=============================");
        Console.WriteLine("RECEIPT");
        string outmesg;
        outmesg = string.Format($"# cogs: {this.CogQuantity}");
        Console.WriteLine(outmesg);

        outmesg = string.Format($"# gears: {this.GearQuantity}");
        Console.WriteLine(outmesg);

        outmesg = string.Format($"Net amount: {this.CalculateNetAmount():C2}");
        Console.WriteLine(outmesg);

        outmesg = string.Format($"Tax amount: {this.CalculateTaxAmount():C2}");
        Console.WriteLine(outmesg);

        outmesg = string.Format($"Total amount: {this.CalculateTotal():C2}");
        Console.WriteLine(outmesg);

        outmesg = string.Format($"Time: {this.SaleDate}");
        Console.WriteLine(outmesg);
        Console.WriteLine("=============================");


    }

    private double CalculateNetAmount()
    {
        double netAmount;
        if (this.CogQuantity > 10 || this.GearQuantity > 10 || this.CogQuantity + this.GearQuantity >16)
        {
            netAmount = (this.CogPrice * this.CogQuantity + this.GearPrice * this.GearQuantity) * (1 + 0.125);

        }
        else
        {
            netAmount = (this.CogPrice * this.CogQuantity + this.GearPrice * this.GearQuantity) * (1 + 0.15);
        }
        return netAmount;
    }

    private double CalculateTaxAmount()
    {
        return this.SalesTaxPercent * this.CalculateNetAmount();
    }

    public double CalculateTotal()
    {
        return this.CalculateNetAmount() + this.CalculateTaxAmount();
    }
}
