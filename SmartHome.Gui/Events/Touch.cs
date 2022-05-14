namespace SmartHome.Gui.Events;

public enum ESwipeDirection
{
    Left,
    Right,
    Up,
    Down
}

public static class Touch
{
    #region OnSwipe

    public delegate void SwipeDelegate( ESwipeDirection direction );

    public static event SwipeDelegate OnSwipe;

    public static void Swipe( ESwipeDirection direction )
    {
        OnSwipe.Invoke( direction );
    }
    #endregion

}