public abstract class Context<T> : EventBus
    where T : Aggregate
{
    protected T model;


    public void Set(T model)
    {
        this.model = model;
    }

    public T Get()
    {
        return model;
    }
}
