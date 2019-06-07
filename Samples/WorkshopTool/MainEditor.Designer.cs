namespace WorkshopTool
{
    partial class MainEditor
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listViewEntries = new System.Windows.Forms.ListView();
            this.flowLayoutPanelTagCollection = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonQuerry = new System.Windows.Forms.Button();
            this.numericUpDownPage = new System.Windows.Forms.NumericUpDown();
            this.radioButtonMatchAllTags = new System.Windows.Forms.RadioButton();
            this.radioButtonMatchAnyTags = new System.Windows.Forms.RadioButton();
            this.checkBoxFromSelf = new System.Windows.Forms.CheckBox();
            this.propertyGridElementDetails = new System.Windows.Forms.PropertyGrid();
            this.flowLayoutPanelDetails = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSubscribe = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.linkLabelItemURL = new System.Windows.Forms.LinkLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripComboBoxMode = new System.Windows.Forms.ToolStripComboBox();
            this.panelQuerry = new System.Windows.Forms.Panel();
            this.panelCreate = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.buttonPreviewImage = new System.Windows.Forms.Button();
            this.textBoxPreviewImage = new System.Windows.Forms.TextBox();
            this.labelPreviewImage = new System.Windows.Forms.Label();
            this.buttonPickFolder = new System.Windows.Forms.Button();
            this.textBoxContentFolder = new System.Windows.Forms.TextBox();
            this.labelContent = new System.Windows.Forms.Label();
            this.textBoxTags = new System.Windows.Forms.TextBox();
            this.labelTag = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.linkLabelWorkshopAgreement = new System.Windows.Forms.LinkLabel();
            this.buttonCreateItem = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.checkBoxSubscribed = new System.Windows.Forms.CheckBox();
            this.buttonUnSubscribe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPage)).BeginInit();
            this.flowLayoutPanelDetails.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelQuerry.SuspendLayout();
            this.panelCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.listViewEntries);
            this.splitContainer.Panel1.Controls.Add(this.flowLayoutPanelTagCollection);
            this.splitContainer.Panel1.Controls.Add(this.flowLayoutPanel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.propertyGridElementDetails);
            this.splitContainer.Panel2.Controls.Add(this.flowLayoutPanelDetails);
            this.splitContainer.Size = new System.Drawing.Size(1262, 619);
            this.splitContainer.SplitterDistance = 739;
            this.splitContainer.TabIndex = 0;
            // 
            // listViewEntries
            // 
            this.listViewEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEntries.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewEntries.FullRowSelect = true;
            this.listViewEntries.HideSelection = false;
            this.listViewEntries.Location = new System.Drawing.Point(0, 51);
            this.listViewEntries.MultiSelect = false;
            this.listViewEntries.Name = "listViewEntries";
            this.listViewEntries.ShowGroups = false;
            this.listViewEntries.Size = new System.Drawing.Size(739, 538);
            this.listViewEntries.TabIndex = 0;
            this.listViewEntries.UseCompatibleStateImageBehavior = false;
            this.listViewEntries.View = System.Windows.Forms.View.List;
            this.listViewEntries.SelectedIndexChanged += new System.EventHandler(this.listViewEntries_SelectedIndexChanged);
            // 
            // flowLayoutPanelTagCollection
            // 
            this.flowLayoutPanelTagCollection.AutoScroll = true;
            this.flowLayoutPanelTagCollection.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelTagCollection.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelTagCollection.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelTagCollection.Name = "flowLayoutPanelTagCollection";
            this.flowLayoutPanelTagCollection.Size = new System.Drawing.Size(739, 51);
            this.flowLayoutPanelTagCollection.TabIndex = 3;
            this.flowLayoutPanelTagCollection.WrapContents = false;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Controls.Add(this.buttonQuerry);
            this.flowLayoutPanel.Controls.Add(this.numericUpDownPage);
            this.flowLayoutPanel.Controls.Add(this.radioButtonMatchAllTags);
            this.flowLayoutPanel.Controls.Add(this.radioButtonMatchAnyTags);
            this.flowLayoutPanel.Controls.Add(this.checkBoxFromSelf);
            this.flowLayoutPanel.Controls.Add(this.checkBoxSubscribed);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 589);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(739, 30);
            this.flowLayoutPanel.TabIndex = 2;
            // 
            // buttonQuerry
            // 
            this.buttonQuerry.Location = new System.Drawing.Point(661, 3);
            this.buttonQuerry.Name = "buttonQuerry";
            this.buttonQuerry.Size = new System.Drawing.Size(75, 23);
            this.buttonQuerry.TabIndex = 2;
            this.buttonQuerry.Text = "Querry";
            this.buttonQuerry.UseVisualStyleBackColor = true;
            this.buttonQuerry.Click += new System.EventHandler(this.buttonQuerry_Click);
            // 
            // numericUpDownPage
            // 
            this.numericUpDownPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownPage.Location = new System.Drawing.Point(578, 4);
            this.numericUpDownPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPage.Name = "numericUpDownPage";
            this.numericUpDownPage.Size = new System.Drawing.Size(77, 22);
            this.numericUpDownPage.TabIndex = 1;
            this.numericUpDownPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPage.ValueChanged += new System.EventHandler(this.numericUpDownPage_ValueChanged);
            // 
            // radioButtonMatchAllTags
            // 
            this.radioButtonMatchAllTags.AutoSize = true;
            this.radioButtonMatchAllTags.Checked = true;
            this.radioButtonMatchAllTags.Location = new System.Drawing.Point(450, 3);
            this.radioButtonMatchAllTags.Name = "radioButtonMatchAllTags";
            this.radioButtonMatchAllTags.Size = new System.Drawing.Size(122, 21);
            this.radioButtonMatchAllTags.TabIndex = 3;
            this.radioButtonMatchAllTags.TabStop = true;
            this.radioButtonMatchAllTags.Text = "Match All Tags";
            this.radioButtonMatchAllTags.UseVisualStyleBackColor = true;
            // 
            // radioButtonMatchAnyTags
            // 
            this.radioButtonMatchAnyTags.AutoSize = true;
            this.radioButtonMatchAnyTags.Location = new System.Drawing.Point(320, 3);
            this.radioButtonMatchAnyTags.Name = "radioButtonMatchAnyTags";
            this.radioButtonMatchAnyTags.Size = new System.Drawing.Size(124, 21);
            this.radioButtonMatchAnyTags.TabIndex = 4;
            this.radioButtonMatchAnyTags.Text = "Match Any Tag";
            this.radioButtonMatchAnyTags.UseVisualStyleBackColor = true;
            // 
            // checkBoxFromSelf
            // 
            this.checkBoxFromSelf.AutoSize = true;
            this.checkBoxFromSelf.Location = new System.Drawing.Point(224, 3);
            this.checkBoxFromSelf.Name = "checkBoxFromSelf";
            this.checkBoxFromSelf.Size = new System.Drawing.Size(90, 21);
            this.checkBoxFromSelf.TabIndex = 5;
            this.checkBoxFromSelf.Text = "From Self";
            this.checkBoxFromSelf.UseVisualStyleBackColor = true;
            // 
            // propertyGridElementDetails
            // 
            this.propertyGridElementDetails.DisabledItemForeColor = System.Drawing.SystemColors.ControlText;
            this.propertyGridElementDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridElementDetails.HelpVisible = false;
            this.propertyGridElementDetails.Location = new System.Drawing.Point(0, 0);
            this.propertyGridElementDetails.Name = "propertyGridElementDetails";
            this.propertyGridElementDetails.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGridElementDetails.Size = new System.Drawing.Size(519, 589);
            this.propertyGridElementDetails.TabIndex = 0;
            this.propertyGridElementDetails.ToolbarVisible = false;
            // 
            // flowLayoutPanelDetails
            // 
            this.flowLayoutPanelDetails.Controls.Add(this.buttonSubscribe);
            this.flowLayoutPanelDetails.Controls.Add(this.buttonUnSubscribe);
            this.flowLayoutPanelDetails.Controls.Add(this.buttonDelete);
            this.flowLayoutPanelDetails.Controls.Add(this.linkLabelItemURL);
            this.flowLayoutPanelDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelDetails.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelDetails.Location = new System.Drawing.Point(0, 589);
            this.flowLayoutPanelDetails.Name = "flowLayoutPanelDetails";
            this.flowLayoutPanelDetails.Size = new System.Drawing.Size(519, 30);
            this.flowLayoutPanelDetails.TabIndex = 3;
            // 
            // buttonSubscribe
            // 
            this.buttonSubscribe.AutoSize = true;
            this.buttonSubscribe.Location = new System.Drawing.Point(387, 3);
            this.buttonSubscribe.Name = "buttonSubscribe";
            this.buttonSubscribe.Size = new System.Drawing.Size(129, 27);
            this.buttonSubscribe.TabIndex = 5;
            this.buttonSubscribe.Text = "Subscribe";
            this.buttonSubscribe.UseVisualStyleBackColor = true;
            this.buttonSubscribe.Click += new System.EventHandler(this.buttonSubscribe_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.AutoSize = true;
            this.buttonDelete.Location = new System.Drawing.Point(144, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(102, 27);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // linkLabelItemURL
            // 
            this.linkLabelItemURL.Location = new System.Drawing.Point(38, 0);
            this.linkLabelItemURL.Name = "linkLabelItemURL";
            this.linkLabelItemURL.Size = new System.Drawing.Size(100, 23);
            this.linkLabelItemURL.TabIndex = 4;
            this.linkLabelItemURL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip.Location = new System.Drawing.Point(0, 651);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1262, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxMode});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1262, 32);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripComboBoxMode
            // 
            this.toolStripComboBoxMode.AutoSize = false;
            this.toolStripComboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxMode.Items.AddRange(new object[] {
            "Querry Workshop",
            "Create Workshop Item"});
            this.toolStripComboBoxMode.Name = "toolStripComboBoxMode";
            this.toolStripComboBoxMode.Size = new System.Drawing.Size(200, 28);
            this.toolStripComboBoxMode.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxMode_SelectedIndexChanged);
            // 
            // panelQuerry
            // 
            this.panelQuerry.Controls.Add(this.splitContainer);
            this.panelQuerry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelQuerry.Location = new System.Drawing.Point(0, 32);
            this.panelQuerry.Name = "panelQuerry";
            this.panelQuerry.Size = new System.Drawing.Size(1262, 619);
            this.panelQuerry.TabIndex = 4;
            // 
            // panelCreate
            // 
            this.panelCreate.Controls.Add(this.splitContainer1);
            this.panelCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCreate.Location = new System.Drawing.Point(0, 32);
            this.panelCreate.Name = "panelCreate";
            this.panelCreate.Size = new System.Drawing.Size(1262, 619);
            this.panelCreate.TabIndex = 5;
            this.panelCreate.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxDetails);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.linkLabelWorkshopAgreement);
            this.splitContainer1.Panel2.Controls.Add(this.buttonCreateItem);
            this.splitContainer1.Size = new System.Drawing.Size(1262, 619);
            this.splitContainer1.SplitterDistance = 387;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.buttonPreviewImage);
            this.groupBoxDetails.Controls.Add(this.textBoxPreviewImage);
            this.groupBoxDetails.Controls.Add(this.labelPreviewImage);
            this.groupBoxDetails.Controls.Add(this.buttonPickFolder);
            this.groupBoxDetails.Controls.Add(this.textBoxContentFolder);
            this.groupBoxDetails.Controls.Add(this.labelContent);
            this.groupBoxDetails.Controls.Add(this.textBoxTags);
            this.groupBoxDetails.Controls.Add(this.labelTag);
            this.groupBoxDetails.Controls.Add(this.textBoxDescription);
            this.groupBoxDetails.Controls.Add(this.labelDescription);
            this.groupBoxDetails.Controls.Add(this.textBoxTitle);
            this.groupBoxDetails.Controls.Add(this.labelTitle);
            this.groupBoxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDetails.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(1262, 387);
            this.groupBoxDetails.TabIndex = 0;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Item Details";
            // 
            // buttonPreviewImage
            // 
            this.buttonPreviewImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPreviewImage.Location = new System.Drawing.Point(3, 286);
            this.buttonPreviewImage.Name = "buttonPreviewImage";
            this.buttonPreviewImage.Size = new System.Drawing.Size(1256, 23);
            this.buttonPreviewImage.TabIndex = 11;
            this.buttonPreviewImage.Text = "Pick a Preview Image";
            this.buttonPreviewImage.UseVisualStyleBackColor = true;
            this.buttonPreviewImage.Click += new System.EventHandler(this.buttonPreviewImage_Click);
            // 
            // textBoxPreviewImage
            // 
            this.textBoxPreviewImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxPreviewImage.Location = new System.Drawing.Point(3, 264);
            this.textBoxPreviewImage.Name = "textBoxPreviewImage";
            this.textBoxPreviewImage.Size = new System.Drawing.Size(1256, 22);
            this.textBoxPreviewImage.TabIndex = 10;
            // 
            // labelPreviewImage
            // 
            this.labelPreviewImage.AutoSize = true;
            this.labelPreviewImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPreviewImage.Location = new System.Drawing.Point(3, 237);
            this.labelPreviewImage.Name = "labelPreviewImage";
            this.labelPreviewImage.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelPreviewImage.Size = new System.Drawing.Size(99, 27);
            this.labelPreviewImage.TabIndex = 9;
            this.labelPreviewImage.Text = "Preview Image";
            // 
            // buttonPickFolder
            // 
            this.buttonPickFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPickFolder.Location = new System.Drawing.Point(3, 214);
            this.buttonPickFolder.Name = "buttonPickFolder";
            this.buttonPickFolder.Size = new System.Drawing.Size(1256, 23);
            this.buttonPickFolder.TabIndex = 8;
            this.buttonPickFolder.Text = "Pick a Content Folder";
            this.buttonPickFolder.UseVisualStyleBackColor = true;
            this.buttonPickFolder.Click += new System.EventHandler(this.buttonPickFolder_Click);
            // 
            // textBoxContentFolder
            // 
            this.textBoxContentFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxContentFolder.Location = new System.Drawing.Point(3, 192);
            this.textBoxContentFolder.Name = "textBoxContentFolder";
            this.textBoxContentFolder.Size = new System.Drawing.Size(1256, 22);
            this.textBoxContentFolder.TabIndex = 7;
            // 
            // labelContent
            // 
            this.labelContent.AutoSize = true;
            this.labelContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelContent.Location = new System.Drawing.Point(3, 165);
            this.labelContent.Name = "labelContent";
            this.labelContent.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelContent.Size = new System.Drawing.Size(101, 27);
            this.labelContent.TabIndex = 6;
            this.labelContent.Text = "Content Folder";
            // 
            // textBoxTags
            // 
            this.textBoxTags.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxTags.Location = new System.Drawing.Point(3, 143);
            this.textBoxTags.Name = "textBoxTags";
            this.textBoxTags.Size = new System.Drawing.Size(1256, 22);
            this.textBoxTags.TabIndex = 5;
            // 
            // labelTag
            // 
            this.labelTag.AutoSize = true;
            this.labelTag.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTag.Location = new System.Drawing.Point(3, 116);
            this.labelTag.Name = "labelTag";
            this.labelTag.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelTag.Size = new System.Drawing.Size(397, 27);
            this.labelTag.TabIndex = 4;
            this.labelTag.Text = "Tags (seperate each tag with a semicolon \"Tag1;Tag2;Tag3\")";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxDescription.Location = new System.Drawing.Point(3, 94);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(1256, 22);
            this.textBoxDescription.TabIndex = 3;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDescription.Location = new System.Drawing.Point(3, 67);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelDescription.Size = new System.Drawing.Size(79, 27);
            this.labelDescription.TabIndex = 2;
            this.labelDescription.Text = "Description";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxTitle.Location = new System.Drawing.Point(3, 45);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(1256, 22);
            this.textBoxTitle.TabIndex = 1;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Location = new System.Drawing.Point(3, 18);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelTitle.Size = new System.Drawing.Size(35, 27);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title";
            // 
            // linkLabelWorkshopAgreement
            // 
            this.linkLabelWorkshopAgreement.AutoSize = true;
            this.linkLabelWorkshopAgreement.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkLabelWorkshopAgreement.Location = new System.Drawing.Point(0, 23);
            this.linkLabelWorkshopAgreement.Name = "linkLabelWorkshopAgreement";
            this.linkLabelWorkshopAgreement.Size = new System.Drawing.Size(590, 17);
            this.linkLabelWorkshopAgreement.TabIndex = 10;
            this.linkLabelWorkshopAgreement.TabStop = true;
            this.linkLabelWorkshopAgreement.Text = "By submitting this item, you agree to the workshop terms of service. Click here t" +
    "o learn more.";
            this.linkLabelWorkshopAgreement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelWorkshopAgreement_LinkClicked);
            // 
            // buttonCreateItem
            // 
            this.buttonCreateItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCreateItem.Location = new System.Drawing.Point(0, 0);
            this.buttonCreateItem.Name = "buttonCreateItem";
            this.buttonCreateItem.Size = new System.Drawing.Size(1262, 23);
            this.buttonCreateItem.TabIndex = 9;
            this.buttonCreateItem.Text = "Upload Workshop Item";
            this.buttonCreateItem.UseVisualStyleBackColor = true;
            this.buttonCreateItem.Click += new System.EventHandler(this.buttonCreateItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "image files (*.png;*.jpg;*.gif)|*.png;*.jpg;*.gif";
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.ShowReadOnly = true;
            this.openFileDialog.Title = "Select a Preview Image for the Workshop Item";
            // 
            // checkBoxSubscribed
            // 
            this.checkBoxSubscribed.AutoSize = true;
            this.checkBoxSubscribed.Location = new System.Drawing.Point(117, 3);
            this.checkBoxSubscribed.Name = "checkBoxSubscribed";
            this.checkBoxSubscribed.Size = new System.Drawing.Size(101, 21);
            this.checkBoxSubscribed.TabIndex = 6;
            this.checkBoxSubscribed.Text = "Subscribed";
            this.checkBoxSubscribed.UseVisualStyleBackColor = true;
            // 
            // buttonUnSubscribe
            // 
            this.buttonUnSubscribe.AutoSize = true;
            this.buttonUnSubscribe.Location = new System.Drawing.Point(252, 3);
            this.buttonUnSubscribe.Name = "buttonUnSubscribe";
            this.buttonUnSubscribe.Size = new System.Drawing.Size(129, 27);
            this.buttonUnSubscribe.TabIndex = 6;
            this.buttonUnSubscribe.Text = "UnSubscribe";
            this.buttonUnSubscribe.UseVisualStyleBackColor = true;
            this.buttonUnSubscribe.Click += new System.EventHandler(this.buttonUnSubscribe_Click);
            // 
            // MainEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.panelQuerry);
            this.Controls.Add(this.panelCreate);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Workshop Tool";
            this.Load += new System.EventHandler(this.MainEditor_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPage)).EndInit();
            this.flowLayoutPanelDetails.ResumeLayout(false);
            this.flowLayoutPanelDetails.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelQuerry.ResumeLayout(false);
            this.panelCreate.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        public System.Windows.Forms.ListView listViewEntries;
        public System.Windows.Forms.PropertyGrid propertyGridElementDetails;
        public System.Windows.Forms.NumericUpDown numericUpDownPage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDetails;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTagCollection;
        private System.Windows.Forms.Button buttonQuerry;
        private System.Windows.Forms.RadioButton radioButtonMatchAllTags;
        private System.Windows.Forms.RadioButton radioButtonMatchAnyTags;
        private System.Windows.Forms.CheckBox checkBoxFromSelf;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxMode;
        private System.Windows.Forms.Panel panelQuerry;
        private System.Windows.Forms.Panel panelCreate;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxTags;
        private System.Windows.Forms.Label labelTag;
        private System.Windows.Forms.Button buttonPickFolder;
        private System.Windows.Forms.TextBox textBoxContentFolder;
        private System.Windows.Forms.Label labelContent;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonCreateItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.LinkLabel linkLabelItemURL;
        private System.Windows.Forms.LinkLabel linkLabelWorkshopAgreement;
        private System.Windows.Forms.Button buttonPreviewImage;
        private System.Windows.Forms.TextBox textBoxPreviewImage;
        private System.Windows.Forms.Label labelPreviewImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonSubscribe;
        private System.Windows.Forms.CheckBox checkBoxSubscribed;
        private System.Windows.Forms.Button buttonUnSubscribe;
    }
}

