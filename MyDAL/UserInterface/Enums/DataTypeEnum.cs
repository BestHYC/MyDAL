﻿namespace MyDAL
{
    public enum DataTypeEnum
    {
        None,

        /**************************************************************************************************/

        /*
         * 整数类型
         */

        /// <summary>
        /// 1byte
        /// </summary>
        TinyInt,

        /// <summary>
        /// 2byte
        /// </summary>
        SmallInt,

        /// <summary>
        /// 3byte
        /// </summary>
        MediumInt,

        /// <summary>
        /// 4byte
        /// </summary>
        Int,

        /// <summary>
        /// 8byte
        /// </summary>
        BigInt,

        /**************************************************************************************************/

        /*
         * 浮点数类型和定点数类型
         */

        /// <summary>
        /// 4byte -- [0,7]位小数
        /// </summary>
        Float,

        /// <summary>
        /// 8byte
        /// </summary>
        Double,

        /// <summary>
        /// 
        /// </summary>
        Decimal,

        /**************************************************************************************************/

        /*
         * 日期与时间类型
         */

        /// <summary>
        /// 1byte -- yyyy -- [1901,2155]
        /// </summary>
        Year,

        /// <summary>
        /// 3byte -- HH:mm:ss
        /// </summary>
        Time,

        /// <summary>
        /// 3byte -- yyyy-MM-dd -- [1000-01-01,9999-12-31]
        /// </summary>
        Date,

        /// <summary>
        /// 8byte -- yyyy-MM-dd HH:mm:ss -- [1000-01-01 00:00:00,9999-12-31 23:59:59]
        /// </summary>
        DateTime,

        /// <summary>
        /// 8byte -- yyyy-MM-dd HH:mm:ss -- [1070,2037]
        /// </summary>
        TimeStamp,

        /**************************************************************************************************/

        /*
         * 文本字符串类型
         */

        /// <summary>
        /// [0,255]byte
        /// </summary>
        Char,

        /// <summary>
        /// [0,65535]byte
        /// </summary>
        VarChar,

        /// <summary>
        /// [0,255]byte
        /// </summary>
        TinyText,

        /// <summary>
        /// [0,65535]byte
        /// </summary>
        Text,

        /// <summary>
        /// [0,16777215]byte
        /// </summary>
        MediumText,

        /// <summary>
        /// [0,4294967295]byte
        /// </summary>
        LongText,

        /// <summary>
        /// [1,2]byte -- [0,65535]值
        /// </summary>
        Enum,

        /// <summary>
        /// [1,8]byte -- [0,64]成员
        /// </summary>
        Set,

        /**************************************************************************************************/

        /*
         * 二进制字符串类型
         */

        /// <summary>
        /// [1,64]bit
        /// </summary>
        Bit,

        /// <summary>
        /// 
        /// </summary>
        Binary,

        /// <summary>
        /// 
        /// </summary>
        VarBinary,
        
        /// <summary>
        /// [0,255]byte
        /// </summary>
        TinyBlob,

        /// <summary>
        /// [0,65535]byte
        /// </summary>
        Blob,

        /// <summary>
        /// [0,16777215]byte
        /// </summary>
        MediumBlob,

        /// <summary>
        /// [0,4294967295]byte
        /// </summary>
        LongBlob

    }
}
