using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public int health;
    public int numOfHealth;

    public Image[] pacs;
    public Sprite life; 
    public Sprite nolife;

    void Update(){
        if(health > numOfHealth){
           health = numOfHealth; 
        }
        for(int i = 0; i < pacs.Length; i++){
            if(i < health){
                pacs[i].sprite = life;
            }else{
                pacs[i].sprite = nolife;
            }
            if(i < numOfHealth){
                pacs[i].enabled = true;
            }else{
                pacs[i].enabled = false;
            }
        }
    }
}

