public interface IViewNavigator
{
    public void Show<T>();
    public void ShowPrevious();
    public void Hide<T>();
    public void HideAll();
}