using System.Text.Json;

namespace Questao2
{
    public class CalculadoraGols
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<int> CalcularGolsAsync(string team, int year)
        {
            int totalGols = 0;
            totalGols += await ObterGolsPorTimeAsync(team, year, "team1");
            totalGols += await ObterGolsPorTimeAsync(team, year, "team2");

            return totalGols;
        }

        private async Task<int> ObterGolsPorTimeAsync(string team, int year, string teamType)
        {
            int totalGols = 0;
            int currentPage = 1;
            bool hasMorePages = true;

            while (hasMorePages)
            {
                var url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&{teamType}={team}&page={currentPage}";
                var response = await httpClient.GetStringAsync(url);
                var jsonDocument = JsonDocument.Parse(response);

                var data = jsonDocument.RootElement.GetProperty("data").EnumerateArray();
                foreach (var match in data)
                {
                    int golsMarcados = int.Parse(match.GetProperty($"{teamType}goals").GetString());
                    totalGols += golsMarcados;
                }

                int totalPages = jsonDocument.RootElement.GetProperty("total_pages").GetInt32();
                currentPage++;
                hasMorePages = currentPage <= totalPages;
            }

            return totalGols;
        }
    }
}
