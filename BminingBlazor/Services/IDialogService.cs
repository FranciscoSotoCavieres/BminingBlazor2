using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BminingBlazor.Services
{
    public interface IDialogService
    {
        void ShowError(string message);
        void ShowNotification(string message);
        void ShowWarning(string message);
    }
}
