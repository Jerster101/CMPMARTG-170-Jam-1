using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruit_counter : MonoBehaviour
{
    public int fruit;
    public int numOfFruits;

    public Image[] fruits;
    public Sprite yesFruit; 
    public Sprite nofruit;

    void Update(){
        if(fruit > numOfFruits){
           fruit = numOfFruits; 
        }
        for(int i = 0; i < fruits.Length; i++){
            if(i < fruit){
                fruits[i].sprite = yesFruit;
            }else{
                fruits[i].sprite = nofruit;
            }
            if(i < numOfFruits){
                fruits[i].enabled = true;
            }else{
                fruits[i].enabled = false;
            }
        }
    }
}
