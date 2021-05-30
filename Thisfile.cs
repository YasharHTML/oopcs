using System;
using System.Collections;

//Dangit;


public class Test
{

    public class Pair<T, U>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    }



    public class Man
    {
        public string bank_name;
        public double bal;
        public string name;
        public double credit = 0;
        public Man(int b, string n, string jay)
        {
            bal = b;
            name = n;
            bank_name = jay;
            
        }
        public string get_balance()
        {
            return string.Format("Your balance:{0}. Mr.{1}", bal, name);
        }
        public string add_money(double a)
        {
            bal += a;
            return string.Format("Money is added. Your balance:{0}. Mr.{1}", bal, name);
        }
        public string remove_money(double a)
        {
            if (bal - a < 0)
            {
                return string.Format("Not enough balance. Your balance:{0}. Mr.{1}", bal, name);
            }
            else
            {
                bal -= a;
                return string.Format("Money is deducted from your balance. Your balance:{0}. Mr.{1}", bal - a, name);
            }
        }
        public void pay_credit(Bank Hilton, double amount)
        {
            foreach(Pair<string, double> acc in Hilton.loanees)
            {
                if(acc.First == name)
                {
                    if(acc.Second <= amount)
                    {
                        bal -= acc.Second;
                        Hilton.add_to_bank_balance(acc.Second);
                        acc.Second = 0;
                    }
                    else
                    {
                        acc.Second -= amount;
                        bal -= amount;
                        Hilton.add_to_bank_balance(amount);
                    }
                }
            }
        }
        public string give_money_to_other_account(Man steph, Bank Hilton ,double a)
        {
            if(bank_name == steph.bank_name)
            {
                if(a > bal)
                {
                    return "ERR,Not enough Balance";
                }
                else
                {
                    bal -= a;
                    steph.add_money(a);
                    return "Transaction complete(Commision isn't applied, because clients' accounts have been registered in the same bank)";
                }
            }
            else
            {
                if(a > bal)
                {
                    return "ERR, Not enough Balance";
                }
                else
                {
                    bal -= a;
                    steph.add_money(a * 0.9);
                    Hilton.add_to_bank_balance(a * 0.1);
                    return "Transaction complete(Commision applied, because clients' accounts haven't been registered in the same bank).";
                }
            }
        }
    }

    public class Bank
    {
        double Safe;
        public string Name;
        public ArrayList loanees = new ArrayList();
        public Bank(double money, string name)
        {
            Safe = money;
            Name = name;
        }
        public double get_bank_balance()
        {
            return Safe;
        }
        public void add_to_bank_balance(double x)
        {
            Safe += x;
        }
        public string give_credit(Man jack, double a)
        {
            jack.add_money(a);
            if (jack.bank_name == Name)
                jack.credit += 1.0 * a;
            else
                jack.credit += 1.2 * a;                
            Safe -= a;
            Pair<string, double> pair = new Pair<string, double>(jack.name, jack.credit);
            loanees.Add(pair);
            return string.Format("{0}$ have been given as credit to Mr.{1}", a, jack.name);
        }
    }
    public static void Main()
    {
        Man man1 = new Man(1000, "Jack", "Bros");
        Man man2 = new Man(0, "Angel Di Maria", "Bros");
        Man man3 = new Man(0, "Lionel Messi", "HSBC");
        Bank Bros = new Bank(1000000, "Bros");
        Console.WriteLine(man1.give_money_to_other_account(man2, Bros, 500));
        Console.WriteLine(man1.give_money_to_other_account(man3, Bros, 500));
        Console.WriteLine(string.Format("{0}\n{1}\n{2}\n{3}", man1.get_balance(), man2.get_balance(), man3.get_balance(), Bros.get_bank_balance()));
    }
}
