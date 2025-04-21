namespace EcoCampus
{
    public partial class Record : ContentPage
    {
        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WasteRecord.txt");

        public Record()
        {
            InitializeComponent();
            if (File.Exists(fileName))
            {
                displayRecord.Text = File.ReadAllText(fileName);
            }
            else
            {
                displayRecord.Text = "No records available.";
            }
        }

        private void OnClearRecordClicked(object sender, EventArgs e)
        {
            if (File.Exists(fileName))
            {
                // Clear the file content
                File.WriteAllText(fileName, string.Empty);

                // Update the display label
                displayRecord.Text = "Records cleared successfully.";
            }
            else
            {
                displayRecord.Text = "No records available to clear.";
            }
        }
    }
}
