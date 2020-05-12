using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare.API.Migrations
{
    public partial class EFCoreCodeFirstSampleModelsAppDbContextAddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecordItem_Diagnoses_DiagnosisId",
                table: "MedicalRecordItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecordItem_MedicalRecords_MedicalRecordId",
                table: "MedicalRecordItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecordItem_Medications_MedicationId",
                table: "MedicalRecordItem");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecordItem_MedicationId",
                table: "MedicalRecordItem");

            migrationBuilder.AlterColumn<int>(
                name: "MedicationId",
                table: "MedicalRecordItem",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiagnosisId",
                table: "MedicalRecordItem",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<short>(
                name: "MedicationId1",
                table: "MedicalRecordItem",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecordItem_MedicationId1",
                table: "MedicalRecordItem",
                column: "MedicationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecordItem_Diagnoses_DiagnosisId",
                table: "MedicalRecordItem",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecordItem_MedicalRecords_MedicalRecordId",
                table: "MedicalRecordItem",
                column: "MedicalRecordId",
                principalTable: "MedicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecordItem_Medications_MedicationId1",
                table: "MedicalRecordItem",
                column: "MedicationId1",
                principalTable: "Medications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecordItem_Diagnoses_DiagnosisId",
                table: "MedicalRecordItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecordItem_MedicalRecords_MedicalRecordId",
                table: "MedicalRecordItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecordItem_Medications_MedicationId1",
                table: "MedicalRecordItem");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecordItem_MedicationId1",
                table: "MedicalRecordItem");

            migrationBuilder.DropColumn(
                name: "MedicationId1",
                table: "MedicalRecordItem");

            migrationBuilder.AlterColumn<short>(
                name: "MedicationId",
                table: "MedicalRecordItem",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DiagnosisId",
                table: "MedicalRecordItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecordItem_MedicationId",
                table: "MedicalRecordItem",
                column: "MedicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecordItem_Diagnoses_DiagnosisId",
                table: "MedicalRecordItem",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecordItem_MedicalRecords_MedicalRecordId",
                table: "MedicalRecordItem",
                column: "MedicalRecordId",
                principalTable: "MedicalRecords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecordItem_Medications_MedicationId",
                table: "MedicalRecordItem",
                column: "MedicationId",
                principalTable: "Medications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
