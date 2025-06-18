using UnityEngine;

public class Dummies : MonoBehaviour
{
    public float width = 5f;
    public float height = 5f;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }
}
