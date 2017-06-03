using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FizzleBizzle
{
    public interface IFizzleBizzle
    {
        int Fizz { set; get; }
        int Buzz { set; get; }

        //string[] FizzBuzz(int start, int end);

        string[] FizzBuzzBazz(int start, int end, Predicate<int> bazz);
    }

    public class FizzleBizzleModel : IFizzleBizzle
    {
        private int _fizz;
        private int _buzz;

        [Required]
        public int Fizz
        {
            get { return _fizz; }
            set { _fizz = value; }
        }

        [Required]
        public int Buzz
        {
            get { return _buzz; }
            set { _buzz = value; }
        }
        //------ Consolidate this into FizzBuzzBazz()
        //public string[] FizzBuzz(int start, int end)
        //{
        //    List<string> numList = new List<string>();

        //    for(int i = start; i <= end; i++)
        //    {
        //        if(i % Fizz == 0 && i % Buzz == 0)
        //        {
        //            numList.Add("FizzBuzz");
        //        } else if(i % Fizz == 0)
        //        {
        //            numList.Add("Fizz");
        //        } else if(i % Buzz == 0)
        //        {
        //            numList.Add("Buzz");
        //        } else
        //        {
        //            numList.Add(i.ToString());
        //        }
        //    }
        //    return numList.ToArray();
        //}

        public string[] FizzBuzzBazz(int start, int end, Predicate<int> bazz)
        {
            List<string> numList = new List<string>();

            for (int i = start; i <= end; i++)
            {
                var boolean = false;
                if (!bazz.Equals(null))
                    boolean = bazz(i);

                if (i % Fizz == 0 && i % Buzz == 0 && boolean)
                {
                    numList.Add("FizzBuzzBazz");
                }
                else if(i % Fizz == 0 && i % Buzz == 0) {
                    numList.Add("FizzBuzz");
                }
                else if (i % Fizz == 0)
                {
                    numList.Add("Fizz");
                }
                else if (i % Buzz == 0)
                {
                    numList.Add("Buzz");
                }
                else
                {
                    numList.Add(i.ToString());
                }
            }
            string[] list = numList.ToArray();
            return list;
        }
    }
}