using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NCKH.Models;

public partial class Customer
{
    [Key]
    public string CustomerId { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public byte SeniorCitizen { get; set; }

    public string Partner { get; set; }

    public string Dependents { get; set; }

    public byte Tenure { get; set; }

    public string PhoneService { get; set; }

    public string? MultipleLines { get; set; }

    public string InternetService { get; set; } = null!;

    public string? OnlineSecurity { get; set; }

    public string? OnlineBackup { get; set; }

    public string? DeviceProtection { get; set; }

    public string? TechSupport { get; set; }

    public string? StreamingTv { get; set; }

    public string? StreamingMovies { get; set; }

    public string Contract { get; set; } = null!;

    public string PaperlessBilling { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public double MonthlyCharges { get; set; }

    public double? TotalCharges { get; set; }

    public string Churn { get; set; }
}
