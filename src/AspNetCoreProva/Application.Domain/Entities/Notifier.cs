using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities
{
    public class Notifier
    {
        public string ErrorMessage { get; private set; }

        public Notifier(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
