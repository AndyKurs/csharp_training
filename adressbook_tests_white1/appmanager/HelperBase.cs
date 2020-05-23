
using System;
using System.Collections.Generic;
using System.Text;


namespace adressbook_tests_white1
{
    public class HelperBase
    {
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
        }
    }
}