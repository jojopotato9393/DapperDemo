﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo
{
   public interface IProductRepo
    {
        IEnumerable<Product> GetAllProducts();
    }
}
