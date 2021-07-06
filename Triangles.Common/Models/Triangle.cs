using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triangles.Common.Enums;

namespace Triangles.Common.Models
{
	public class Triangle
	{
		public long SideA { get; set; }

		public long SideB { get; set; }

		public long SideC { get; set; }

		public ClassificationSide ClassificationSide { get; set; }

		public ClassificationAngle ClassificationAngle { get; set; }


	}
}
