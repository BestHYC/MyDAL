﻿using MyDAL.Core;

namespace MyDAL.UserFacade.Update
{
    public sealed class Updater<M> 
        : Operator
    {
        internal Updater(Context dc)
            : base(dc)
        { }
    }
}
