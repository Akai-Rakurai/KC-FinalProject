using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public PlayerMovement Player;
    public WeaponScript Gun;
    void Start()
    {
        Player = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;
        Gun = FindObjectOfType(typeof(WeaponScript)) as WeaponScript;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void savestats()
    {
        PlayerPrefs.SetInt("Health", Player.Health);
        PlayerPrefs.SetInt("Bullets", Gun.BulletsLeft);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);

        }
    }
}
