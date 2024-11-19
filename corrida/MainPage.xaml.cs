namespace corrida;
using FFImageLoading.Maui;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		player = new Player(imgplayer);
		player.Run();
	}

	bool estaMorto = false;
	bool estaPulando = false;

	const int tempoEntreFrames = 25;
	const int forcaGravidade=6;
	bool EstaNoChao=true;
	bool EstaNoAr=false;
	int tempoPulando=0;
	int tempoNoAr=0;
	const int forcaPulo=8;
	const int maxtempoPulando=6;
	const int maxTempoNoar=4;

	int velocidade1 = 0;
	int velocidade2 = 0;
	int velocidade3 = 0;
	int velocidade = 0;
	int LarguraJanela = 0;
	int alturaJanela = 0;
	Player player;

	





	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		CorrigeTamanhoCenario(w, h);
		CalculaVelocidade(w);
	}


	void CalculaVelocidade(double w)

	{
		velocidade1 = (int)(w * 0.001);
		velocidade2 = (int)(w * 0.004);
		velocidade3 = (int)(w * 0.008);
		velocidade = (int)(w * 0.01);

	}

	void CorrigeTamanhoCenario(double w, double h)
	{
		foreach (var a in stack1.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in stack2.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in stack3.Children)
			(a as Image).WidthRequest = w;


		stack1.WidthRequest = w * 1.5;
		stack2.WidthRequest = w * 1.5;
		stack3.WidthRequest = w * 1.5;


	}

	void GerenciaCenarios()
	{
		MoveCenario();
		GerenciaCenarios(stack1);
		GerenciaCenarios(stack2);
		GerenciaCenarios(stack3);

	}
	void MoveCenario()
	{
		stack1.TranslationX -= velocidade1;
		stack2.TranslationX -= velocidade2;
		stack3.TranslationX -= velocidade3;
	}
	void GerenciaCenarios(HorizontalStackLayout horizontalStackLayout)
	{
		var view = (horizontalStackLayout.Children.First() as Image);
		if (view.WidthRequest + horizontalStackLayout.TranslationX < 0)
		{
			horizontalStackLayout.Children.Remove(view);
			horizontalStackLayout.Children.Add(view);
			horizontalStackLayout.TranslationX = view.TranslationX;
		}
	}


	async Task Desenha()
	{
		while (!estaMorto)
		{
			GerenciaCenarios();
			await Task.Delay(tempoEntreFrames);
			if (!estaPulando && !EstaNoAr)
			{
				Aplicagravidade();
				player.Desenha();
			}
			else
			AplicaPulo();
			await Task.Delay( tempoEntreFrames);
		}


	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		Desenha();


	}

	void Aplicagravidade()
	{
		if (player.GetY ()< 0)
		player.MoveY ( forcaGravidade);
		else if (player.GetY() >=0)
		{
			player.SetY(0);
			EstaNoChao= true;
		}
	}
void AplicaPulo()
{
	EstaNoChao=false;
	if (estaPulando && tempoPulando>=maxtempoPulando)
	{
		estaPulando=false;
		EstaNoAr=true;
		tempoNoAr=0;

	}
	else if (EstaNoAr && tempoNoAr>=maxTempoNoar)
	{
		estaPulando=false;
		EstaNoAr=false;
		tempoNoAr=0;
	}

	else if (estaPulando && tempoPulando< maxtempoPulando)
	{
		player.MoveY (-forcaPulo);
		tempoPulando ++;
	}
	else if (EstaNoAr)
	tempoNoAr ++;
}

void OnGridTapped(object o, TappedEventArgs a)
{
	if ( EstaNoChao)
	  estaPulando=true;
}





}





