using System;

namespace BinaryClock
{
	public enum ColumnName { TenHour, Hour, TenMinute, Minute, TenSecond, Second }

	public class ColumnType
	{
		public ColumnName ColumnName;

		public ColumnType (ColumnName columnName)
		{
			ColumnName = columnName;
		}

	}
}

