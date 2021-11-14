using System;
using System.Collections.Generic;

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
            string[] answers = new string[numberOfAnswers];
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
        public Exam(int h)
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

    partial class OhMy
    {
        bool thatIsNotGood = true;
    }
    class Printer
    {
        public virtual void IAmPrinting(ref ISomethingLikeTest somethingLikeTest) { }

        public static void IAmPrinting(Object obj)
        {
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj.ToString());
        }
    }

    enum lessonNames
    {
        oop = 0,
        pl = 2,
        phy = 4,
        math1 = 6,
        math2 = 8
    }

    struct ForNothing
    {
        bool iWhantToCry;
        public ForNothing(bool i)
        {
            iWhantToCry = true;
        }
    }

    class Session
    {
        private List<Quest>sessionExams;
        public int counter;
        public List<Quest> SessionExams
        {
            set
            {
                sessionExams = value;
            }
            get
            {
                return sessionExams;
            }
        }
        public Session()
        {
            this.sessionExams = new List<Quest>();
        }
        public void Add(Quest quest)
        {
            sessionExams.Add(quest);
            ++counter;
            return;
        }
        public void Delete(int pos)
        {
            sessionExams.RemoveAt(pos);
            return;
        }
        public void Show()
        {
            int pos = 1; 
            foreach (Quest sess in sessionExams)
            {
                Console.WriteLine($"{pos}) {sess.ToString()}");
                ++pos;
            }
        }
    }
    class SessionControl : Session
    {
        public static int HowManyQuestsInSession(Session session)
        {
            return session.counter;
        }
        public static int HowManyQuestions(Session session, int number)
        {
            int cntr = 0;
            foreach (Quest q in session.SessionExams)
            {
                if (q.numberOfQuestions == number)
                    ++cntr;
            }
            return cntr;
        }
    }






    class Program
    {
        static void Main()
        {
            Exam ex1 = new Exam();
            ex1.numberOfQuestions = 5;
            Test ex2 = new Exam();
            ex2.numberOfQuestions = 10;
            Test ex3 = new Test();
            ex3.numberOfQuestions = 15;
            Session ses = new Session();
            ses.Add(ex1);
            ses.Add(ex2);
            ses.Add(ex3);
            ses.Show();
            Console.WriteLine("How many exams with 10 questions: "+SessionControl.HowManyQuestions(ses, 10));
            Console.WriteLine("How many exams: "+SessionControl.HowManyQuestsInSession(ses));
        }
    }
}

