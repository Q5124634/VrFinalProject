using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public GameObject Gun;
    public static Bullets acInstance;
    public AudioSource myAudioSource;
    public AudioClip Shoot1, Shoot2, Shoot3; 
    public ParticleSystem muzzleflash;
    public float damage = 10f;
    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public float shootAngleRandomAim = 5;
    public float shootAngleRandomNotAim = 15;
    public float Bullet_Forward_Force;
    public Vector3 PreviousLocation;
    public Transform Target;

    public void Start()
    {
        PreviousLocation = Gun.transform.position;

    }
    public void PlayShot1()
    {
        myAudioSource.PlayOneShot(Shoot1);
    }
    public void PlayShot2()
    {
        myAudioSource.PlayOneShot(Shoot2);
    }
    public void PlayShot3()
    {
        myAudioSource.PlayOneShot(Shoot3);
    }
    
    void Update()
    {
        

        if (Input.GetKeyDown("space"))
        {
            GunShoot();



        }

        WaitOneSecond();
        Gun.transform.position = PreviousLocation;

    }
    void GunShoot()
    {
        muzzleflash.Play();

        int ShotNo = Random.Range((int)1, (int)4);
        Debug.Log(ShotNo);
            if(ShotNo == 1)
        {
            PlayShot1();
        }
        if (ShotNo == 2)
        {
            PlayShot2();
        }
        if (ShotNo == 3)
        {
            PlayShot3();
        }
        
        GameObject Temporary_Bullet_Handler;

        Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
        Temporary_Bullet_Handler.transform.Rotate(Vector3.right * 90);
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
        Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);
        Gun.transform.position = Vector3.Lerp(Gun.transform.position, Target.position, 0.1f);

        Destroy(Temporary_Bullet_Handler, 10.0f);
    }

    IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(1);
    }

}