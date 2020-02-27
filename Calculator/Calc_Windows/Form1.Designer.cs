namespace Calc_Windows
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.inputData1 = new System.Windows.Forms.TextBox();
            this.inputData2 = new System.Windows.Forms.TextBox();
            this.comboBoxOperator = new System.Windows.Forms.ComboBox();
            this.result = new System.Windows.Forms.Label();
            this.btnEqual = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputData1
            // 
            this.inputData1.Location = new System.Drawing.Point(157, 83);
            this.inputData1.Name = "inputData1";
            this.inputData1.Size = new System.Drawing.Size(50, 21);
            this.inputData1.TabIndex = 0;
            // 
            // inputData2
            // 
            this.inputData2.Location = new System.Drawing.Point(328, 83);
            this.inputData2.Name = "inputData2";
            this.inputData2.Size = new System.Drawing.Size(50, 21);
            this.inputData2.TabIndex = 1;
            // 
            // comboBoxOperator
            // 
            this.comboBoxOperator.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.comboBoxOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperator.FormattingEnabled = true;
            this.comboBoxOperator.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.comboBoxOperator.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.comboBoxOperator.Location = new System.Drawing.Point(240, 83);
            this.comboBoxOperator.Name = "comboBoxOperator";
            this.comboBoxOperator.Size = new System.Drawing.Size(60, 20);
            this.comboBoxOperator.TabIndex = 2;
            this.comboBoxOperator.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(463, 85);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(0, 12);
            this.result.TabIndex = 4;
            // 
            // btnEqual
            // 
            this.btnEqual.Location = new System.Drawing.Point(409, 80);
            this.btnEqual.Name = "btnEqual";
            this.btnEqual.Size = new System.Drawing.Size(33, 23);
            this.btnEqual.TabIndex = 5;
            this.btnEqual.Text = "=";
            this.btnEqual.UseVisualStyleBackColor = true;
            this.btnEqual.Click += new System.EventHandler(this.btnEqual_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 182);
            this.Controls.Add(this.btnEqual);
            this.Controls.Add(this.result);
            this.Controls.Add(this.comboBoxOperator);
            this.Controls.Add(this.inputData2);
            this.Controls.Add(this.inputData1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputData1;
        private System.Windows.Forms.TextBox inputData2;
        private System.Windows.Forms.ComboBox comboBoxOperator;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.Button btnEqual;
    }
}

