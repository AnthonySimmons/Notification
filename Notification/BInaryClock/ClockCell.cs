using System;

namespace Notification
{
	public class ClockCell
	{
		public bool IsOn;

		public int Value; 

		public TimeColumn TimeColumn;

		public int Height;

		public ClockCell (TimeColumn timeColumn, int height, bool isOn = false)
		{
			IsOn = isOn;
			TimeColumn = timeColumn;
			Height = height;
		}

		public void Update(int hours, int minutes, int seconds)
		{
			// #: #: # 8
			// #:##:## 4
			//##:##:## 2
			//##:##:## 1
			//--------
			//HH:MM:SS

			IsOn = false;
  			if (TimeColumn.ColumnType.ColumnName == ColumnName.TenHour) 
			{
				IsOn = ((hours / 10) & Height) != 0;
			}
			else if (TimeColumn.ColumnType.ColumnName == ColumnName.Hour) 
			{
				IsOn = ((hours % 10) & Height) != 0;
			}
			else if (TimeColumn.ColumnType.ColumnName == ColumnName.TenMinute) 
			{
				IsOn = ((minutes / 10) & Height) != 0;
			}
			else if (TimeColumn.ColumnType.ColumnName == ColumnName.Minute) 
			{
				IsOn = ((minutes % 10) & Height) != 0;
			}
			else if (TimeColumn.ColumnType.ColumnName == ColumnName.TenSecond) 
			{
				IsOn = ((seconds / 10) & Height) != 0;
			}
			else if (TimeColumn.ColumnType.ColumnName == ColumnName.Second) 
			{
				IsOn = ((seconds % 10) & Height) != 0;
			}
		}
	}
}

