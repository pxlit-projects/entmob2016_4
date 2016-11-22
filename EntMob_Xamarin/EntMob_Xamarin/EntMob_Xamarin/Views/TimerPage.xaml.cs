using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EntMob_Xamarin
{
	public partial class TimerPage : ContentPage
	{
		public TimerPage()
		{
			InitializeComponent();
			BindingContext = ViewModelLocator.Timer();
		}
	}
}
