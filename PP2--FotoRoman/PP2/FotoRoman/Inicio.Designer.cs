namespace FotoRoman
{
    partial class Inicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menu = new MenuStrip();
            menuusuario = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem18 = new FontAwesome.Sharp.IconMenuItem();
            consultarVendedor = new FontAwesome.Sharp.IconMenuItem();
            menupedidos = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem3 = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem4 = new FontAwesome.Sharp.IconMenuItem();
            menupagos = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem5 = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem6 = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem7 = new FontAwesome.Sharp.IconMenuItem();
            menuclientes = new FontAwesome.Sharp.IconMenuItem();
            RegistrarCliente = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem11 = new FontAwesome.Sharp.IconMenuItem();
            menuproductos = new FontAwesome.Sharp.IconMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            iconMenuItem15 = new FontAwesome.Sharp.IconMenuItem();
            verCategoriaToolStripMenuItem = new ToolStripMenuItem();
            menureportes = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem22 = new FontAwesome.Sharp.IconMenuItem();
            reporteProducto = new ToolStripMenuItem();
            listadoDePedidosPorClientesToolStripMenuItem = new ToolStripMenuItem();
            menuacercade = new FontAwesome.Sharp.IconMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            menutitulo = new MenuStrip();
            label1 = new Label();
            contenedor = new Panel();
            buttonCerrarSesion = new Button();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // menu
            // 
            menu.Items.AddRange(new ToolStripItem[] { menuusuario, menupedidos, menupagos, menuclientes, menuproductos, menureportes, menuacercade });
            menu.Location = new Point(0, 59);
            menu.Name = "menu";
            menu.Size = new Size(800, 73);
            menu.TabIndex = 0;
            menu.Text = "menuStrip1";
            // 
            // menuusuario
            // 
            menuusuario.AutoSize = false;
            menuusuario.DropDownItems.AddRange(new ToolStripItem[] { iconMenuItem18, consultarVendedor });
            menuusuario.Font = new Font("Yu Gothic", 9F);
            menuusuario.IconChar = FontAwesome.Sharp.IconChar.Users;
            menuusuario.IconColor = Color.Black;
            menuusuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuusuario.IconSize = 50;
            menuusuario.ImageScaling = ToolStripItemImageScaling.None;
            menuusuario.Name = "menuusuario";
            menuusuario.Size = new Size(80, 69);
            menuusuario.Text = "Usuario";
            menuusuario.TextImageRelation = TextImageRelation.ImageAboveText;
            menuusuario.Click += menuusuario_Click;
            // 
            // iconMenuItem18
            // 
            iconMenuItem18.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem18.IconColor = Color.Black;
            iconMenuItem18.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem18.Name = "iconMenuItem18";
            iconMenuItem18.Size = new Size(180, 22);
            iconMenuItem18.Text = "Registrar usuario";
            iconMenuItem18.Click += crearUsuario;
            // 
            // consultarVendedor
            // 
            consultarVendedor.IconChar = FontAwesome.Sharp.IconChar.None;
            consultarVendedor.IconColor = Color.Black;
            consultarVendedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            consultarVendedor.Name = "consultarVendedor";
            consultarVendedor.Size = new Size(180, 22);
            consultarVendedor.Text = "Consultar Usuario";
            consultarVendedor.Click += iconMenuItem21_Click;
            // 
            // menupedidos
            // 
            menupedidos.AutoSize = false;
            menupedidos.DropDownItems.AddRange(new ToolStripItem[] { iconMenuItem1, iconMenuItem3, iconMenuItem4 });
            menupedidos.Font = new Font("Yu Gothic", 9F);
            menupedidos.IconChar = FontAwesome.Sharp.IconChar.Tags;
            menupedidos.IconColor = Color.Black;
            menupedidos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menupedidos.IconSize = 50;
            menupedidos.ImageScaling = ToolStripItemImageScaling.None;
            menupedidos.Name = "menupedidos";
            menupedidos.Size = new Size(80, 69);
            menupedidos.Text = "Pedidos";
            menupedidos.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // iconMenuItem1
            // 
            iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem1.IconColor = Color.Black;
            iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem1.Name = "iconMenuItem1";
            iconMenuItem1.Size = new Size(180, 22);
            iconMenuItem1.Text = "Crear Pedido";
            iconMenuItem1.Click += iconMenuItem1_Click;
            // 
            // iconMenuItem3
            // 
            iconMenuItem3.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem3.IconColor = Color.Black;
            iconMenuItem3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem3.Name = "iconMenuItem3";
            iconMenuItem3.Size = new Size(180, 22);
            iconMenuItem3.Text = "Eliminar Pedido";
            // 
            // iconMenuItem4
            // 
            iconMenuItem4.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem4.IconColor = Color.Black;
            iconMenuItem4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem4.Name = "iconMenuItem4";
            iconMenuItem4.Size = new Size(180, 22);
            iconMenuItem4.Text = "Ver Pedido";
            iconMenuItem4.Click += iconMenuItem4_Click;
            // 
            // menupagos
            // 
            menupagos.AutoSize = false;
            menupagos.DropDownItems.AddRange(new ToolStripItem[] { iconMenuItem5, iconMenuItem6, iconMenuItem7 });
            menupagos.Font = new Font("Yu Gothic", 9F);
            menupagos.IconChar = FontAwesome.Sharp.IconChar.MoneyBill;
            menupagos.IconColor = Color.Black;
            menupagos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menupagos.IconSize = 50;
            menupagos.ImageScaling = ToolStripItemImageScaling.None;
            menupagos.Name = "menupagos";
            menupagos.Size = new Size(80, 69);
            menupagos.Text = "Cobranzas";
            menupagos.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // iconMenuItem5
            // 
            iconMenuItem5.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem5.IconColor = Color.Black;
            iconMenuItem5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem5.Name = "iconMenuItem5";
            iconMenuItem5.Size = new Size(163, 22);
            iconMenuItem5.Text = "Registrar Cobro";
            // 
            // iconMenuItem6
            // 
            iconMenuItem6.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem6.IconColor = Color.Black;
            iconMenuItem6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem6.Name = "iconMenuItem6";
            iconMenuItem6.Size = new Size(163, 22);
            iconMenuItem6.Text = "Editar Cobro";
            iconMenuItem6.Click += iconMenuItem6_Click;
            // 
            // iconMenuItem7
            // 
            iconMenuItem7.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem7.IconColor = Color.Black;
            iconMenuItem7.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem7.Name = "iconMenuItem7";
            iconMenuItem7.Size = new Size(163, 22);
            iconMenuItem7.Text = "Consultar Cobro";
            iconMenuItem7.Click += iconMenuItem7_Click;
            // 
            // menuclientes
            // 
            menuclientes.AutoSize = false;
            menuclientes.DropDownItems.AddRange(new ToolStripItem[] { RegistrarCliente, iconMenuItem11 });
            menuclientes.Font = new Font("Yu Gothic", 9F);
            menuclientes.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            menuclientes.IconColor = Color.Black;
            menuclientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuclientes.IconSize = 50;
            menuclientes.ImageScaling = ToolStripItemImageScaling.None;
            menuclientes.Name = "menuclientes";
            menuclientes.Size = new Size(80, 69);
            menuclientes.Text = "Clientes";
            menuclientes.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // RegistrarCliente
            // 
            RegistrarCliente.IconChar = FontAwesome.Sharp.IconChar.None;
            RegistrarCliente.IconColor = Color.Black;
            RegistrarCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            RegistrarCliente.Name = "RegistrarCliente";
            RegistrarCliente.Size = new Size(169, 22);
            RegistrarCliente.Text = "Registrar Cliente";
            RegistrarCliente.Click += iconMenuItem8_Click;
            // 
            // iconMenuItem11
            // 
            iconMenuItem11.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem11.IconColor = Color.Black;
            iconMenuItem11.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem11.Name = "iconMenuItem11";
            iconMenuItem11.Size = new Size(169, 22);
            iconMenuItem11.Text = "Consultar Cliente";
            iconMenuItem11.Click += iconMenuItem11_Click;
            // 
            // menuproductos
            // 
            menuproductos.AutoSize = false;
            menuproductos.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem5, iconMenuItem15, verCategoriaToolStripMenuItem });
            menuproductos.Font = new Font("Yu Gothic", 9F);
            menuproductos.IconChar = FontAwesome.Sharp.IconChar.ProductHunt;
            menuproductos.IconColor = Color.Black;
            menuproductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuproductos.IconSize = 50;
            menuproductos.ImageScaling = ToolStripItemImageScaling.None;
            menuproductos.Name = "menuproductos";
            menuproductos.Size = new Size(122, 69);
            menuproductos.Text = "Productos";
            menuproductos.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(181, 22);
            toolStripMenuItem1.Text = "Registrar producto";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(181, 22);
            toolStripMenuItem5.Text = "Ver Producto";
            toolStripMenuItem5.Click += toolStripMenuItem5_Click;
            // 
            // iconMenuItem15
            // 
            iconMenuItem15.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem15.IconColor = Color.Black;
            iconMenuItem15.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem15.Name = "iconMenuItem15";
            iconMenuItem15.Size = new Size(181, 22);
            iconMenuItem15.Text = "Registrar Categoria";
            iconMenuItem15.Click += iconMenuItem15_Click;
            // 
            // verCategoriaToolStripMenuItem
            // 
            verCategoriaToolStripMenuItem.Name = "verCategoriaToolStripMenuItem";
            verCategoriaToolStripMenuItem.Size = new Size(181, 22);
            verCategoriaToolStripMenuItem.Text = "Ver Categoria";
            verCategoriaToolStripMenuItem.Click += verCategoriaToolStripMenuItem_Click;
            // 
            // menureportes
            // 
            menureportes.AutoSize = false;
            menureportes.DropDownItems.AddRange(new ToolStripItem[] { iconMenuItem22, reporteProducto, listadoDePedidosPorClientesToolStripMenuItem });
            menureportes.Font = new Font("Yu Gothic", 9F);
            menureportes.IconChar = FontAwesome.Sharp.IconChar.Tasks;
            menureportes.IconColor = Color.Black;
            menureportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menureportes.IconSize = 50;
            menureportes.ImageScaling = ToolStripItemImageScaling.None;
            menureportes.Name = "menureportes";
            menureportes.Size = new Size(80, 69);
            menureportes.Text = "Reportes";
            menureportes.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // iconMenuItem22
            // 
            iconMenuItem22.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem22.IconColor = Color.Black;
            iconMenuItem22.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem22.Name = "iconMenuItem22";
            iconMenuItem22.Size = new Size(267, 22);
            iconMenuItem22.Text = "Reportes de Pedidos Por Vendedor";
            iconMenuItem22.Click += iconMenuItem22_Click;
            // 
            // reporteProducto
            // 
            reporteProducto.Name = "reporteProducto";
            reporteProducto.Size = new Size(267, 22);
            reporteProducto.Text = "Productos Más Vendidos";
            reporteProducto.Click += reporteProducto_Click;
            // 
            // listadoDePedidosPorClientesToolStripMenuItem
            // 
            listadoDePedidosPorClientesToolStripMenuItem.Name = "listadoDePedidosPorClientesToolStripMenuItem";
            listadoDePedidosPorClientesToolStripMenuItem.Size = new Size(267, 22);
            listadoDePedidosPorClientesToolStripMenuItem.Text = "Reportes de Pedidos por Clientes";
            listadoDePedidosPorClientesToolStripMenuItem.Click += listadoDePedidosPorClientesToolStripMenuItem_Click;
            // 
            // menuacercade
            // 
            menuacercade.AutoSize = false;
            menuacercade.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2 });
            menuacercade.Font = new Font("Yu Gothic", 9F);
            menuacercade.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            menuacercade.IconColor = Color.Black;
            menuacercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuacercade.IconSize = 50;
            menuacercade.ImageScaling = ToolStripItemImageScaling.None;
            menuacercade.Name = "menuacercade";
            menuacercade.Size = new Size(80, 69);
            menuacercade.Text = "Acerca De";
            menuacercade.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(131, 22);
            toolStripMenuItem2.Text = "System JS";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // menutitulo
            // 
            menutitulo.AutoSize = false;
            menutitulo.BackColor = Color.Firebrick;
            menutitulo.Location = new Point(0, 0);
            menutitulo.Name = "menutitulo";
            menutitulo.RightToLeft = RightToLeft.Yes;
            menutitulo.Size = new Size(800, 59);
            menutitulo.TabIndex = 1;
            menutitulo.Text = "menuStrip2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Firebrick;
            label1.Font = new Font("Yu Gothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(8, 8);
            label1.Name = "label1";
            label1.Size = new Size(235, 38);
            label1.TabIndex = 2;
            label1.Text = "Pedidos Román";
            // 
            // contenedor
            // 
            contenedor.Dock = DockStyle.Fill;
            contenedor.Location = new Point(0, 132);
            contenedor.Name = "contenedor";
            contenedor.Size = new Size(800, 318);
            contenedor.TabIndex = 3;
            // 
            // buttonCerrarSesion
            // 
            buttonCerrarSesion.BackColor = Color.LightGray;
            buttonCerrarSesion.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCerrarSesion.Location = new Point(657, 24);
            buttonCerrarSesion.Name = "buttonCerrarSesion";
            buttonCerrarSesion.Size = new Size(131, 32);
            buttonCerrarSesion.TabIndex = 4;
            buttonCerrarSesion.Text = "Cerrar Sesión ";
            buttonCerrarSesion.UseVisualStyleBackColor = false;
            buttonCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonCerrarSesion);
            Controls.Add(contenedor);
            Controls.Add(label1);
            Controls.Add(menu);
            Controls.Add(menutitulo);
            MainMenuStrip = menu;
            Name = "Inicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu Principal";
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menu;
        private MenuStrip menutitulo;
        private Label label1;
        private FontAwesome.Sharp.IconMenuItem menuusuario;
        private FontAwesome.Sharp.IconMenuItem menupedidos;
        private FontAwesome.Sharp.IconMenuItem menupagos;
        private FontAwesome.Sharp.IconMenuItem menuclientes;
        private FontAwesome.Sharp.IconMenuItem menuproductos;
        private FontAwesome.Sharp.IconMenuItem menuacercade;
        private FontAwesome.Sharp.IconMenuItem menureportes;
        private Panel contenedor;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem3;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem4;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem5;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem6;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem7;
        private FontAwesome.Sharp.IconMenuItem RegistrarCliente;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem11;
        private ToolStripMenuItem toolStripMenuItem1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem15;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem18;
        private FontAwesome.Sharp.IconMenuItem consultarVendedor;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem22;
        private ToolStripMenuItem toolStripMenuItem2;
        private Button buttonCerrarSesion;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem verCategoriaToolStripMenuItem;
        private ToolStripMenuItem reporteProducto;
        private ToolStripMenuItem listadoDePedidosPorClientesToolStripMenuItem;
    }
}
