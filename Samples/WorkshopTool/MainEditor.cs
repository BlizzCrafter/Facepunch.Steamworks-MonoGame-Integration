using Steamworks;
using Steamworks.Data;
using Steamworks.Ugc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace WorkshopTool
{
    public partial class MainEditor : Form
    {
        private List<string> _TagCollection = new List<string>();
        private List<string> _SelectedTagCollection = new List<string>();

        private bool _LockTagCheckBoxEvents = false;
        private bool _LockNumericUpDownPagesEvents = false;
        private int _LastMaxPage;

        private ProgressData _ProgressData = new ProgressData();
        private void _ProgressData_Progress(float obj)
        {
            _ProgressLabel.Text = $"Progress: {obj * 10f}%";
            statusStrip.Invalidate();
        }
        private ToolStripLabel _ProgressLabel = new ToolStripLabel() { Alignment = ToolStripItemAlignment.Right };

        #region Init
        
        private void MainEditor_Load(object sender, EventArgs e)
        {
            toolStripComboBoxMode.SelectedIndex = 0;
        }

        private void MainEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Functions.IsSteamRunning) SteamClient.Shutdown();
        }

        #endregion

        #region Menu

        // Switch between Querry-Mode and CreateWorkshopItem-Mode
        private void toolStripComboBoxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            statusStrip.Items.Clear();

            int selectedIndex = ((ToolStripComboBox)sender).SelectedIndex;

            // Querry-Mode
            if (selectedIndex == 0)
            {
                panelQuerry.Visible = true;
                panelCreate.Visible = false;

                propertyGridElementDetails.Refresh();
            }
            // Create-Mode
            else if (selectedIndex == 1)
            {
                panelQuerry.Visible = false;
                panelCreate.Visible = true;

                RefreshStorageQuota();
            }
        }

        #endregion

        #region Querry

        private void StartQuerry()
        {
            if (Functions.IsSteamRunning)
            {
                var q = Query.All;

                if (checkBoxFromSelf.Checked) q.WhereUserPublished(); // Only items from a specific user (self in this case)
                if (checkBoxSubscribed.Checked) q.WhereUserSubscribed(); // Only subscribed items from a specific user (self in this case)

                if (radioButtonMatchAllTags.Checked) q.MatchAllTags(); // Item tags need to match all selected tags
                else if (radioButtonMatchAnyTags.Checked) q.MatchAnyTag(); // Item tags need to match any selected tag

                foreach (string tag in _SelectedTagCollection)
                {
                    q.WithTag(tag);
                }

                UgcQuerry(q); // Starting the Querry
            }
        }

        private async Task UgcQuerry(Query query)
        {
            var result = await query.GetPageAsync((int)numericUpDownPage.Value);

            if (result.HasValue)
            {
                listViewEntries.Items.Clear();
                statusStrip.Items.Clear();
                flowLayoutPanelTagCollection.Controls.Clear();
                _TagCollection.Clear();

                int pages = 0;
                if (result.Value.ResultCount >= 50) pages = result.Value.TotalCount / result.Value.ResultCount;
                else if (result.Value.TotalCount < 50) pages = 1;
                else pages = _LastMaxPage;

                if (pages > 0 && result.Value.TotalCount / pages > 50) pages++;

                _LastMaxPage = pages;

                statusStrip.Items.Add(new ToolStripLabel($"Pages: {pages} | TotalCount: {result.Value.TotalCount}")
                {
                    Alignment = ToolStripItemAlignment.Right
                });
                numericUpDownPage.Maximum = pages;

                // Fill ListView with found Workshop Items
                foreach (Item entry in result.Value.Entries)
                {
                    ListViewItem item = new ListViewItem(entry.Title);
                    item.Tag = entry;
                    listViewEntries.Items.Add(item);

                    foreach (string tag in entry.Tags)
                    {
                        if (!_TagCollection.Contains(tag)) _TagCollection.Add(tag);
                    }
                }

                // Adding possibility of resetting the current selected tags
                if (_SelectedTagCollection.Count > 0)
                {
                    Button resetTagsButton = new Button();
                    resetTagsButton.Text = "Reset";
                    resetTagsButton.AutoSize = true;
                    resetTagsButton.Click += ResetTagsButton_Click;

                    flowLayoutPanelTagCollection.Controls.Add(resetTagsButton);
                }

                // Adding a tag collection, where the user can select from
                List<CheckBox> TagControls = new List<CheckBox>();
                foreach (string tag in _TagCollection)
                {
                    _LockTagCheckBoxEvents = true;

                    CheckBox checkBoxTag = new CheckBox();
                    checkBoxTag.Text = tag;
                    checkBoxTag.Checked = _SelectedTagCollection.Exists(x => x == tag);
                    checkBoxTag.Margin = new Padding(0);
                    checkBoxTag.Padding = new Padding(0);
                    checkBoxTag.AutoSize = true;
                    checkBoxTag.CheckedChanged += CheckBoxTag_CheckedChanged;

                    TagControls.Add(checkBoxTag);

                    _LockTagCheckBoxEvents = false;
                }

                flowLayoutPanelTagCollection.Controls.AddRange(TagControls.ToArray());
            }
        }

        private void CheckBoxTag_CheckedChanged(object sender, EventArgs e)
        {
            if (!_LockTagCheckBoxEvents)
            {
                _SelectedTagCollection.Clear();

                foreach (CheckBox tagCheckBox in flowLayoutPanelTagCollection.Controls.OfType<CheckBox>().Where(x => x.Checked))
                {
                    _SelectedTagCollection.Add(tagCheckBox.Text);
                }
            }

            _LockNumericUpDownPagesEvents = true;
            ResetNumericUpDownPageValue();
            _LockNumericUpDownPagesEvents = false;
        }

        #endregion

        #region PropertyGrid

        private void listViewEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewEntries.SelectedItems != null && listViewEntries.SelectedItems.Count > 0 &&
                listViewEntries.SelectedItems[0] != null && listViewEntries.SelectedItems[0].Tag != null)
            {
                buttonDelete.Tag = (Item)listViewEntries.SelectedItems[0].Tag;
                buttonSubscribe.Tag = (Item)listViewEntries.SelectedItems[0].Tag;
                buttonUnSubscribe.Tag = (Item)listViewEntries.SelectedItems[0].Tag;

                propertyGridElementDetails.SelectedObject = (Item)listViewEntries.SelectedItems[0].Tag;
                propertyGridElementDetails.ExpandAllGridItems();

                linkLabelItemURL.Text = "Visit Website";
                linkLabelItemURL.Tag = ((Item)listViewEntries.SelectedItems[0].Tag).Url;
                linkLabelItemURL.LinkClicked -= Url_LinkClicked;
                linkLabelItemURL.LinkClicked += Url_LinkClicked;
            }
        }

        #endregion

        #region Common

        private void buttonPickFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
                {
                    textBoxContentFolder.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void buttonPreviewImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(openFileDialog.FileName))
                {
                    textBoxPreviewImage.Text = openFileDialog.FileName;
                }
            }
        }
        private void ResetTagsButton_Click(object sender, EventArgs e)
        {
            _SelectedTagCollection.Clear();
            if (numericUpDownPage.Maximum == 0) ResetNumericUpDownPageValue();
            StartQuerry();
        }

        private void RefreshStorageQuota()
        {
            if (Functions.IsSteamRunning)
            {
                statusStrip.Items.Clear();

                float ratioUsed = (float)Math.Round((float)SteamRemoteStorage.QuotaUsedBytes / (float)SteamRemoteStorage.QuotaBytes * 100f, 0, MidpointRounding.AwayFromZero);
                float ratioAvailable = (float)Math.Round(100f - ratioUsed, 0, MidpointRounding.AwayFromZero);

                statusStrip.Items.Add(new ToolStripLabel(
                    $"Bytes: {SteamRemoteStorage.QuotaBytes} | Used: {SteamRemoteStorage.QuotaUsedBytes} ({ratioUsed}%) | Available: {SteamRemoteStorage.QuotaRemainingBytes} ({ratioAvailable}%)"));
            }
        }

        private void ResetNumericUpDownPageValue()
        {
            numericUpDownPage.Minimum = 1;
            numericUpDownPage.Maximum = 1;
            numericUpDownPage.Value = 1;
        }

        private void Url_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(((LinkLabel)sender).Tag as string))
            {
                System.Diagnostics.Process.Start(((LinkLabel)sender).Tag as string);
            }
        }

        private void linkLabelWorkshopAgreement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://steamcommunity.com/sharedfiles/workshoplegalagreement");
        }

        private void buttonQuerry_Click(object sender, EventArgs e)
        {
            StartQuerry();
        }

        private void numericUpDownPage_ValueChanged(object sender, EventArgs e)
        {
            StartQuerry();
        }

        #endregion

        #region Core Methods

        private void buttonCreateItem_Click(object sender, EventArgs e)
        {
            if (Functions.IsSteamRunning)
            {
                statusStrip.Items.Add(_ProgressLabel);
                _ProgressData.Reset();

                var workshopItem = Editor.NewCommunityFile;

                workshopItem.WithTitle(textBoxTitle.Text);
                workshopItem.WithDescription(textBoxDescription.Text);

                if (!string.IsNullOrEmpty(textBoxPreviewImage.Text))
                {
                    workshopItem.WithPreviewFile(textBoxPreviewImage.Text);
                }

                if (!string.IsNullOrEmpty(textBoxContentFolder.Text))
                {
                    workshopItem.WithContent(new System.IO.DirectoryInfo(textBoxContentFolder.Text));
                }

                string[] tags = textBoxTags.Text.Split(';');
                foreach (string tag in tags)
                {
                    string trimmed = tag.Trim();
                    workshopItem.WithTag(trimmed);
                }

                CreateWorkshopItem(workshopItem);
            }
        }

        private async Task CreateWorkshopItem(Editor workshopItem)
        {
            var result = await workshopItem.SubmitAsync(_ProgressData);

            if (result.Success)
            {
                MessageBox.Show($"This workshop item was successfully created!", "Workshop Item Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshStorageQuota();
            }
            else
            {
                MessageBox.Show($"Can't create workshop item!\n\nPlease try again later.", $"Error: {result.Result}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            statusStrip.Items.Remove(_ProgressLabel);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (Functions.IsSteamRunning)
            {
                if (((Button)sender).Tag != null)
                {
                    Item item = (Item)((Button)sender).Tag;
                    DeleteWorkshopItem(item.Id);
                }
            }
        }

        private async Task DeleteWorkshopItem(PublishedFileId fileID)
        {
            var result = await SteamUGC.DeleteFileAsync(fileID);

            if (result)
            {
                // Delete preview files etc.
                foreach (string file in SteamRemoteStorage.Files)
                {
                    if (file.Contains(fileID.ToString())) SteamRemoteStorage.FileDelete(file);
                }

                MessageBox.Show($"The workshop item with the id '{fileID}' was successfully deleted!", "Workshop Item Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StartQuerry();
            }
            else
            {
                MessageBox.Show($"Can't delete workshop item with the id '{fileID}'!\n\nMaybe you don't own this file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSubscribe_Click(object sender, EventArgs e)
        {
            if (Functions.IsSteamRunning)
            {
                if (((Button)sender).Tag != null)
                {
                    Item item = (Item)((Button)sender).Tag;
                    SubscribeItem(item.Id);
                }
            }
        }

        private async Task SubscribeItem(PublishedFileId fileID)
        {
            var result = await SteamUGC.SubscribeItem(fileID);

            if (result)
            {

            }

            propertyGridElementDetails.Refresh();
        }

        private void buttonUnSubscribe_Click(object sender, EventArgs e)
        {
            if (Functions.IsSteamRunning)
            {
                if (((Button)sender).Tag != null)
                {
                    Item item = (Item)((Button)sender).Tag;
                    UnSubscribeItem(item.Id);
                }
            }
        }

        private async Task UnSubscribeItem(PublishedFileId fileID)
        {
            var result = await SteamUGC.UnSubscribeItem(fileID);

            if (result)
            {

            }

            propertyGridElementDetails.Refresh();
        }

        #endregion

        public MainEditor()
        {
            InitializeComponent();

            FormClosing += MainEditor_FormClosing;
            _ProgressData.Progress += _ProgressData_Progress;

            try
            {
                SteamClient.Init(480);

                Functions.IsSteamRunning = true;

                SteamUtils.OverlayNotificationPosition = NotificationPosition.BottomRight;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.ToString());
            }

            StartQuerry();
        }
    }
}
