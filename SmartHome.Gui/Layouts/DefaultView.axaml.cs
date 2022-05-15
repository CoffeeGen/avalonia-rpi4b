using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        Touch.Swipe += TouchOnSwipe;
    }

    private void TouchOnSwipe( ESwipeDirection direction )
    {
        int oldViewId = _carousel.SelectedIndex;
        
        switch( direction )
        {
            case ESwipeDirection.Left:
                _carousel.Previous();
                break;
            
            case ESwipeDirection.Right:
                _carousel.Next();
                break;
        }

        int newViewId = _carousel.SelectedIndex;

        if( oldViewId != newViewId )
            View.OnChange( oldViewId, Default.Instance.Views[ oldViewId ], newViewId, Default.Instance.Views[ newViewId ] );
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
            Touch.OnSwipe( ESwipeDirection.Left );
        else if( _pointerStart?.X > pointerEnd.X + 75 )
            Touch.OnSwipe( ESwipeDirection.Right );
        
        if( _pointerStart?.Y < pointerEnd.Y - 75 )
            Touch.OnSwipe( ESwipeDirection.Down );
        else if( _pointerStart?.Y > pointerEnd.Y - 75 )
            Touch.OnSwipe( ESwipeDirection.Up );

        _pointerStart = null;
    }
}