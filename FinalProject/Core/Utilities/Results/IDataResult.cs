﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult  //Generic olmasinin sebebi - hansi tipdir? // List<Product> , <Product>
    {
         T Data { get; } 
    }
}
