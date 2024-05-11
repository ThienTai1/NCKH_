namespace NCKH.Models
{
    public class Customer
    {
        public string customerID { get; set; }
        public string gender { get; set; }
        public int SeniorCitizen { get; set; }
        public string Partner { get; set; }
        public string Dependents { get; set; }
        public int tenure { get; set; }
        public string PhoneService { get; set; }
        public string MultipleLines { get; set; }
        public string InternetService { get; set; }
        public string OnlineSecurity { get; set; }
        public string OnlineBackup { get; set; }
        public string DeviceProtection { get; set;}
        public string TechSupport { get; set;}
        public string StreamingTV { get; set;}
        public string StreamingMovies { get; set;}
        public string Contract { get; set;}
        public string PaperlessBilling { get; set;}
        public string PaymentMethod { get; set; }
        public string MonthlyCharges { get; set;}
        public string TotalCharges { get; set;}
        public string Churn { get; set;}
    }
}
