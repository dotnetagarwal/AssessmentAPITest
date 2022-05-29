using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESOC.CLTPull.Assessment.Core.Extensions
{
	public static class SqlDataReaderExtensions
	{
        public static T Value<T>(this SqlDataReader reader, string name, T defaultValue = default)
        {
            var val = reader[name];

            if (val == DBNull.Value)
                return defaultValue;

            return (T)val;
        }
    }
}
