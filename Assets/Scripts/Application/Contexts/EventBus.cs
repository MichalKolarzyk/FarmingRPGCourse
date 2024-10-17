using System;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : MonoBehaviour
{
  protected Dictionary<string, List<Action<DomainEvent>>> subscribers = new();

  public void Subscribe<TDomainEvent>(Action<TDomainEvent> subscriber)
      where TDomainEvent : DomainEvent
  {
    var key = typeof(TDomainEvent).ToString();
    if (!subscribers.ContainsKey(key))
    {
      subscribers[key] = new List<Action<DomainEvent>>();
    }
    subscribers[key].Add(o => subscriber(o as TDomainEvent));
  }

  public void Unsubscribe<TDomainEvent>(Action<TDomainEvent> subscriber)
    where TDomainEvent : DomainEvent
  {
    var key = typeof(TDomainEvent).ToString();
    subscribers[key].RemoveAll(s => s.Equals((Action<object>) (o => subscriber(o as TDomainEvent))));
  }

  public void Publish<TDomainEvent>(TDomainEvent eventToPublish) where TDomainEvent : DomainEvent
  {
    var key = eventToPublish.GetType().ToString();
    if (subscribers.ContainsKey(key))
    {
      foreach (var subscriber in subscribers[key])
      {
        subscriber(eventToPublish);
      }
    }
  }
}