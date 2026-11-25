public interface IObjectPool<T>
{
    public void Prewarm(int quantity);
    public T Rent();
    public void Return(T obj);
}