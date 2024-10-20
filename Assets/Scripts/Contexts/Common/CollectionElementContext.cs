public abstract class CollectionElementContext<T> : Context<T>
{
    //Run on Awake
    public void SetModel(T model){
        this.model = model;
    }

    //Run after Awake
    protected abstract void UpdateContext();

    public void Set(T model){
        SetModel(model);
        UpdateContext();
    }
}
