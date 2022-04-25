
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VendMachine3;

public interface Ivending
{
    void Purchase(char selection);


    void ShowAll();


    void InsertMoney(int money);

    void EndTransaction();

}
public class DrinkMachine : Ivending
{



    public int minCost = 1;
    public int MoneyPool { get; set; }

    public DrinkMachine()
    {
        MoneyPool = 0;
    }

    public void InsertMoney(int money)
    {

        int[] cash = { 1, 5, 10, 20, 50, 100, 500, 1000 };
        IReadOnlyCollection<int> result = Array.AsReadOnly(cash);

        switch (money)
        {
            case (1):
                MoneyPool += cash[0];
                break;
            case (5):
                MoneyPool += cash[1];
                break;
            case (10):
                MoneyPool += cash[2];
                break;
            case (20):
                MoneyPool += cash[3];
                break;
            case (50):
                MoneyPool += cash[4];
                break;
            case (100):
                MoneyPool += cash[5];
                break;
            case (500):
                MoneyPool += cash[6];
                break;
            case (1000):
                MoneyPool += cash[7];
                break;
            default:
                Console.WriteLine("Invalid Entry.");
                break;
        }
    }

    public bool checkTotal()
    {

        if (MoneyPool >= minCost)
            return true;
        else
            return false;
    }


    Coke c = new Coke();
    Pepsi p = new Pepsi();
    Mars m = new Mars();

    public int cCost = 150;
    public int pCost = 120;
    public int mCost = 100;

    public int currPool;

    public void ShowAll()
    {
        c.Name = "Coke";
        c.Price = 150;

        p.Name = "Pepsi";
        p.Price = 120;

        m.Name = "Mars";
        m.Price = 100;

        Console.WriteLine("****************");
        Console.WriteLine("* C - Coke     *");
        Console.WriteLine("* P - Pepsi    *");
        Console.WriteLine("* M - Mars     *");
        Console.WriteLine("****************");
        Console.WriteLine();
        Console.WriteLine("Please make your selection");
        Purchase(Convert.ToChar(Console.ReadLine().ToUpper()));

    }

    public void Purchase(char selection)
    {

        Console.WriteLine();

        bool keepRun = true;

        while (keepRun)
        {

            switch (selection)
            {
                case 'C':

                    if (MoneyPool > cCost)
                    {

                        Console.WriteLine("Thank you for your purchase");
                        c.Examine();
                        c.Use();
                        currPool = MoneyPool - cCost;
                        EndTransaction();
                    }
                    else
                    {
                        Console.WriteLine("Money too low");
                    }

                    keepRun = false;



                    break;

                case 'P':

                    if (MoneyPool > pCost)
                    {
                        Console.WriteLine("Thank you for your purchase");
                        p.Examine();
                        p.Use();
                        currPool = MoneyPool - pCost;
                        EndTransaction();
                    }
                    else
                    {
                        Console.WriteLine("Money too low");
                    }

                    keepRun = false;


                    break;
                case 'M':

                    if (MoneyPool > pCost)
                    {
                        Console.WriteLine("Thank you for your purchase");
                        m.Examine();
                        m.Use();
                        currPool = MoneyPool - mCost;
                        EndTransaction();
                    }
                    else
                    {
                        Console.WriteLine("Money too low");
                    }

                    keepRun = false;



                    break;

                default:


                    Console.WriteLine("Invalid Selection. Please re-enter your selection.");
                    selection = Convert.ToChar(Console.ReadLine().ToUpper());
                    keepRun = false;

                    break;
            }
        }
    }

    public void EndTransaction()
    {

        Console.WriteLine("\nCurrent credit = " + currPool);

        Console.WriteLine("\nPress E to exit or S to continue shopping");

        char printChange = Convert.ToChar(Console.ReadLine().ToUpper());

        if (printChange == 'E')
        {

            Console.WriteLine("Thank you for shopping. Your change is {0:C}", (currPool));


        }
        else if (printChange == 'S')
        {
            ShowAll();

            Console.ReadLine();
        }
        {
            Console.Clear();

            Console.WriteLine("Please insert one of the amounts: (1, 5, 10, 20, 50, 100, 500, 1000)");
            InsertMoney(Convert.ToInt32(Console.ReadLine()));

            ShowAll();

            Console.ReadLine();

        }






    }

}

