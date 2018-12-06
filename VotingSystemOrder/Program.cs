using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystemOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sl = new Solution();
            string str = sl.electionWinner(new[] {"1","2","3","4","5","1","3","34","2","3","7","8","9","2","1"});

            Console.ReadKey();

        }
    }

    class Solution
    {
        // Complete the electionWinner function below.
        public string electionWinner(string[] votes)
        {
            List<string> strList = new List<string>(votes);
            
            strList.Sort();
            var grouped = strList
                            .GroupBy(s => s)
                            .Select(g => new { Member = g.Key, Votes = g.Count() }).ToList();

            var group = grouped.GroupBy(k => k.Member);

            var items = from pair in grouped
                        orderby pair.Votes descending
                        select pair;

            var keyOfMaxValue = items.Aggregate((x, y) => x.Votes > y.Votes ? x : y).Votes;

            var finalList = items.Where(kvp => kvp.Votes == keyOfMaxValue).Select(kvp => kvp.Member).OrderByDescending(x => x).ToList();

            foreach (var v in finalList)
            {
                Console.WriteLine(v);
                return v;
            }
            return "None";
        }
    }
}
