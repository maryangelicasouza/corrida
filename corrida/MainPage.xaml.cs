namespace corrida;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		Player player;
		Player= new Player( imgplayer);
		Player.Run();
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
		foreach (var a in stack1.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in stack2.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in stack3.Children)
			(a as Image).WidthRequest = w;
		

		stack1.WidthRequest = w ;
		stack2.WidthRequest = w ;
		stack3.WidthRequest = w ;


	}

	void GerenciaCenarios()
	{
		MoveCenario();
		GerenciaCenarios (stack1);
		GerenciaCenarios (stack2);
		GerenciaCenarios (stack3);
		
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

	   protected override void OnAppearing()
    {
		 base.OnAppearing();
		 Desenha();
      
		
			
    }
   async Task Desenha()
  {
        while (!estaMorto)
		{
			GerenciaCenarios();
			Player.Desenha();
			await Task.Delay (tempoEntreFrames);
		}
  }






}





