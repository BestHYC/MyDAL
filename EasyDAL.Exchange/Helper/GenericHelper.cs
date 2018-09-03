﻿using EasyDAL.Exchange.Common;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EasyDAL.Exchange.Helper
{
    internal class GenericHelper : ClassInstance<GenericHelper>
    {

        public RM GetPropertyValue<M, RM>(M m, string properyName)
        {
            try
            {
                if (m is ExpandoObject)
                {
                    var dic = m as IDictionary<string, object>;
                    return (RM)dic[properyName];
                }

                return (RM)m.GetType().GetProperty(properyName).GetValue(m, null);
            }
            catch (Exception ex)
            {
                throw new Exception("方法GetPropertyValue<M, RM>出错:" + ex.Message);
            }
        }

        public string GetPropertyValue<M>(M m, string properyName)
        {
            try
            {
                if (m is ExpandoObject)
                {
                    var dic = m as IDictionary<string, object>;
                    return ConvertType(dic[properyName]);
                }

                return m.GetType().GetProperty(properyName).GetValue(m, null).ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("方法GetPropertyValue<M>出错:" + "请向方法 [GenericHelper.ConvertType] 中添加类型解析 " + ex.Message);
            }
        }


        public string GetTypeValue(Type valType, PropertyInfo outerProp, object outerObj)
        {
            var val = string.Empty;

            if (valType == typeof(sbyte))
            {
                val = ((sbyte)outerProp.GetValue(outerObj, null)).ToString();
            }
            else if (valType == typeof(byte))
            {
                val = ((byte)outerProp.GetValue(outerObj, null)).ToString();
            }
            else if (valType == typeof(char))
            {
                val = ((char)outerProp.GetValue(outerObj, null)).ToString();
            }
            else if (valType == typeof(bool))
            {
                val = ((bool)outerProp.GetValue(outerObj, null)).ToString();
            }
            else if (valType == typeof(short)
                || valType == typeof(int)
                || valType == typeof(long))
            {
                val = outerProp.GetValue(outerObj, null).ToString();
            }
            else if (valType == typeof(ushort)
                || valType == typeof(uint)
                || valType == typeof(ulong))
            {
                val = outerProp.GetValue(outerObj, null).ToString();
            }
            else if (valType == typeof(float)
                || valType == typeof(decimal)
                || valType == typeof(double))
            {
                val = outerProp.GetValue(outerObj, null).ToString();
            }
            else if (valType == typeof(DateTime)
                || valType == typeof(Guid)
                || valType == typeof(string))
            {
                val = outerProp.GetValue(outerObj, null).ToString();
            }
            else if (valType == typeof(sbyte?)
                || valType == typeof(byte?)
                || valType == typeof(char?)
                || valType == typeof(bool?)
                || valType == typeof(short?)
                || valType == typeof(int?)
                || valType == typeof(long?)
                || valType == typeof(ushort?)
                || valType == typeof(uint?)
                || valType == typeof(ulong?)
                || valType == typeof(float?)
                || valType == typeof(decimal?)
                || valType == typeof(double?)
                || valType == typeof(DateTime?)
                || valType == typeof(Guid?))
            {
                var obj = outerProp.GetValue(outerObj, null);
                if (obj == null)
                {
                    val = null;
                }
                else
                {
                    val = obj.ToString();
                }
            }
            else if (valType.IsEnum)
            {
                val = ((int)outerProp.GetValue(outerObj, null)).ToString();
            }
            else
            {
                val = outerProp.GetValue(outerObj, null).ToString();
            }
            return val;
        }
        public string GetTypeValue(Type valType, object objVal)
        {
            var val = string.Empty;

            if (valType == typeof(sbyte))
            {
                val = objVal.ToString();
            }
            else if (valType == typeof(short))
            {
                val = objVal.ToString();
            }
            else if (valType == typeof(int))
            {
                val = objVal.ToString();
            }
            else if (valType == typeof(long))
            {
                val = objVal.ToString();
            }
            else if (valType == typeof(byte))
            {
                val = objVal.ToString();
            }
            else if (valType == typeof(ushort))
            {
                val = objVal.ToString();
            }
            else if (valType == typeof(uint))
            {
                val = objVal.ToString();
            }
            else if (valType == typeof(ulong))
            {
                val = objVal.ToString();
            }
            else if (valType == typeof(float))
            {
                val = objVal.ToString();
            }
            else if (valType == typeof(double))
            {
                val = objVal.ToString();
            }
            else if (valType == typeof(decimal))
            {
                val = objVal.ToString();
            }
            else if (valType == typeof(bool))
            {
                val = objVal.ToString();
            }
            else if (valType == typeof(char))
            {
                val = objVal.ToString();
            }
            else if (valType == typeof(DateTime))
            {
                val = objVal.ToString();
            }
            else if (valType == typeof(Guid))
            {
                val = objVal.ToString();
            }
            else if (valType == typeof(string))
            {
                val = objVal.ToString();
            }
            else if (valType.IsEnum)
            {
                val = ((int)objVal).ToString();
            }
            else
            {
                val = objVal.ToString();
            }
            return val;
        }
        public void SetPropertyValue<M>(M m, string propertyName, object value)
        {
            try
            {
                if (value != null)
                {
                    m.GetType().GetProperty(propertyName).SetValue(m, value, null);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("方法SetPropertyValue<M>出错:" + ex.Message);
            }
        }

        public List<PropertyInfo> GetPropertyInfos<M>(M m)
        {
            if (m == null)
            {
                return new List<PropertyInfo>();
            }
            var props = m.GetType().GetProperties(BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public).ToList();
            return props;
        }
        public List<PropertyInfo> GetPropertyInfos(Type mType)
        {
            var props = mType.GetProperties(BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public).ToList();
            return props;
        }

        private string ConvertType(object value)
        {
            if (value.GetType() == typeof(DateTime))
            {
                return Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm:ss");
            }

            if (value.GetType() == typeof(Guid))
            {
                return value.ToString();
            }

            return value.ToString();
        }
    }
}
