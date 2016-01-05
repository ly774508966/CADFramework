using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Enesy.CAD.Framework.Controls
{
    public class TextBoxWithHeight : TextBox
    {
        public bool isTextChanging = false;

        public TextBoxWithHeight()
        {
            base.AutoSize = false;
            base.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            // Call the base OnTextChanged method. 
            base.OnTextChanged(e);

            // Change the dirty flag to True.
            isTextChanging = true;
        }
    }
}
