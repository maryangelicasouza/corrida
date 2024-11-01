namespace corrida;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}


	bool estaMorto = false;
	bool estaPulando = false;

	const int tempoEntreFrames = 25;
	int velocidade1 = 0;
	int velocidade2 = 0;
	int velocidade3 = 0;
	int velocidade = 0;
	int LarguraJanela = 0;
	int alturaJanela = 0;

	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		CorrigeTamanhoCenario(w, h);
		CalculaVelocidade(w);
	}


	void CalculaVelocidade(double w)

	{
		velocidade1 = (int)(w * 0.0001);
		velocidade2 = (int)(w * 0.0004);
		velocidade3 = (int)(w * 0.0008);
		velocidade = (int)(w * 0.01);

	}

	void CorrigeTamanhoCenario(double w, double h)
	{
		foreach (var a in satack1.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in satack2.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in satack3.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in satackchao.Children)
			(a as Image).WidthRequest = w;

		satack1.WidthRequest = w * 1.5;
		satack2.WidthRequest = w * 1.5;
		satack3.WidthRequest = w * 1.5;
		satackchao.WidthRequest = w * 1.5;





	}






}





