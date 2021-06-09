using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asynch_Practice.ApiResponse;

namespace Asynch_Practice.ViewModels.Home
{
    public class IndexViewModel
    {
        public int RandomNumber { get; set; }

        public string ChuckNorrisFact { get; set; }

        public List<Seleucid> Seleucids { get; set; }

    }
}
