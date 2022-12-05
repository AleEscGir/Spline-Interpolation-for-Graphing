namespace Spline_Interpolation__CSharp_
{
    partial class InterpolationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WFPainterPictureBox = new System.Windows.Forms.PictureBox();
            this.WFSectionsGroupBox = new System.Windows.Forms.GroupBox();
            this.WFInterpolationStartButton = new System.Windows.Forms.Button();
            this.WFConnectSectionNumeric = new System.Windows.Forms.NumericUpDown();
            this.WFConnectSectionsButton = new System.Windows.Forms.Button();
            this.WFRemoveSectionButton = new System.Windows.Forms.Button();
            this.WFAddSectionButton = new System.Windows.Forms.Button();
            this.WFChangeNameTextBox = new System.Windows.Forms.TextBox();
            this.WFChangeNameButton = new System.Windows.Forms.Button();
            this.WFRemovePointButton = new System.Windows.Forms.Button();
            this.WFShowVectorButton = new System.Windows.Forms.Button();
            this.WFAddPointButton = new System.Windows.Forms.Button();
            this.WFActualPointNumeric = new System.Windows.Forms.NumericUpDown();
            this.WFActualPointLabel = new System.Windows.Forms.Label();
            this.WFActualSectionNumeric = new System.Windows.Forms.NumericUpDown();
            this.WFSectionNameTextBox = new System.Windows.Forms.TextBox();
            this.WFActualSectionLabel = new System.Windows.Forms.Label();
            this.WFSaveLoadGroupBox = new System.Windows.Forms.GroupBox();
            this.WFSaveButton = new System.Windows.Forms.Button();
            this.WFLoadButton = new System.Windows.Forms.Button();
            this.WFInterpolationMenuGroupBox = new System.Windows.Forms.GroupBox();
            this.WFPointsNumberNumeric = new System.Windows.Forms.NumericUpDown();
            this.WFPointsNumberLabel = new System.Windows.Forms.Label();
            this.WFInterpolationButton = new System.Windows.Forms.Button();
            this.WFEndInterplationButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WFPainterPictureBox)).BeginInit();
            this.WFSectionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WFConnectSectionNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WFActualPointNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WFActualSectionNumeric)).BeginInit();
            this.WFSaveLoadGroupBox.SuspendLayout();
            this.WFInterpolationMenuGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WFPointsNumberNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // WFPainterPictureBox
            // 
            this.WFPainterPictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.WFPainterPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WFPainterPictureBox.Location = new System.Drawing.Point(1, 1);
            this.WFPainterPictureBox.Name = "WFPainterPictureBox";
            this.WFPainterPictureBox.Size = new System.Drawing.Size(647, 448);
            this.WFPainterPictureBox.TabIndex = 0;
            this.WFPainterPictureBox.TabStop = false;
            this.WFPainterPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.WFPainterPictureBox_Paint);
            this.WFPainterPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.WFPainterPictureBox_MouseClick);
            // 
            // WFSectionsGroupBox
            // 
            this.WFSectionsGroupBox.Controls.Add(this.WFInterpolationStartButton);
            this.WFSectionsGroupBox.Controls.Add(this.WFConnectSectionNumeric);
            this.WFSectionsGroupBox.Controls.Add(this.WFConnectSectionsButton);
            this.WFSectionsGroupBox.Controls.Add(this.WFRemoveSectionButton);
            this.WFSectionsGroupBox.Controls.Add(this.WFAddSectionButton);
            this.WFSectionsGroupBox.Controls.Add(this.WFChangeNameTextBox);
            this.WFSectionsGroupBox.Controls.Add(this.WFChangeNameButton);
            this.WFSectionsGroupBox.Controls.Add(this.WFRemovePointButton);
            this.WFSectionsGroupBox.Controls.Add(this.WFShowVectorButton);
            this.WFSectionsGroupBox.Controls.Add(this.WFAddPointButton);
            this.WFSectionsGroupBox.Controls.Add(this.WFActualPointNumeric);
            this.WFSectionsGroupBox.Controls.Add(this.WFActualPointLabel);
            this.WFSectionsGroupBox.Controls.Add(this.WFActualSectionNumeric);
            this.WFSectionsGroupBox.Controls.Add(this.WFSectionNameTextBox);
            this.WFSectionsGroupBox.Controls.Add(this.WFActualSectionLabel);
            this.WFSectionsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFSectionsGroupBox.Location = new System.Drawing.Point(654, 12);
            this.WFSectionsGroupBox.Name = "WFSectionsGroupBox";
            this.WFSectionsGroupBox.Size = new System.Drawing.Size(233, 285);
            this.WFSectionsGroupBox.TabIndex = 1;
            this.WFSectionsGroupBox.TabStop = false;
            this.WFSectionsGroupBox.Text = "Secciones:";
            // 
            // WFInterpolationStartButton
            // 
            this.WFInterpolationStartButton.Location = new System.Drawing.Point(118, 237);
            this.WFInterpolationStartButton.Name = "WFInterpolationStartButton";
            this.WFInterpolationStartButton.Size = new System.Drawing.Size(106, 42);
            this.WFInterpolationStartButton.TabIndex = 15;
            this.WFInterpolationStartButton.Text = "Comenzar Interpolación";
            this.WFInterpolationStartButton.UseVisualStyleBackColor = true;
            this.WFInterpolationStartButton.Click += new System.EventHandler(this.WFInterpolationStartButton_Click);
            // 
            // WFConnectSectionNumeric
            // 
            this.WFConnectSectionNumeric.Location = new System.Drawing.Point(169, 131);
            this.WFConnectSectionNumeric.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WFConnectSectionNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WFConnectSectionNumeric.Name = "WFConnectSectionNumeric";
            this.WFConnectSectionNumeric.Size = new System.Drawing.Size(34, 20);
            this.WFConnectSectionNumeric.TabIndex = 14;
            this.WFConnectSectionNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // WFConnectSectionsButton
            // 
            this.WFConnectSectionsButton.Location = new System.Drawing.Point(6, 124);
            this.WFConnectSectionsButton.Name = "WFConnectSectionsButton";
            this.WFConnectSectionsButton.Size = new System.Drawing.Size(150, 30);
            this.WFConnectSectionsButton.TabIndex = 13;
            this.WFConnectSectionsButton.Text = "Conectar con otra sección";
            this.WFConnectSectionsButton.UseVisualStyleBackColor = true;
            this.WFConnectSectionsButton.Click += new System.EventHandler(this.WFConnectSectionsButton_Click);
            // 
            // WFRemoveSectionButton
            // 
            this.WFRemoveSectionButton.Location = new System.Drawing.Point(108, 88);
            this.WFRemoveSectionButton.Name = "WFRemoveSectionButton";
            this.WFRemoveSectionButton.Size = new System.Drawing.Size(95, 30);
            this.WFRemoveSectionButton.TabIndex = 12;
            this.WFRemoveSectionButton.Text = "Eliminar Sección";
            this.WFRemoveSectionButton.UseVisualStyleBackColor = true;
            this.WFRemoveSectionButton.Click += new System.EventHandler(this.WFRemoveSectionButton_Click);
            // 
            // WFAddSectionButton
            // 
            this.WFAddSectionButton.Location = new System.Drawing.Point(6, 88);
            this.WFAddSectionButton.Name = "WFAddSectionButton";
            this.WFAddSectionButton.Size = new System.Drawing.Size(95, 30);
            this.WFAddSectionButton.TabIndex = 11;
            this.WFAddSectionButton.Text = "Agregar Sección";
            this.WFAddSectionButton.UseVisualStyleBackColor = true;
            this.WFAddSectionButton.Click += new System.EventHandler(this.WFAddSectionButton_Click);
            // 
            // WFChangeNameTextBox
            // 
            this.WFChangeNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WFChangeNameTextBox.Location = new System.Drawing.Point(108, 59);
            this.WFChangeNameTextBox.Name = "WFChangeNameTextBox";
            this.WFChangeNameTextBox.Size = new System.Drawing.Size(88, 20);
            this.WFChangeNameTextBox.TabIndex = 10;
            // 
            // WFChangeNameButton
            // 
            this.WFChangeNameButton.Location = new System.Drawing.Point(6, 52);
            this.WFChangeNameButton.Name = "WFChangeNameButton";
            this.WFChangeNameButton.Size = new System.Drawing.Size(95, 30);
            this.WFChangeNameButton.TabIndex = 9;
            this.WFChangeNameButton.Text = "Cambiar Nombre";
            this.WFChangeNameButton.UseVisualStyleBackColor = true;
            this.WFChangeNameButton.Click += new System.EventHandler(this.WFChangeNameButton_Click);
            // 
            // WFRemovePointButton
            // 
            this.WFRemovePointButton.Location = new System.Drawing.Point(108, 201);
            this.WFRemovePointButton.Name = "WFRemovePointButton";
            this.WFRemovePointButton.Size = new System.Drawing.Size(84, 30);
            this.WFRemovePointButton.TabIndex = 8;
            this.WFRemovePointButton.Text = "Eliminar Punto";
            this.WFRemovePointButton.UseVisualStyleBackColor = true;
            this.WFRemovePointButton.Click += new System.EventHandler(this.WFRemovePointButton_Click);
            // 
            // WFShowVectorButton
            // 
            this.WFShowVectorButton.Location = new System.Drawing.Point(6, 237);
            this.WFShowVectorButton.Name = "WFShowVectorButton";
            this.WFShowVectorButton.Size = new System.Drawing.Size(106, 42);
            this.WFShowVectorButton.TabIndex = 7;
            this.WFShowVectorButton.Text = "Mostrar Tangentes";
            this.WFShowVectorButton.UseVisualStyleBackColor = true;
            this.WFShowVectorButton.Click += new System.EventHandler(this.WFShowVectorButton_Click);
            // 
            // WFAddPointButton
            // 
            this.WFAddPointButton.Location = new System.Drawing.Point(6, 201);
            this.WFAddPointButton.Name = "WFAddPointButton";
            this.WFAddPointButton.Size = new System.Drawing.Size(84, 30);
            this.WFAddPointButton.TabIndex = 5;
            this.WFAddPointButton.Text = "Agregar Punto";
            this.WFAddPointButton.UseVisualStyleBackColor = true;
            this.WFAddPointButton.Click += new System.EventHandler(this.WFAddPointButton_Click);
            // 
            // WFActualPointNumeric
            // 
            this.WFActualPointNumeric.Location = new System.Drawing.Point(96, 172);
            this.WFActualPointNumeric.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.WFActualPointNumeric.Name = "WFActualPointNumeric";
            this.WFActualPointNumeric.Size = new System.Drawing.Size(48, 20);
            this.WFActualPointNumeric.TabIndex = 4;
            this.WFActualPointNumeric.ValueChanged += new System.EventHandler(this.WFActualPointNumeric_ValueChanged);
            // 
            // WFActualPointLabel
            // 
            this.WFActualPointLabel.AutoSize = true;
            this.WFActualPointLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WFActualPointLabel.Location = new System.Drawing.Point(6, 174);
            this.WFActualPointLabel.Name = "WFActualPointLabel";
            this.WFActualPointLabel.Size = new System.Drawing.Size(73, 15);
            this.WFActualPointLabel.TabIndex = 3;
            this.WFActualPointLabel.Text = "Punto Actual:";
            // 
            // WFActualSectionNumeric
            // 
            this.WFActualSectionNumeric.Location = new System.Drawing.Point(96, 22);
            this.WFActualSectionNumeric.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WFActualSectionNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WFActualSectionNumeric.Name = "WFActualSectionNumeric";
            this.WFActualSectionNumeric.Size = new System.Drawing.Size(34, 20);
            this.WFActualSectionNumeric.TabIndex = 2;
            this.WFActualSectionNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WFActualSectionNumeric.ValueChanged += new System.EventHandler(this.WFActualSectionNumeric_ValueChanged);
            // 
            // WFSectionNameTextBox
            // 
            this.WFSectionNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WFSectionNameTextBox.Location = new System.Drawing.Point(136, 22);
            this.WFSectionNameTextBox.Name = "WFSectionNameTextBox";
            this.WFSectionNameTextBox.ReadOnly = true;
            this.WFSectionNameTextBox.Size = new System.Drawing.Size(88, 20);
            this.WFSectionNameTextBox.TabIndex = 1;
            // 
            // WFActualSectionLabel
            // 
            this.WFActualSectionLabel.AutoSize = true;
            this.WFActualSectionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WFActualSectionLabel.Location = new System.Drawing.Point(6, 25);
            this.WFActualSectionLabel.Name = "WFActualSectionLabel";
            this.WFActualSectionLabel.Size = new System.Drawing.Size(84, 15);
            this.WFActualSectionLabel.TabIndex = 0;
            this.WFActualSectionLabel.Text = "Seccion Actual:";
            // 
            // WFSaveLoadGroupBox
            // 
            this.WFSaveLoadGroupBox.Controls.Add(this.WFSaveButton);
            this.WFSaveLoadGroupBox.Controls.Add(this.WFLoadButton);
            this.WFSaveLoadGroupBox.Location = new System.Drawing.Point(654, 303);
            this.WFSaveLoadGroupBox.Name = "WFSaveLoadGroupBox";
            this.WFSaveLoadGroupBox.Size = new System.Drawing.Size(233, 60);
            this.WFSaveLoadGroupBox.TabIndex = 2;
            this.WFSaveLoadGroupBox.TabStop = false;
            this.WFSaveLoadGroupBox.Text = "Cargar/Salvar Archivo";
            // 
            // WFSaveButton
            // 
            this.WFSaveButton.Location = new System.Drawing.Point(130, 19);
            this.WFSaveButton.Name = "WFSaveButton";
            this.WFSaveButton.Size = new System.Drawing.Size(84, 30);
            this.WFSaveButton.TabIndex = 16;
            this.WFSaveButton.Text = "Salvar Archivo";
            this.WFSaveButton.UseVisualStyleBackColor = true;
            this.WFSaveButton.Click += new System.EventHandler(this.WFSaveButton_Click);
            // 
            // WFLoadButton
            // 
            this.WFLoadButton.Location = new System.Drawing.Point(11, 19);
            this.WFLoadButton.Name = "WFLoadButton";
            this.WFLoadButton.Size = new System.Drawing.Size(95, 30);
            this.WFLoadButton.TabIndex = 15;
            this.WFLoadButton.Text = "Cargar Archivo";
            this.WFLoadButton.UseVisualStyleBackColor = true;
            this.WFLoadButton.Click += new System.EventHandler(this.WFLoadButton_Click);
            // 
            // WFInterpolationMenuGroupBox
            // 
            this.WFInterpolationMenuGroupBox.Controls.Add(this.WFEndInterplationButton);
            this.WFInterpolationMenuGroupBox.Controls.Add(this.WFInterpolationButton);
            this.WFInterpolationMenuGroupBox.Controls.Add(this.WFPointsNumberNumeric);
            this.WFInterpolationMenuGroupBox.Controls.Add(this.WFPointsNumberLabel);
            this.WFInterpolationMenuGroupBox.Location = new System.Drawing.Point(660, 369);
            this.WFInterpolationMenuGroupBox.Name = "WFInterpolationMenuGroupBox";
            this.WFInterpolationMenuGroupBox.Size = new System.Drawing.Size(227, 80);
            this.WFInterpolationMenuGroupBox.TabIndex = 3;
            this.WFInterpolationMenuGroupBox.TabStop = false;
            this.WFInterpolationMenuGroupBox.Text = "Menú de Interpolación";
            // 
            // WFPointsNumberNumeric
            // 
            this.WFPointsNumberNumeric.Location = new System.Drawing.Point(145, 19);
            this.WFPointsNumberNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.WFPointsNumberNumeric.Name = "WFPointsNumberNumeric";
            this.WFPointsNumberNumeric.Size = new System.Drawing.Size(73, 20);
            this.WFPointsNumberNumeric.TabIndex = 17;
            // 
            // WFPointsNumberLabel
            // 
            this.WFPointsNumberLabel.AutoSize = true;
            this.WFPointsNumberLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WFPointsNumberLabel.Location = new System.Drawing.Point(6, 23);
            this.WFPointsNumberLabel.Name = "WFPointsNumberLabel";
            this.WFPointsNumberLabel.Size = new System.Drawing.Size(105, 15);
            this.WFPointsNumberLabel.TabIndex = 16;
            this.WFPointsNumberLabel.Text = "Cantidad de Puntos:";
            // 
            // WFInterpolationButton
            // 
            this.WFInterpolationButton.Location = new System.Drawing.Point(5, 44);
            this.WFInterpolationButton.Name = "WFInterpolationButton";
            this.WFInterpolationButton.Size = new System.Drawing.Size(90, 30);
            this.WFInterpolationButton.TabIndex = 17;
            this.WFInterpolationButton.Text = "Interpolar";
            this.WFInterpolationButton.UseVisualStyleBackColor = true;
            this.WFInterpolationButton.Click += new System.EventHandler(this.WFInterpolationButton_Click);
            // 
            // WFEndInterplationButton
            // 
            this.WFEndInterplationButton.Location = new System.Drawing.Point(128, 44);
            this.WFEndInterplationButton.Name = "WFEndInterplationButton";
            this.WFEndInterplationButton.Size = new System.Drawing.Size(90, 30);
            this.WFEndInterplationButton.TabIndex = 18;
            this.WFEndInterplationButton.Text = "Finalizar";
            this.WFEndInterplationButton.UseVisualStyleBackColor = true;
            this.WFEndInterplationButton.Click += new System.EventHandler(this.WFEndInterplationButton_Click);
            // 
            // InterpolationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(890, 450);
            this.Controls.Add(this.WFInterpolationMenuGroupBox);
            this.Controls.Add(this.WFSaveLoadGroupBox);
            this.Controls.Add(this.WFSectionsGroupBox);
            this.Controls.Add(this.WFPainterPictureBox);
            this.Name = "InterpolationForm";
            this.Text = "Spline Interpolation";
            ((System.ComponentModel.ISupportInitialize)(this.WFPainterPictureBox)).EndInit();
            this.WFSectionsGroupBox.ResumeLayout(false);
            this.WFSectionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WFConnectSectionNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WFActualPointNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WFActualSectionNumeric)).EndInit();
            this.WFSaveLoadGroupBox.ResumeLayout(false);
            this.WFInterpolationMenuGroupBox.ResumeLayout(false);
            this.WFInterpolationMenuGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WFPointsNumberNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox WFPainterPictureBox;
        private System.Windows.Forms.GroupBox WFSectionsGroupBox;
        private System.Windows.Forms.NumericUpDown WFActualSectionNumeric;
        private System.Windows.Forms.TextBox WFSectionNameTextBox;
        private System.Windows.Forms.Label WFActualSectionLabel;
        private System.Windows.Forms.Button WFRemovePointButton;
        private System.Windows.Forms.Button WFShowVectorButton;
        private System.Windows.Forms.Button WFAddPointButton;
        private System.Windows.Forms.NumericUpDown WFActualPointNumeric;
        private System.Windows.Forms.Label WFActualPointLabel;
        private System.Windows.Forms.Button WFChangeNameButton;
        private System.Windows.Forms.TextBox WFChangeNameTextBox;
        private System.Windows.Forms.Button WFRemoveSectionButton;
        private System.Windows.Forms.Button WFAddSectionButton;
        private System.Windows.Forms.Button WFConnectSectionsButton;
        private System.Windows.Forms.NumericUpDown WFConnectSectionNumeric;
        private System.Windows.Forms.GroupBox WFSaveLoadGroupBox;
        private System.Windows.Forms.Button WFSaveButton;
        private System.Windows.Forms.Button WFLoadButton;
        private System.Windows.Forms.Button WFInterpolationStartButton;
        private System.Windows.Forms.GroupBox WFInterpolationMenuGroupBox;
        private System.Windows.Forms.Button WFEndInterplationButton;
        private System.Windows.Forms.Button WFInterpolationButton;
        private System.Windows.Forms.NumericUpDown WFPointsNumberNumeric;
        private System.Windows.Forms.Label WFPointsNumberLabel;
    }
}

