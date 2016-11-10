using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EntMob_Xamarin
{
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage()
		{
			InitializeComponent();
			BindingContext = ViewModelLocator.Register(this.Navigation);
		}
	}
}
