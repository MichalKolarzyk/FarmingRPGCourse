using System;
using System.Collections.Generic;

public class EventBus
{
  public Dictionary<Type, Dictionary<string, object>> subscribers;

  public void Subscribe<TEvent>(Action<TEvent> action)
  {
    var eventKey = typeof(TEvent);
    var actionKey = action.GetHashCode().ToString();

    if (!subscribers.ContainsKey(eventKey))
    {
      subscribers.TryAdd(eventKey, new Dictionary<string, object>());
    }

    var eventSubscribers = subscribers[eventKey];
    eventSubscribers.Add(actionKey, action);
  }

  public void Remove<TEvent>(Action<TEvent> action)
  {
    var eventKey = typeof(TEvent);
    var actionKey = action.GetHashCode().ToString();
    subscribers[eventKey].Remove(actionKey);
  }

  public void Publish<TEvent>(TEvent eventArgs){
    var eventKey = typeof(TEvent);
    var containsEventSubscribers = subscribers.TryGetValue(eventKey, out var eventSubscribers);

    if(!containsEventSubscribers)
      return;

    foreach(var eventSubscriber in eventSubscribers){
      var action = eventSubscriber as Action<TEvent>;
      action?.Invoke(eventArgs);
    }
  }
}