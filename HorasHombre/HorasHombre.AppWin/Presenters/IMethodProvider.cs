using System;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Presenters
{
    public interface IMethodProvider
    {
        event EventHandler<EventArgs> ActiveAction;
        event EventHandler<EventArgs> CancelAction;
        event EventHandler<EventArgs> DeleteAction;
        event EventHandler<EventArgs> NewAction;
        event EventHandler<EventArgs> SaveAction;
        event EventHandler<EventArgs> ViewAction;
        event TabControlCancelEventHandler SelectingTabAction;
    }
}
