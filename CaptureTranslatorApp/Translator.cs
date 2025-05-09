using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace CaptureTranslatorApp
{
    public class Translator
    {
        private static string apiKey = string.Empty;  // API 키는 메모리에서만 관리

        // API 키 설정 메서드
        public static void SetApiKey(string key)
        {
            apiKey = key;
        }

        // 외부에서 읽기만 가능한 속성 추가
        public static string ApiKey
        {
            get { return apiKey; }
        }

        private static readonly string endpoint = "https://api-free.deepl.com/v2/translate";

        public static async Task<string> TranslateTextAsync(string text, string targetLanguage)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                return "에러: API키가 설정되지 않았습니다.";
            }

            using (HttpClient client = new HttpClient())
            {
                var requestContent = new StringContent(
                    $"auth_key={apiKey}&text={text}&target_lang=KO",
                    Encoding.UTF8,
                    "application/x-www-form-urlencoded"
                );

                HttpResponseMessage response = await client.PostAsync(endpoint, requestContent);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // JSON 파싱
                    dynamic result = JsonConvert.DeserializeObject(responseBody);
                    string translatedText = result.translations[0].text;

                    return translatedText;
                }
                else
                {
                    return $"Error: {response.ReasonPhrase}";
                }
            }
        }
    }
}
