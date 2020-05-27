using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Functional_LINQ.ProductJoiner
{
    class ProductJoiner
    {
        internal IEnumerable<Product> JoinProducts(
            List<Product> firstList,
            List<Product> secondList)
        {
            return firstList.Concat(secondList)
                .GroupBy(
                p => p.Name,
                p => p.Quantity, (name, values) =>
                    new Product()
                    {
                        Name = name,
                        Quantity = values.Sum()
                    });
        }
    }
}
