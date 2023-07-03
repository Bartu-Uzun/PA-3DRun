using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float runningSpeed;
    float touchXDelta = 0;
    float newX = 0;
    [SerializeField] float xSpeed;
    [SerializeField] float limitX;
    private bool isStop = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwipeCheck();
    }

    private void SwipeCheck()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && !isStop)
        { //if we use our phone

            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }

        else if (Input.GetMouseButton(0) && !isStop)
        { //if we use our pc

            touchXDelta = Input.GetAxis("Mouse X"); //the name Mouse X comes from Input Manager (edit-->project settings--> inputManager)
        }
        else {
            touchXDelta = 0;
        }


        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX); //girilen value girilen min-max limitler arasında değilse o aralığa sokuyor

        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);

        transform.position = newPosition;
    }

    public void StopMoving() {

        runningSpeed = 0;
        isStop = true;
    }
}
