using System;
using System.Collections.Generic;
using System.Linq;

namespace Example2
{
    class Program
    {
        static HashSet<Pair> pairs = new HashSet<Pair>();

        static void Main(string[] args)
        {
            HashSet<Pair> pairs = getPairs(new int[] {11, 1, 1, 506, 11, 3, 4, 5, 6, 7, 8, 8, 8, 8, 8, 9, 10}, 9);

            pairs.ToList().ForEach(p => Console.WriteLine(p));

            Console.ReadKey();
        }

        static HashSet<Pair> getPairs(int[] array, int sum)
        {
            HashSet<Pair> pairs = new HashSet<Pair>();
            Array.Sort(array);

            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                if (array[left] + array[right] > sum)
                {
                    right--;
                }
                else if (array[left] + array[right] < sum)
                {
                    left++;
                }
                else
                {
                    pairs.Add(new Pair(array[left], array[right]));                    
                    right--;
                    left++;
                }
            }
            return pairs;
        }
    }

    public class Pair
    {
        private int left;
        private int right;
        
        public Pair(int left, int right)
        {
            this.left = left;
            this.right = right;
        }

        public override bool Equals(object other)
        {
            Pair otherPair = other as Pair;
            if (otherPair == null)
                return false;
            else
                return left.Equals(otherPair.left) && right.Equals(otherPair.right);
        }

        public override int GetHashCode()
        {
            return left.GetHashCode() + 31 * right.GetHashCode();
        }

        public override string ToString()
        {
            return left + " " + right;
        }
    }
}
