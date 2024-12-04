using System.Globalization;
using Foundation;

namespace decimal_parse;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnTextChange(object? sender, TextChangedEventArgs e)
    {
        if (decimal.TryParse(e.NewTextValue, out decimal result))
        {
            resultLabel.Text = $"Parsed value with default culture: {result}";
        }
        else
        {
            resultLabel.Text = "Invalid input";
        }
#if IOS
        var correctedCulture = CultureInfo.CurrentCulture.Clone() as CultureInfo;
        correctedCulture.NumberFormat.NumberDecimalSeparator = NSLocale
            .CurrentLocale
            .DecimalSeparator;
        correctedCulture.NumberFormat.NumberGroupSeparator = NSLocale
            .CurrentLocale
            .GroupingSeparator;

        if (decimal.TryParse(e.NewTextValue, correctedCulture, out decimal result2))
        {
            resultLabel2.Text = $"Parsed value with culture from IOS settings: {result2}";
        }
        else
        {
            resultLabel2.Text = "Invalid input";
        }
#endif
    }
}
