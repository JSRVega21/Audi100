using DevExpress.Drawing;
using System.Net.Http;

namespace Audi100.Client
{
    public class FontLoader
    {
        private readonly HttpClient _httpClient;

        public FontLoader(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task LoadFonts(List<string> fontNames)
        {
            foreach (var fontName in fontNames)
            {
                var fontBytes = await _httpClient.GetByteArrayAsync($"/fonts/{fontName}");
                DXFontRepository.Instance.AddFont(fontBytes);
            }
        }
    }
}
