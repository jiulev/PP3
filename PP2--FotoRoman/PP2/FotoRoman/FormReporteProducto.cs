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
            this.DoubleBuffered = true;
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
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int margenIzquierdo = 60;
            int margenInferior = 100;
            int alturaMaxima = 300;
            int anchoBarra = 40;
            int espacioEntreBarras = 30;

            Font font = new Font("Segoe UI", 8);
            Font fontEje = new Font("Segoe UI", 8, FontStyle.Bold);
            Font fontTitulo = new Font("Segoe UI", 14, FontStyle.Bold);

            int maximo = datosProductos.Max(dp => dp.CantidadVendida);
            int step = (int)Math.Ceiling(maximo / 5.0 / 10.0) * 10; // salto más "estético"

            Pen ejePen = new Pen(Color.DimGray, 1.5f);
            Pen guiaPen = new Pen(Color.LightGray) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };

            // Líneas guías horizontales
            for (int i = 0; i <= maximo; i += step)
            {
                int y = margenInferior + alturaMaxima - (int)((double)i / maximo * alturaMaxima);
                g.DrawLine(guiaPen, margenIzquierdo, y, margenIzquierdo + 700, y);
                g.DrawString(i.ToString(), fontEje, Brushes.Gray, 10, y - 7);
            }

            // Ejes
            g.DrawLine(ejePen, margenIzquierdo, margenInferior, margenIzquierdo, margenInferior + alturaMaxima);
            g.DrawLine(ejePen, margenIzquierdo, margenInferior + alturaMaxima, margenIzquierdo + 700, margenInferior + alturaMaxima);

            Brush[] brushes = new Brush[]
            {
        new SolidBrush(Color.FromArgb(72, 126, 176)), new SolidBrush(Color.FromArgb(243, 156, 18)),
        new SolidBrush(Color.FromArgb(46, 204, 113)), new SolidBrush(Color.FromArgb(155, 89, 182)),
        new SolidBrush(Color.FromArgb(230, 126, 34)), new SolidBrush(Color.FromArgb(231, 76, 60))
            };

            int xActual = margenIzquierdo + 20;
            int colorIndex = 0;

            foreach (var dato in datosProductos)
            {
                int alturaBarra = (int)((double)dato.CantidadVendida / maximo * alturaMaxima);
                Brush barraBrush = brushes[colorIndex % brushes.Length];

                Rectangle barra = new Rectangle(xActual, margenInferior + alturaMaxima - alturaBarra, anchoBarra, alturaBarra);
                g.FillRectangle(barraBrush, barra);

                // Bordes redondeados visuales (simulados con overlay más claro arriba)
                g.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.White)), barra.X, barra.Y, barra.Width, 5);

                // Nombre del producto (rotado si es muy largo)
                string nombre = dato.NombreProducto.Length > 10 ? dato.NombreProducto.Substring(0, 10) + "..." : dato.NombreProducto;
                SizeF textoSize = g.MeasureString(nombre, font);
                float xTexto = xActual + (anchoBarra / 2) - (textoSize.Width / 2);
                g.DrawString(nombre, font, Brushes.Black, xTexto, margenInferior + alturaMaxima + 5);

                // Valor encima
                string valorTexto = dato.CantidadVendida.ToString();
                SizeF valorSize = g.MeasureString(valorTexto, font);
                float xValor = xActual + (anchoBarra / 2) - (valorSize.Width / 2);
                g.DrawString(valorTexto, font, Brushes.Black, xValor, margenInferior + alturaMaxima - alturaBarra - 15);

                xActual += anchoBarra + espacioEntreBarras;
                colorIndex++;
            }

            // Título centrado
            string titulo = "Top 10 Productos Más Vendidos";
            SizeF tituloSize = g.MeasureString(titulo, fontTitulo);
            g.DrawString(titulo, fontTitulo, Brushes.Black, (this.Width - tituloSize.Width) / 2, 15);
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
