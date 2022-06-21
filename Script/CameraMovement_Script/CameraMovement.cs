
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject car;
    private GameObject player;
    private Vector3 temp;
    public Vector3 delta;
    LayerMask mask;
    bool rightMouseClicked;
    // LayerMask mask = LayerMask.GetMask("Wall") | LayerMask.GetMask("Default");

    //cr
    public GameObject head;
    public float rotationSpeed = 5.0f;
    [SerializeField]
    private Vector3 offsetPosition = new Vector3(0.0f, 1.8f, -2.14f);

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;


    public void Awake()
    {
        car = GameObject.Find("car");
        mask = LayerMask.GetMask("Wall");
        player = transform.parent.gameObject;
        delta = new Vector3(1.0f, 1.8f, -2.14f);
        head = transform.parent.GetChild(1).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(4).gameObject;
        //

    }


    private void Update()
    {
        RaycastHit hit;


        //Layer를 Wall로 설정한 오브젝트가 카메라와 플레이어 사이에 있으면 카메라를 플레이어와 가깝게 이동
        if (Physics.Raycast(player.transform.position, delta, out hit, delta.magnitude, mask))
        {
            Debug.Log("hit");
            float dist = (hit.point - player.transform.position).magnitude * 0.8f;
            transform.position = player.transform.position + delta.normalized * dist;
        }

        else if (Input.GetMouseButton(1))
        {
            transform.eulerAngles += rotationSpeed * new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0.0f);
        }
        else
        {
            if (offsetPositionSpace == Space.Self)
            {
                transform.position = player.transform.TransformPoint(offsetPosition);
            }
            else
            {
                transform.position = player.transform.position + offsetPosition;
            }

            // compute rotation
            if (lookAt)
            {

                transform.LookAt(head.transform); 


            }
            else
            {
                transform.rotation = player.transform.rotation;
            }

        }



        // transform.LookAt(playerTransform);




    }


    public void RideonMove()
    { //자동차에 탈 때 카메라 이동
        transform.Translate(car.transform.position - player.transform.position, Space.World);
        transform.RotateAround(car.transform.position, Vector3.up, -transform.eulerAngles.y + car.transform.eulerAngles.y);

        transform.SetParent(car.transform);
    }

    public void RideoffMove()
    { //자동차에서 내릴 때 카메라 이동
        transform.Translate(player.transform.position - car.transform.position, Space.World);

        transform.SetParent(player.transform);
    }

    public void CarryMove(Vector3 P1, Vector3 R1, Vector3 P2, Vector3 R2, Transform T) {
        transform.Translate(P1-P2, Space.World);
        transform.RotateAround(P1, Vector3.up, -transform.eulerAngles.y + R1.y);
        
        transform.SetParent(T);

    } // 2번째 이후로 차탈때 쓰는 카메라워크

}
