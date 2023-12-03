using MauiPopup.Views;

namespace NailBar_App.Views;

public partial class CalificarClientePage : BasePopupPage
{
    public CalificarClientePage()
    {
        InitializeComponent();
    }

    private void OnCerrarClicked(object sender, EventArgs e)
    {
        MauiPopup.PopupAction.ClosePopup(new CalificarClientePage());
    }

    private async void evaluate(object sender, EventArgs e)
    {
        if (sender is Image image) 
        {
            deseleccionar();
            int ob = int.Parse(image.AutomationId);
            switch (ob)
            {
                case 1:
                    star1.Source = "star2.svg";
                    break;
                case 2:
                    star1.Source = "star2.svg";
                    star2.Source = "star2.svg";
                    break;
                case 3:
                    star1.Source = "star2.svg";
                    star2.Source = "star2.svg";
                    star3.Source = "star2.svg";
                    break;
                case 4:
                    star1.Source = "star2.svg";
                    star2.Source = "star2.svg";
                    star3.Source = "star2.svg";
                    star4.Source = "star2.svg";
                    break;
                case 5:
                    star1.Source = "star2.svg";
                    star2.Source = "star2.svg";
                    star3.Source = "star2.svg";
                    star4.Source = "star2.svg";
                    star5.Source = "star2.svg";
                    break;
            }

        }
    }

    private void deseleccionar()
    {
        star1.Source = "star1.svg";
        star2.Source = "star1.svg";
        star3.Source = "star1.svg";
        star4.Source = "star1.svg";
        star5.Source = "star1.svg";
    }

    private async void evaluatea(int x)
    {
        await DisplayAlert("Prueba","PRUEBA","ok");
    }
}