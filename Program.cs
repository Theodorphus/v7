using System;
using VendMachine3;

namespace VendMachine3;

public class Program
{

    static void Main(string[] args)
    {


        var drinkMachine = new DrinkMachine();



        Console.WriteLine("Please insert one of the amounts: (1, 5, 10, 20, 50, 100, 500, 1000)");
        drinkMachine.InsertMoney(Convert.ToInt32(Console.ReadLine()));

        while (drinkMachine.checkTotal() == true)
        {

            drinkMachine.ShowAll();

            Console.ReadLine();

        }






    }



}
