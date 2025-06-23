using DocumentFormat.OpenXml.Spreadsheet;
using System.Windows.Forms;

namespace FormularioExcel
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cbbArea = new System.Windows.Forms.ComboBox();
            this.cbbOficina = new System.Windows.Forms.ComboBox();
            this.cbbDirEncargo = new System.Windows.Forms.ComboBox();
            this.cbbResTec = new System.Windows.Forms.ComboBox();
            this.cbbCordProy = new System.Windows.Forms.ComboBox();
            this.cbbRespMon = new System.Windows.Forms.ComboBox();
            this.cbbSolicitud = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbNumProyecto = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxCliente = new System.Windows.Forms.CheckBox();
            this.cbxFaltaInf = new System.Windows.Forms.CheckBox();
            this.cbxErrTecnico = new System.Windows.Forms.CheckBox();
            this.cbxErrModelado = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNumPlanosProyecto = new System.Windows.Forms.TextBox();
            this.txtNumPlanosEntrega = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbbTipoEntrega = new System.Windows.Forms.ComboBox();
            this.txtComentarios = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(602, 415);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(684, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // cbbArea
            // 
            this.cbbArea.AutoCompleteCustomSource.AddRange(new string[] {
            "Industria",
            "GHI",
            "Edificacion"});
            this.cbbArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbbArea.FormattingEnabled = true;
            this.cbbArea.Items.AddRange(new object[] {
            "Industria",
            "Edificacion",
            "GHI",
            "Medio Ambiente",
            "Renovables"});
            this.cbbArea.Location = new System.Drawing.Point(54, 23);
            this.cbbArea.Name = "cbbArea";
            this.cbbArea.Size = new System.Drawing.Size(97, 21);
            this.cbbArea.TabIndex = 4;
            this.cbbArea.SelectedIndexChanged += new System.EventHandler(this.cbbArea_SelectedIndexChanged);
            // 
            // cbbOficina
            // 
            this.cbbOficina.AutoCompleteCustomSource.AddRange(new string[] {
            "Valencia",
            "Madrid",
            "Sevilla"});
            this.cbbOficina.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbOficina.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbbOficina.FormattingEnabled = true;
            this.cbbOficina.Items.AddRange(new object[] {
            "Valencia",
            "Madrid",
            "Sevilla"});
            this.cbbOficina.Location = new System.Drawing.Point(268, 24);
            this.cbbOficina.Name = "cbbOficina";
            this.cbbOficina.Size = new System.Drawing.Size(97, 21);
            this.cbbOficina.TabIndex = 4;
            // 
            // cbbDirEncargo
            // 
            this.cbbDirEncargo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbDirEncargo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbbDirEncargo.FormattingEnabled = true;
            this.cbbDirEncargo.Location = new System.Drawing.Point(156, 133);
            this.cbbDirEncargo.Name = "cbbDirEncargo";
            this.cbbDirEncargo.Size = new System.Drawing.Size(148, 21);
            this.cbbDirEncargo.TabIndex = 4;
            this.cbbDirEncargo.SelectedIndexChanged += new System.EventHandler(this.cbbDirEncargo_SelectedIndexChanged);
            // 
            // cbbResTec
            // 
            this.cbbResTec.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbResTec.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbbResTec.FormattingEnabled = true;
            this.cbbResTec.Location = new System.Drawing.Point(156, 174);
            this.cbbResTec.Name = "cbbResTec";
            this.cbbResTec.Size = new System.Drawing.Size(148, 21);
            this.cbbResTec.TabIndex = 4;
            // 
            // cbbCordProy
            // 
            this.cbbCordProy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbCordProy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbbCordProy.FormattingEnabled = true;
            this.cbbCordProy.Location = new System.Drawing.Point(571, 134);
            this.cbbCordProy.Name = "cbbCordProy";
            this.cbbCordProy.Size = new System.Drawing.Size(188, 21);
            this.cbbCordProy.TabIndex = 4;
            // 
            // cbbRespMon
            // 
            this.cbbRespMon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbRespMon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbbRespMon.FormattingEnabled = true;
            this.cbbRespMon.Location = new System.Drawing.Point(571, 174);
            this.cbbRespMon.Name = "cbbRespMon";
            this.cbbRespMon.Size = new System.Drawing.Size(188, 21);
            this.cbbRespMon.TabIndex = 4;
            // 
            // cbbSolicitud
            // 
            this.cbbSolicitud.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbSolicitud.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbbSolicitud.FormattingEnabled = true;
            this.cbbSolicitud.Location = new System.Drawing.Point(571, 98);
            this.cbbSolicitud.Name = "cbbSolicitud";
            this.cbbSolicitud.Size = new System.Drawing.Size(188, 21);
            this.cbbSolicitud.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Area";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(205, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Oficina";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Director de Encargo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Responsable Técnico";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(396, 134);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(158, 16);
            this.Label5.TabIndex = 6;
            this.Label5.Text = "Coordinador de Proyecto";
            this.Label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(396, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Responsable de modelado";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(396, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Solicitado por:";
            // 
            // cbbNumProyecto
            // 
            this.cbbNumProyecto.AutoCompleteCustomSource.AddRange(new string[] {
            "Valencia",
            "Madrid",
            "Sevilla"});
            this.cbbNumProyecto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbNumProyecto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbbNumProyecto.FormattingEnabled = true;
            this.cbbNumProyecto.Location = new System.Drawing.Point(156, 94);
            this.cbbNumProyecto.Name = "cbbNumProyecto";
            this.cbbNumProyecto.Size = new System.Drawing.Size(148, 21);
            this.cbbNumProyecto.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "N. de Proyecto";
            // 
            // txtFecha
            // 
            this.txtFecha.AutoSize = true;
            this.txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(693, 23);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(0, 16);
            this.txtFecha.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 16);
            this.label10.TabIndex = 6;
            this.label10.Text = "Motivo del cambio";
            // 
            // cbxCliente
            // 
            this.cbxCliente.AutoSize = true;
            this.cbxCliente.Location = new System.Drawing.Point(14, 38);
            this.cbxCliente.Name = "cbxCliente";
            this.cbxCliente.Size = new System.Drawing.Size(77, 17);
            this.cbxCliente.TabIndex = 7;
            this.cbxCliente.Text = "Por Cliente";
            this.cbxCliente.UseVisualStyleBackColor = true;
            // 
            // cbxFaltaInf
            // 
            this.cbxFaltaInf.AutoSize = true;
            this.cbxFaltaInf.Location = new System.Drawing.Point(100, 38);
            this.cbxFaltaInf.Name = "cbxFaltaInf";
            this.cbxFaltaInf.Size = new System.Drawing.Size(137, 17);
            this.cbxFaltaInf.TabIndex = 7;
            this.cbxFaltaInf.Text = "Por falta de informacion";
            this.cbxFaltaInf.UseVisualStyleBackColor = true;
            // 
            // cbxErrTecnico
            // 
            this.cbxErrTecnico.AutoSize = true;
            this.cbxErrTecnico.Location = new System.Drawing.Point(13, 61);
            this.cbxErrTecnico.Name = "cbxErrTecnico";
            this.cbxErrTecnico.Size = new System.Drawing.Size(90, 17);
            this.cbxErrTecnico.TabIndex = 7;
            this.cbxErrTecnico.Text = "Error Tecnico";
            this.cbxErrTecnico.UseVisualStyleBackColor = true;
            // 
            // cbxErrModelado
            // 
            this.cbxErrModelado.AutoSize = true;
            this.cbxErrModelado.Location = new System.Drawing.Point(99, 61);
            this.cbxErrModelado.Name = "cbxErrModelado";
            this.cbxErrModelado.Size = new System.Drawing.Size(112, 17);
            this.cbxErrModelado.TabIndex = 7;
            this.cbxErrModelado.Text = "Error de modelado";
            this.cbxErrModelado.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.cbxErrModelado);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cbxErrTecnico);
            this.panel1.Controls.Add(this.cbxCliente);
            this.panel1.Controls.Add(this.cbxFaltaInf);
            this.panel1.Location = new System.Drawing.Point(12, 220);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 100);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.txtNumPlanosProyecto);
            this.panel2.Controls.Add(this.txtNumPlanosEntrega);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.dtpFechaEntrega);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.cbbTipoEntrega);
            this.panel2.Location = new System.Drawing.Point(268, 220);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(488, 100);
            this.panel2.TabIndex = 8;
            // 
            // txtNumPlanosProyecto
            // 
            this.txtNumPlanosProyecto.Location = new System.Drawing.Point(376, 57);
            this.txtNumPlanosProyecto.Name = "txtNumPlanosProyecto";
            this.txtNumPlanosProyecto.Size = new System.Drawing.Size(109, 20);
            this.txtNumPlanosProyecto.TabIndex = 9;
            // 
            // txtNumPlanosEntrega
            // 
            this.txtNumPlanosEntrega.Location = new System.Drawing.Point(264, 57);
            this.txtNumPlanosEntrega.Name = "txtNumPlanosEntrega";
            this.txtNumPlanosEntrega.Size = new System.Drawing.Size(109, 20);
            this.txtNumPlanosEntrega.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(384, 8);
            this.label12.MaximumSize = new System.Drawing.Size(100, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 32);
            this.label12.TabIndex = 6;
            this.label12.Text = "N. de planos en proyecto";
            // 
            // dtpFechaEntrega
            // 
            this.dtpFechaEntrega.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaEntrega.Location = new System.Drawing.Point(9, 57);
            this.dtpFechaEntrega.MinDate = new System.DateTime(2024, 7, 18, 0, 0, 0, 0);
            this.dtpFechaEntrega.Name = "dtpFechaEntrega";
            this.dtpFechaEntrega.Size = new System.Drawing.Size(129, 20);
            this.dtpFechaEntrega.TabIndex = 8;
            this.dtpFechaEntrega.Value = new System.DateTime(2024, 7, 18, 20, 23, 2, 0);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(270, 8);
            this.label11.MaximumSize = new System.Drawing.Size(100, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 32);
            this.label11.TabIndex = 6;
            this.label11.Text = "N. de planos a entregar";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(21, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 16);
            this.label13.TabIndex = 6;
            this.label13.Text = "Fecha de entrega";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(150, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "Tipo de entrega";
            // 
            // cbbTipoEntrega
            // 
            this.cbbTipoEntrega.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbTipoEntrega.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbbTipoEntrega.FormattingEnabled = true;
            this.cbbTipoEntrega.Items.AddRange(new object[] {
            "Parcial",
            "Total"});
            this.cbbTipoEntrega.Location = new System.Drawing.Point(144, 57);
            this.cbbTipoEntrega.Name = "cbbTipoEntrega";
            this.cbbTipoEntrega.Size = new System.Drawing.Size(114, 21);
            this.cbbTipoEntrega.TabIndex = 4;
            // 
            // txtComentarios
            // 
            this.txtComentarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComentarios.Location = new System.Drawing.Point(12, 344);
            this.txtComentarios.Multiline = true;
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.Size = new System.Drawing.Size(746, 65);
            this.txtComentarios.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 450);
            this.Controls.Add(this.txtComentarios);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbCordProy);
            this.Controls.Add(this.cbbRespMon);
            this.Controls.Add(this.cbbResTec);
            this.Controls.Add(this.cbbNumProyecto);
            this.Controls.Add(this.cbbDirEncargo);
            this.Controls.Add(this.cbbOficina);
            this.Controls.Add(this.cbbSolicitud);
            this.Controls.Add(this.cbbArea);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAceptar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox cbbArea;
        private System.Windows.Forms.ComboBox cbbOficina;
        private System.Windows.Forms.ComboBox cbbDirEncargo;
        private System.Windows.Forms.ComboBox cbbResTec;
        private System.Windows.Forms.ComboBox cbbCordProy;
        private System.Windows.Forms.ComboBox cbbRespMon;
        private System.Windows.Forms.ComboBox cbbSolicitud;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ComboBox cbbNumProyecto;
        private Label label8;
        private Label txtFecha;
        private Label label10;
        private CheckBox cbxCliente;
        private CheckBox cbxFaltaInf;
        private CheckBox cbxErrTecnico;
        private CheckBox cbxErrModelado;
        private Panel panel1;
        private Panel panel2;
        private Label label11;
        private Label label9;
        private ComboBox cbbTipoEntrega;
        private Label label12;
        private Label label13;
        private DateTimePicker dtpFechaEntrega;
        private TextBox txtComentarios;
        private TextBox txtNumPlanosProyecto;
        private TextBox txtNumPlanosEntrega;
    }
}

