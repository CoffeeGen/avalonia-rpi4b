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
            _ = Update( );
    }

    private Task Update( )
    {
        _cts = new CancellationTokenSource( );
        
        return Task.Run( async ( ) =>
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
    }

    protected virtual Task OnUpdate( )
    {
        return Task.CompletedTask;
    }

    protected virtual void OnUpdateMainThread( )
    {
    }

    public void Dispose( )
    {
        _cts?.Dispose( );
        GC.SuppressFinalize( this );
    }
}