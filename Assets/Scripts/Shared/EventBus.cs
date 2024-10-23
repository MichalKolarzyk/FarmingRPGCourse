using System;
using System.Collections.Generic;

public class EventBus
{
  public Dictionary<Type, Dictionary<string, Action<object>>> subscribers = new();

  public void Subscribe<TEvent>(Action<TEvent> action)
    where TEvent : class
  {
    var eventKey = typeof(TEvent);
    var actionKey = action.GetHashCode().ToString();

    if (!subscribers.ContainsKey(eventKey))
    {
      subscribers.TryAdd(eventKey, new Dictionary<string, Action<object>>());
    }

    var eventSubscribers = subscribers[eventKey];
    eventSubscribers.Add(actionKey, o => action(o as TEvent));
  }

  public void Remove<TEvent>(Action<TEvent> action)
    where TEvent : class
  {
    var eventKey = typeof(TEvent);
    var actionKey = action.GetHashCode().ToString();
    subscribers[eventKey].Remove(actionKey);
  }

  public void Publish<TEvent>(TEvent eventArgs) 
    where TEvent : class
  {

    var eventKey = eventArgs.GetType();
    var containsEventSubscribers = subscribers.TryGetValue(eventKey, out var eventSubscribers);

    if (!containsEventSubscribers)
      return;

    foreach (var eventSubscriber in eventSubscribers)
    {
      eventSubscriber.Value(eventArgs);
    }
  }
}