using System.ComponentModel;

namespace MauiListViewMultiSelect;

public static class MauiProgram
{
    // Critical pieces:
    // Item constructor with BackgroudnColor setting based on IsSelected (force PaleGreen is selected)
    // single selection uses ListView with padding
    // multiselect uses CollectionView with padding plus MUST use List<object> for SelectedItems binding
    // SelectionChangedEvents for both ListView and CollectionView set IsSelected on items behind binding


	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}

#region Item
public class Item : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged; // public
    public virtual void OnPropertyChanged(string propertyName) // public
    {
        if (null != PropertyChanged)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public Item()
    {
    }
    public Item(string item)
    {
        Value = item;
    }
    public Item(string item, bool selected)
    {
        Value = item;
        IsSelected = selected;
    }
    public Item(string item, bool selected, Color backgroundColor)
    {
        Value = item;
        IsSelected = selected;
        BackgroundColor = backgroundColor;
    }
    public override string ToString()
    {
        return _Value;
    }
    public Item(string key, string value)
    {
        Key = key;
        Value = value;
        //IsSelected = false; // default
    }
    public Item(string key, string value, bool selected)
    {
        Key = key;
        Value = value;
        IsSelected = selected;
    }

    private string _Key = null;
    public string Key
    {
        get { return _Key; }
        set
        {
            _Key = value;
            OnPropertyChanged(nameof(Key));
        }
    }

    private string _Value = null;
    public string Value
    {
        get { return _Value; }
        set
        {
            _Value = value;
            OnPropertyChanged(nameof(Value));
        }
    }

    private bool _IsSelected = false;
    public bool IsSelected
    {
        get { return _IsSelected; }
        set
        {
            _IsSelected = value;
            OnPropertyChanged(nameof(IsSelected));
            OnPropertyChanged(nameof(BackgroundColor));
        }
    }

    private Color _BackgroundColor = Colors.Transparent;
    public Color BackgroundColor
    {
        get 
        {
            if (_IsSelected) // overrides set color
            {
                return Colors.PaleGreen; 
            }
            return _BackgroundColor; 
        }
        set
        {
            _BackgroundColor = value;
            OnPropertyChanged(nameof(BackgroundColor));
        }
    }
}
#endregion
