using UnityEngine;

public class GhostScatter : GhostBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled && !this.ghost.run.enabled)
        {
            int index = Random.Range(0, node.availableDirections.Count);
            Debug.Log(node.availableDirections.Count);
            Debug.Log(index);
            if (node.availableDirections[index] == -this.ghost.movement.direction && node.availableDirections.Count > 0)
            {
                index++;
                if (index >= node.availableDirections.Count)
                {
                    index = 0;
                }
            }

            this.ghost.movement.SetDirection(node.availableDirections[index]);
        }
    }
}
