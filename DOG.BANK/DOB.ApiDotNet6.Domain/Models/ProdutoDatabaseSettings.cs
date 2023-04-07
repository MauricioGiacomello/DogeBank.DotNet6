using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOB.ApiDotNet6.Domain.Models
{
    public class ProdutoDatabaseSettings
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? ProdutoCollectionName { get; set; }
    }
}
