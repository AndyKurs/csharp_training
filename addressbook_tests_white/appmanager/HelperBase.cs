﻿
using System;
using System.Collections.Generic;
using System.Text;


namespace addressbook_tests_white
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