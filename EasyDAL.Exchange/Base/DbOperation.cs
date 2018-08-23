﻿using EasyDAL.Exchange.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EasyDAL.Exchange.Base
{
    public abstract partial class DbOperation
    {

        private DbOperation() { }
        public DbOperation(IDbConnection conn)
        {
            Conn = conn;
            AH = AttributeHelper.Instance;
            GH = GenericHelper.Instance;
            EH = ExpressionHelper.Instance;
            Conditions = new List<string>();
        }

    }
}
