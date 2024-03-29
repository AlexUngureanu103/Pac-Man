﻿namespace Pac_Man.Domain.ObserverInterfaces
{
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers(string state);
    }
}
