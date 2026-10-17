using Presenter;
using System;
using System.Threading.Tasks;

public enum GameScreen
{
    Title,
    Gameplay,
}
public interface IScreenNavigator
{
    public Task NavigateToAsync(GameScreen screenType);
}