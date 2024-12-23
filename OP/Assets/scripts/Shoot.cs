using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Pool pool; 
    [SerializeField] private Transform firePoint; 

    void Update()
    {
        HandleShootingInput();
    }

    private void HandleShootingInput()
    {
        if (IsFireButtonPressed())
        {
            FireBullet();
        }
    }

    private bool IsFireButtonPressed()
    {
        return Input.GetButtonDown("Fire1"); 
    }

    private void FireBullet()
    {
        GameObject bullet = pool.GetBulletFromPool(); 
        if (bullet != null)
        {
            PositionBullet(bullet); 
            bullet.SetActive(true); 
        }
    }

    private void PositionBullet(GameObject bullet)
    {
        bullet.transform.position = firePoint.position; 
        bullet.transform.rotation = firePoint.rotation; 
    }
}