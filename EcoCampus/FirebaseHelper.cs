using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;



namespace EcoCampus
{
    internal class FirebaseHelper
    {
       /* FirebaseClient firebase = new FirebaseClient("https://ecocampus-eaa49-default-rtdb.asia-southeast1.firebasedatabase.app/");

            public async Task AddWasteRecord(string dateRecorded, double totalResaleValue, string wasteType)
        {
            await firebase
                .Child("WasteRecords")  // Firebase table name
                .PostAsync(new WasteRecord()
                {
                    DateRecorded = dateRecorded,
                    TotalResaleValue = totalResaleValue,
                    WasteType = wasteType
                });
        }

        public async Task<List<WasteRecord>> GetAllWasteRecords()
        {
            return (await firebase
                .Child("WasteRecords")  // Firebase table name
                .OnceAsync<WasteRecord>())  // Retrieve all records as WasteRecord objects
                .Select(item => new WasteRecord
                {
                    DateRecorded = item.Object.DateRecorded,
                    WasteType = item.Object.WasteType,
                    TotalResaleValue = item.Object.TotalResaleValue
                }).ToList();
        } */


    }

}
