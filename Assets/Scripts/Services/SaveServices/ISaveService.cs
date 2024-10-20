public interface ISaveService : IService
{
  public bool Exists(string save);
  public T Load<T>(string save) where T : class;
  public void Save<T>(string save, T data) where T : class;
}