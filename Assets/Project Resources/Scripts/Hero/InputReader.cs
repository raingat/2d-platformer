using UnityEngine;

public class InputReader
{
    private readonly string Horizontal = nameof(Horizontal);
    private readonly KeyCode ButtonForJump = KeyCode.Space;

    public float GetHorizontalDirection()
    {
        return Input.GetAxis(Horizontal);
    }

    public bool IsJump()
    {
        return Input.GetKeyDown(ButtonForJump);
    }
}
