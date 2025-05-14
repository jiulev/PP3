using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FotoRoman
{
    public partial class FormReporteProducto : Form
    {
        private List<(string NombreProducto, int CantidadVendida)> datosProductos;
        private bool esPrimeraCarga = true;



        public FormReporteProducto()
        {
            InitializeComponent();
        }

        private void FormReporteProducto_Load(object sender, EventArgs e)
        {
            // Llenar el ComboBox de meses
            cmbMeses.Items.AddRange(new string[]
            {
        "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
        "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
            });

            cmbMeses.SelectedIndex = DateTime.Now.Month - 1; // Selecciona el mes actual por defecto

            // Llenar el ComboBox de años
            int anioActual = DateTime.Now.Year;
            for (int i = anioActual - 5; i <= anioActual; i++) // Últimos 5 años
            {
                comboBoxAnio.Items.Add(i);
            }
            comboBoxAnio.SelectedItem = anioActual; // Selecciona el año actual por defecto

            // Cargar datos iniciales
            CargarDatos(DateTime.Now.Month, anioActual);
            esPrimeraCarga = false; // Ahora cualquier cambio posterior ya no es "la primera vez"
        }

        private void CargarDatos(int mes, int anio)
        {
            try
            {
                datosProductos = CNProducto.ObtenerTop10ProductosPorMes(mes, anio);

                if ((datosProductos == null || datosProductos.Count == 0))
                {
                    // Solo mostrar el mensaje si NO es la primera carga
                    if (!esPrimeraCarga)
                    {
                        MessageBox.Show("No se encontraron productos más vendidos para el mes y año seleccionados.",
                                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                this.Invalidate(); // Redibuja el gráfico aunque esté vacío (por si antes mostraba algo)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void CargarGraficoProductos(int mes)
        {
            try
            {
                // Obtener el año seleccionado del ComboBox de años
                int anioSeleccionado = int.Parse(comboBoxAnio.SelectedItem.ToString());

                // Obtener los datos desde la Capa de Negocio con mes y año
                datosProductos = CNProducto.ObtenerTop10ProductosPorMes(mes, anioSeleccionado);

                if (datosProductos == null || datosProductos.Count == 0)
                {
                    MessageBox.Show("No se encontraron productos más vendidos para el mes y año seleccionados.",
                                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Forzar el redibujado del gráfico
                this.Refresh(); // Refresca todo el formulario
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void comboBoxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMeses.SelectedIndex >= 0 && comboBoxAnio.SelectedItem != null)
            {
                int mesSeleccionado = cmbMeses.SelectedIndex + 1; // Índice del mes (0 = Enero)
                int anioSeleccionado;

                // Validar que el año sea válido
                if (int.TryParse(comboBoxAnio.SelectedItem.ToString(), out anioSeleccionado))
                {
                    CargarDatos(mesSeleccionado, anioSeleccionado); // Llama a CargarDatos con mes y año
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un año válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
               // MessageBox.Show("Selecciona un mes y un año antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        private void FormReporteProducto_Paint(object sender, PaintEventArgs e)
        {
            if (datosProductos == null || datosProductos.Count == 0)
                return;

            Graphics g = e.Graphics;

            // Configuración inicial
            int margenIzquierdo = 50;
            int margenInferior = 100;
            int alturaMaxima = 300;
            int anchoBarra = 50;
            int espacioEntreBarras = 20;

            // Fuente común
            Font font = new Font("Arial", 8);

            // Buscar el valor máximo para escalar las barras
            int maximo = datosProductos.Max(dp => dp.CantidadVendida);

            // Dibujar líneas horizontales (guías)
            for (int i = 100; i <= maximo; i += 100)
            {
                int y = margenInferior + alturaMaxima - (int)((double)i / maximo * alturaMaxima);
                g.DrawLine(Pens.LightGray, margenIzquierdo, y, margenIzquierdo + 700, y);
                g.DrawString(i.ToString(), font, Brushes.Gray, 5, y - 7);
            }

            // Dibujar ejes X e Y
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, margenIzquierdo, margenInferior, margenIzquierdo, margenInferior + alturaMaxima);
            g.DrawLine(pen, margenIzquierdo, margenInferior + alturaMaxima, margenIzquierdo + 700, margenInferior + alturaMaxima);

            // Colores para las barras
            Brush[] brushes = new Brush[]
            {
        Brushes.SteelBlue, Brushes.OrangeRed, Brushes.MediumSeaGreen, Brushes.SlateBlue,
        Brushes.DarkCyan, Brushes.Tomato, Brushes.CadetBlue, Brushes.DarkOrange,
        Brushes.IndianRed, Brushes.MediumPurple
            };

            int colorIndex = 0;
            int xActual = margenIzquierdo + 20;

            foreach (var dato in datosProductos)
            {
                int alturaBarra = (int)((double)dato.CantidadVendida / maximo * alturaMaxima);

                // Dibujar barra
                Brush barraBrush = brushes[colorIndex % brushes.Length];
                g.FillRectangle(barraBrush, xActual, margenInferior + alturaMaxima - alturaBarra, anchoBarra, alturaBarra);

                // Truncar y centrar nombre
                string nombreCorto = dato.NombreProducto.Length > 8 ? dato.NombreProducto.Substring(0, 8) + "..." : dato.NombreProducto;
                SizeF textoSize = g.MeasureString(nombreCorto, font);
                float xTexto = xActual + (anchoBarra / 2) - (textoSize.Width / 2);
                g.DrawString(nombreCorto, font, Brushes.Black, xTexto, margenInferior + alturaMaxima + 5);

                // Valor encima de la barra
                string cantidadTexto = dato.CantidadVendida.ToString();
                SizeF cantidadSize = g.MeasureString(cantidadTexto, font);
                float xCantidad = xActual + (anchoBarra / 2) - (cantidadSize.Width / 2);
                g.DrawString(cantidadTexto, font, Brushes.Black, xCantidad, margenInferior + alturaMaxima - alturaBarra - 15);

                xActual += anchoBarra + espacioEntreBarras;
                colorIndex++;
            }

            // Título centrado
            string titulo = "Productos Más Vendidos";
            Font tituloFont = new Font("Arial", 12, FontStyle.Bold);
            SizeF tituloSize = g.MeasureString(titulo, tituloFont);
            float xTitulo = (this.Width / 2) - (tituloSize.Width / 2);
            g.DrawString(titulo, tituloFont, Brushes.Black, xTitulo, 10);
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mesSeleccionado = cmbMeses.SelectedIndex + 1; // Índice del mes
            int anioSeleccionado = int.Parse(comboBoxAnio.SelectedItem.ToString()); // Año seleccionado

            if (mesSeleccionado > 0 && mesSeleccionado <= 12)
            {
                CargarDatos(mesSeleccionado, anioSeleccionado); // Actualiza los datos
            }
        }
    }
}
