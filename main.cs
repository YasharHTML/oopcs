using System;

public class Test
{
    public class Man{
        int bal;
        string name;
        public Man(int b, string n){
            bal = b;
            name = n;
        }
        public string get_balance(){
            return string.Format("Your balance:{0}. Mr.{1}",bal, name);    
        }
        public string add_money(int a){
            bal += a;
            return string.Format("Money is added. Your balance:{0}. Mr.{1}",bal, name);
        }
        public string remove_money(int a){
            if(bal-a < 0){
                return string.Format("Not enough balance. Your balance:{0}. Mr.{1}", bal, name);
            }
            else{
                return string.Format("Money is deducted from your balance. Your balance:{0}. Mr.{1}",bal-a, name);
                bal -= a;
            }
        }
    }
	public static void Main()
	{
		Man myman = new Man(1000, "Jack");
		Console.WriteLine(myman.get_balance());
		Console.WriteLine(myman.add_money(500));
		Console.WriteLine(myman.remove_money(1600));
	}
}
