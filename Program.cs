using System;
using System.Linq;
using System.Collections.Generic;

namespace Bank_transfer
{
    class Program
    {
        static List<account> accountList = new List<account>();
        private static string getUserInput(){
            try{
                Console.WriteLine("\nSelect one of the following options:");
                Console.WriteLine("1- Accounts list");
                Console.WriteLine("2- Add account");
                Console.WriteLine("3- Transfer");
                Console.WriteLine("4- Withdraw");
                Console.WriteLine("5- Deposit");
                Console.WriteLine("C- Clear Screen");
                Console.WriteLine("X- Exit\n");

                string userInput = Console.ReadLine().ToUpper();
                return userInput;
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
                return null;
            }
        }
        static void Main(string[] args)
        {
            try{
                string[] options = {"1","2","3","4","5","C","X"};
                string userInput = getUserInput();
                while(userInput != "X"){
                    if(options.Contains(userInput)){
                        switch(userInput){
                            case "1":
                                listAccounts();
                                break;
                            case "2":
                                addAccount();
                                break;
                            case "3":
                                transfer();
                                break;
                            case "4":
                                withdraw();
                                break;
                            case "5":
                                deposit();
                                break;
                            case "C":
                                Console.Clear();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        userInput = getUserInput();
                    }
                    else{
                        Console.WriteLine("\nEnter a valid option");
                        userInput = getUserInput();

                    }
                }
                Console.WriteLine("Thank you for choosing our service\n");
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
        }

        private static void addAccount()
        {   
            try{
                Console.WriteLine("ADD NEW ACCOUNT");
                Console.Write("type 1 for Natural Person or 2 for Legal Person: ");
                string input = Console.ReadLine();
                if(input == "1" || input =="2")
                {
                    int inputAccountType = Convert.ToInt32(input);
                    Console.Write("Client name: ");
                    string inputName = Console.ReadLine();
                    Console.Write("Initial balance: ");
                    double inputBalance = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Initial credit: ");
                    double inputCredit = Convert.ToDouble(Console.ReadLine());
                    account newAccount = new account(accountList.Count, (accountType)inputAccountType, inputBalance, inputCredit, inputName);
                    
                    accountList.Add(newAccount);
                }
                else{
                    Console.WriteLine("\nType 1 or 2\n");                 
                }

            }
            catch{
                Console.WriteLine("\nThe fields 'Balance' and 'Credit', only accept numbers");
            }
        }
        private static void listAccounts(){
            if(accountList.Count == 0){
                Console.WriteLine("No account registered");
                return;
            }
            Console.WriteLine("ACCOUNTS LIST\n");
            foreach( account account in accountList){
                int i = accountList.IndexOf(account);
                Console.Write($"{i}. ");
                Console.WriteLine(account);
                
            }
        }
        private static void withdraw(){
            try{
            Console.WriteLine("WITHDRAW");
            Console.Write("Account number: ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (id < accountList.Count)
            {
                Console.Write("amount: ");
                double amount = Convert.ToDouble(Console.ReadLine());
                
                accountList[id].withdraw(amount, false);
                return;
            }
            Console.WriteLine("This account number does not exist");
            }
            catch{
                Console.WriteLine("Type a valid account number an a valid amount");
            }
        }
        private static void deposit(){
            try{
            Console.WriteLine("DEPOSIT");
            Console.Write("Account number: ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (id < accountList.Count)
            {
                Console.Write("amount: ");
                double amount = Convert.ToDouble(Console.ReadLine());

                accountList[id].deposit(amount, false);
                return;
            }
            Console.WriteLine("This account number does not exist");
            }
            catch{
                Console.WriteLine("Type a valid account number an a valid amount");
            }
        }
        private static void transfer(){
            try{
                Console.WriteLine("TRANSFER");
                Console.Write("From account number: ");
                int id1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("To account number: ");
                int id2 = Convert.ToInt32(Console.ReadLine());
                if (id1 != id2)
                {
                    if ((id1 < accountList.Count) && (id2 < accountList.Count))
                    {
                        Console.Write("amount: ");
                        double amount = Convert.ToDouble(Console.ReadLine());

                        accountList[id1].transfer(amount,accountList[id2]);
                    }
                    else{
                        Console.WriteLine("\nType valid account numbers");
                    }
                }
                else{
                    Console.WriteLine("Select to different accounts to transfer");
                }
            }
            catch{
                Console.WriteLine("Type valid account numbers an a valid amount");
            }
        }
    }
}
