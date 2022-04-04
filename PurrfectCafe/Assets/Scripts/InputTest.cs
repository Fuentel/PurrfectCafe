using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true; 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //pillar inputs pc
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Verical");

        //Gyroscopio
        Vector3 eulerAngles = GyroToUnity(Input.gyro.attitude).eulerAngles;

        //accelerometer
        Vector3 acceleration = Input.acceleration;

        //touchscreen
        if(Application.platform == RuntimePlatform.Android)//comprobacion de que es android para ejecutar este codigo solo ahi
        {
            for (int i=0; i< Input.touchCount; i++)
            {
                float relativePositionX = Input.touches[i].rawPosition.x / Screen.width;
                if(Input.touches[i].position.x > 0.5f )//que haga algo si toca en la mitad derecha de la pantalla   
                {
                    if (Input.touches[i].phase == TouchPhase.Began) //solo tocando, no pulsando
                    {
                        //jump();
                    }
                }
                else
                {
                    //joystick virtual a la izq 
                    float horizontalDisplacement = (Input.touches[i].position.x - Input.touches[i].rawPosition.x)/Screen.width;
                    float verticalDisplacement = Input.touches[i].position.y - Input.touches[i].rawPosition.y / Screen.height;

                    horizontalAxis = Mathf.Clamp(10.0f * horizontalDisplacement, -1.0f, 1.0f);
                    verticalAxis = Mathf.Clamp(10.0f * verticalDisplacement, -1.0f, 1.0f);

                    //Input.touches[i].rawPosition;     posicion original previa a arrastrar
                }
            }
        }
        if(Input.touchCount ==2)//para contar la cantidad de touchInputs de la pantalla
        {

        }
        
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
