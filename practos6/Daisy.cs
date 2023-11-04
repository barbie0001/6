namespace practos6
{
    public partial class Program
    {
        public class Daisy
        {
            public string Client;
            public string WeekDay;

            static  public Daisy[] Human()
            {
                Daisy[] a = new Daisy[3];

                Daisy client1 = new Daisy();
                client1.Client = "Варвара";
                client1.WeekDay = "Вторник";
               

                Daisy client2 = new Daisy();
                client2.Client = "Александра";
                client2.WeekDay = "Среда";
               

                Daisy client3 = new Daisy();
                client3.Client = "София";
                client3.WeekDay = "Пятница";

                a[0] = client1;
                a[1] = client2; 
                a[2] = client3;

                return a;
               
            }
        }

    }
}

