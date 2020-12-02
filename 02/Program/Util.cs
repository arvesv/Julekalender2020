using System;
using System.Linq;

namespace Program
{
    public class Util
    {
        public static bool Contains7(int number)
        {
            Func<char, bool> is7 = c => c == '7';

            return number
                            .ToString()
                            .ToCharArray()
                            .Where(is7)
                            .Count() > 0;
        }


        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 != 0)
            {
                var boundary = (int)Math.Floor(Math.Sqrt(number));

                for (int i = 3; i <= boundary; i += 2)
                    if (number % i == 0)
                        return false;

                return true;
            }

            return false;
        }

        public static int GetPrimeLowerOrEqualTo(int number)
        {
            int i = number;
            while(!Util.IsPrime(i))
                i--;

            return i;
        }

        public static int GetNoDelivered(int numberOfPackages)
        {
            int delivered = 0;
            int toSkip = 0;

            for(int i = 0; i < numberOfPackages; i++) {
                if(toSkip > 0) {
                    toSkip--;
                    continue;
                }

                if(Contains7(i))
                {
                    toSkip = GetPrimeLowerOrEqualTo(i);
                    continue;
                }

                delivered++;
            }
            return delivered;
        }

    }
}

