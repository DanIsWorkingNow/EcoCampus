namespace EcoCampus
{
    public partial class MainPage : ContentPage
    {
        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WasteRecord.txt");
        // Predefined resale rates per kg for each waste type in MYR
        const double plasticRate = 1.5;  // Plastic rate in MYR per kg
        const double metalRate = 2.0;    // Metal rate in MYR per kg
        const double paperRate = 0.8;    // Paper rate in MYR per kg
        const double glassRate = 1.2;    // Glass rate in MYR per kg

        /*FirebaseHelper firebaseHelper = new FirebaseHelper();*/

        public MainPage()
        {
            InitializeComponent();
        }

        void onDatePickerSelected(object sender, DateChangedEventArgs e)
        {
            var selectedDate = e.NewDate.ToString();
        }

        // Method to calculate resale value based on weight of different waste types
        void OnCalculateWaste(object sender, EventArgs e)
        {
            double plasticWeight = 0.0;
            double metalWeight = 0.0;
            double paperWeight = 0.0;
            double glassWeight = 0.0;
            double totalResaleValue = 0.0;

            // Try parsing the input values from the Entry fields
            bool isPlasticValid = Double.TryParse(inputPlastic.Text, out plasticWeight);
            bool isMetalValid = Double.TryParse(inputMetal.Text, out metalWeight);
            bool isPaperValid = Double.TryParse(inputPaper.Text, out paperWeight);
            

            // Calculate resale value for each waste type where input is valid
            if (isPlasticValid)
            {
                totalResaleValue += (plasticWeight * plasticRate);
            }
            if (isMetalValid)
            {
                totalResaleValue += (metalWeight * metalRate);
            }
            if (isPaperValid)
            {
                totalResaleValue += (paperWeight * paperRate);
            }
           

            // Display the result in the outputResult label in MYR
            if (totalResaleValue > 0)
            {
                outputResult.Text = $"Total Resale Value: RM {totalResaleValue:0.00}";
            }
            else
            {
                outputResult.Text = "Please enter valid values for at least one waste type.";
            }
        }

         void OnSaveRecord(object sender, EventArgs e)
        {
            var selectedDate = selectDate.Date.ToString("dd/MM/yyyy");

            // Get input values
            double plasticWeight = 0.0, metalWeight = 0.0, paperWeight = 0.0, glassWeight = 0.0;
            Double.TryParse(inputPlastic.Text, out plasticWeight);
            Double.TryParse(inputMetal.Text, out metalWeight);
            Double.TryParse(inputPaper.Text, out paperWeight);
            

            // Calculate resale value
            double totalResaleValue = (plasticWeight * plasticRate) +
                                      (metalWeight * metalRate) +
                                      (paperWeight * paperRate) +
                                      (glassWeight * glassRate);

            // Prepare the waste type
            string wasteType = "";
            if (plasticWeight > 0) wasteType += "Plastic ";
            if (metalWeight > 0) wasteType += "Metal ";
            if (paperWeight > 0) wasteType += "Paper ";
            if (glassWeight > 0) wasteType += "Glass ";

            // Prepare the record to save
            var record = $"Date: {selectedDate}\n" +
                         $"Waste Type: {wasteType.Trim()}\n" +
                         $"Total Resale Value: RM {totalResaleValue:0.00}\n\n";

            // Write to file
            File.AppendAllText(fileName, record);
            DisplayAlert("Record Saved", "Your recycling record has been saved.", "OK");
            /*var selectdate = selectDate.Date.ToString("dd/MM/yyyy");

            // Get the weights entered by the user for each type of waste
            double plasticWeight = Double.Parse(inputPlastic.Text);
            double metalWeight = Double.Parse(inputMetal.Text);
            double paperWeight = Double.Parse(inputPaper.Text);
            double glassWeight = Double.Parse(inputGlass.Text);

            // Calculate the total resale value (you can modify this calculation based on your logic)
            double totalResaleValue = (plasticWeight * plasticRate) +
                                      (metalWeight * metalRate) +
                                      (paperWeight * paperRate) +
                                      (glassWeight * glassRate);

            // Prepare the waste type string (could be "Plastic", "Metal", etc. based on user input)
            string wasteType = "";
            if (plasticWeight > 0) wasteType += "Plastic ";
            if (metalWeight > 0) wasteType += "Metal ";
            if (paperWeight > 0) wasteType += "Paper ";
            if (glassWeight > 0) wasteType += "Glass ";

            // Use firebaseHelper to save the record in Firebase
            await firebaseHelper.AddWasteRecord(selectdate, wasteType.Trim(), totalResaleValue);

            // Notify the user that the record has been saved
            await DisplayAlert("Record Saved", "Waste Record has been saved", "OK");*/
        }


        // Method to reset the fields and output result
        void OnReset(object sender, EventArgs e)
        {
            // Clear the input fields and reset the output label
            inputPlastic.Text = string.Empty;
            inputMetal.Text = string.Empty;
            inputPaper.Text = string.Empty;
            
            outputResult.Text = "0.00";
        }
    }
}


