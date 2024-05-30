using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PooledItems
{
    public string Name;
    public GameObject objectToPool;
    public int amount;
}

public class Pulling_Controller : MonoBehaviour
{
    private static Pulling_Controller _instance;
    public static Pulling_Controller Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<Pulling_Controller>();
            }
            return _instance;
        }
    }

    [SerializeField]
    private List<PooledItems> pooledLists = new List<PooledItems>();

    [SerializeField]
    private Dictionary<string, List<GameObject>> _items = new Dictionary<string, List<GameObject>>();

    private void Awake()
    {
        for (int i = 0; i < pooledLists.Count; ++i)
        {
            PooledItems item = pooledLists[i];
            _items.Add(item.Name, new List<GameObject>());

            for (int j = 0; j < item.amount; ++j)
            {
                GameObject tmp;
                tmp = Instantiate(item.objectToPool);
                tmp.SetActive(false);
                _items[item.Name].Add(tmp);

            }
        }


        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public GameObject GetPooledObject(string name)
    {
        List<GameObject> tmp = _items[name];

        for (int i = 0; i < tmp.Count; ++i)
        {
            if (!tmp[i].activeInHierarchy)
            {
                return tmp[i];
            }
        }

        GameObject x = Instantiate(tmp[0]);
        _items[name].Add(x);
        return x;
    }

    public void ClearLists()
    {
        Destroy(gameObject);
    }
}
