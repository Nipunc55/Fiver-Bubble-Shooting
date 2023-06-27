using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shooting : MonoBehaviour
{
    public GameObject[] CirclePreFab;
    public Sprite[] shootImages;
    public Button shoot;
    public GameObject shooterPoint;

    public float speed = 5;
    int randomNum;
    public float rotateSpeed = 40;
    public AudioSource shootSound;
    public void Shoot()
    {

        //int randomNum = Random.Range(0, CirclePreFab.Length);
        GameObject circle = Instantiate(CirclePreFab[randomNum], transform.position, transform.rotation);
        shoot.image.sprite = shootImages[randomNum];

        Rigidbody2D circleRidgidBody = circle.GetComponent<Rigidbody2D>();
        //circleRidgidBody.bodyType = RigidbodyType2D.Kinematic;
        //  circleRidgidBody.velocity = new Vector2(0.0f, 1.0f) * speed;
        circle.GetComponent<otherCircles>().EnableCanDestroy();
        randomNum = Random.Range(0, CirclePreFab.Length);
        shoot.image.sprite = shootImages[randomNum];
        circleRidgidBody.AddForce(transform.up * speed, ForceMode2D.Impulse);
        shootSound.Play();


    }
    private void Update()
    {
        // Debug.Log(SimpleInput.GetAxis("Horizontal"));
        //  Vector3 v2 = Vector3(0.0, Input.GetAxis("Horizontal"),0.0);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, -SimpleInput.GetAxis("Horizontal") * rotateSpeed);
    }


}
