﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviApi.Application.Features.MediatorDesignPattern.Results.CastResults
{
    public class GetCastQueryResult
    {
        public int CastId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public string? Overview { get; set; }     // Boş Bırakılabilir  ? işareti anlamı
        public string? Biography { get; set; }
    }
}
