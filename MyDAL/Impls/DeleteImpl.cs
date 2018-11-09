﻿using MyDAL.Core.Bases;
using MyDAL.Core.Enums;
using MyDAL.Interfaces;
using System.Threading.Tasks;

namespace MyDAL.Impls
{
    internal class DeleteImpl<M>
        : Impler, IDelete
        where M:class
    {
        internal DeleteImpl(Context dc) 
            : base(dc)
        {
        }

        public async Task<int> DeleteAsync()
        {
            DC.Method = UiMethodEnum.DeleteAsync;
            DC.SqlProvider.GetSQL();
            return await DC.DS.ExecuteNonQueryAsync();
        }
    }
}
