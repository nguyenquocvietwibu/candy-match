using System.Threading.Tasks;

public interface IFader
{
    public ValueTask FadeInAsync();
    public ValueTask FadeOutAsync();
}