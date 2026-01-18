using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private PlayerInput input;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 dir = input.Move;
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
}
