using System.Windows.Forms;

namespace SimpleVectorGraphicViewer.Utils.Extensions
{
    internal static class FormExtensions
    {
        /// <summary>
        /// Invokes method/expression on Form's main thread when necessary
        /// </summary>
        /// <param name="form"></param>
        /// <param name="code"></param>
        internal static void UIThread(this Form form, MethodInvoker code)
        {
            if (form.InvokeRequired)
            {
                form.BeginInvoke(code);
                return;
            }

            code.Invoke();
        }
    }
}
