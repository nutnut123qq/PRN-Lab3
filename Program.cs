using Lab3;
using System.Collections;
using System.ComponentModel;

namespace Lab3
{
    internal class Program
    {
        public class MyCollection<T> : IEnumerable where T : class, new()
        {
            private List<T> list = new List<T>();
            public void AddItem(params T[] item) => list.AddRange(item);
            IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();
        }

        public static T Input<T>()
        {
            var input = Console.ReadLine();
            if (input == null)
                return default;
            return (T)Convert.ChangeType(input, typeof(T));
        }


        public static void Swap<T>(ref T a, ref T b)
        {
            T temp;
            temp = a;
            a = b;
            b = temp;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("1. Demo List<>, Sortset<>, Collection<>");
                    Console.WriteLine("2. Add, Subtract, Multi, Div with Generics");
                    Console.WriteLine("3. Illustrate with Arraylist");
                    Console.WriteLine("4. Illustrate with Hashtable");
                    Console.WriteLine("5. Swap 2 elements with Generics");
                    Console.WriteLine("6. Exit");
                    Console.Write("Enter your choice: ");
                    var choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            //Demo List<>
                            Console.WriteLine("Demo List<>");
                            List<Student> students = new List<Student>();
                            students.Add(new Student { ID = 1, Age = 22, FullName = "John Doe" });
                            students.Add(new Student { ID = 2, Age = 21, FullName = "Jane Doe" });
                            students.Add(new Student { ID = 3, Age = 24, FullName = "John Smith" });
                            students.Add(new Student { ID = 4, Age = 19, FullName = "Jane Smith" });
                            students.Add(new Student { ID = 5, Age = 30, FullName = "John Johnson" });
                            foreach (Student stu in students)
                            {
                                Console.WriteLine(stu);
                            }
                            Console.WriteLine("============");
                            //Demo SortSet<>
                            Console.WriteLine("Demo SortSet<> by Age");
                            SortedSet<Student> studentsSorted = new SortedSet<Student>();
                            foreach (Student stu in students)
                            {
                                studentsSorted.Add(stu);
                            }
                            foreach (Student stu in studentsSorted)
                            {
                                Console.WriteLine(stu);
                            }
                            Console.WriteLine("============");
                            //Demo Emnumerable
                            Console.WriteLine("Demo Emnumerable<>");
                            MyCollection<Student> myCollection = new MyCollection<Student>();
                            foreach (Student stu in students)
                            {
                                myCollection.AddItem(stu);
                            }
                            foreach (var item in myCollection)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("============");
                            break;
                        case 2:
                            bool Exit = false;
                            while (!Exit)
                            {
                                Console.WriteLine("1. Add");
                                Console.WriteLine("2. Subtract");
                                Console.WriteLine("3. Multi");
                                Console.WriteLine("4. Div");
                                Console.WriteLine("5. Back to Menu");
                                Console.Write("Enter your choice: ");
                                choice = int.Parse(Console.ReadLine());
                                switch (choice)
                                {
                                    case 1:
                                        Console.WriteLine("Add 2 numbers");
                                        Console.Write("Num 1: ");
                                        var a = Input<int>();
                                        Console.Write("Num 2: ");
                                        var b = Input<int>();
                                        Console.WriteLine($"Result: {Calculator<int>.Add(a, b)}");
                                        break;
                                    case 2:
                                        Console.WriteLine("Subtract 2 numbers");
                                        Console.Write("Num 1: ");
                                        a = Input<int>();
                                        Console.Write("Num 2: ");
                                        b = Input<int>();
                                        Console.WriteLine($"Result: {Calculator<int>.Subtract(a, b)}");
                                        break;
                                    case 3:
                                        Console.WriteLine("Multiply 2 numbers");
                                        Console.Write("Num 1: ");
                                        var adboule = Input<double>();
                                        Console.Write("Num 2: ");
                                        var bdouble = Input<double>();
                                        Console.WriteLine($"Result: {Calculator<double>.Multiply(adboule, bdouble)}");
                                        break;
                                    case 4:
                                        Console.WriteLine("Divide 2 numbers");
                                        Console.Write("Num 1: ");
                                        adboule = Input<double>();
                                        Console.Write("Num 2: ");
                                        bdouble = Input<double>();
                                        Console.WriteLine($"Result: {Calculator<double>.Divide(adboule, bdouble)}");
                                        break;
                                    case 5:
                                        Exit = true;
                                        break;
                                }
                            }
                            break;

                        case 3:
                            Console.Write("Illustrate with Arraylist: ");
                            ArrayList arrayList = new ArrayList();
                            arrayList.Add(1);
                            arrayList.Add(2);
                            arrayList.Add(3);
                            arrayList.Add(4);
                            arrayList.Add(5);
                            foreach (var item in arrayList)
                            {
                                Console.Write(item + " ");
                            }
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Illustrate with Hashtable: ");
                            Hashtable hashtable = new Hashtable();
                            hashtable.Add("1", "One");
                            hashtable.Add("2", "Two");
                            hashtable.Add("3", "Three");
                            hashtable.Add("4", "Four");
                            Console.WriteLine("Key and Value pairs: ");
                            foreach (DictionaryEntry item in hashtable)
                            {
                                Console.WriteLine(item.Key + " " + item.Value);
                            }
                            Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Swap 2 Elements");
                            Console.Write("Num 1: ");
                            var num1 = Input<int>();
                            Console.Write("Num 2: ");
                            var num2 = Input<int>();
                            Swap<int>(ref num1, ref num2);
                            Console.WriteLine("After Swap");
                            Console.WriteLine($"Num 1: {num1}");
                            Console.WriteLine($"Num 2: {num2}");
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
