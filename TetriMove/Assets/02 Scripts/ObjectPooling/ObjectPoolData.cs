using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Pool
{
    [Serializable]
    public class ObjectPoolData
    {
        public GameObject prefab;
        public int count;
        public ObjectPoolType type;
    }
}
