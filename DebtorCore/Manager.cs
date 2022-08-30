using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtorCore
{
    public class Manager
    {
        /// <summary>
        /// Lista dłużników
        /// </summary>
        private List<Borrower> Borrowers { get; set; }
        private string FileName { get; set; } = "borrowers.txt";
        /// <summary>
        /// Lista w której znajdują się dłużnicy w typie string
        /// </summary>
        private List<string> BorrowersToString = new List<string>();
        /// <summary>
        /// Funkcja wczytuje dłużników z pliku do listy Borrowers i BorrowersToString
        /// </summary>
        public Manager()
        {
            Borrowers = new List<Borrower>();
            if (!File.Exists(FileName))
            {
                return;
            }

                var filesLines = File.ReadAllLines(FileName);
            var borrowerstostring = new List<string>();
            foreach (var line in filesLines)
                {
                    var lineItems = line.Split(';');
                        
                        if (decimal.TryParse(lineItems[1], out var moneyInDecimal))
                        {
                    var borrower = new Borrower
                    {
                        Name = lineItems[0],
                        Money = moneyInDecimal
                    };
                    AddBorowers(lineItems[0], moneyInDecimal);
                    borrowerstostring.Add(borrower.ToString());
                        }
                }
            BorrowersToString = borrowerstostring;
            
            
        }
        /// <summary>
        /// Funkcja dodaje do pliku dłużnika i jego dług
        /// </summary>
        /// <param name="name">Nazwa dłużnika</param>
        /// <param name="money">Kwota długu</param>
        public void AddBorowers(string name, decimal money)
        {
            var borrower = new Borrower
            {
                Name = name,
                Money = money
            };
            Borrowers.Add(borrower);
            BorrowersToString.Add(borrower.ToString());
            File.WriteAllLines(FileName, BorrowersToString);
        }
        /// <summary>
        /// Funkcja usuwa dłużnika o nazwie podanej przez użytkownika
        /// </summary>
        /// <param name="name">Nazwa wskazana przez użytkownika</param>
        public void DeleteBorowers(string name)
        {
            foreach(var borrower in Borrowers)
            {
                if (borrower.Name == name)
                {
                    Borrowers.Remove(borrower);
                    break;
                }
                
            }

                 var borrowersToFile = new List<string>();

                foreach(var borrower in Borrowers)
                {
                    borrowersToFile.Add(borrower.ToString());
                }
                File.Delete(FileName);
                File.WriteAllLines(FileName, borrowersToFile);

        }
        /// <summary>
        /// Funkcja wyświetlająca listę dłużników
        /// </summary>
        public List<string> ListBorrowers()
        {
            var borrowersStrings = new List<string>();
            var indexer = 1;
            foreach (var borrower in Borrowers)
            {
                var borrowerString = indexer + " "+ borrower.Name + " "+ borrower.Money + " zł";
                indexer++;
                borrowersStrings.Add(borrowerString);
            }
            return borrowersStrings;
        }
    }
}
