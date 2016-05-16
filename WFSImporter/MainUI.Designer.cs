namespace WFSImporter
{
    partial class MainUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.address_TxtBx = new System.Windows.Forms.TextBox();
            this.coordLat_TxtBx = new System.Windows.Forms.TextBox();
            this.coordLng_TxtBx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.size_TxtBx = new System.Windows.Forms.TextBox();
            this.getData_Btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.layerListCmboBx = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chchApiLabel = new System.Windows.Forms.Label();
            this.chchApiKeyTxtBx = new System.Windows.Forms.TextBox();
            this.getApiLink = new System.Windows.Forms.Label();
            this.apiKeyTxtBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Coordinates(WGS84):";
            // 
            // address_TxtBx
            // 
            this.address_TxtBx.Location = new System.Drawing.Point(137, 30);
            this.address_TxtBx.Name = "address_TxtBx";
            this.address_TxtBx.Size = new System.Drawing.Size(275, 20);
            this.address_TxtBx.TabIndex = 1;
            this.address_TxtBx.Leave += new System.EventHandler(this.address_TxtBx_Leave);
            // 
            // coordLat_TxtBx
            // 
            this.coordLat_TxtBx.Location = new System.Drawing.Point(137, 66);
            this.coordLat_TxtBx.Name = "coordLat_TxtBx";
            this.coordLat_TxtBx.Size = new System.Drawing.Size(122, 20);
            this.coordLat_TxtBx.TabIndex = 2;
            // 
            // coordLng_TxtBx
            // 
            this.coordLng_TxtBx.Location = new System.Drawing.Point(290, 66);
            this.coordLng_TxtBx.Name = "coordLng_TxtBx";
            this.coordLng_TxtBx.Size = new System.Drawing.Size(122, 20);
            this.coordLng_TxtBx.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Bounding Box Size (m):";
            // 
            // size_TxtBx
            // 
            this.size_TxtBx.Location = new System.Drawing.Point(137, 103);
            this.size_TxtBx.Name = "size_TxtBx";
            this.size_TxtBx.Size = new System.Drawing.Size(122, 20);
            this.size_TxtBx.TabIndex = 4;
            this.size_TxtBx.Text = "250";
            // 
            // getData_Btn
            // 
            this.getData_Btn.Location = new System.Drawing.Point(134, 560);
            this.getData_Btn.Name = "getData_Btn";
            this.getData_Btn.Size = new System.Drawing.Size(200, 32);
            this.getData_Btn.TabIndex = 2;
            this.getData_Btn.Text = "Get Data";
            this.getData_Btn.UseVisualStyleBackColor = true;
            this.getData_Btn.Click += new System.EventHandler(this.getData_Btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.layerListCmboBx);
            this.groupBox1.Controls.Add(this.size_TxtBx);
            this.groupBox1.Controls.Add(this.coordLng_TxtBx);
            this.groupBox1.Controls.Add(this.coordLat_TxtBx);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.address_TxtBx);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 188);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // layerListCmboBx
            // 
            this.layerListCmboBx.FormattingEnabled = true;
            this.layerListCmboBx.Items.AddRange(new object[] {
            "Linz Parcel",
            "Canterburry Contours"});
            this.layerListCmboBx.Location = new System.Drawing.Point(137, 144);
            this.layerListCmboBx.Name = "layerListCmboBx";
            this.layerListCmboBx.Size = new System.Drawing.Size(275, 21);
            this.layerListCmboBx.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Layer:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chchApiLabel);
            this.groupBox2.Controls.Add(this.chchApiKeyTxtBx);
            this.groupBox2.Controls.Add(this.getApiLink);
            this.groupBox2.Controls.Add(this.apiKeyTxtBox);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 149);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Api Key";
            // 
            // chchApiLabel
            // 
            this.chchApiLabel.AutoSize = true;
            this.chchApiLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chchApiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chchApiLabel.Location = new System.Drawing.Point(158, 121);
            this.chchApiLabel.Name = "chchApiLabel";
            this.chchApiLabel.Size = new System.Drawing.Size(76, 13);
            this.chchApiLabel.TabIndex = 0;
            this.chchApiLabel.Text = "Get API Key";
            this.chchApiLabel.Click += new System.EventHandler(this.chchApiLabel_Click);
            // 
            // chchApiKeyTxtBx
            // 
            this.chchApiKeyTxtBx.Font = new System.Drawing.Font("Proxy 1", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chchApiKeyTxtBx.ForeColor = System.Drawing.Color.Red;
            this.chchApiKeyTxtBx.Location = new System.Drawing.Point(122, 91);
            this.chchApiKeyTxtBx.Name = "chchApiKeyTxtBx";
            this.chchApiKeyTxtBx.Size = new System.Drawing.Size(290, 21);
            this.chchApiKeyTxtBx.TabIndex = 1;
            this.chchApiKeyTxtBx.Text = "b96d858dc1f543bab7926bc3197f75f7";
            this.chchApiKeyTxtBx.TextChanged += new System.EventHandler(this.chchApiKeyTxtBx_TextChanged);
            // 
            // getApiLink
            // 
            this.getApiLink.AutoSize = true;
            this.getApiLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.getApiLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getApiLink.Location = new System.Drawing.Point(158, 64);
            this.getApiLink.Name = "getApiLink";
            this.getApiLink.Size = new System.Drawing.Size(76, 13);
            this.getApiLink.TabIndex = 0;
            this.getApiLink.Text = "Get API Key";
            this.getApiLink.Click += new System.EventHandler(this.getApiLink_Click);
            // 
            // apiKeyTxtBox
            // 
            this.apiKeyTxtBox.Font = new System.Drawing.Font("Proxy 1", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiKeyTxtBox.ForeColor = System.Drawing.Color.Red;
            this.apiKeyTxtBox.Location = new System.Drawing.Point(122, 34);
            this.apiKeyTxtBox.Name = "apiKeyTxtBox";
            this.apiKeyTxtBox.Size = new System.Drawing.Size(290, 21);
            this.apiKeyTxtBox.TabIndex = 1;
            this.apiKeyTxtBox.Text = "b96d858dc1f543bab7926bc3197f75f7";
            this.apiKeyTxtBox.TextChanged += new System.EventHandler(this.apiKeyTxtBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Canterburry Maps:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "LINZ:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 375);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(446, 169);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Attribution";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(425, 65);
            this.label6.TabIndex = 0;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(429, 53);
            this.label5.TabIndex = 0;
            this.label5.Text = "Parcel data sourced from the LINZ Data Service http://data.linz.govt.nz and licen" +
    "sed by LINZ for re-use under the Creative Commons Attribution 3.0 New Zealand li" +
    "cence.";
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 604);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.getData_Btn);
            this.Name = "MainUI";
            this.Text = "GetLinzData";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainUI_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox address_TxtBx;
        private System.Windows.Forms.TextBox coordLat_TxtBx;
        private System.Windows.Forms.TextBox coordLng_TxtBx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox size_TxtBx;
        private System.Windows.Forms.Button getData_Btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox layerListCmboBx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox apiKeyTxtBox;
        private System.Windows.Forms.Label getApiLink;
        private System.Windows.Forms.Label chchApiLabel;
        private System.Windows.Forms.TextBox chchApiKeyTxtBx;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
    }
}