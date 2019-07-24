using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuntingManager : MonoBehaviour
{
    public GameObject bullet;
    public GameObject monkey;

    public Slider vSlider;

    public Slider monkeyHSlider;
    public Slider bulletHSlider;

    public Slider monkeyDSlider;
    public Slider bulletDSlider;

    public Slider monkeyMSlider;
    public Slider bulletMSlider;
    public Text directionText;
    private Rigidbody monkeyRigid;
    private Rigidbody bulletRigid;

    // Start is called before the first frame update
    void Start()
    {
        vSlider.maxValue = 40;
        vSlider.minValue = 1;
        vSlider.value = 10;

        monkeyHSlider.maxValue = 20;
        monkeyHSlider.minValue = -6;
        monkeyHSlider.value = monkey.transform.position.y;

        bulletHSlider.maxValue = 20;
        bulletHSlider.minValue = -6;
        bulletHSlider.value = bullet.transform.position.y;

        monkeyDSlider.maxValue = 20;
        monkeyDSlider.minValue = 3;
        monkeyDSlider.value = monkey.transform.position.x;

        bulletDSlider.maxValue = -3;
        bulletDSlider.minValue = -20;
        bulletDSlider.value = bullet.transform.position.x;

        monkeyRigid = monkey.GetComponent<Rigidbody>();
        bulletRigid = bullet.GetComponent<Rigidbody>();
        monkeyRigid.useGravity = false;
        bulletRigid.useGravity = false;

        monkeyMSlider.maxValue = 100;
        monkeyMSlider.minValue = 1;
        monkeyMSlider.value = monkeyRigid.mass;

        bulletMSlider.maxValue = 100;
        bulletMSlider.minValue = 1;
        bulletMSlider.value = bulletRigid.mass;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 monkeyDir = monkey.transform.position - bullet.transform.position;
        monkeyDir.Normalize();

        directionText.text = monkeyDir.ToString();

        if (bullet.transform.position.y < -30)
        {
            Camera camera = Camera.main;
            Vector3 pos = camera.transform.position;
            pos.y = (monkey.transform.position.y + bullet.transform.position.y) / 2;
            camera.transform.position = pos;
        }

    }

    public void Stop()
    {
        monkeyRigid.useGravity = false;
        bulletRigid.useGravity = false;

        monkeyRigid.velocity = Vector3.zero;
        monkeyRigid.angularVelocity = Vector3.zero;

        bulletRigid.velocity = Vector3.zero;
        bulletRigid.angularVelocity = Vector3.zero;

        Vector3 pos = monkey.transform.position;
        pos.y = monkeyHSlider.value;
        pos.x = monkeyDSlider.value;
        monkey.transform.position = pos;

        pos = bullet.transform.position;
        pos.y = bulletHSlider.value;
        pos.x = bulletDSlider.value;
        bullet.transform.position = pos;

        Camera camera = Camera.main;
        pos = camera.transform.position;
        pos.y = 1;
        camera.transform.position = pos;
    }

    public void MonkeyHeightChange()
    {
        Vector3 pos = monkey.transform.position;
        pos.y = monkeyHSlider.value;
        monkey.transform.position = pos;
    }

    public void BulletHeightChange()
    {
        Vector3 pos = bullet.transform.position;
        pos.y = bulletHSlider.value;
        bullet.transform.position = pos;
    }

    public void MonkeyDistanceChange()
    {
        Vector3 pos = monkey.transform.position;
        pos.x = monkeyDSlider.value;
        monkey.transform.position = pos;
    }

    public void BulletDistanceChange()
    {
        Vector3 pos = bullet.transform.position;
        pos.x = bulletDSlider.value;
        bullet.transform.position = pos;
    }

    public void MonkeyMassChange()
    {
        monkeyRigid.mass = monkeyMSlider.value;
    }

    public void BulletMassChange()
    {
        bulletRigid.mass = bulletMSlider.value;
    }

    public void StartHunt()
    {
        float v0 = vSlider.value;

        Vector3 monkeyDir = monkey.transform.position - bullet.transform.position;
        monkeyDir.Normalize();

        monkeyRigid.useGravity = true;
        bulletRigid.useGravity = true;
        bulletRigid.velocity = v0 * monkeyDir;
    }
}
