
using System;

public interface IConfirmationPopup
{
    public event Action ConfirmButtonClicked;
    public event Action CancelButtonClicked;
}