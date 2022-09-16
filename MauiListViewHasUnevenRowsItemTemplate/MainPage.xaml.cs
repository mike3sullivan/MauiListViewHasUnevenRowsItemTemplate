using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiListViewMultiSelect;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
	public MainPage()
	{
		InitializeComponent();
        BindingContext = this;
    }

    public ObservableCollection<string> ListStrings { get; set; }
        = new ObservableCollection<string>
        {
                "AAA","BBB","CCC"
        };
    
    private void Reset_Clicked(object sender, EventArgs e)
    {
        try
        {
            ListStrings.Clear();
            ListStrings.Add("aaa");
            ListStrings.Add("bbb");
            ListStrings.Add("ccc");

        }
        catch (Exception ex)
        {
            string m = ex.Message;
            //	ex	{System.NullReferenceException: Object reference not set to an instance of an object.
            //	at Microsoft.Maui.Controls.Handlers.Compatibility.ListViewRenderer.UnevenListViewDataSource.ClearPrototype()
            //	at Microsoft.Maui.Controls.Handlers.Compatibility.ListViewRe…}	
        }
    }
}

