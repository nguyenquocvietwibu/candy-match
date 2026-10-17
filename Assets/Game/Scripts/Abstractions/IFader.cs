using System.Threading.Tasks;

public interface IFader
{
    public Task FadeInAsync();
    public Task FadeOutAsync();
}