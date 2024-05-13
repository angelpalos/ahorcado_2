namespace ah;

public partial class SelectCharacter : ContentPage
{
	public SelectCharacter()
	{
		InitializeComponent();

        Data.Prueba.Read();
        double pto = Data.Prueba.max;
        Puntaje.Text =$"Puntos: {pto}";

        if (pto >= 10)
        {
            Nami.IsEnabled = true;
            Nami.Source = "nami_icon.png";
        }

        if (pto >= 15)
        {
            Zoro.IsEnabled = true;
            Zoro.Source = "zoro_icon.png";
        }

        if (pto >= 20)
        {
            Law.IsEnabled = true;
            Law.Source = "law_icon.png";
        }
    }

    private void SelectLuffy(object sender, EventArgs e)
    {
		Navigation.PushAsync(new MainPage());
    }

    private void SelectNami(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NamiPlay());
    }

    private void SelectZoro(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ZoroPlay());
    }

    private void SelectLaw(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LawPlay());
    }
}