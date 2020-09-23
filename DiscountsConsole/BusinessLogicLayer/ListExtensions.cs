using DiscountsConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscountsConsole.BusinessLogicLayer
{
    public static class ListExtensions
    {
        public delegate List<T> PerformCalc<T>(List<T> ts);
        public static List<T> SortByName<T>(this List<T> ts) where T : IName
        {
            ts.Sort(CompareByName);
            return ts;
        }

        public static List<T> SortByPrice<T>(this List<T> ts) where T : IPrice
        {
            ts.Sort(CompareByPrice);
            return ts;
        }

        public static List<T> SearchByName<T>(this List<T> ts, string search) where T : IName
        {
            return ts.Where(s => s.Name.Contains(search)).ToList();
        }

        public static List<T> PriceRange<T>(this List<T> ts, double minPrice, double maxPrice) where T : IPrice
        {
            return ts.Where(s => s.Price > minPrice && s.Price < maxPrice).ToList();
        }

        public static List<T> PriceLessThan<T>(this List<T> ts, double maxPrice) where T : IPrice
        {
            return ts.Where(s => s.Price < maxPrice).ToList();
        }

        public static List<T> PriceGreaterThan<T>(this List<T> ts, double minPrice) where T : IPrice
        {
            return ts.Where(s => s.Price > minPrice).ToList();
        }

        private static int CompareByName<T>(T x, T y) where T : IName
        {
            return x.Name.CompareTo(y.Name);
        }

        private static int CompareByPrice<T>(T x, T y) where T : IPrice
        {
            return x.Price.CompareTo(y.Price);
        }

        public static string Print<T>(this List<T> ts) where T : IDisplayable
        {
            List<string> vs = new List<string>();
            foreach (var item in ts)
            {
                vs.Add(item.Display());
            }
            return string.Join('\n', vs);
        }
    }
}
