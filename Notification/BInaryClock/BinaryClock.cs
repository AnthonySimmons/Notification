using System;

namespace BinaryClock
{
	public class BinaryClock
	{
		public string TimeString;

		public int Hours;

		public int Minutes;

		public int Seconds;

		public TimeColumn[] TimeColumns = new TimeColumn[6];

		public BinaryClock ()
		{
			InitTimeColumns ();
		}


		public void InitTimeColumns()
		{
			TimeColumns = new TimeColumn[6];
			TimeColumns [0] = new TimeColumn (ColumnName.TenHour);
			TimeColumns [1] = new TimeColumn (ColumnName.Hour);
			TimeColumns [2] = new TimeColumn (ColumnName.TenMinute);
			TimeColumns [3] = new TimeColumn (ColumnName.Minute);
			TimeColumns [4] = new TimeColumn (ColumnName.TenSecond);
			TimeColumns [5] = new TimeColumn (ColumnName.Second);
		}


		public void UpdateTime()
		{
			ConvertTime ();

			foreach (TimeColumn column in TimeColumns) 
			{
				column.Update (Hours, Minutes, Seconds);
			}
		}

		public void ConvertTime()
		{
			Hours = DateTime.Now.Hour;

			Minutes = DateTime.Now.Minute;

			Seconds = DateTime.Now.Second;

			TimeString = String.Format ("{0}:{1}:{2}", Hours.ToString("##"), Minutes.ToString("##"), Seconds.ToString("##"));

		}
	}
}

