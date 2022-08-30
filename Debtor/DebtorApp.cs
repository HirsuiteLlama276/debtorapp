using DebtorCore;
using System;

namespace Debtor
{
    public class DebtorApp
    {
        public Manager BorrowerManager { get; set; } = new Manager();
        public void Hello()
        {
            Console.WriteLine("Aplikacja dłużnik - zarządzaj swoimi dłużnikami!");
        }

        public void AddBorrower()
        {
            Console.Clear();
            Console.WriteLine("Podaj nazwę dłużnika, którego chcesz dodać do listy ");
                var debtorName = Console.ReadLine();
            Console.WriteLine("Podaj kwotę dłużnika ");
            var debtorMoney = Console.ReadLine();
            if (decimal.TryParse(debtorMoney, out var moneyInDecimal))
            { 
                BorrowerManager.AddBorowers(debtorName, moneyInDecimal); 
            }
            else
            {
                Console.WriteLine("Podano złą kwotę - spróbuj jeszcze raz");
                AddBorrower();
            }
            
        }

        public void DeleteBorrower()
        {
            Console.Clear();
            Console.WriteLine("Podaj nazwę dłużnika, którego chcesz usunąć z listy ");
            var debtorName = Console.ReadLine();
            BorrowerManager.DeleteBorowers(debtorName);
        }
        public void AllBorrowers()
        {
            Console.Clear();
            Console.WriteLine("Oto lista wszystkich dłużników: ");
            foreach(var borrower in BorrowerManager.ListBorrowers())
            {
                Console.WriteLine(borrower);
            }
            
          
        }
        /// <summary>
        /// Menu w którym porusza się użytkownik
        /// </summary>
        public void AskForAction()
        {
            var userInput = default(string);
            while (userInput!="exit")
            {

            
            Console.WriteLine("Podaj czynność którą chcesz wykonać: ");
            Console.WriteLine("add - dodawanie dłużnika ");
            Console.WriteLine("del - usunięcie dłużnika ");
            Console.WriteLine("list - wyświetlenie dłużników ");
            Console.WriteLine("exit - wyjście z programu ");
             userInput = Console.ReadLine();
             userInput =  userInput.ToLower();

            switch (userInput)
            {
                case "add":
                    AddBorrower();
                        break;
                case "del":
                    DeleteBorrower();
                        break;
                case "list":
                    AllBorrowers();
                        break;
                    default:
                    Console.WriteLine("Wpisano złą wartość");
                        break;
                }
            }
        }
    }
}
