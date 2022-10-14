using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Movement movement { get; private set; }
    public GhostChase chase { get; private set; }
    public GhostScatter scatter { get; private set; }
    public GhostRun run { get; private set; }
    public GhostBehaviour initialBehaviour;
    public Transform target;
    public Vector3 startpos = Vector3.zero;
    public int points = 100;

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        this.chase = GetComponent<GhostChase>();
        this.scatter = GetComponent<GhostScatter>();
        this.run = GetComponent<GhostRun>();
    }

    private void Start()
    {
        ResetState();
        this.startpos = this.transform.position;
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();

        this.run.Disable();
        this.chase.Disable();
        this.scatter.Enable();

        if (this.initialBehaviour != null)
        {
            this.initialBehaviour.Enable();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (this.run.enabled)
            {
                FindObjectOfType<GameManager>().GhostEaten(this);
            }
            else
            {
                FindObjectOfType<GameManager>().PacmanEaten();
            }
        }
    }
}
