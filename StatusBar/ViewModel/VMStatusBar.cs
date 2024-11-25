using System;
using System.Collections.Generic;
using System.Text;

namespace StatusBar.ViewModel
{
    public interface VMStatusBar
    {
        void OcultarStatusBar();
        void MostarStatusBar();
        void Traslucido();
        void Transparente();
        void CambiarColor();
    }
}
