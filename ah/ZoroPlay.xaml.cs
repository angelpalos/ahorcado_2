namespace ah;

public partial class ZoroPlay : ContentPage
{
    int n1, n2, res, result, fallo = 0, pto = 0, cont, max;
    bool cnt = true;
    public ZoroPlay()
	{
		InitializeComponent();
        Max.Text = $"Record: {Data.Prueba.max}";
    }

    private async void Check_Clicked(object sender, EventArgs e)
    {
        n1 = Convert.ToInt32(N1.Text);
        n2 = Convert.ToInt32(N2.Text);
        result = Convert.ToInt32(Result.Text);
        res = n1 * n2;

        if (res == result)
        {
            cnt = false;
            await DisplayAlert("Felicidades",
                $"!{result} era la respuesta correcta¡", null, "Ok");
            pto++;
            Pto.Text = $"Puntos: {pto}";


        }
        else
        {
            cnt = false;
            await DisplayAlert("Incorrecto",
                $"!Mal¡ La respuesta correcta era {res}", "Ok");
            fallo++;

            FailCheck();
        }

        setNumber();
        Temporizador();
        Result.Text = string.Empty;
    }

    private void Start_Clicked(object sender, EventArgs e)
    {
        Check.IsEnabled = true;
        Result.IsEnabled = true;

        Start.IsEnabled = false;
        Lvl.IsEnabled = false;
        Personaje.IsEnabled = false;

        setNumber();
        Temporizador();
    }

    public void setNumber()
    {
        var rdm = new Random();

        n1 = rdm.Next(1, 10);
        n2 = rdm.Next(1, 10);

        N1.Text = $" {n1} ";
        N2.Text = $" {n2} ";
    }

    public async void Temporizador()
    {
        if (LabelDificulty.Text == "Dificultad: 1")
        {
            cont = 0;
        }
        else if (LabelDificulty.Text == "Dificultad: 2")
        {
            cont = 60;
            while (cnt)
            {
                if (cont <= 0)
                {
                    cnt = false;
                    await DisplayAlert("Te quedaste sin Tiempo",
                        "Se mas rapido para responder a tiempo", "Ok");
                    fallo++;
                    setNumber();
                    FailCheck();
                    Temporizador();
                }
                Tiempo.Text = $"{cont}";
                cont = cont - 1;
                await Task.Delay(1000);
            }
            cnt = true;
        }
        else if (LabelDificulty.Text == "Dificultad: 3")
        {
            cont = 30;
            while (cnt)
            {
                if (cont <= 0)
                {
                    cnt = false;
                    await DisplayAlert("Te quedaste sin Tiempo",
                        "Se mas rapido para responder a tiempo", "Ok");
                    fallo++;
                    setNumber();
                    FailCheck();
                    Temporizador();
                }
                Tiempo.Text = $"{cont}";
                cont = cont - 1;
                await Task.Delay(1000);
            }
            cnt = true;
        }
    }

    public async void FailCheck()
    {
        if (fallo == 1)
        {
            Ahorcado.Source = "zoro_1.png";
        }
        else if (fallo == 2)
        {
            Ahorcado.Source = "zoro_2.png";
        }
        else if (fallo == 3)
        {
            Ahorcado.Source = "zoro_3.png";
        }
        else if (fallo == 4)
        {
            Ahorcado.Source = "zoro_4.png";
        }
        else if (fallo == 5)
        {
            Ahorcado.Source = "zoro_5.png";
        }
        else if (fallo == 6)
        {
            Ahorcado.Source = "zoro_6.png";

        }
        else if (fallo == 7)
        {
            await DisplayAlert("HAS PERDIDO",
                $"Te quedaste sin intentos.\nIntenta de nuevo.\nTu puntaje fue de {pto} puntos ", "Ok");
            Ahorcado.Source = "zero.png";
            Check.IsEnabled = false;
            Result.IsEnabled = false;

            Start.IsEnabled = true;
            Lvl.IsEnabled = true;
            Personaje.IsEnabled = true;

            N1.Text = "00";
            N2.Text = "00";
            cnt = false;

            if (pto > Data.Prueba.max)
            {
                max = pto;
                Max.Text = $"Record: {max}";
                Data.Prueba.Write(max);
            }

            pto = 0;
            Pto.Text = "Puntos: 0";


        }
    }

    private async void Lvl_Clicked(object sender, EventArgs e)
    {
        var dificultad = await DisplayActionSheet("Selecciona la Dificultad", "Cancel", null,
            "Nivel 1 (Sin Contador)",
            "Nivel 2 (60 segundos)",
            "Nivel 3 (30 segundos)");

        if (dificultad == "Nivel 1 (Sin Contador)")
        {
            LabelDificulty.Text = "Dificultad: 1";

        }
        else if (dificultad == "Nivel 2 (60 segundos)")
        {
            LabelDificulty.Text = "Dificultad: 2";

        }
        else if (dificultad == "Nivel 3 (30 segundos)")
        {
            LabelDificulty.Text = "Dificultad: 3";

        }
    }

    private async void Personaje_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SelectCharacter());
    }
}