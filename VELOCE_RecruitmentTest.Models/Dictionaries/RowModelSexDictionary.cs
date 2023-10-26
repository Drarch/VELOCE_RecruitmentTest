using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VELOCE_RecruitmentTest.Models.Enums;

namespace VELOCE_RecruitmentTest.Models
{
    public static class RowModelSexDictionary
    {
        public static Dictionary<ESex, String> Map = new Dictionary<ESex, String>()
        {
            { ESex.Female, "Pani" },
            { ESex.Male, "Pan" },
            { ESex.Unknown, String.Empty },
        };
    }
}
