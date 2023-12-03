using MauiPopup.Views;

namespace NailBar_App.Views;

public partial class PerfilPage : BasePopupPage
{
    public PerfilPage()
    {
        InitializeComponent();
    }

    private void OnCerrarClicked(object sender, EventArgs e)
    {
        MauiPopup.PopupAction.ClosePopup(new PerfilPage());
    }
}