using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevUpConference.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attende",
                columns: table => new
                {
                    AttendeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendeFirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AttendeLastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AttendeEmailAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attende", x => x.AttendeId);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeedbackText = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    FeedbackRating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.FeedbackId);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "SessionLevel",
                columns: table => new
                {
                    SessionLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionLevelName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionLevel", x => x.SessionLevelId);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    SpeakerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpeakerName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SpeakerBio = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    SpeakerJobTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SpeakerWebsite = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SpeakerImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerId);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionDescription = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    SessionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SessionSpeakerSpeakerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionRoomRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionLevelId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SpeakerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_Session_Room_SessionRoomRoomId",
                        column: x => x.SessionRoomRoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Session_SessionLevel_SessionLevelId",
                        column: x => x.SessionLevelId,
                        principalTable: "SessionLevel",
                        principalColumn: "SessionLevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Session_SessionLevel_SessionLevelId1",
                        column: x => x.SessionLevelId1,
                        principalTable: "SessionLevel",
                        principalColumn: "SessionLevelId");
                    table.ForeignKey(
                        name: "FK_Session_Speaker_SessionSpeakerSpeakerId",
                        column: x => x.SessionSpeakerSpeakerId,
                        principalTable: "Speaker",
                        principalColumn: "SpeakerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Session_Speaker_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Speaker",
                        principalColumn: "SpeakerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Session_SessionLevelId",
                table: "Session",
                column: "SessionLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_SessionLevelId1",
                table: "Session",
                column: "SessionLevelId1");

            migrationBuilder.CreateIndex(
                name: "IX_Session_SessionRoomRoomId",
                table: "Session",
                column: "SessionRoomRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_SessionSpeakerSpeakerId",
                table: "Session",
                column: "SessionSpeakerSpeakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_SpeakerId",
                table: "Session",
                column: "SpeakerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attende");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "SessionLevel");

            migrationBuilder.DropTable(
                name: "Speaker");
        }
    }
}
