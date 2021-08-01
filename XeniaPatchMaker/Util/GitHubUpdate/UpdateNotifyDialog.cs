﻿using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace GitHubUpdate
{
    public partial class UpdateNotifyDialog : XtraForm
    {
        private readonly UpdateChecker _checker;
        private bool _loadednotes;

        public UpdateNotifyDialog(UpdateChecker checker)
        {
            _checker = checker;

            InitializeComponent();

            label1.Text = string.Format(label1.Text, checker.RepostoryName);
        }

        void panel1_Resize(object sender, EventArgs e)
        {
            label1.Left = (panel1.ClientSize.Width - label1.Width) / 2;
            label2.Left = (panel1.ClientSize.Width - label2.Width) / 2;
        }

        async void boxReleaseNotes_CheckedChanged(object sender, EventArgs e)
        {
            ReleaseNotesPanel.Visible = boxReleaseNotes.Checked;

            if (_loadednotes) return;

            ReleaseNotes.DocumentText = await _checker.RenderReleaseNotes();
            _loadednotes = true;
        }
    }
}
