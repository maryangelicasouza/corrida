using Microsoft.Maui.Platform;
using FFImageLoading.Maui;

namespace corrida;
public delegate void Callback();
public class Player : Animacao
{
    public Player ( CachedImageView a) : base(a)
    {
        for (int i = 1; i <= 6; ++i)
            animacao1.Add($"player{i.ToString("D2")}.png");
        for (int i = 1; i <= 2; ++i)
            animacao2.Add($"morte{i.ToString("D2")}.png");
    }
    public void Run()
    {
        loop = true;
        SetAnimacaoAtiva(1);
        Play();
    }

    public void Die()
    {
        loop = false;
        SetAnimacaoAtiva(2);
    }

public void MoveY( int s)
{
     imageView.TranslationY +=s;
}
public double GetY()
{
    return  imageView.TranslationY;
}
public void SetY (double a)
{
     imageView.TranslationY =a;
}
}

