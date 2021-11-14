using System;

namespace OOP_lab3
{
    public partial class GoodPhone
    {
        int id; 
    }
    public class Phone
    {
        private static int counter;//стачиское поле с количеством экземпляров

        public const int maxNumberOfPhones = 15;//поле-константа
        public readonly string bestName = "Игорь";//поле, которое можно только читать

        public int id;
        public int Id
        {
            set
            {
                if (value > maxNumberOfPhones)
                {
                    Console.WriteLine("Слишком много аккаунтов");
                }
                else
                {
                    id = value;
                }
            }
            get { return id; }
        }
        public string familyName;
        public string firstName;
        public string fatherName;
        public string adress;
        public string creditCardNumber;
        public int debet;
        public int credit;
        public void MoveCreditWithExpanding(ref int inputt, int a, out int result)
        {
            result = inputt += a;
        }
        public int inCityCalls;
        private int InCityCalls
        {
            get { return inCityCalls; }
            set { inCityCalls = value; }
        }
        public int outCityCalls;

        static Phone() { counter = 0; }//статический конструктор, он же конструктор без параметров
        private Phone(int id1, string fName, string lName, string cNumber)//приватный конструктор, с параметрами
        {
            ++counter;
            id = id1;
            firstName = fName; familyName = lName;
            creditCardNumber = cNumber;
        }
        public Phone(int id2 = 0, string adr2 = "", string fName = "", string lName = "", string fthrName = "", string cardNumber = "", int dbt = 0, int crdt = 0, int nCtClls = 0, int tCtClls = 0, string bstNm = "Игорь")
        {//публичный конструктор, с параметрами по умолчанию
            ++counter;
            id = id2; adress = adr2;
            firstName = fName; familyName = lName; fatherName = fthrName;
            creditCardNumber = cardNumber; credit = crdt; debet = dbt;
            inCityCalls = nCtClls; outCityCalls = tCtClls;
            bestName = bstNm;
        }

        public int GetHashsh(int i)
        {
            int res = i.GetHashCode();
            return res;
        }

        public static void ShowMeInfo(Phone model)
        {
            Console.WriteLine($"ID: {model.id.ToString()}\nИмя: {model.firstName}\nФамилия: {model.familyName}\nОтчество: {model.fatherName}\nНомер кредитной карты: {model.creditCardNumber}\nКредит: {model.credit}\nДебет: {model.debet}\nВремя звонков внутри города: {model.inCityCalls}\nВремя звоноков по межгороду: {model.outCityCalls}");
        }

        public void ShowByOutcity(Phone[] phonearray)
        {
             foreach (Phone buffPhone in phonearray)
             {
                 if (buffPhone.outCityCalls > 0)
                     ShowMeInfo(buffPhone);
             }
        }
        public void ShowByInCityParam(Phone[] phonearray, int max)
        {
            foreach (Phone buffPhone in phonearray)
            {
                if (buffPhone.inCityCalls > max)
                    ShowMeInfo(buffPhone);
            }
        }
        ~Phone()//деструктор
        {
            Console.WriteLine("Аккаунт аннигилирован!");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Начато!\n---");
            Phone smartphone1 = new Phone(1, "Ул. Милая, д.19", "Сидор", "Сидоров", "Сидорович", "5553 5351 2345", 0, 120, 50, 0, "Игорь");
            Phone.ShowMeInfo(smartphone1);
            Phone smartphone2 = new Phone(2, "Ул. Добрая, д.2", "Иван", "Иванов", "Иванович", "5554 5451 2435", 0, 120, 50, 0, "Игорь");
            Console.WriteLine("---");
            Phone.ShowMeInfo(smartphone2);
            if (smartphone2.Equals(smartphone1))                                                    //Использую Equals
                Console.WriteLine(smartphone1.firstName + " " + smartphone2.firstName + " подобны!");
            int onehash = smartphone1.GetHashsh(smartphone1.id);
            Console.WriteLine("---");
            Console.WriteLine("Hash1: " + onehash);
            Console.WriteLine("---");
            Phone[] smartphones = new Phone[8];                                     //array
            for (int i = 0; i < 8; ++i)
            {
                smartphones[i] = new Phone();
            }
            {
                smartphones[0].id = 15;
                smartphones[0].outCityCalls = 0;
                smartphones[0].inCityCalls = 60;
                smartphones[1].id = 16;
                smartphones[1].outCityCalls = 120;
                smartphones[1].inCityCalls = 10;
                smartphones[2].id = 17;
                smartphones[2].outCityCalls = 12;
                smartphones[2].inCityCalls = 65;
                smartphones[3].id = 18;
                smartphones[3].outCityCalls = 0;
                smartphones[3].inCityCalls = 0;
                smartphones[4].id = 19;
                smartphones[4].outCityCalls = 0;
                smartphones[4].inCityCalls = 100;
                smartphones[5].id = 20;
                smartphones[5].outCityCalls = 5;
                smartphones[5].inCityCalls = 13;
                smartphones[6].id = 21;
                smartphones[6].outCityCalls = 0;
                smartphones[6].inCityCalls = 74;
                smartphones[7].id = 22;
                smartphones[7].outCityCalls = 50;
                smartphones[7].inCityCalls = 59;
            }
            smartphones[0].ShowByInCityParam(smartphones, 60);
            Console.WriteLine("---");
            smartphones[0].ShowByOutcity(smartphones);
            Console.WriteLine("---");
            var maybesmartphone = new { id = 1, adress = "Ул. Милая, д.19", firstName = "Сидор", familyName = "Сидоров", fatherName = "Сидорович", creditCardNumber = "5553 5351 2345", credit = 0, debet = 120, inCityCalls = 50, outCityCalls =  0, bestName = "Игорь" };
            
            Console.WriteLine("---\nЗакончено!");
        }
    }



    public partial class GoodPhone
    {
        bool isGood;
        GoodPhone(int ID)
        {
            if (ID == 777)
                this.isGood = true;
            else
                this.isGood = false;
        }
    }
}
