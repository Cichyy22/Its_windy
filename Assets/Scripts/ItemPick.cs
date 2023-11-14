using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPick : MonoBehaviour {

    [SerializeField]
    private TMP_Text pickUpText;
    [SerializeField]
    private TMP_Text missionText1;
    [SerializeField]
    private TMP_Text missionText2;

    private bool pickUpAllowed;

    public Player myPlayer;

	// Use this for initialization
	private void Start () {
        gameObject.SetActive(true);
        pickUpText.gameObject.SetActive(false);
        missionText2.gameObject.SetActive(false);
        // if(PlayerPrefs.GetInt("BasketPick") == 1){
            // gameObject.SetActive(false);
        // }
	}
	
	// Update is called once per frame
	private void Update () {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Gracz"))
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }        
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Gracz"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        PlayerPrefs.SetInt("BasketPick", 1);
        PlayerPrefs.Save();
        missionText1.gameObject.SetActive(false);
        missionText2.gameObject.SetActive(true);
        Destroy(gameObject);
    }

}