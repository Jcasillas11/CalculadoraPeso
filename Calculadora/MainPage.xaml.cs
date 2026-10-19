namespace Calculadora
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCalcularClicked(object sender, EventArgs e)
        {
            try
            {
                // 1. Convertimos los textos ingresados a número double
                double peso = Convert.ToDouble(PesoEntry.Text);
                double altura = Convert.ToDouble(AlturaEntry.Text);

                // 2. Comprobamos que sean mayores que cero
                if (peso > 0 && altura > 0)
                {
                    // Cálculo de la fórmula IMC
                    double imc = peso / (altura * altura);
                    ResultadoLabel.Text = $"Tu IMC es: {imc:F2}";

                    // Clasificación por rangos y cambio de imagen
                    if (imc < 18.5)
                    {
                        CategoriaLabel.Text = "Categoría: DELGADO";
                        ImagenImage.Source = "delgado.png";
                    }
                    else if (imc <= 24.9)
                    {
                        CategoriaLabel.Text = "Categoría: NORMAL";
                        ImagenImage.Source = "normal.png";
                    }
                    else if (imc <= 29.9)
                    {
                        CategoriaLabel.Text = "Categoría: SOBREPESO";
                        ImagenImage.Source = "sobrepeso.png";
                    }
                    else
                    {
                        CategoriaLabel.Text = "Categoría: OBESIDAD";
                        ImagenImage.Source = "obesidad.png";
                    }
                }
                else
                {
                    // Si introduce ceros o números negativos
                    await DisplayAlert("Error", "Los datos deben ser mayores que cero.", "OK");
                }
            }
            catch
            {
                // Si la casilla está vacía o el usuario escribe letras
                await DisplayAlert("Error", "Por favor ingresa números válidos.", "OK");
            }
        }
    }
}