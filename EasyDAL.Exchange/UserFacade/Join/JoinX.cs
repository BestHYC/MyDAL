﻿using EasyDAL.Exchange.Common;
using EasyDAL.Exchange.Core;
using EasyDAL.Exchange.Enums;
using System;
using System.Linq.Expressions;

namespace EasyDAL.Exchange.UserFacade.Join
{
    public class JoinX : Operator, IMethodObject
    {
        internal JoinX(DbContext dc)
            : base(dc)
        { }

        public FromX From<M>(Expression<Func<M>> func)
        {
            var dic = DC.EH.ExpressionHandle(func)[0];
            dic.Action = ActionEnum.From;
            dic.Crud = CrudTypeEnum.Join;
            DC.AddConditions(dic);
            return new FromX(DC);
        }
    }
}
