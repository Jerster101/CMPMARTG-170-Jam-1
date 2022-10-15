using UnityEngine;

public class GhostRun : GhostBehaviour
{
    [SerializeField]
    private Animator anim;

    //public Animator animator { get; private set; }
    public float death = 10.0f;

    public bool eaten { get; private set; }

    /*private void Awake()
    {
        this.animator = this.gameObject.GetComponent<Animator>();
    }*/

    public override void Enable(float duration)
    {
        base.Enable(duration);
        //animator.runtimeAnimatorController = Resources.Load("PowerUpGhost") as RuntimeAnimatorController;
    }

    public override void Disable()
    {
        base.Disable();
       /* if (this.gameObject.name == "Blinky")
        {
            animator.runtimeAnimatorController = Resources.Load("Blinky") as RuntimeAnimatorController;
        }
        else if (this.gameObject.name == "Inky")
        {
            animator.runtimeAnimatorController = Resources.Load("Inky") as RuntimeAnimatorController;
        }
        else if (this.gameObject.name == "Clyde")
        {
            animator.runtimeAnimatorController = Resources.Load("Clyde") as RuntimeAnimatorController;
        }
        else if (this.gameObject.name == "Pinky")
        {
            animator.runtimeAnimatorController = Resources.Load("Pinky") as RuntimeAnimatorController;
        }*/
    }

    private void Eaten()
    {
        this.eaten = true;
        this.ghost.transform.position = this.ghost.startpos;
        this.gameObject.SetActive(false);
        Invoke(nameof(Disable), this.death);
        anim.SetBool("PelletEaten", false);
    }

    private void OnEnable()
    {
        this.ghost.movement.speedMultiplier = 0.5f;
        this.eaten = false;
        anim.SetBool("PelletEaten", true);
    }

    private void OnDisable()
    {
        this.ghost.movement.speedMultiplier = 1.0f;
        this.eaten = false;
        anim.SetBool("PelletEaten", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (this.enabled)
            {
                Eaten();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled)
        {
            Vector2 direction = Vector2.zero;
            float maxDistance = float.MinValue;

            foreach (Vector2 availableDirections in node.availableDirections)
            {
                Vector3 newPosition = this.transform.position + new Vector3(availableDirections.x, availableDirections.y, 0.0f);
                float distance = (this.ghost.target.position - newPosition).sqrMagnitude;
                if (distance > maxDistance)
                {
                    direction = availableDirections;
                    maxDistance = distance;
                }
            }

            this.ghost.movement.SetDirection(direction);
        }
    }
}
