using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchSharp.Utilities
{
	public static class Sorting
	{
		public static IEnumerable<int> QuickSort(IEnumerable<int> i)
		{
			if (!i.Any())
				return i;
			var p = new Random().Next(i.First(), i.Last());
			return QuickSort(i.Where(x => x < p)).Concat(i.Where(x => x == p).Concat(QuickSort(i.Where(x => x > p))));
		}
	}
}
