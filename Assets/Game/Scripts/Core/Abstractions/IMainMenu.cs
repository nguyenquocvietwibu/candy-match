using System;

public interface IMainMenu
{
    public event Action PlayButtonClicked;
    public event Action SettingsButtonClicked;
    public event Action QuitButtonClicked;
}