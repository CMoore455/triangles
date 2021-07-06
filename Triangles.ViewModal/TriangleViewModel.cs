using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triangles.Common.Enums;
using Triangles.Common.Models;

namespace Triangles.ViewModel
{
	public class TriangleViewModel : ViewModelBase
	{
		private readonly Triangle triangle;

		public TriangleViewModel(Triangle triangle)
		{
			this.triangle = triangle;
		}

		public long SideA
		{
			get { return triangle.SideA; }
			set
			{
				if (triangle.SideA != value)
				{
					triangle.SideA = value;
					RaisePropertyChanged();
					RaisePropertyChanged(nameof(CanCalculate));
					if (CanCalculate)
					{
						ClassifyTriangleBySide();
						ClassifyTriangleByAngle();
						SetClassification();
						SetAngles();
					}
				}
			}
		}

		public long SideB
		{
			get { return triangle.SideB; }
			set
			{
				if (triangle.SideB != value)
				{
					triangle.SideB = value;
					RaisePropertyChanged();
					RaisePropertyChanged(nameof(CanCalculate));
					if (CanCalculate)
					{
						ClassifyTriangleBySide();
						ClassifyTriangleByAngle();
						SetClassification();
						SetAngles();
					}
				}
			}
		}

		public long SideC
		{
			get { return triangle.SideC; }
			set
			{
				if (triangle.SideC != value)
				{
					triangle.SideC = value;
					RaisePropertyChanged();
					RaisePropertyChanged(nameof(CanCalculate));
					if (CanCalculate)
					{
						ClassifyTriangleBySide();
						ClassifyTriangleByAngle();
						SetClassification();
						SetAngles();
					}
				}
			}
		}

		public ClassificationSide ClassificationSide
		{
			get { return triangle.ClassificationSide; }
			set
			{
				if (triangle.ClassificationSide != value)
				{
					triangle.ClassificationSide = value;
				}
			}
		}

		public ClassificationAngle ClassificationAngle
		{
			get { return triangle.ClassificationAngle; }
			set
			{
				if (triangle.ClassificationAngle != value)
				{
					triangle.ClassificationAngle = value;
				}
			}
		}

		private double AngleA { get; set; }

		private double AngleB { get; set; }

		private double AngleC { get; set; }

		private string classification;

		public string Classification
		{
			get { return classification; }
			set
			{
				classification = value;
				RaisePropertyChanged();
			}
		}

		private string angleOutput;

		public string AngleOutput
		{
			get { return angleOutput; }
			set 
			{ 
				angleOutput = value;
				RaisePropertyChanged();
			}
		}


		public bool CanCalculate => SideA > 0 && SideB > 0 && SideC > 0 && IsValidTriangle();

		private bool IsValidTriangle()
		{
			return (SideA + SideB > SideC) && (SideB + SideC > SideA) && (SideA + SideC > SideB);
		}

		private void ClassifyTriangleBySide()
		{
			if (SideA == SideB && SideB == SideC)
			{
				ClassificationSide = ClassificationSide.Equilateral;
			}
			else if ((SideA == SideB) || (SideB == SideC) || (SideA == SideC))
			{
				ClassificationSide = ClassificationSide.Isosceles;
			}
			else
			{
				ClassificationSide = ClassificationSide.Scalene;
			}
		}

		private void ClassifyTriangleByAngle()
		{
			List<long> sides = new List<long>() { SideA, SideB, SideC };
			sides.Sort();
			long a = sides[0];
			long b = sides[1];
			long c = sides[2];
			long result = (long) (Math.Pow(a, 2) + Math.Pow(b, 2));
			long cSqr = (long) Math.Pow(c, 2);
			if (cSqr == result)
			{
				ClassificationAngle = ClassificationAngle.Right;
			}
			else if (cSqr < result)
			{
				ClassificationAngle = ClassificationAngle.Acute;
			}
			else
			{
				ClassificationAngle = ClassificationAngle.Obtuse;
			}

		}

		private double CalculateAngle(long side1, long side2, long side3)
		{
			double angle;

			long a = (long) Math.Pow(side1, 2);
			long b = (long)Math.Pow(side2, 2);
			long c = (long)Math.Pow(side3, 2);

			long d = b + c;
			double e = -2 * side2 * side3;
			double f = a - d;
			double g = Math.Acos(f / e);
			angle = g * 180 / Math.PI;

			angle = Math.Round(angle, 2);
			return angle;
		}

		private void SetClassification()
		{
			Classification = $"These side lengths produce a valid {ClassificationAngle} {ClassificationSide} triangle";
		}

		private void SetAngles()
		{
			AngleA = CalculateAngle(SideA, SideB, SideC);
			AngleB = CalculateAngle(SideB, SideA, SideC);
			AngleC = CalculateAngle(SideC, SideA, SideB);
			AngleOutput = $"Angle Measurements {{ A: {AngleA}\u00B0 B: {AngleB}\u00B0 C: {AngleC}\u00B0 }}";
		}
	}
}
