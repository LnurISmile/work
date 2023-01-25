using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace work.data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "archives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_archives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bodyds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    FootSize = table.Column<int>(type: "int", nullable: false),
                    BodyDimensionUp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyDimensionDown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadDimension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentBD = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bodyds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bonus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BonusAmount = table.Column<double>(type: "float", nullable: false),
                    BonusPercent = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bonus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bonusreadies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BonusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BonusAmount = table.Column<double>(type: "float", nullable: false),
                    BonusPercent = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bonusreadies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "children",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_children", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "colleges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeSpecialty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    College_StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    College_CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PDFUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colleges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseOnWhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course_StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Course_UCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PDFUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssuingAuthority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DL_SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Categories = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PDFUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentDL = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "emails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "exps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resignation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CVPDF = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mphones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mphones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "oskills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oskills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "penalties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PenaltyAmount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_penalties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "penaltyready",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PenaltyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PenaltyAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_penaltyready", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "salary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeZoneId = table.Column<int>(type: "int", nullable: false),
                    Full_Salary = table.Column<double>(type: "float", nullable: false),
                    Hourly_Salary = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    School_StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    School_CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PDFUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentSch = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "snetworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialNetworkName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_snetworks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "socialnslist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_socialnslist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "timeZones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OffDay = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    One = table.Column<bool>(type: "bit", nullable: false),
                    Two = table.Column<bool>(type: "bit", nullable: false),
                    Three = table.Column<bool>(type: "bit", nullable: false),
                    Four = table.Column<bool>(type: "bit", nullable: false),
                    Five = table.Column<bool>(type: "bit", nullable: false),
                    Six = table.Column<bool>(type: "bit", nullable: false),
                    Seven = table.Column<bool>(type: "bit", nullable: false),
                    Eight = table.Column<bool>(type: "bit", nullable: false),
                    Nine = table.Column<bool>(type: "bit", nullable: false),
                    Ten = table.Column<bool>(type: "bit", nullable: false),
                    Eleven = table.Column<bool>(type: "bit", nullable: false),
                    Twelve = table.Column<bool>(type: "bit", nullable: false),
                    Thirteen = table.Column<bool>(type: "bit", nullable: false),
                    Fourteen = table.Column<bool>(type: "bit", nullable: false),
                    Fifteen = table.Column<bool>(type: "bit", nullable: false),
                    Sixteen = table.Column<bool>(type: "bit", nullable: false),
                    Seventeen = table.Column<bool>(type: "bit", nullable: false),
                    Eighteen = table.Column<bool>(type: "bit", nullable: false),
                    Nineteen = table.Column<bool>(type: "bit", nullable: false),
                    Twenty = table.Column<bool>(type: "bit", nullable: false),
                    TwentyOne = table.Column<bool>(type: "bit", nullable: false),
                    TwentyTwo = table.Column<bool>(type: "bit", nullable: false),
                    TwentyThree = table.Column<bool>(type: "bit", nullable: false),
                    TwentyFour = table.Column<bool>(type: "bit", nullable: false),
                    TwentyFive = table.Column<bool>(type: "bit", nullable: false),
                    TwentySix = table.Column<bool>(type: "bit", nullable: false),
                    TwentySeven = table.Column<bool>(type: "bit", nullable: false),
                    TwentyEight = table.Column<bool>(type: "bit", nullable: false),
                    TwentyNine = table.Column<bool>(type: "bit", nullable: false),
                    Thirty = table.Column<bool>(type: "bit", nullable: false),
                    ThirtyOne = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timeZones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "unis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversitySpecialty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uni_StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uni_CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PDFUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unis", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "archives");

            migrationBuilder.DropTable(
                name: "bodyds");

            migrationBuilder.DropTable(
                name: "bonus");

            migrationBuilder.DropTable(
                name: "bonusreadies");

            migrationBuilder.DropTable(
                name: "children");

            migrationBuilder.DropTable(
                name: "colleges");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "dls");

            migrationBuilder.DropTable(
                name: "emails");

            migrationBuilder.DropTable(
                name: "exps");

            migrationBuilder.DropTable(
                name: "mphones");

            migrationBuilder.DropTable(
                name: "oskills");

            migrationBuilder.DropTable(
                name: "penalties");

            migrationBuilder.DropTable(
                name: "penaltyready");

            migrationBuilder.DropTable(
                name: "salary");

            migrationBuilder.DropTable(
                name: "schools");

            migrationBuilder.DropTable(
                name: "snetworks");

            migrationBuilder.DropTable(
                name: "socialnslist");

            migrationBuilder.DropTable(
                name: "timeZones");

            migrationBuilder.DropTable(
                name: "unis");
        }
    }
}
