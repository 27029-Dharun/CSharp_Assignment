using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment4.Services;
using Assignment4.View;

namespace Assignment4.Controllers
{
    internal class TransactionController
    {
        private TransactionService _service;
        private ConsoleView _\view;

        public TransactionController(TransactionService service, ConsoleView view)
        {
            this._service = service;
            this._\view = view;
        }

        internal void RunExpenseTracker()
        {
            throw new NotImplementedException();
        }
    }
}
