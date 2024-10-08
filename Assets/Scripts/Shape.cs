using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//INHERITANCE
public class Shape : ShootableObject, IShootableObject
{
    public AudioClip clickShapeAudioClip;
    private readonly int pointsValue = 50;

    //POLYMORPHISM
    protected override void Update() 
    {
        if (transform.position.y < outOfBoundsY)
        {
            playerController.gameObject.SetActive(false);
            gameManager.GameOver();
            Destroy(gameObject);
        }
        base.Update();
    }

    public void PlayAnimation()
    {
        ParticleSystem ps = GameObject.Find("ClickSafe").GetComponent<ParticleSystem>();
        ps.transform.position = transform.position;
        ps.Play();
    } 

    //POLYMORPHISM
    protected override void DestroyShootableObject()
    {
        PlayAnimation();
        MusicPlayer.Instance.PlayAudioClip(clickShapeAudioClip);
        base.DestroyShootableObject();
        onDestroyed.Invoke(pointsValue);
    }
}
