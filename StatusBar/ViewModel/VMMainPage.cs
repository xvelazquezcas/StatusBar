using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace StatusBar.ViewModel
{
    public class VMMainPage
    {
        public VMMainPage() 
        {
            
        }
        public void Ocultar()
        {
            DependencyService.Get<VMStatusBar>().OcultarStatusBar();
        }
        public void Mostrar()
        {
            DependencyService.Get<VMStatusBar>().MostarStatusBar();
        }
        public void Translucido()
        {
            DependencyService.Get<VMStatusBar>().Traslucido();
        }
        public void Transparente()
        {
            DependencyService.Get<VMStatusBar>().Transparente();
        }
        public void CambiarColor()
        {
            DependencyService.Get<VMStatusBar>().CambiarColor();
        }
        public ICommand OcultarCommand => new Command(Ocultar);
        public ICommand MostrarCommand => new Command(Mostrar);
        public ICommand TranslucidoCommand => new Command(Translucido);
        public ICommand TransparenteCommand => new Command(Transparente);
        public ICommand CambiarColorCommand => new Command(CambiarColor);
    }
}
