using Newtonsoft.Json;
using Note_Taking.Data;
using System.Data;

namespace Note_Taking
{
    public partial class NoteForm : Form
    {
        const string filePath = "storage.json";
        DataTable table;
        List<NoteEntry> lstNoteEntries;

        public int GrvNotesSelectedRowIndex
        {
            get { return GrvNotes.CurrentCell.RowIndex; }
        }


        public NoteForm()
        {
            InitializeComponent();
        }

        #region Form Events

        private void NoteForm_Load(object sender, EventArgs e)
        {
            LoadGridView();
            LoadDataFromJsonFile();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (LblId.Text == string.Empty)
            {
                table.Rows.Add(Guid.NewGuid(), TxtTitle.Text, TxtMessage.Text);
            }
            else
            {
                string findById = string.Concat("Id='", LblId.Text, "'");
                DataRow? dr = table.Select(findById).FirstOrDefault();

                if (dr != null)
                {
                    dr["Title"] = TxtTitle.Text;
                    dr["Message"] = TxtMessage.Text;
                }
            }

            ClearTextBox();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (table.Rows.Count > 0)
            {
                ClearTextBox();

                table.Rows.RemoveAt(GrvNotesSelectedRowIndex);

                if (GrvNotes.Rows.Count > 0)
                {
                    if (GrvNotesSelectedRowIndex > GrvNotes.Rows.Count)
                    {
                        GrvNotes.Rows[GrvNotes.Rows.Count - 1].Selected = true;
                    }
                    else
                    {
                        GrvNotes.Rows[GrvNotesSelectedRowIndex].Selected = true;
                    }
                }

            }
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            ReadItemSelected();
        }

        private void GrvNotes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ReadItemSelected();
        }

        private void NoteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveDataToJsonFile();
        }

        #endregion


        #region Methods

        private void LoadGridView()
        {
            table = new DataTable();
            table.Columns.Add("Id", typeof(Guid));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Message", typeof(string));

            GrvNotes.DataSource = table;

            GrvNotes.Columns["Id"].Visible = false;
            GrvNotes.Columns["Message"].Visible = false;

            GrvNotes.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GrvNotes.Columns["Title"].FillWeight = 100;
        }

        private void ClearTextBox()
        {
            LblId.Text = string.Empty;
            TxtMessage.Clear();
            TxtTitle.Clear();
        }

        private void LoadDataFromJsonFile()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            string json = File.ReadAllText(filePath);
            lstNoteEntries = JsonConvert.DeserializeObject<List<NoteEntry>>(json);

            table.Rows.Clear();

            foreach (NoteEntry item in lstNoteEntries)
            {
                table.Rows.Add(item.Id, item.Title, item.Message);
            }

        }
        private void SaveDataToJsonFile()
        {
            lstNoteEntries = new List<NoteEntry>();

            foreach (DataGridViewRow row in GrvNotes.Rows)
            {
                if (!row.IsNewRow)
                {
                    NoteEntry entry = new NoteEntry
                    {
                        Id = row.Cells[0].Value.ToString(),
                        Title = row.Cells[1].Value.ToString(),
                        Message = row.Cells[2].Value.ToString(),
                    };

                    lstNoteEntries.Add(entry);
                }
            }

            string json = JsonConvert.SerializeObject(lstNoteEntries, Formatting.Indented);

            File.WriteAllText(filePath, json);
        }

        private void ReadItemSelected()
        {
            if (table.Rows.Count > 0)
            {
                LblId.Text = table.Rows[GrvNotesSelectedRowIndex].ItemArray[0].ToString();
                TxtTitle.Text = table.Rows[GrvNotesSelectedRowIndex].ItemArray[1].ToString();
                TxtMessage.Text = table.Rows[GrvNotesSelectedRowIndex].ItemArray[2].ToString();
            }
        }

        #endregion



    }
}