using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    public Pacman pacman;
    //public Transform pellets;
    public Transform fruits;

    public int score { get; private set; }
    public int lives { get; private set; }

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (this.lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
        }
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(2);
        NewFloor();
    }

    private void NewFloor()
    {
        foreach (Transform fruit in this.fruits)
        {
            fruit.gameObject.SetActive(true);
        }
        ResetState();
    }

    private void ResetState()
    {
        this.pacman.ResetState();
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].ResetState();
        }
    }

    private void GameOver()
    {
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(false);
        }
        this.pacman.gameObject.SetActive(false);
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    public void GhostEaten(Ghost ghost)
    {
        SetScore(this.score + ghost.points);
        ghost.ResetState();
    }

    public void PacmanEaten()
    {
        this.pacman.gameObject.SetActive(false);
        SetLives(this.lives - 1);
        if (this.lives > 0)
        {
            Invoke(nameof(ResetState), 3.0f);
        }
        else
        {
            GameOver();
        }
    }
    public void FruitEaten(Fruit fruit){
        fruit.gameObject.SetActive(false);
        SetScore(this.score + fruit.points);
        if(!RemainingFruit()){
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewFloor), 3.0f);
        }
    }

    public void PowerPelletEaten(PowerPellet pellet){
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            ghosts[i].run.Enable(pellet.duration);
        }

        FruitEaten(pellet);
        
    }

    private bool RemainingFruit(){
        foreach (Transform fruit in this.fruits){
            if(fruit.gameObject.activeSelf){
                return true;
            }
        }
        return false;
    }

}
