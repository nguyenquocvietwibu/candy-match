using System;

public interface IPauseMenu 
{
    public event Action ResumeButtonClicked;
    public event Action RestartButtonClicked;
    public event Action SettingsButtonClicked;
    public event Action MainMenuButtonClicked;
}