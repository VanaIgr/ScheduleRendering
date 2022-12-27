using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static ScheduleExt;

namespace ScheduleCreation {
	public class ScheduleContext {
		public List<int> timesUsage = new List<int>();
		public List<int> daysUsage = new List<int>();
		public List<int> lessonsUsage = new List<int>();
		
		public Schedule schedule;
	}
}
