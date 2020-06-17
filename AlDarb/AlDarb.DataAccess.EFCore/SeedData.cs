/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlDarb.DataAccess.EFCore
{
    public static class SeedData
    {
        public static string Initial(string schema)
        {
            var rnd = new Random();
            var currentDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            var sqlCommand = new StringBuilder();


            //Roles
            sqlCommand.Append($"INSERT INTO [{schema}].[Roles] ([Name]) VALUES ('admin'), ('user')");
            sqlCommand.AppendLine();

            //Users
            sqlCommand.Append($"INSERT INTO [{schema}].[Users] ([Login], [Password], [FirstName], [LastName], [Email], [Age], [Street], [City], [ZipCode], [Lat], [Lng]) VALUES ");
            sqlCommand.Append(
                "('@Admin', 'AD0DNFM256PNVsW1x8UwrR58c+Y2WFpqdIpdzQkhAN+cgLcggpPs7XtYZnH92DvSvA==', 'Admin', 'Admin', 'admin@admin.admin', null, null, null, null, null, null), ");
            //Password = !2e4S
            sqlCommand.Append(
                "('@User', 'ANpycNjtAeZwCsCQlzGucATzkwQq6/Cz1QAfd/5mEVRqjzhXdPa5IlbL+bcDKP/Gmw==', 'User', 'User', 'user@user.user', null, null, null, null, null, null), ");
            //Password = 12345
            const int initialCountOfUsers = 35;
            sqlCommand.Append(string.Join(", ", GetNamesList(initialCountOfUsers).Select((name, id)
               =>
            {
                var firstName = name.Split(' ')[0];
                var lastName = name.Split(' ')[1];
                return
                    $"\n('@{firstName}_{(id + 2).ToString()}', null, '{firstName}', '{lastName}', '{firstName.ToLower()}@{firstName.ToLower()}.user', {rnd.Next(18, 70)}, 'Wall St.', 'New York', '10005', 40.7043, -74.0070)";
            })));
            sqlCommand.AppendLine();

            //UserRoles
            sqlCommand.Append($"INSERT INTO [{schema}].[UserRoles] ([UserId], [RoleId]) VALUES (1, 1);");
            sqlCommand.AppendLine();
            sqlCommand.Append($@"INSERT INTO [{schema}].[UserRoles] ([UserId], [RoleId])
                       SELECT [u].[Id], 2 FROM [{schema}].[Users] AS [u] WHERE [u].[Id] != 1");
            sqlCommand.AppendLine();

            // User Settings
            sqlCommand.Append($"INSERT INTO [{schema}].[Settings] ([Id], [ThemeName]) SELECT [u].[Id], 'default' FROM [{schema}].[Users] AS [u]");
            sqlCommand.AppendLine();

            return sqlCommand.ToString();
        }

        private static IEnumerable<string> GetNamesList(int count = 30)
        {
            return new List<string> {
                "Rostand Simon", "Petulia Samuel", "Bacon Mathghamhain", "Adlei Michael", "Damian IvorJohn", "Fredenburg Neil", "Strader O''Neal", "Meill Donnell", "Crowell O''Donnell",
               "Lenssen Rory", "Jac Names", "Budge Mahoney", "Bondy Simon", "Bilow Ahearn", "Weintrob Farrell", "Tristan Cathasach", "Baxy Bradach", "Utta Damhan", "Brag Treasach",
               "Vallie Kelly", "Trutko Aodha", "Mellins Cennetig", "Zurek Casey", "Star O''Neal", "Hoffer Names", "Sturges Macshuibhne", "Lifton Sioda", "Rochell Ahearn", "Lynsey Mcmahon",
               "Delp Seaghdha", "Sproul O''Brien", "Omar Ahearn", "Keriann Bhrighde", "Killoran Sullivan", "Olette Riagain", "Kohn Gorman", "Shimberg Maurice", "Nalda Aodh",
               "Livvie Casey", "Zoie Treasach", "Kletter Daly", "Sandy Mckay", "Ern O''Neal", "Loats Maciomhair", "Marlena Mulryan", "Hoshi Naoimhin", "Schmitt Whalen",
               "Patterson Raghailligh", "Ardeen Kelly", "Rasla Simon", "Douty Cennetig", "Giguere Names", "Dorina Clark", "Rothmuller Simon", "Shabbir Delaney", "Placidia Bradach",
               "Savior Keefe", "Concettina Maguire", "Malynda Muirchertach", "Vanzant Fearghal", "Schroder Ruaidh", "Ainslie Ciardha", "Richter Colman", "Gianni Macghabhann",
               "Norvan O''Boyle", "Polak Mcneil", "Bridges Macghabhann", "Eisenberg Samuel", "Thenna Daly", "Moina Mcmahon", "Gasper Whelan", "Hutt O''Keefe", "Quintin Names",
               "Towny Reynold", "Viviane Ceallachan", "Girovard Power", "Fanchon Flann", "Nickolai Meadhra", "Polash Login", "Cacilia Macghabhann", "Chaffee Rory", "Baseler Conchobhar",
               "Amathiste Cuidightheach", "Ishii Riagain", "Marieann Damhan", "Rangel Dubhain", "Alarick Fionn", "Humfrey Rory", "Mable O''Mooney", "Jemie Macdermott", "Hogen Rhys",
               "Cazzie Mohan", "Airlie Reynold", "Safire O''Hannigain", "Strephonn Nuallan", "Brion Eoghan", "Banquer Seaghdha", "Sedgewinn Mcguire", "Alma Macghabhann", "Durward Mcnab" }.Take(count);
        }
    }
}
