using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectColl : MonoBehaviour
{
    [SerializeField]
    private UIManager uIManager;

    [SerializeField]
    private AnimateCombo comboAnimator;

    [SerializeField]
    private ParticleSystem goodSmoke, badSmoke, neutralSmoke;

    private AudioSource audio;

    [SerializeField]
    private AudioClip ding, splash, wrong;

    [SerializeField]
    private float dingVolume, splashVolume, wrongVolume;

    [SerializeField]
    private Sprite glassesSprite, noGlassesSprite;

    private Animator animator;
    private SpriteRenderer renderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (UIManager.comboNum >= 5)
        {
            animator.enabled = false;
            renderer.sprite = glassesSprite;
        }
        else
        {
            animator.enabled = true;
            renderer.sprite = noGlassesSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Marshmallow")//marshmallow
        {
            if (UIManager.comboNum >= 5)
            {
                uIManager.IncreasePoints(1 * UIManager.comboNum);//points increase with our combo and rainbow particles
                audio.PlayOneShot(ding, dingVolume);//play both at same time hopefully?
            }
            else
                uIManager.IncreasePoints(1);//points increase with our combo

            if (badSmoke.isEmitting)//if it's bad, it goes neutral
            {
                goodSmoke.gameObject.SetActive(false);
                neutralSmoke.gameObject.SetActive(true);
                badSmoke.gameObject.SetActive(false);
            }

            UIManager.comboNum++;//give us an addition to our combo
            StartCoroutine(comboAnimator.AnimateCountdownText());//make our text move up a bit for effect

            audio.PlayOneShot(splash, splashVolume);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Nasty")//nasty
        {
            UIManager.comboNum = 0;//give us an addition to our combo
            goodSmoke.gameObject.SetActive(false);
            neutralSmoke.gameObject.SetActive(false);
            badSmoke.gameObject.SetActive(true);
            uIManager.DecreaseQuality();

            audio.PlayOneShot(wrong, wrongVolume);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "CandyCane")//candy cane
        {
            UIManager.comboNum++;//give us an addition to our combo
            StartCoroutine(comboAnimator.AnimateCountdownText());//make our text move up a bit for effect

            if (UIManager.comboNum >= 5)
            {
                uIManager.IncreasePoints(2 * UIManager.comboNum);//points increase with our combo
                audio.PlayOneShot(ding, dingVolume);//play both at same time hopefully?

            }
            else
                uIManager.IncreasePoints(3);//points increase with our combo

            if (badSmoke.isEmitting)//if it's bad, it goes neutral
            {
                goodSmoke.gameObject.SetActive(false);
                neutralSmoke.gameObject.SetActive(true);
                badSmoke.gameObject.SetActive(false);
            }
            else
            {
                goodSmoke.gameObject.SetActive(true);
                neutralSmoke.gameObject.SetActive(false);
                badSmoke.gameObject.SetActive(false);
            }
            uIManager.IncreaseQuality();

            audio.PlayOneShot(splash, splashVolume);
            Destroy(collision.gameObject);
        }
    }
}
