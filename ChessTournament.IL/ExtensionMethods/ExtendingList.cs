using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.IL.ExtensionMethods
{
    public static class ExtendingList
    {
        public static void Shuffle<T>(this List<T> list) where T : class, new()
        {
            if (list is null) throw new ArgumentNullException(nameof(list));
            if (list.Count == 0 || list.Count == 1) return;

            T temp = new();
            int count = list.Count;
            int r = 0;
            Random random = new Random();


            for (int i = 0; i < count - 1; i++)
            {
                r = random.Next(1, count - i);

                temp = list[r];
                list[r] = list[count - i - 1];
                list[count - i - 1] = temp;
            }

            //Randomizing the position of the initial last value
            r = random.Next(1, count);
            temp = list[r - 1];
            list[r - 1] = list[0];
            list[0] = temp;

        }
    }
}
