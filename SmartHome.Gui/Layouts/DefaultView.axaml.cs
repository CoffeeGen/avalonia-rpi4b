using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using SmartHome.Gui.Events;

namespace SmartHome.Gui.Layouts;

public partial class DefaultView : UserControl
{
    private Carousel _carousel;

    private Point? _pointerStart;
    
    public DefaultView( )
    {
        InitializeComponent( );
        
        Touch.OnSwipe += TouchOnSwipe;
    }

    private void TouchOnSwipe( ESwipeDirection direction )
    {
        switch( direction )
        {
            case ESwipeDirection.Left:
                _carousel.Previous();
                break;
            
            case ESwipeDirection.Right:
                _carousel.Next();
                break;
        }
    }

    private void InitializeComponent( )
    {
        AvaloniaXamlLoader.Load( this );
        _carousel = this.FindControl<Carousel>("Carousel");
    }

    private void OnPointerPressed( object? sender, PointerPressedEventArgs e )
    {
        _pointerStart = e.GetPosition( null );
    }

    private void OnPointerReleased( object? sender, PointerReleasedEventArgs e )
    {
        if( _pointerStart == null )
            return;

        Point pointerEnd = e.GetPosition( null );

        if( _pointerStart?.X < pointerEnd.X - 75 )
            Touch.Swipe( ESwipeDirection.Left );
        else if( _pointerStart?.X > pointerEnd.X + 75 )
            Touch.Swipe( ESwipeDirection.Right );
        
        if( _pointerStart?.Y < pointerEnd.Y - 75 )
            Touch.Swipe( ESwipeDirection.Down );
        else if( _pointerStart?.Y > pointerEnd.Y - 75 )
            Touch.Swipe( ESwipeDirection.Up );

        _pointerStart = null;
    }
}