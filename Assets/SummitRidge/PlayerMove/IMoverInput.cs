namespace SummitRidge.PlayerMove
{
    public interface IMoverInput
    {
        float Horizontal();
        float Vertical();
        bool IsJump();
        bool IsCrouch();
    }
}