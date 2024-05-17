using System;
using System.Collections.Generic;

namespace NCKH.Models;

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public bool SeniorCitizen { get; set; }

    public bool Partner { get; set; }

    public bool Dependents { get; set; }

    public byte Tenure { get; set; }

    public bool PhoneService { get; set; }

    public bool? MultipleLines { get; set; }

    public string InternetService { get; set; } = null!;

    public bool? OnlineSecurity { get; set; }

    public bool? OnlineBackup { get; set; }

    public bool? DeviceProtection { get; set; }

    public bool? TechSupport { get; set; }

    public bool? StreamingTv { get; set; }

    public bool? StreamingMovies { get; set; }

    public string Contract { get; set; } = null!;

    public bool PaperlessBilling { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public double MonthlyCharges { get; set; }

    public double? TotalCharges { get; set; }

    public bool Churn { get; set; }
}
