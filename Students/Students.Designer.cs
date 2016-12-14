namespace Students
{
    partial class StudentsApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentsApplication));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.appLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.inputLayout = new System.Windows.Forms.TableLayoutPanel();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxImei = new System.Windows.Forms.TextBox();
            this.labelPhoneNumber = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.buttonsLayout1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonsLayout2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddStudent = new System.Windows.Forms.Button();
            this.buttonClearFields = new System.Windows.Forms.Button();
            this.buttonDeleteStudent = new System.Windows.Forms.Button();
            this.saleFL = new System.Windows.Forms.RadioButton();
            this.sale_cpec_YL = new System.Windows.Forms.RadioButton();
            this.sale_spec_FL = new System.Windows.Forms.RadioButton();
            this.sales_6_month_FL = new System.Windows.Forms.RadioButton();
            this.sale6_month_YL = new System.Windows.Forms.RadioButton();
            this.saleYL = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
            this.appLayout.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.inputLayout.SuspendLayout();
            this.buttonsLayout1.SuspendLayout();
            this.buttonsLayout2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewStudents
            // 
            this.dataGridViewStudents.AllowUserToAddRows = false;
            this.dataGridViewStudents.AllowUserToDeleteRows = false;
            this.dataGridViewStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStudents.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewStudents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridViewStudents, "dataGridViewStudents");
            this.dataGridViewStudents.Name = "dataGridViewStudents";
            this.dataGridViewStudents.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewStudents.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStudents_CellClick);
            this.dataGridViewStudents.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridViewStudents_KeyUp);
            // 
            // appLayout
            // 
            resources.ApplyResources(this.appLayout, "appLayout");
            this.appLayout.Controls.Add(this.groupBox2, 0, 1);
            this.appLayout.Controls.Add(this.dataGridViewStudents, 0, 0);
            this.appLayout.Controls.Add(this.inputLayout, 2, 0);
            this.appLayout.Name = "appLayout";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton8);
            this.groupBox2.Controls.Add(this.radioButton9);
            this.groupBox2.Controls.Add(this.radioButton10);
            this.groupBox2.Controls.Add(this.radioButton11);
            this.groupBox2.Controls.Add(this.radioButton12);
            this.groupBox2.Controls.Add(this.radioButton13);
            this.groupBox2.Controls.Add(this.radioButton14);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // radioButton8
            // 
            resources.ApplyResources(this.radioButton8, "radioButton8");
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.TabStop = true;
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            resources.ApplyResources(this.radioButton9, "radioButton9");
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.TabStop = true;
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            resources.ApplyResources(this.radioButton10, "radioButton10");
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.TabStop = true;
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // radioButton11
            // 
            resources.ApplyResources(this.radioButton11, "radioButton11");
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.TabStop = true;
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            resources.ApplyResources(this.radioButton12, "radioButton12");
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.TabStop = true;
            this.radioButton12.UseVisualStyleBackColor = true;
            // 
            // radioButton13
            // 
            resources.ApplyResources(this.radioButton13, "radioButton13");
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.TabStop = true;
            this.radioButton13.UseVisualStyleBackColor = true;
            // 
            // radioButton14
            // 
            resources.ApplyResources(this.radioButton14, "radioButton14");
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.TabStop = true;
            this.radioButton14.UseVisualStyleBackColor = true;
            // 
            // inputLayout
            // 
            resources.ApplyResources(this.inputLayout, "inputLayout");
            this.inputLayout.Controls.Add(this.labelEmail, 0, 0);
            this.inputLayout.Controls.Add(this.textBoxImei, 1, 0);
            this.inputLayout.Controls.Add(this.labelPhoneNumber, 0, 1);
            this.inputLayout.Controls.Add(this.button1, 1, 3);
            this.inputLayout.Controls.Add(this.textBoxPhoneNumber, 1, 1);
            this.inputLayout.Controls.Add(this.buttonsLayout1, 0, 2);
            this.inputLayout.Controls.Add(this.buttonsLayout2, 1, 2);
            this.inputLayout.Controls.Add(this.groupBox1, 0, 3);
            this.inputLayout.Name = "inputLayout";
            this.inputLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.inputLayout_Paint);
            // 
            // labelEmail
            // 
            resources.ApplyResources(this.labelEmail, "labelEmail");
            this.labelEmail.Name = "labelEmail";
            // 
            // textBoxImei
            // 
            resources.ApplyResources(this.textBoxImei, "textBoxImei");
            this.textBoxImei.Name = "textBoxImei";
            // 
            // labelPhoneNumber
            // 
            resources.ApplyResources(this.labelPhoneNumber, "labelPhoneNumber");
            this.labelPhoneNumber.Name = "labelPhoneNumber";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxPhoneNumber
            // 
            resources.ApplyResources(this.textBoxPhoneNumber, "textBoxPhoneNumber");
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            // 
            // buttonsLayout1
            // 
            resources.ApplyResources(this.buttonsLayout1, "buttonsLayout1");
            this.buttonsLayout1.Controls.Add(this.buttonExport, 0, 1);
            this.buttonsLayout1.Controls.Add(this.buttonImport, 0, 0);
            this.buttonsLayout1.Name = "buttonsLayout1";
            // 
            // buttonExport
            // 
            resources.ApplyResources(this.buttonExport, "buttonExport");
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonImport
            // 
            resources.ApplyResources(this.buttonImport, "buttonImport");
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonsLayout2
            // 
            resources.ApplyResources(this.buttonsLayout2, "buttonsLayout2");
            this.buttonsLayout2.Controls.Add(this.buttonAddStudent, 0, 0);
            this.buttonsLayout2.Controls.Add(this.buttonClearFields, 1, 1);
            this.buttonsLayout2.Controls.Add(this.buttonDeleteStudent, 0, 1);
            this.buttonsLayout2.Name = "buttonsLayout2";
            this.buttonsLayout2.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonsLayout2_Paint);
            // 
            // buttonAddStudent
            // 
            resources.ApplyResources(this.buttonAddStudent, "buttonAddStudent");
            this.buttonAddStudent.Name = "buttonAddStudent";
            this.buttonAddStudent.UseVisualStyleBackColor = true;
            this.buttonAddStudent.Click += new System.EventHandler(this.buttonAddStudent_Click);
            // 
            // buttonClearFields
            // 
            resources.ApplyResources(this.buttonClearFields, "buttonClearFields");
            this.buttonClearFields.Name = "buttonClearFields";
            this.buttonClearFields.UseVisualStyleBackColor = true;
            this.buttonClearFields.Click += new System.EventHandler(this.buttonClearFields_Click);
            // 
            // buttonDeleteStudent
            // 
            resources.ApplyResources(this.buttonDeleteStudent, "buttonDeleteStudent");
            this.buttonDeleteStudent.Name = "buttonDeleteStudent";
            this.buttonDeleteStudent.UseVisualStyleBackColor = true;
            this.buttonDeleteStudent.Click += new System.EventHandler(this.buttonDeleteStudent_Click);
            // 
            // saleFL
            // 
            resources.ApplyResources(this.saleFL, "saleFL");
            this.saleFL.Name = "saleFL";
            this.saleFL.TabStop = true;
            this.saleFL.UseVisualStyleBackColor = true;
            // 
            // sale_cpec_YL
            // 
            resources.ApplyResources(this.sale_cpec_YL, "sale_cpec_YL");
            this.sale_cpec_YL.Name = "sale_cpec_YL";
            this.sale_cpec_YL.TabStop = true;
            this.sale_cpec_YL.UseVisualStyleBackColor = true;
            this.sale_cpec_YL.CheckedChanged += new System.EventHandler(this.sale_cpec_YL_CheckedChanged);
            // 
            // sale_spec_FL
            // 
            resources.ApplyResources(this.sale_spec_FL, "sale_spec_FL");
            this.sale_spec_FL.Name = "sale_spec_FL";
            this.sale_spec_FL.TabStop = true;
            this.sale_spec_FL.UseVisualStyleBackColor = true;
            this.sale_spec_FL.CheckedChanged += new System.EventHandler(this.sale_spec_FL_CheckedChanged);
            // 
            // sales_6_month_FL
            // 
            resources.ApplyResources(this.sales_6_month_FL, "sales_6_month_FL");
            this.sales_6_month_FL.Name = "sales_6_month_FL";
            this.sales_6_month_FL.TabStop = true;
            this.sales_6_month_FL.UseVisualStyleBackColor = true;
            // 
            // sale6_month_YL
            // 
            resources.ApplyResources(this.sale6_month_YL, "sale6_month_YL");
            this.sale6_month_YL.Name = "sale6_month_YL";
            this.sale6_month_YL.TabStop = true;
            this.sale6_month_YL.UseVisualStyleBackColor = true;
            // 
            // saleYL
            // 
            resources.ApplyResources(this.saleYL, "saleYL");
            this.saleYL.Name = "saleYL";
            this.saleYL.TabStop = true;
            this.saleYL.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saleYL);
            this.groupBox1.Controls.Add(this.sale6_month_YL);
            this.groupBox1.Controls.Add(this.sales_6_month_FL);
            this.groupBox1.Controls.Add(this.sale_spec_FL);
            this.groupBox1.Controls.Add(this.sale_cpec_YL);
            this.groupBox1.Controls.Add(this.saleFL);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // StudentsApplication
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.appLayout);
            this.Name = "StudentsApplication";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudentsApplication_FormClosed);
            this.Load += new System.EventHandler(this.StudentsApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            this.appLayout.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.inputLayout.ResumeLayout(false);
            this.inputLayout.PerformLayout();
            this.buttonsLayout1.ResumeLayout(false);
            this.buttonsLayout2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.TableLayoutPanel appLayout;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton12;
        private System.Windows.Forms.RadioButton radioButton13;
        private System.Windows.Forms.RadioButton radioButton14;
        private System.Windows.Forms.TableLayoutPanel inputLayout;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxImei;
        private System.Windows.Forms.Label labelPhoneNumber;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.TableLayoutPanel buttonsLayout1;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.TableLayoutPanel buttonsLayout2;
        private System.Windows.Forms.Button buttonAddStudent;
        private System.Windows.Forms.Button buttonClearFields;
        private System.Windows.Forms.Button buttonDeleteStudent;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton saleYL;
        private System.Windows.Forms.RadioButton sale6_month_YL;
        private System.Windows.Forms.RadioButton sales_6_month_FL;
        private System.Windows.Forms.RadioButton sale_spec_FL;
        private System.Windows.Forms.RadioButton sale_cpec_YL;
        private System.Windows.Forms.RadioButton saleFL;
    }
}

