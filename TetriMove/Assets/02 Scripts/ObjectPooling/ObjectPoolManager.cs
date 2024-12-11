using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
    {
        [SerializeField] private List<ObjectPoolData> _objectPoolDatas = new List<ObjectPoolData>();

        private Dictionary<ObjectPoolType, ObjectPoolData> _objectPoolDataMap = new Dictionary<ObjectPoolType, ObjectPoolData>();
        private Dictionary<ObjectPoolType, Queue<GameObject>> _objectPool = new Dictionary<ObjectPoolType, Queue<GameObject>>();

        protected override void Awake()
        {
            base.Awake();

            Init();
        }

        private void Init()
        {
            foreach(var data in _objectPoolDatas)
            {
                _objectPoolDataMap.Add(data.type, data);
            }

            foreach(var poolData in _objectPoolDataMap)
            {
                _objectPool.Add(poolData.Key, new Queue<GameObject>());
                var objectPoolData = poolData.Value;

                for(int i = 0; i < objectPoolData.count; i++)
                {
                    var poolObject = CreateNewObject(poolData.Key);
                    _objectPool[poolData.Key].Enqueue(poolObject);
                }
            }
        }

        private GameObject CreateNewObject(ObjectPoolType type)
        {
            var newObj = Instantiate(_objectPoolDataMap[type].prefab, transform);
            newObj.SetActive(false);

            return newObj;
        }

        public GameObject GetObject(ObjectPoolType type, Transform trans = null)
        {
            if (_objectPool[type].Count > 0)
            {
                var obj = _objectPool[type].Dequeue();
                if(trans != null)
                {
                    obj.transform.SetParent(trans);
                }
                obj.SetActive(true);
                return obj;
            }
            else
            {
                var newObj = CreateNewObject(type);
                if(trans != null)
                {
                    newObj.transform.SetParent(trans);
                }
                newObj.SetActive(true);
                return newObj;
            }
        }

        public void ReturnObject(ObjectPoolType type, GameObject obj)
        {
            obj.SetActive(false);
            obj.transform.SetParent(transform);
            _objectPool[type].Enqueue(obj);
        }
    }
}

