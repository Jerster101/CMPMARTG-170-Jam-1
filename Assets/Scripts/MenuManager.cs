using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene(1); // 0 = Main menu, 1 = Game
    }
}
