using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

public interface ICountMachine
{
    public ValueTask CountAsync();
    public void Cancel();
}