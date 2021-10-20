using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployEnemy : MonoBehaviour
{
    public int dice = 1;
    public GameObject MeleeEnemy;
    public GameObject RifleEnemy;
    public GameObject CamPos;
    void Start()
    {
        StartCoroutine(Wave());
    }

    // Update is called once per frame
    void Update()
    {
        dice = Random.Range(0, 10);
    }
    IEnumerator Wave()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            //new WaitForSeconds(4f);
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        int dice1 = Random.Range(1, 5);
        //GameObject a = Instantiate(MeleeEnemy);
        //a.transform.position = new Vector2(Random.Range(-50,50), Random.Range(-50,50));

        if (true)
        {
            GameObject a = Instantiate(MeleeEnemy);
            if (dice1 == 1)
            {
                a.transform.position = new Vector2(Random.Range(CamPos.transform.position.x + 23, CamPos.transform.position.x + 30), Random.Range(CamPos.transform.position.y - 12, CamPos.transform.position.y + 12));
            }
            else if (dice1 == 2)
            {
                a.transform.position = new Vector2(Random.Range(CamPos.transform.position.x - 30, CamPos.transform.position.x - 23), Random.Range(CamPos.transform.position.y - 12, CamPos.transform.position.y + 12));
            }
            else if (dice1 == 3)
            {
                a.transform.position = new Vector2(Random.Range(CamPos.transform.position.x - 23, CamPos.transform.position.x + 23), Random.Range(CamPos.transform.position.y + 12, CamPos.transform.position.y + 15));
            }
            else
            {
                a.transform.position = new Vector2(Random.Range(CamPos.transform.position.x - 23, CamPos.transform.position.x + 23), Random.Range(CamPos.transform.position.y + 12, CamPos.transform.position.y + 15));
            }
        }
        //else
        //{
        //    GameObject a = Instantiate(RifleEnemy);
        //    dice1 = Random.Range(1, 5);
        //    if (dice1 == 1)
        //    {
        //        a.transform.position = new Vector2(Random.Range(CamPos.transform.position.x + 23, CamPos.transform.position.x + 30), Random.Range(CamPos.transform.position.y - 12, CamPos.transform.position.y + 12));
        //    }
        //    else if (dice1 == 2)
        //    {
        //        a.transform.position = new Vector2(Random.Range(CamPos.transform.position.x - 30, CamPos.transform.position.x - 23), Random.Range(CamPos.transform.position.y - 12, CamPos.transform.position.y + 12));
        //    }
        //    else if (dice1 == 3)
        //    {
        //        a.transform.position = new Vector2(Random.Range(CamPos.transform.position.x - 23, CamPos.transform.position.x + 23), Random.Range(CamPos.transform.position.y + 12, CamPos.transform.position.y + 15));
        //    }
        //    else
        //    {
        //        a.transform.position = new Vector2(Random.Range(CamPos.transform.position.x - 23, CamPos.transform.position.x + 23), Random.Range(CamPos.transform.position.y + 12, CamPos.transform.position.y + 15));
        //    }
        //}
    }
}
