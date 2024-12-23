using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private int maxPoolSize = 15; 
    [SerializeField] private int initialPoolSize = 7; 

    private List<GameObject> bulletList; 
    private int activeBulletCount; 

    private void Awake()
    {
        InitializeBulletPool();
    }

    private void InitializeBulletPool()
    {
        bulletList = new List<GameObject>();

        for (int i = 0; i < initialPoolSize; i++)
        {
            AddBulletToPool();
        }
    }

    private GameObject AddBulletToPool()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.SetActive(false); 
        bulletList.Add(bullet);
        activeBulletCount++;
        return bullet;
    }

    public GameObject GetBulletFromPool()
    {
        foreach (GameObject bullet in bulletList)
        {
            if (!bullet.activeInHierarchy) 
            {
                return bullet; 
            }
        }

        return ExpandPoolIfNeeded(); 
    }

    private GameObject ExpandPoolIfNeeded()
    {
        if (activeBulletCount < maxPoolSize)
        {
            return AddBulletToPool(); 
        }

        return null; 
    }
}