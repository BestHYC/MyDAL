﻿using MyDAL.Core.Enums;
using MyDAL.UserFacade.Join;
using System;
using System.Linq.Expressions;

namespace MyDAL
{
    public static class OnExtension
    {

        public static OnX On(this JoinX join, Expression<Func<bool>> func)
        {
            join.DC.Action = ActionEnum.On;
            var field = join.DC.EH.ExpressionHandle(func);
            join.DC.AddConditions(field);
            return new OnX(join.DC);
        }

    }
}
