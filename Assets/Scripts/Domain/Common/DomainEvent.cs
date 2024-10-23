public class DomainEvent
{

}

public class DomainEvent<T> : DomainEvent
{
  public T Value;

  public DomainEvent(T value)
  {
    Value = value;
  }
}