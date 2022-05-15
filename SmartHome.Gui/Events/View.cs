using SmartHome.Gui.Layouts;

namespace SmartHome.Gui.Events;

public static class View
{
    #region OnChange

    public delegate void ChangeDelegate( int oldViewId, ModelBase oldView, int newViewId, ModelBase newView );

    public static event ChangeDelegate Change;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="oldViewId"></param>
    /// <param name="oldView"></param>
    /// <param name="newViewId"></param>
    /// <param name="newView"></param>
    public static void OnChange( int oldViewId, ModelBase oldView, int newViewId, ModelBase newView )
    {
        Change.Invoke( oldViewId, oldView, newViewId, newView );
    }
    #endregion

}