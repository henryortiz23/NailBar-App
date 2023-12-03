namespace NailBar_App.Views;

public partial class AgendarCitaAdminPage : ContentPage
{
	public AgendarCitaAdminPage()
	{
		InitializeComponent();
	}


    private void SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedIndex = picServicios.SelectedIndex;
        if (selectedIndex != -1)
        {
            //ComboBoxEntry.Text = OptionsPicker.Items[selectedIndex];
            // Ocultar el Picker u otras acciones según sea necesario
        }
    }
}