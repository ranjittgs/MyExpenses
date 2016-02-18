using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Popups;

namespace MyExpenses.Utilities
{
    class CommonPopup
    {
        public static async void OpenMessageDialog(string content, string title, string buttonLabel, string buttonLabel2,
      UICommandInvokedHandler CommandInvokedHandler)
        {
            try
            {
                var messageDialog = new MessageDialog(content, title);
                messageDialog.Commands.Add(new UICommand(buttonLabel, CommandInvokedHandler));
                if (!string.IsNullOrEmpty(buttonLabel2))
                    messageDialog.Commands.Add(new UICommand(buttonLabel2, CommandInvokedHandler));
                await messageDialog.ShowAsync();
            }
            catch { }
        }
    }
}
