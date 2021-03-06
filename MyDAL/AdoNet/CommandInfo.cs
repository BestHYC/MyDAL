﻿using System.Data;

namespace MyDAL.AdoNet
{
    internal struct CommandInfo
    {
        internal string CommandText { get; }
        internal DbParamInfo Parameter { get; }
        internal CommandType CommandType { get; }
        
        internal CommandInfo(string sql, DbParamInfo paras)
        {
            CommandText = sql;
            Parameter = paras;
            CommandType = CommandType.Text;
        }
    }
}
