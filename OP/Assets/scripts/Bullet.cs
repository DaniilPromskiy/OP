using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f; 
    [SerializeField] private float lifeDuration = 2f; 

    private void OnEnable()
    {
        StartCoroutine(DeactivateAfterLifetime());
    }

    private void Update()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private System.Collections.IEnumerator DeactivateAfterLifetime()
    {
        yield return new WaitForSeconds(lifeDuration);
        Deactivate();
    }

    private void Deactivate()
    {
        gameObject.SetActive(false); 
    }
}
