using System;
using UnityEngine;

namespace Core.Entity
{
    public class Moon : Planet
    {
        // MARK: - INode
        
        public new MonoBehaviour GetBehavior()
        {
            throw new NotImplementedException();
        }
    }
}