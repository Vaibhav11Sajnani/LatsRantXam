using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LatsRantXam.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : TabbedPage
	{
		public MainPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this,false);
		}
	}
}