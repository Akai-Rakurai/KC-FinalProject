using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public PlayerMovement Player;
    public WeaponScript Gun;
    public Score Score;
    public EnemySpawner Spawner;
    void Start()
    {
        gameObject.SetActive(false);
        Player = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;
        Gun = FindObjectOfType(typeof(WeaponScript)) as WeaponScript;
        Score = FindObjectOfType(typeof(Score)) as Score;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void savestats()
    {
        PlayerPrefs.SetInt("Health", Player.Health);
        PlayerPrefs.SetInt("Bullets", Gun.BulletsLeft);
        PlayerPrefs.SetInt("Score", Score.score);
        PlayerPrefs.SetInt("Kills", Score.Kills);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            savestats();
            SceneManager.LoadScene(0);
        }
    }
}
