using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public Vector2 Move { get; private set; }


    // Update is called once per frame
    void Update()
    {
        Move = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );
    }
}
