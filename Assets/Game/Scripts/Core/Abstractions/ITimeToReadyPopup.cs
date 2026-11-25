using System.Collections;
using System.Threading;
using System.Threading.Tasks;

public interface ITimeToReadyPopup 
{
    public void SetDefault();
    public ValueTask CountDownAsync(CancellationToken token);
}