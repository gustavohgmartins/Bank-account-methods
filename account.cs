using System;
namespace Bank_transfer
{
    public class account
    {
        private accountType accountType{get;set;}
        private int id{get;set;}
        private string name{get;set;}
        private double balance{get;set;}
        private double credit{get;set;}

        public account(int id, accountType accountType, double balance, double credit, string name){
            this.accountType = accountType;
            this.id = id;
            this.name = name;
            this.balance = balance;
            this.credit = credit;
        }

        public bool withdraw(double amount, bool transfer){
            //withdraw validation
            if((this.balance+this.credit)>=amount){
                if(this.balance>=amount){
                    this.balance -= amount;
                }
                else{
                    this.credit += (this.balance - amount);
                    this.balance = 0;
                }
                if (transfer)
                {
                    return true;
                }
                Console.WriteLine($"Withdraw successful. Amount: {amount} | Account: {this.id} | Account name: {this.name}");
                Console.WriteLine($"Balance: {this.balance}");
                Console.WriteLine($"credit: {this.credit}");
                return true;
            }
                Console.WriteLine($"insufficient funds");
                return false;
        }
        public void deposit(double amount, bool transfer){
            this.balance += amount;
            if (!transfer)
            {
                Console.WriteLine($"Deposit successful. Amount: {amount} | Account: {this.id} | Account name: {this.name}");
                Console.WriteLine($"Balance: {this.balance}");
                Console.WriteLine($"credit: {this.credit}");
            }

        }
        public void transfer(double amount, account account){
            if (this.withdraw(amount, true)){
                Console.WriteLine($"Transfer successful. | Amount: {amount}. \nFrom: Account: {this.id} | Account name: {this.name}. \nTo: Account: {account.id} | Account name: {account.name}");
                account.deposit(amount, true);
            }
        }
        public override string ToString()
        {
            string content = "";
            content += $"Account type: {this.accountType} | ";
            content += $"Name: {this.name} | ";
            content += $"Balance: {this.balance} | ";
            content += $"Credit: {this.credit}";

            return content;
        }
    }
}