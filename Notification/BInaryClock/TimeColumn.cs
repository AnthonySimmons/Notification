using System;

namespace BinaryClock
{
	public class TimeColumn
	{
		public ColumnType ColumnType;

		public int Size;

		public ClockCell [] Cells;

		public TimeColumn (ColumnName columnName)
		{
			ColumnType = new ColumnType (columnName);
			Size = GetColumnSizeByName (columnName);
			Cells = new ClockCell[Size];
			InitCells ();
		}

		public void InitCells()
		{
			for(int i = 0; i < Cells.Length; i++)
			{
				Cells[i] = new ClockCell (this, (int)Math.Pow(2.0, (double)i));
			}
		}

		public int GetColumnSizeByName(ColumnName columnName)
		{
			int size = 0;
			switch (columnName) 
			{
			case ColumnName.TenHour:
				size = 2;
				break;
			case ColumnName.Hour:
				size = 4;
				break;
			case ColumnName.TenMinute:
				size = 3;
				break;
			case ColumnName.Minute:
				size = 4;
				break;
			case ColumnName.TenSecond:
				size = 3;
				break;
			case ColumnName.Second:
				size = 4;
				break;
			}
			return size;
		}


		public void Update(int hours, int minutes, int seconds)
		{
			foreach (ClockCell cell in Cells) 
			{
				cell.Update (hours, minutes, seconds);
			}
		}
	}
}

