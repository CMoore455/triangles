using System;
using Triangles.Common.Models;

namespace Triangles.ViewModel
{
	public class MainViewModel : ViewModelBase
	{
		public MainViewModel()
		{
			Triangle = new TriangleViewModel(new Triangle());
		}

		public TriangleViewModel Triangle { get; set; }

	}
}
