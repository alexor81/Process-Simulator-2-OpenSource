// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.SpecialControls
{
    partial class PlayPause
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayPause));
            this.checkBox_PlayPause = new System.Windows.Forms.CheckBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // checkBox_PlayPause
            // 
            this.checkBox_PlayPause.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_PlayPause.ImageIndex = 0;
            this.checkBox_PlayPause.ImageList = this.imageList;
            this.checkBox_PlayPause.Location = new System.Drawing.Point(1, 1);
            this.checkBox_PlayPause.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_PlayPause.Name = "checkBox_PlayPause";
            this.checkBox_PlayPause.Size = new System.Drawing.Size(29, 27);
            this.checkBox_PlayPause.TabIndex = 2;
            this.checkBox_PlayPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_PlayPause.UseVisualStyleBackColor = true;
            this.checkBox_PlayPause.CheckedChanged += new System.EventHandler(this.checkBox_PlayPause_CheckedChanged);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Play.gif");
            this.imageList.Images.SetKeyName(1, "Pause.gif");
            // 
            // PlayPause
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox_PlayPause);
            this.Name = "PlayPause";
            this.Size = new System.Drawing.Size(31, 29);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_PlayPause;
        private System.Windows.Forms.ImageList imageList;
    }
}
