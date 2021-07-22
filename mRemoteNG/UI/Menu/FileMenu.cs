using System;
using System.Linq;
using System.Windows.Forms;
using mRemoteNG.App;
using mRemoteNG.Connection;
using mRemoteNG.Container;
using mRemoteNG.Properties;
using mRemoteNG.Resources.Language;
using mRemoteNG.Security;
using mRemoteNG.Tree;
using mRemoteNG.UI.Forms;
using mRemoteNG.UI.Window;

namespace mRemoteNG.UI.Menu
{
    public class FileMenu : ToolStripMenuItem
    {
        private ToolStripMenuItem _mMenFileNew;
        private ToolStripMenuItem _mMenFileLoad;
        private ToolStripMenuItem _mMenFileSave;
        private ToolStripMenuItem _mMenFileSaveAs;
        private ToolStripMenuItem _mMenFileExit;
        private ToolStripSeparator _mMenToolsSep1;
        private ToolStripSeparator _mMenToolsSep2;
        private ToolStripSeparator _mMenToolsSep3;
        private ToolStripMenuItem _mMenToolsOptions;
        private ToolStripMenuItem _mMenToolsSshTransfer;
        private ToolStripMenuItem _mMenToolsExternalApps;
        private ToolStripMenuItem _mMenToolsPortScan;
        private ToolStripMenuItem _mMenToolsUvncsc;
        private ToolStripMenuItem _mMenToolsUpdate;

        public ConnectionTreeWindow TreeWindow { get; set; }

        public FileMenu()
        {
            Initialize();
        }

        private void Initialize()
        {
            _mMenFileNew = new ToolStripMenuItem();
            _mMenFileLoad = new ToolStripMenuItem();
            _mMenFileSave = new ToolStripMenuItem();
            _mMenFileSaveAs = new ToolStripMenuItem();
            _mMenFileExit = new ToolStripMenuItem();
            _mMenToolsSshTransfer = new ToolStripMenuItem();
            _mMenToolsUvncsc = new ToolStripMenuItem();
            _mMenToolsExternalApps = new ToolStripMenuItem();
            _mMenToolsPortScan = new ToolStripMenuItem();
            _mMenToolsSep1 = new ToolStripSeparator();
            _mMenToolsSep2 = new ToolStripSeparator();
            _mMenToolsSep3 = new ToolStripSeparator();
            _mMenToolsOptions = new ToolStripMenuItem();
            _mMenToolsUpdate = new ToolStripMenuItem();

            // 
            // mMenFile
            // 
            DropDownItems.AddRange(new ToolStripItem[]
            {
                _mMenFileNew,
                _mMenFileLoad,
                _mMenFileSave,
                _mMenFileSaveAs,
                _mMenToolsSep1,
                _mMenToolsSshTransfer,
                _mMenToolsUvncsc,
                _mMenToolsExternalApps,
                _mMenToolsPortScan,
                _mMenToolsSep2,
                _mMenToolsUpdate,
                _mMenToolsOptions,
                _mMenToolsSep3,
                _mMenFileExit
            });
            Name = "mMenFile";
            Size = new System.Drawing.Size(37, 20);
            Text = Language._File;
            // 
            // mMenFileNew
            // 
            _mMenFileNew.Image = Properties.Resources.Connections_New;
            _mMenFileNew.Name = "mMenFileNew";
            _mMenFileNew.Size = new System.Drawing.Size(281, 22);
            _mMenFileNew.Text = Language.NewConnectionFile;
            _mMenFileNew.Click += mMenFileNew_Click;
            // 
            // mMenFileLoad
            // 
            _mMenFileLoad.Image = Properties.Resources.Connections_Load;
            _mMenFileLoad.Name = "mMenFileLoad";
            _mMenFileLoad.ShortcutKeys = Keys.Control | Keys.O;
            _mMenFileLoad.Size = new System.Drawing.Size(281, 22);
            _mMenFileLoad.Text = Language.OpenConnectionFile;
            _mMenFileLoad.Click += mMenFileLoad_Click;
            // 
            // mMenFileSave
            // 
            _mMenFileSave.Image = Properties.Resources.Connections_Save;
            _mMenFileSave.Name = "mMenFileSave";
            _mMenFileSave.ShortcutKeys = Keys.Control | Keys.S;
            _mMenFileSave.Size = new System.Drawing.Size(281, 22);
            _mMenFileSave.Text = Language.SaveConnectionFile;
            _mMenFileSave.Click += mMenFileSave_Click;
            // 
            // mMenFileSaveAs
            // 
            _mMenFileSaveAs.Image = Properties.Resources.Connections_SaveAs;
            _mMenFileSaveAs.Name = "mMenFileSaveAs";
            _mMenFileSaveAs.ShortcutKeys = (Keys.Control | Keys.Shift)
                                         | Keys.S;
            _mMenFileSaveAs.Size = new System.Drawing.Size(281, 22);
            _mMenFileSaveAs.Text = Language.SaveConnectionFileAs;
            _mMenFileSaveAs.Click += mMenFileSaveAs_Click;
            // 
            // mMenFileExit
            // 
            _mMenFileExit.Image = Properties.Resources.Quit;
            _mMenFileExit.Name = "mMenFileExit";
            _mMenFileExit.ShortcutKeys = Keys.Alt | Keys.F4;
            _mMenFileExit.Size = new System.Drawing.Size(281, 22);
            _mMenFileExit.Text = Language.Exit;
            _mMenFileExit.Click += mMenFileExit_Click;
            // 
            // mMenToolsSSHTransfer
            // 
            _mMenToolsSshTransfer.Image = Properties.Resources.SSHTransfer;
            _mMenToolsSshTransfer.Name = "mMenToolsSSHTransfer";
            _mMenToolsSshTransfer.Size = new System.Drawing.Size(184, 22);
            _mMenToolsSshTransfer.Text = Language.SshFileTransfer;
            _mMenToolsSshTransfer.Click += mMenToolsSSHTransfer_Click;
            // 
            // mMenToolsUVNCSC
            // 
            _mMenToolsUvncsc.Image = Properties.Resources.UVNC_SC;
            _mMenToolsUvncsc.Name = "mMenToolsUVNCSC";
            _mMenToolsUvncsc.Size = new System.Drawing.Size(184, 22);
            _mMenToolsUvncsc.Text = Language.UltraVNCSingleClick;
            _mMenToolsUvncsc.Visible = false;
            _mMenToolsUvncsc.Click += mMenToolsUVNCSC_Click;
            // 
            // mMenToolsExternalApps
            // 
            _mMenToolsExternalApps.Image = Properties.Resources.ExtApp;
            _mMenToolsExternalApps.Name = "mMenToolsExternalApps";
            _mMenToolsExternalApps.Size = new System.Drawing.Size(184, 22);
            _mMenToolsExternalApps.Text = Language.ExternalTool;
            _mMenToolsExternalApps.Click += mMenToolsExternalApps_Click;
            // 
            // mMenToolsPortScan
            // 
            _mMenToolsPortScan.Image = Properties.Resources.PortScan;
            _mMenToolsPortScan.Name = "mMenToolsPortScan";
            _mMenToolsPortScan.Size = new System.Drawing.Size(184, 22);
            _mMenToolsPortScan.Text = Language.PortScan;
            _mMenToolsPortScan.Click += mMenToolsPortScan_Click;
            // 
            // mMenToolsSep1
            // 
            _mMenToolsSep1.Name = "mMenToolsSep1";
            _mMenToolsSep1.Size = new System.Drawing.Size(181, 6);
            // 
            // mMenToolsOptions
            // 
            _mMenToolsOptions.Image = Properties.Resources.Options;
            _mMenToolsOptions.Name = "mMenToolsOptions";
            _mMenToolsOptions.Size = new System.Drawing.Size(184, 22);
            _mMenToolsOptions.Text = Language.Options;
            _mMenToolsOptions.Click += mMenToolsOptions_Click;
            // 
            // mMenToolsUpdate
            // 
            _mMenToolsUpdate.Image = Properties.Resources.Update;
            _mMenToolsUpdate.Name = "mMenToolsUpdate";
            _mMenToolsUpdate.Size = new System.Drawing.Size(190, 22);
            _mMenToolsUpdate.Text = Language.CheckForUpdates;
            _mMenToolsUpdate.Click += mMenToolsUpdate_Click;
        }

        public void ApplyLanguage()
        {
            Text = Language._File;
            _mMenFileNew.Text = Language.NewConnectionFile;
            _mMenFileLoad.Text = Language.OpenConnectionFile;
            _mMenFileSave.Text = Language.SaveConnectionFile;
            _mMenFileSaveAs.Text = Language.SaveConnectionFileAs;
            _mMenFileExit.Text = Language.Exit;
            _mMenToolsSshTransfer.Text = Language.SshFileTransfer;
            _mMenToolsExternalApps.Text = Language.ExternalTool;
            _mMenToolsPortScan.Text = Language.PortScan;
            _mMenToolsOptions.Text = Language.Options;
            _mMenToolsUpdate.Text = Language.CheckForUpdates;
        }

        #region File

        private void mMenFileNewConnection_Click(object sender, EventArgs e)
        {
            TreeWindow.ConnectionTree.AddConnection();
        }

        private void mMenFileNewFolder_Click(object sender, EventArgs e)
        {
            TreeWindow.ConnectionTree.AddFolder();
        }

        private void mMenFileNew_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = DialogFactory.ConnectionsSaveAsDialog())
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                Runtime.ConnectionsService.NewConnectionsFile(saveFileDialog.FileName);
            }
        }

        private void mMenFileLoad_Click(object sender, EventArgs e)
        {
            if (Runtime.ConnectionsService.IsConnectionsFileLoaded)
            {
                var msgBoxResult = MessageBox.Show(Language.SaveConnectionsFileBeforeOpeningAnother,
                                                   Language.Save, MessageBoxButtons.YesNoCancel);
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (msgBoxResult)
                {
                    case DialogResult.Yes:
                        Runtime.ConnectionsService.SaveConnections();
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }

            Runtime.LoadConnections(true);
        }

        private void mMenFileSave_Click(object sender, EventArgs e)
        {
            Runtime.ConnectionsService.SaveConnectionsAsync();
        }

        private void mMenFileSaveAs_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = DialogFactory.ConnectionsSaveAsDialog())
            {
                if (saveFileDialog.ShowDialog(FrmMain.Default) != DialogResult.OK)
                    return;

                var newFileName = saveFileDialog.FileName;

                Runtime.ConnectionsService.SaveConnections(Runtime.ConnectionsService.ConnectionTreeModel, false,
                                                           new SaveFilter(), newFileName);

                if (newFileName == Runtime.ConnectionsService.GetDefaultStartupConnectionFileName())
                {
                    Settings.Default.LoadConsFromCustomLocation = false;
                }
                else
                {
                    Settings.Default.LoadConsFromCustomLocation = true;
                    Settings.Default.CustomConsPath = newFileName;
                }
            }
        }

        private void mMenFileDelete_Click(object sender, EventArgs e)
        {
            TreeWindow.ConnectionTree.DeleteSelectedNode();
        }

        private void mMenFileRename_Click(object sender, EventArgs e)
        {
            TreeWindow.ConnectionTree.RenameSelectedNode();
        }

        private void mMenFileDuplicate_Click(object sender, EventArgs e)
        {
            TreeWindow.ConnectionTree.DuplicateSelectedNode();
        }

        private void mMenFileImportFromFile_Click(object sender, EventArgs e)
        {
            var selectedNode = TreeWindow.SelectedNode;
            ContainerInfo importDestination;
            if (selectedNode == null)
                importDestination = Runtime.ConnectionsService.ConnectionTreeModel.RootNodes.First();
            else
                importDestination = selectedNode as ContainerInfo ?? selectedNode.Parent;
            Import.ImportFromFile(importDestination);
        }

        private void mMenFileImportFromActiveDirectory_Click(object sender, EventArgs e)
        {
            Windows.Show(WindowType.ActiveDirectoryImport);
        }

        private void mMenFileImportFromPortScan_Click(object sender, EventArgs e)
        {
            Windows.Show(WindowType.PortScan);
        }

        private void mMenFileExport_Click(object sender, EventArgs e)
        {
            Export.ExportToFile(Windows.TreeForm.SelectedNode, Runtime.ConnectionsService.ConnectionTreeModel);
        }

        private void mMenFileExit_Click(object sender, EventArgs e)
        {
            Shutdown.Quit();
        }

        private void mMenToolsSSHTransfer_Click(object sender, EventArgs e)
        {
            Windows.Show(WindowType.SSHTransfer);
        }

        private void mMenToolsUVNCSC_Click(object sender, EventArgs e)
        {
            Windows.Show(WindowType.UltraVNCSC);
        }

        private void mMenToolsExternalApps_Click(object sender, EventArgs e)
        {
            Windows.Show(WindowType.ExternalApps);
        }

        private void mMenToolsPortScan_Click(object sender, EventArgs e)
        {
            Windows.Show(WindowType.PortScan);
        }

        private void mMenToolsOptions_Click(object sender, EventArgs e)
        {
            Windows.Show(WindowType.Options);
        }
        private void mMenToolsUpdate_Click(object sender, EventArgs e) => Windows.Show(WindowType.Update);

        #endregion
    }
}