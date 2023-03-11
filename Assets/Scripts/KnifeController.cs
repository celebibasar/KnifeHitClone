using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeController : MonoBehaviour
{
    private Rigidbody2D knifeRigidbody;
    private KnifeManager knifeManager;
    [SerializeField] private float knifeSpeed;
    private bool canShoot;

    private void Start()
    {
        GetComponentValues();
        
    }
    private void Update()
    {
        HandleShootInput();
    }
    private void FixedUpdate()
    {
        Shoot();
        
    }
    private void HandleShootInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            knifeManager.SetDisableIcon();
            canShoot = true;

        }

    }
    private void Shoot()
    {
        if (canShoot)
        {
            knifeRigidbody.AddForce(knifeSpeed * Time.fixedDeltaTime * Vector2.up*2);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Circle"))
        {
            knifeManager.KnifeSetActive();
            canShoot = false;
            knifeRigidbody.isKinematic = true;
            transform.SetParent(collision.gameObject.transform);
        }
        if (collision.gameObject.CompareTag("Knife"))
        {
            SceneManager.LoadScene(0);
        }
    }
    private void GetComponentValues()
    {
        knifeRigidbody = GetComponent<Rigidbody2D>();
        knifeManager = GameObject.FindObjectOfType<KnifeManager>();
    }
}
