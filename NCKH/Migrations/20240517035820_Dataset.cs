using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NCKH.Migrations
{
    /// <inheritdoc />
    public partial class Dataset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeniorCitizen = table.Column<bool>(type: "bit", nullable: false),
                    Partner = table.Column<bool>(type: "bit", nullable: false),
                    Dependents = table.Column<bool>(type: "bit", nullable: false),
                    tenure = table.Column<byte>(type: "tinyint", nullable: false),
                    PhoneService = table.Column<bool>(type: "bit", nullable: false),
                    MultipleLines = table.Column<bool>(type: "bit", nullable: true),
                    InternetService = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OnlineSecurity = table.Column<bool>(type: "bit", nullable: true),
                    OnlineBackup = table.Column<bool>(type: "bit", nullable: true),
                    DeviceProtection = table.Column<bool>(type: "bit", nullable: true),
                    TechSupport = table.Column<bool>(type: "bit", nullable: true),
                    StreamingTV = table.Column<bool>(type: "bit", nullable: true),
                    StreamingMovies = table.Column<bool>(type: "bit", nullable: true),
                    Contract = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaperlessBilling = table.Column<bool>(type: "bit", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MonthlyCharges = table.Column<double>(type: "float", nullable: false),
                    TotalCharges = table.Column<double>(type: "float", nullable: true),
                    Churn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
