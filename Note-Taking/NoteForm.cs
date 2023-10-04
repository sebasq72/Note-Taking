using Newtonsoft.Json;
using Note_Taking.Data;
using System.Data;
using System.Text.Json.Serialization;

namespace Note_Taking
{
    public partial class NoteForm : Form
    {

        DataTable table;
        List<NoteEntry> lstNoteEntries;

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
            table.Rows.Add(Guid.NewGuid(), TxtTitle.Text, TxtNote.Text);

            ClearTextBox();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            if (table.Rows.Count > 0)
            {
                int index = GrvNotes.CurrentCell.RowIndex;

                TxtTitle.Text = table.Rows[index].ItemArray[1].ToString();
                TxtNote.Text = table.Rows[index].ItemArray[2].ToString();
            }
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
            TxtNote.Clear();
            TxtTitle.Clear();
        }

        private void LoadDataFromJsonFile()
        {
            string filePath = "storage.json";

            if(!File.Exists(filePath))
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

        }

        #endregion

    }
}