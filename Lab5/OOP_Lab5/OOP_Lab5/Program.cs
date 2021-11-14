using System;

namespace OOP_Lab5
{
    interface ISomethingLikeTest
    {
        bool Result();
    }

    public abstract class Quest
    {
        public readonly int numberOfTries = 1;
        public int numberOfQuestions = 0;
        public abstract bool Result();
        public override string ToString()
        {
            string str = "";
            str += numberOfTries;
            return str;
        }
    }
    public class Test : Quest, ISomethingLikeTest
    {
        public bool isHard;
        public Test(bool f)
        {
            f = true ? isHard = true : isHard = false;
        }
        public Test()
        {
            isHard = false;
        }
        public override bool Result()
        {
            if (this.isHard == false)
                return true;
            else
                return false;
        }
        public class Question
        {
            static int numberOfAnswers = 1;
            string [] answers = new string[numberOfAnswers];
        }
        public override string ToString()
        {
            string str = "";
            str += numberOfTries + "--->" + isHard;
            return str;
        }
    }
    public class Exam : Test
    {
        public int howManyIntrestingQuestions;
        public Exam(bool f, int h) : base(f)
        {
            isHard = true;
            howManyIntrestingQuestions = h;
        }
        public Exam()
        {
            isHard = true;
            howManyIntrestingQuestions = 1;
        }
        public override string ToString()
        {
            string str = "";
            str += numberOfTries;
            str += "--->" + howManyIntrestingQuestions;
            return str;
        }
    }
    public sealed class FinalExam : Exam
    {
        readonly bool goodbye = true;
        public FinalExam()
        {
            isHard = true;
            howManyIntrestingQuestions = 10;
        }
        public override string ToString()
        {
            string str = "";
            str += numberOfTries;
            str += "--->" + howManyIntrestingQuestions;
            str += "--->" + goodbye;
            return str;
        }
        public override int GetHashCode()
        {
            int str = 0;
            Random random1 = new Random();
            str += random1.Next(-10, 10);
            return str;
        }
        public override bool Equals(object fe)
        {
            if (this == fe)
                return true;
            else
                return false;
        }
    }

    class Printer
    {
        public virtual void IAmPrinting(ref ISomethingLikeTest somethingLikeTest){}

        public static void IAmPrinting(Object obj)
        {
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj.ToString());
        }
    }



    class Program
    {
        static void Main()
        {
            Test test1 = new Test(false);
            Exam exam1 = new FinalExam();
            FinalExam fe1 = new FinalExam();
            if (test1 is Quest)
                Console.WriteLine("test1 - Quest");
            if (test1 is Test)
                Console.WriteLine("test1 - Test");
            if (test1 is Exam)
                Console.WriteLine("test1 - Exam");
            if (test1 is FinalExam)
                Console.WriteLine("test1 - Final Exam");

            /*if (exam1 is Quest)
                Console.WriteLine("test1 - Quest");
            if (exam1 is Test)
                Console.WriteLine("test1 - Test");
            if (exam1 is Exam)
                Console.WriteLine("test1 - Exam");
            if (exam1 is FinalExam)
                Console.WriteLine("test1 - Final Exam");*/

            if (exam1 is ISomethingLikeTest)
                Console.WriteLine("\nexam1 was created with interface\n");

            Test test2 = exam1 as Test;
            if (test2 is Quest)
                Console.WriteLine("test2 - Quest");
            if (test2 is Test)
                Console.WriteLine("test2 - Test");
            if (test2 is Exam)
                Console.WriteLine("test2 - Exam");
            if (test2 is FinalExam)
                Console.WriteLine("test2 - Final Exam");

            Console.WriteLine("\n" + exam1.ToString());
            Console.WriteLine("\n|\n|\n|");
            Quest [] questArray = new Quest[3];
            questArray[0] = new Test();
            questArray[1] = new Exam();
            questArray[2] = new FinalExam();
            Printer.IAmPrinting(questArray);
            Console.WriteLine("|");
            for (int i = 0; i < 3; ++i)
                Printer.IAmPrinting(questArray[i]);
        }
    }
}
