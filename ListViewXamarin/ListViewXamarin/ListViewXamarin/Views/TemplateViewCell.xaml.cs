﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListViewXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TemplateViewCell : ViewCell
	{
		public TemplateViewCell()
		{
			InitializeComponent ();
		}
	}
}