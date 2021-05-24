using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler
{
    public class ListsResults
    {
        public static void ListDifference(List<Uri> list1, List<Uri> list2)
        {
            var result = list1.Except(list2);
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}



