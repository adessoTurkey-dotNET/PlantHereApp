﻿using PlantHere.Domain.Common.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlantHere.Domain.Aggregate.CategoryAggregate
{
    public class Image
    {
        public int Id { get; set; }
        
        public string Url { get; set; }

        [JsonIgnore]
        public  Product Product { get; set; }
        
        public int ProductId { get; set; }
    }
}
