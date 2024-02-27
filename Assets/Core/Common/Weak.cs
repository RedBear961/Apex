using System;
using JetBrains.Annotations;

namespace Core.Common
{
    public readonly struct Weak<T> where T : class
    {
        private readonly WeakReference _weakReference;
        
        public Weak(T anObject)
        {
            this._weakReference = new WeakReference(anObject);
        }

        [CanBeNull] public T TryValue => _weakReference.IsAlive ? (T)_weakReference.Target : null;
    }
}