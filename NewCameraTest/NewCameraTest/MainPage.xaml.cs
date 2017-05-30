using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NewCameraTest
{
	public partial class MainPage : ContentPage
	{
        public ICommand TirarFotoCommand { get; set; }
        public ImageSource foto = "foto.png"; 
        public ImageSource Foto {
            get
            {
                return foto;
            }
            set
            {
                foto = value;
                OnPropertyChanged();
            }
        }        

        public MainPage()
		{
			InitializeComponent();
            this.TirarFotoCommand = new Command(() =>
            {
                DependencyService.Get<ICamera>().tirarFoto();
            });
            MessagingCenter.Subscribe<byte[]>(this,"FotoTirada",
                (bytes) =>
                {
                    Foto = ImageSource.FromStream(
                        () => new MemoryStream(bytes));
                });
            this.BindingContext = this;
        }
	}
}
