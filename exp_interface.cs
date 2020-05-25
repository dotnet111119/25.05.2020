using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2505
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car();
            //c.Go(); // its private ! error!
            (c as I1).Go();
            (c as I2).Go();

            // must reference the object using the explicit interface 
            I1 c1 = new Car();
            c1.Go();

            
        }
    }

    public interface I1
    {
        void Go();
    }
    public interface I2
    {
        void Go();
    }
    public class Car : I1, I2
    {
        // 1- implementation of interface will turn the function into private!

        void I1.Go()
        {
            Console.WriteLine("I1 go!");
        }

        void I2.Go()
        {
            Console.WriteLine("I2 go!");
        }
    }


}
