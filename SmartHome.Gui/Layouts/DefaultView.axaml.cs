using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using SmartHome.Core.Gpio;
using SmartHome.Gui.Events;

namespace SmartHome.Gui.Layouts;

public partial class DefaultView : UserControl
{
    private Carousel _carousel;

    private Point? _pointerStart;

    private CancellationTokenSource? _cts;
    private int _screenTimeoutMs = 5000;

    public DefaultView( )
    {
        InitializeComponent( );
        Touch.Swipe += TouchOnSwipe;

        // ScreenTimeout( );
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

    private Task ScreenTimeout( )
    {
        _cts = new CancellationTokenSource( );

        return Task.Run( async ( ) =>
        {
            await Task.Delay( _screenTimeoutMs, _cts.Token );

            if( _cts.IsCancellationRequested )
                return;
            
            Backlight.Off( );

        }, _cts.Token );
    }
    
    private async void OnPointerPressed( object? sender, PointerPressedEventArgs e )
    {
        if( !await Backlight.State( ) )
        {
            _cts?.Cancel();
            // _ = ScreenTimeout( );
            // Backlight.On( );
        }
        
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