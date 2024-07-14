using Microsoft.EntityFrameworkCore.Migrations;
using TaskManager.Enums;

namespace TaskManager.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultData : Migration
    {
        public Dictionary<string, string> _defaultUsers = new Dictionary<string, string>
        {
            {"1e112b3c-2375-487f-be71-5ede0f29316b", "Default User 1"},
            {"4d54900b-71a8-4005-a3c2-c4afc165c718", "Default User 2"},
            {"bd7a445f-7ff7-40bd-bec9-e64623907204", "Default User 3"}
        };

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var priorityLevels = GetPriorityLevels();
            foreach (var priorityLevel in priorityLevels)
            {
                migrationBuilder.InsertData(
                    table: "Priorities",
                    columns: new[] { "Level" },
                    values: new object[] { (int)priorityLevel });
            }

            foreach (var defaultUser in _defaultUsers)
            {
                migrationBuilder.InsertData(
                    table: "Users",
                    columns: new[] { "Id", "Name" },
                    values: new object[] { defaultUser.Key, defaultUser.Value });
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var priorityLevels = GetPriorityLevels();
            foreach (var priorityLevel in priorityLevels)
            {
                migrationBuilder.DeleteData(
                    table: "Priorities",
                    keyColumns: new[] { "Level" },
                    keyValues: new object[] { (int)priorityLevel });
            }

            foreach (var defaultUser in _defaultUsers)
            {
                migrationBuilder.DeleteData(
                    table: "Users",
                    keyColumns: new[] { "Id" },
                    keyValues: new object[] { defaultUser.Key });
            }
        }

        private PriorityLevels[] GetPriorityLevels()
        {
            return Enum.GetValues<PriorityLevels>();
        }
    }
}
