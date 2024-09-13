using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header (" ship speep and range")]

    [Tooltip("ship speed")][SerializeField] float speed = 30f;
    [SerializeField] float xRange = 20f;
    [SerializeField] float yRange = 17f;

    
    [Header (" bullets")]
    [SerializeField] GameObject[] Guns;
    [Header (" ship un down right left controls")]
    [Tooltip("ship nose direction ")][SerializeField] float PositionPitchFactor = -1f;
    [Tooltip("ship nose right left movement")][SerializeField] float PositionYawFactor = -1f;
    [Tooltip("ship nose movement")][SerializeField] float ControlPitchFactor = 1f;
    [Tooltip("ship turns right left")][SerializeField] float ControlrollFactor = -1f;
    

    
 

    float xMovement , yMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();

    }
    
    void ProcessRotation()
    {
        float pitch = transform.localPosition.y*PositionPitchFactor+ yMovement*ControlPitchFactor;
        float yaw = transform.localPosition.x* PositionYawFactor;
        float roll = xMovement* ControlrollFactor;

        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    void ProcessTranslation()
    {

        xMovement = Input.GetAxis("Horizontal");
        yMovement = Input.GetAxis("Vertical");

        float xvalue = xMovement * Time.deltaTime * speed;
        float newXPosition = transform.localPosition.x + xvalue;
        float clampedXPos = Mathf.Clamp(newXPosition,-xRange,xRange);

        float yvalue = yMovement * Time.deltaTime * speed;
        float newYPosition = transform.localPosition.y + yvalue;
        float clampedYPos = Mathf.Clamp(newYPosition,-yRange,yRange);

        

        transform.localPosition = new Vector3(clampedXPos,clampedYPos,transform.localPosition.z);
      
    }
    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            ActivateGuns(true);
        }
        else
        {
            ActivateGuns(false);
        }
    }
    void ActivateGuns( bool isActive)
    {
        foreach (GameObject bullets in Guns)
        {
           var emissionModule = bullets.GetComponent<ParticleSystem>().emission;
           emissionModule.enabled = isActive;

        }

    }

}
