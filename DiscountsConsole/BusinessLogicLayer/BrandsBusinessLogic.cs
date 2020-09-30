using DiscountsConsole.DataAccessLayer;
using DiscountsConsole.Data;
using System;
using System.Collections.Generic;
using DiscountsConsole.Models;
using System.Linq;

namespace DiscountsConsole.BusinessLogicLayer
{
    public class BrandsBusinessLogic
    {
        BrandsDAL DAL;
        public BrandsBusinessLogic(IDatabase db)
        {
            DAL = new BrandsDAL(db.Brands);
        }



        public void Run(Stack<string> args)
        {
            List<Brand> brands = DAL.Get();
            while (args.Count > 0)
            {
                var flag = args.Pop().ToUpper();
                switch (flag)
                {
                    case "-SORT":
                        brands = Sort(brands, args);
                        break;
                    case "-NAMESEARCH":
                        brands = Search(brands, args);
                        break;
                    default:
                        Console.WriteLine("No flags or args were passed, printing all products");
                        break;
                }
            }
            
            Console.WriteLine(brands.Print());
        }

        public List<Brand> Search(List<Brand> entities, Stack<string> args)
        {
            var arg = args.Pop().ToUpper();
            entities = entities.SearchByName(arg);
            return entities;
        }

        public List<Brand> Sort(List<Brand> entities, Stack<string> args)
        {
            throw new NotImplementedException();
        }
    }
}