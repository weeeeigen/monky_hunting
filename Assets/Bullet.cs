using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public Text huntedText;
    public Text posText;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        huntedText.enabled = false;
        posText.enabled = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monkey")
        {
            Vector3 pos = collision.transform.position;
            huntedText.enabled = true;
            posText.enabled = true;
            posText.text = "x: " + pos.x + ", y: " + pos.y + ", z: " + pos.z;
        }
    }
}
