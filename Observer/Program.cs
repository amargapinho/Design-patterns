using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public interface ISubscriber
    {
        void Update(IPublisher publisher);
    }

    public interface IPublisher
    {
        void Subscribe(ISubscriber subscriber);
        void Unsubscribe(ISubscriber subscriber);
        void Dispatch();
    }

    public class Publisher : IPublisher
    {
        public string state = "unavailable";
        private List<ISubscriber> subscribersList = new List<ISubscriber>();

        public void Subscribe(ISubscriber subscriber)
        {
            this.subscribersList.Add(subscriber);
            Console.WriteLine("Subscribed!");
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            this.subscribersList.Remove(subscriber);
            Console.WriteLine("Unsubscribed!");
        }

        public void Dispatch()
        {
            foreach (ISubscriber subscriber in subscribersList)
            {
                Console.WriteLine("Update sent.");
                subscriber.Update(this);
            }
        }

        public void Update()
        {
            this.state = "available";
            this.Dispatch();
        }

    }

    public class Subscriber : ISubscriber
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public Subscriber(int memberId, string name)
        {
            MemberId = memberId;
            Name = name;
        }

        public void Update(IPublisher publisher)
        {
            Console.WriteLine("Update received.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Publisher NewYorkTimes = new Publisher();
            Subscriber person1 = new Subscriber(1501, "Müller");
            Subscriber person2 = new Subscriber(1289, "Klein");

            NewYorkTimes.Subscribe(person1);
            NewYorkTimes.Subscribe(person2);

            NewYorkTimes.Update();

        }
    }
}