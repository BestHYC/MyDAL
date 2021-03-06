﻿using MyDAL.Core.Bases;
using MyDAL.Core.Enums;
using MyDAL.Core.Extensions;
using MyDAL.Interfaces;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyDAL.Impls
{
    internal class FirstOrDefaultImpl<M>
        : Impler, IFirstOrDefault<M>
        where M : class
    {
        internal FirstOrDefaultImpl(Context dc)
            : base(dc)
        {
        }

        public async Task<M> FirstOrDefaultAsync()
        {
            PreExecuteHandle(UiMethodEnum.FirstOrDefaultAsync);
            return await DC.DS.ExecuteReaderSingleRowAsync<M>();
        }

        public async Task<VM> FirstOrDefaultAsync<VM>()
            where VM : class
        {
            SelectMHandle<M, VM>();
            PreExecuteHandle(UiMethodEnum.FirstOrDefaultAsync);
            return await DC.DS.ExecuteReaderSingleRowAsync<VM>();
        }

        public async Task<T> FirstOrDefaultAsync<T>(Expression<Func<M, T>> func)
        {
            if (typeof(T).IsSingleColumn())
            {
                return default(T);
            }
            else
            {
                SelectMHandle(func);
                PreExecuteHandle(UiMethodEnum.FirstOrDefaultAsync);
                return await DC.DS.ExecuteReaderSingleRowAsync<T>();
            }
        }
    }

    internal class FirstOrDefaultXImpl
        : Impler, IFirstOrDefaultX
    {
        internal FirstOrDefaultXImpl(Context dc)
            : base(dc)
        {
        }

        public async Task<M> FirstOrDefaultAsync<M>()
            where M : class
        {
            SelectMHandle<M>();
            PreExecuteHandle(UiMethodEnum.FirstOrDefaultAsync);
            return await DC.DS.ExecuteReaderSingleRowAsync<M>();
        }

        public async Task<VM> FirstOrDefaultAsync<VM>(Expression<Func<VM>> func)
            where VM : class
        {
            SelectMHandle(func);
            PreExecuteHandle(UiMethodEnum.FirstOrDefaultAsync);
            return await DC.DS.ExecuteReaderSingleRowAsync<VM>();
        }
    }
}
