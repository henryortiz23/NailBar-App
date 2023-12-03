using MauiPopup.Views;

namespace NailBar_App.Views;

public partial class ConfirmacionCorreoPage : BasePopupPage
{
    public ConfirmacionCorreoPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        imageAnimacion.Dispatcher.DispatchAsync(async () =>
        {
            while (true)
            {
                await imageAnimacion.RotateTo(360, 500);
                imageAnimacion.Rotation = 0;
            }
        }
        );
    }
    private void OnCerrarClicked(object sender, EventArgs e)
    {
        MauiPopup.PopupAction.ClosePopup(new PerfilPage());
    }
}