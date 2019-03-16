using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Minator : MonoBehaviour
{
    public float Health;

    public AudioClip DamageSfx;
    public AudioClip DeathSfx;
    public AudioClip RunSfx;

    private GameObject mPlayer;
    private NavMeshAgent mAgent;
    private Animator mAnimator;

    private bool mIsDeath;

    private AudioSource mAudio;


	// Use this for initialization
	void Start ()
    {
        mIsDeath = false;
        mAudio = GetComponent<AudioSource>();
        mAnimator = GetComponent<Animator>();
        mAgent = GetComponent<NavMeshAgent>();
        mPlayer = GameObject.FindGameObjectWithTag("Player");	
	}
	
    /// <summary>
    /// Minator'un NavMeshAgent bileşeni (Component) var. Sahne NavMesh olarak tanımlandığı için, bu agent bu sahnede ona izin verilen yerlere gidebilir.
    /// Hedef olarak kendimizi (Player)'ı veriyoruz ki, hep bizi takip etsin. Eğer mIsDeath flag'i true ise, izlemeyi bırakıyor.
    /// </summary>
	void Update ()
    {
        if (mIsDeath)
        {
            return;
        }

        mAgent.SetDestination(mPlayer.transform.position);
        mAnimator.SetFloat("Speed", mAgent.velocity.magnitude);
	}

    /// <summary>
    /// Minator'a zarar vermek için kullandığımız fonksiyon. Normalde Health'i azaltmamız yeterliydi, diğer
    /// karışık şeyler animasyon durumlarını istediğimiz gibi ayarlamak için yazıldı.
    /// </summary>
    public void Damage(int damage)
    {
        if (!mIsDeath)
        {
            Health -= damage;

            if (Health < 0)
            {
                mAnimator.SetTrigger("Die");
                mAgent.isStopped = true;
                mIsDeath = true;
                mAudio.PlayOneShot(DeathSfx);
            }
            else
            {
                mAudio.PlayOneShot(DamageSfx);
                mAnimator.SetTrigger("Damage");
            }
        }
    }
}
