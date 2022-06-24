using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Threading;
using ReactiveUI;
using SmartHome.Gui.Interfaces;

namespace SmartHome.Gui.Layouts;

public abstract class ModelBase : ReactiveObject, IModelBase, IDisposable
{
    private CancellationTokenSource? _cts;
    
    public virtual IControl? Control { get; set; }

    protected ModelBase( )
    {
        if( this is IUpdatable )
            Update( );
    }

    private void Update( )
    {
        _cts = new CancellationTokenSource( );
        
        _ = Task.Run( async ( ) =>
        {
            while( true )
            {
                if( _cts.IsCancellationRequested )
                    break;

                _ = Dispatcher.UIThread.InvokeAsync( OnUpdateMainThread );
                
                _ = OnUpdate( );

                await Task.Delay( 1000, _cts.Token );
            }
            
        }, _cts.Token );
        
        _ = Task.Run( async ( ) =>
        {
            while( true )
            {
                if( _cts.IsCancellationRequested )
                    break;

                _ = Dispatcher.UIThread.InvokeAsync( OnUpdateMainThread100ms );
                
                _ = OnUpdate100ms( );

                await Task.Delay( 100, _cts.Token );
            }
            
        }, _cts.Token );
    }

    protected virtual Task OnUpdate( )
    {
        return Task.CompletedTask;
    }
    
    protected virtual Task OnUpdate100ms( )
    {
        return Task.CompletedTask;
    }

    protected virtual void OnUpdateMainThread( )
    {
    }

    protected virtual void OnUpdateMainThread100ms( )
    {
    }

    public void Dispose( )
    {
        _cts?.Dispose( );
        GC.SuppressFinalize( this );
    }
}