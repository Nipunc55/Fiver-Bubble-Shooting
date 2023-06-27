using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedStar : MonoBehaviour
{

    public int numOfObjects;
    public int count;
    public RedStar otherresdstar;
    public UIManager uimanager;
    public List<GameObject> touchedCircles = new List<GameObject>();
    public string nameOFCircle = "Star";
    public bool canDestroy = false;
    public int score;
    private void Awake()
    {

        GetComponent<Rigidbody2D>().gravityScale = 0f;
        GameObject Go = GameObject.Find("UIManager");
        uimanager = Go.GetComponent<UIManager>();

    }
    private void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);

        // canDestroy = false;
    }
    public void TouchedCircleCount()
    {
        count++;
    }

    public void EnableCanDestroy()
    {
        canDestroy = true;
    }



    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == nameOFCircle)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            touchedCircles.Add(other.gameObject);
            TouchedCircleCount();


            otherresdstar = other.gameObject.GetComponent<RedStar>();
            int newCount = otherresdstar.count;

            score = PlayerPrefs.GetInt("score", 0);
            //  bool otheCanDestroy = otherresdstar.canDestroy;

            Debug.Log(numOfObjects);
            if ((count + newCount) > 2)
            {
                int Score = 3 + score;
                uimanager.UpdateScore();
                PlayerPrefs.SetInt("score", Score);
                DestroyCircles();
                otherresdstar.DestroyCircles();

            }
        }
    }
    public void DestroyCircles()
    {
        foreach (GameObject circles in touchedCircles)
        {
            //circles.gameObject.GetComponent<RedStar>().EnableCanDestroy();
            Destroy(circles);
        }

        Destroy(gameObject);
    }
}
