using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoveForward : MonoBehaviour
{
    Slider slider;
    private static float speed;
    [SerializeField] float currPosY1 = -1.8f;
    [SerializeField] float currPosY2 = 1.6f;
    [SerializeField] float currPosX1 = -2.1f;
    [SerializeField] float currPosX2 = 1.3f;
    [SerializeField] int previousSliderValue = 1;
    // Start is called before the first frame update
    void Start()
    {
       
        slider = GameObject.Find("Slider (3)").GetComponent<Slider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = slider.value;
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (transform.position.y >= currPosY2 || transform.position.y <= currPosY1 || transform.position.x >= currPosX2 || transform.position.x <= currPosX1)
        {
            Destroy(gameObject);
        }
    }
    
}
