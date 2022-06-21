using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGreen : MonoBehaviour
{
    public Rigidbody buttonrb;
    Renderer buttoncolor;
    Renderer origincolor;
    public GameObject cloud;
    private Rigidbody cloudrb;

    void Start()
    {
        buttonrb = GetComponent<Rigidbody>();
        buttoncolor = gameObject.GetComponent<Renderer>();
        origincolor = gameObject.GetComponent<Renderer>();
        cloudrb = cloud.GetComponent<Rigidbody>();
    }



    private void OnCollisionStay(Collision Button1Click)
    {
        if (Button1Click.gameObject.tag == "Player")
        {

            buttonrb.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            buttoncolor.material.color = Color.white;




        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //떨어뜨리기
            cloudrb.useGravity = true;
            //새로 생성
            Invoke("Detroycloud", 3.0f);
            Invoke("NewCloudInstantiate", 4.0f);

            //StartCoroutine(CoolTime(30.0f));



        }


    }

    /*
    IEnumerator CoolTime(float cool)
    {


        print("쿨타임 코루틴 실행");
        while (cool > 1.0f)
        {
            cool -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        print("쿨타임 코루틴 end");
    }
    */
    public void Detroycloud()
    {
        Destroy(cloud);

        
    }

    public void NewCloudInstantiate()
    {

        GameObject newcloudob = Resources.Load<GameObject>($"UI_pref/SpawnObject/Stage2/FlyingCloud");
        Vector3 spawnPos = GameObject.Find("@NewCloudPosition").transform.position;

        GameObject newcloud = Instantiate(newcloudob, spawnPos, Quaternion.Euler(0, 0, 0));
        cloud = newcloud;
        cloudrb = cloud.GetComponent<Rigidbody>();

    }


    private void OnCollisionExit(Collision Button1Click)
    {
        if (Button1Click.gameObject.tag == "Player")
        {
            buttonrb.AddForce(Vector3.up * 10.0f, ForceMode.Acceleration);
            buttoncolor.material.color = origincolor.material.color;
        }

    }


    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Stop")
        {
            buttonrb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }
}
