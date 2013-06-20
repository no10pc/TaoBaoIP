namespace taoIP
{
    partial class weatherdisplay
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.imgday = new System.Windows.Forms.PictureBox();
            this.txtcityname = new System.Windows.Forms.Label();
            this.temp1 = new System.Windows.Forms.Label();
            this.imgnight = new System.Windows.Forms.PictureBox();
            this.temp2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtweather = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txttime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgnight)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "城市";
            // 
            // imgday
            // 
            this.imgday.Image = global::taoIP.Properties.Resources._00;
            this.imgday.InitialImage = global::taoIP.Properties.Resources._00;
            this.imgday.Location = new System.Drawing.Point(16, 69);
            this.imgday.Name = "imgday";
            this.imgday.Size = new System.Drawing.Size(125, 125);
            this.imgday.TabIndex = 1;
            this.imgday.TabStop = false;
            // 
            // txtcityname
            // 
            this.txtcityname.AutoSize = true;
            this.txtcityname.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtcityname.Location = new System.Drawing.Point(59, 25);
            this.txtcityname.Name = "txtcityname";
            this.txtcityname.Size = new System.Drawing.Size(42, 22);
            this.txtcityname.TabIndex = 2;
            this.txtcityname.Text = "北京";
            // 
            // temp1
            // 
            this.temp1.AutoSize = true;
            this.temp1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.temp1.Location = new System.Drawing.Point(42, 199);
            this.temp1.Name = "temp1";
            this.temp1.Size = new System.Drawing.Size(80, 38);
            this.temp1.TabIndex = 3;
            this.temp1.Text = "34℃";
            // 
            // imgnight
            // 
            this.imgnight.BackColor = System.Drawing.SystemColors.Control;
            this.imgnight.Image = global::taoIP.Properties.Resources._00;
            this.imgnight.InitialImage = global::taoIP.Properties.Resources._00;
            this.imgnight.Location = new System.Drawing.Point(147, 69);
            this.imgnight.Name = "imgnight";
            this.imgnight.Size = new System.Drawing.Size(125, 125);
            this.imgnight.TabIndex = 1;
            this.imgnight.TabStop = false;
            // 
            // temp2
            // 
            this.temp2.AutoSize = true;
            this.temp2.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.temp2.Location = new System.Drawing.Point(170, 199);
            this.temp2.Name = "temp2";
            this.temp2.Size = new System.Drawing.Size(80, 38);
            this.temp2.TabIndex = 3;
            this.temp2.Text = "34℃";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "白天";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "夜间";
            // 
            // txtweather
            // 
            this.txtweather.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtweather.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtweather.Location = new System.Drawing.Point(16, 246);
            this.txtweather.Name = "txtweather";
            this.txtweather.Size = new System.Drawing.Size(256, 21);
            this.txtweather.TabIndex = 5;
            this.txtweather.Text = "晴转多云";
            this.txtweather.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "发布时间:";
            // 
            // txttime
            // 
            this.txttime.AutoSize = true;
            this.txttime.Location = new System.Drawing.Point(80, 282);
            this.txttime.Name = "txttime";
            this.txttime.Size = new System.Drawing.Size(35, 12);
            this.txttime.TabIndex = 7;
            this.txttime.Text = "11:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "数据来源：www.weather.com.cn";
            // 
            // weatherdisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txttime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtweather);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.temp2);
            this.Controls.Add(this.temp1);
            this.Controls.Add(this.txtcityname);
            this.Controls.Add(this.imgnight);
            this.Controls.Add(this.imgday);
            this.Controls.Add(this.label1);
            this.Name = "weatherdisplay";
            this.Size = new System.Drawing.Size(286, 316);
            ((System.ComponentModel.ISupportInitialize)(this.imgday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgnight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox imgday;
        private System.Windows.Forms.Label txtcityname;
        private System.Windows.Forms.Label temp1;
        private System.Windows.Forms.PictureBox imgnight;
        private System.Windows.Forms.Label temp2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtweather;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txttime;
        private System.Windows.Forms.Label label2;
    }
}
