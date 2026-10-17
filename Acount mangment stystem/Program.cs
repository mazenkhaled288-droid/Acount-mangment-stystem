namespace Acount_mangment_stystem
{
    class Transaction(string uuid, string type, bool statues, double amount, string fromAcount, string toAcount, DateTime time)
    {
        string uuid=uuid;
        string type=type;
        bool statues=statues;
        double amount=amount;
        string fromAcount=fromAcount;
        string toAcount=toAcount;
        DateTime time = time;
    }
    class Acount(string name, string phoneNumber, string password, double balance, string address, int age)
    {
        string name;
        string phoneNumber;
        string password;
        double balance;
        string address;
        int age;
        List<Transaction> transactions = [];

        public bool withdraw(string password, double amount)
        {
            if (password != this.password)
                return false;
            if (amount > this.balance)
                return false;
            this.balance -= amount;
            return true;
        }

        public bool deposite(string password, double amount)
        {
            if (password != this.password)
                return false;
            if (amount < 0)
                return false;
            this.balance += amount;
            return true;
        }
        public bool Transfer(string password, double amount,Acount toAcount)
        {
            if (password != this.password)
                return false;
            if (amount < 0)
                return false;
            if (toAcount == null)
                return false;

            this.balance -= amount;
            toAcount.balance += amount;
            return true;
        }
        public double? getBalance(string password)
        {
            if (password != this.password)
                return null;

            return this.balance;
        }
    }
    internal class Program
    {
        static void Main()
        {
             Acount acount = new Acount("Mazen", "012", "123", 400, "Alex", 20);
             Acount acount2 = new Acount("sahar", "011", "1234", 500, "Alex", 19);

            int num;
            do
            {
                Console.WriteLine("press 1 To Withdraw:");
                Console.WriteLine("press 2 To deposite:");
                Console.WriteLine("press 3 To Transfer:");
                Console.WriteLine("press 4 To Get Balance");
                Console.WriteLine("press 5 To Get last transaction:");
                Console.WriteLine("press 6 To Change password:");
                Console.WriteLine("press 7 To Add user info:");
                Console.WriteLine("press 8 To Quit:");
                num = Convert.ToInt32(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter password:");
                            string password = Convert.ToString(Console.ReadLine());

                            Console.WriteLine("Enter amount:");
                            double amount = Convert.ToDouble(Console.ReadLine());

                            acount.withdraw(password, amount);
                            break;
                        }
                    case 2:
                        { 
                        Console.WriteLine("Enter password:");
                        string password = Convert.ToString(Console.ReadLine());

                        Console.WriteLine("Enter amount");
                        double amount = Convert.ToDouble(Console.ReadLine());

                        acount.deposite(password, amount);
                        break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter Password:");
                            string password = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Enter amount:");
                            double amount = Convert.ToDouble(Console.ReadLine());
                            acount.Transfer(password, amount, acount2);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter Password: ");
                            string? password = Console.ReadLine();

                            double? balance = acount.getBalance(password);

                            if(balance==null)
                            {
                                Console.WriteLine("incorrect password");
                            }
                            else
                            {
                                Console.WriteLine($"balance is: {balance}");
                            }
                        }
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;

                }
            }
            while (num!= 0);
        }
    }
}
