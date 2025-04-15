using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_103022330128
{
    public class BankTransferConfig
    {
        public string lang { get; set; }
        public class Transfer {  
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }
        }
            public Transfer transfer { get; set; }

        public List<string> methods  { get; set; }
        public class Confirmation 
        {
           public string en {  get; set; }
           public string id { get; set; }
        }
        
            public Confirmation confirmation { get; set; }
        private const string configPath = "bank_transfer_config.json";

        public void setDefault()
        {
            BankTransferConfig bankTransferConfig = new BankTransferConfig();
            bankTransferConfig.lang = "en";
            bankTransferConfig.transfer.threshold = 25000000;
            bankTransferConfig.transfer.low_fee = 6500;
            bankTransferConfig.transfer.high_fee = 15000;
            bankTransferConfig.methods = ["RTO(real-time)", "SKN", "RTGS", "BI FAST"];
            bankTransferConfig.confirmation.en = "yes";
            bankTransferConfig.confirmation.id = "ya";
            
        }

        public static BankTransferConfig LoadFromFile()
        {
            if (File.Exists(configPath))
            {
                string json = File.ReadAllText(configPath);
                return JsonSerializer.Deserialize<BankTransferConfig>(json);
            }
            else
            {
                var defaultConfig = new BankTransferConfig
                {
                    lang = "en",
                    transfer =''
                }
            }
        }



}
