using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Tools.CustomValidationAttribute
{
    public class BeforeTodayAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime? Date = value as DateTime?;
            if (Date == null)
            {
                return true;
            }

            return Date < DateTime.Now;
        }
    }
}
