using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Pacman : MonoBehaviour
{
    public Movement movement { get; private set; }
    private bool facingLeft = false;

    private void Awake(){
        this.movement = GetComponent<Movement>();
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            this.movement.SetDirection(Vector2.up);
        }else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            this.movement.SetDirection(Vector2.down);
        }else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            this.movement.SetDirection(Vector2.left);
        }else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            this.movement.SetDirection(Vector2.right);
        }

        float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
        Debug.Log(angle);
        Debug.Log(facingLeft);
        if (angle == Mathf.PI && !facingLeft)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
            facingLeft = true;
        }
        else if (facingLeft && angle != Mathf.PI)
        {
            transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
            facingLeft = false;
        }
        else if (angle != Mathf.PI)
        {
            transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
            facingLeft = false;
        }
            
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();
    }
}
