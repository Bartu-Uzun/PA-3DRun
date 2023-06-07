using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{

    [SerializeField] private Transform cameraTarget;
    [SerializeField] Transform lookTarget;
    [SerializeField] float sSpeed = 10.0f;
    [SerializeField] Vector3 dist;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate() {

        Vector3 dPos = cameraTarget.position + dist;

        //Lerp: iki vektör arasındaki geçişi belli bir zaman içerisinde smooth bir şekilde yapmayı sağlıyor
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);

        transform.position = sPos;
        transform.LookAt(lookTarget.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
