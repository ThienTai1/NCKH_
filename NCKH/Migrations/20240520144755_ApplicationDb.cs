using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NCKH.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeniorCitizen = table.Column<byte>(type: "tinyint", nullable: false),
                    Partner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dependents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tenure = table.Column<byte>(type: "tinyint", nullable: false),
                    PhoneService = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MultipleLines = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternetService = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OnlineSecurity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlineBackup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceProtection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechSupport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreamingTV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreamingMovies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contract = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaperlessBilling = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MonthlyCharges = table.Column<double>(type: "float", nullable: false),
                    TotalCharges = table.Column<double>(type: "float", nullable: true),
                    Churn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customerID);
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
