﻿using EasyDAL.Exchange.Core.Sql;
using EasyDAL.Exchange.Enums;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EasyDAL.Exchange.Core.Delete
{
    public class Deleter<M>: Operator
    {
        public Deleter(DbContext dc)
        {
            DC = dc;
        }

        public DeleteFilter<M> Where(Expression<Func<M, bool>> func)
        {
            WhereHandle(func);
            return new DeleteFilter<M>(DC);
        }


    }
}
