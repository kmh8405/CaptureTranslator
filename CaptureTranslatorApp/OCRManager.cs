using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Tesseract;

namespace CaptureTranslatorApp
{
    public static class OCRManager
    {
        public static string PerformOCR(Bitmap image)
        {
            try
            {
                Bitmap preprocessedImage = PreprocessImage(image);
                preprocessedImage.Save("debug_preprocessed.png"); // 디버깅용 저장

                using (var engine = new TesseractEngine(@"./tessdata", "eng+jpn", EngineMode.Default))
                {
                    engine.SetVariable("preserve_interword_spaces", "1");

                    using (var page = engine.Process(preprocessedImage))
                    {
                        string rawText = page.GetText();

                        // 1. 줄바꿈 정리
                        string noLineBreaks = Regex.Replace(rawText, @"(?<!\.)\r?\n", " ");

                        // 2. 일본어 문자 사이 공백 제거
                        string noJapaneseSpaces = Regex.Replace(
                            noLineBreaks,
                            @"(?<=[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}])\s+(?=[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}])",
                            ""
                        );

                        // 3. 여분 공백 제거
                        string cleanedText = Regex.Replace(noJapaneseSpaces, @"[ ]{2,}", " ").Trim();

                        return cleanedText;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("OCR 예외 발생: " + ex.Message);
                return $"OCR 실패: {ex.Message}";
            }
        }

        public static async Task<(string originalText, string translatedText)> PerformOCRAndTranslateAsync(Bitmap image)
        {
            string originalText = PerformOCR(image);
            string translatedText = await Translator.TranslateTextAsync(originalText, "KO");
            return (originalText, translatedText);
        }

        private static Bitmap PreprocessImage(Bitmap original)
        {
            // 1. OpenCV Mat로 변환
            Mat src = BitmapConverter.ToMat(original);

            // 2. Grayscale
            Mat gray = new Mat();
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

            // 3. CLAHE (대비 향상)
            var clahe = Cv2.CreateCLAHE(clipLimit: 1.8, tileGridSize: new OpenCvSharp.Size(8, 8));
            Mat enhanced = new Mat();
            clahe.Apply(gray, enhanced);

            // 4. 이진화 (adaptiveThreshold or Otsu)
            Mat binary = new Mat();
            Cv2.Threshold(enhanced, binary, 0, 255, ThresholdTypes.Binary | ThresholdTypes.Otsu);

            // 5. 크기가 너무 작다면 확대
            if (binary.Width < 800)
            {
                Cv2.Resize(binary, binary, new OpenCvSharp.Size(), 2.0, 2.0, InterpolationFlags.Lanczos4);
            }

            // 6. Bitmap 변환 및 DPI 설정
            Bitmap final = BitmapConverter.ToBitmap(binary);
            final.SetResolution(300, 300); // OCR 정확도 향상

            return final;
        }

        // [보존용] 향후 대비 조정 기능 실험 시 사용할 수 있음
        //private static Bitmap IncreaseContrast(Bitmap image)
        //{
        //    Bitmap newImage = new Bitmap(image);
        //    float contrast = 1.5f;
        //    float brightness = 0f;

        //    float[][] contrastArray = new float[][]
        //    {
        //        new float[] { contrast, 0, 0, 0, 0 },
        //        new float[] { 0, contrast, 0, 0, 0 },
        //        new float[] { 0, 0, contrast, 0, 0 },
        //        new float[] { 0, 0, 0, 1, 0 },
        //        new float[] { brightness, brightness, brightness, 0, 1 }
        //    };

        //    var colorMatrix = new System.Drawing.Imaging.ColorMatrix(contrastArray);
        //    var attributes = new System.Drawing.Imaging.ImageAttributes();
        //    attributes.SetColorMatrix(colorMatrix);

        //    using (Graphics g = Graphics.FromImage(newImage))
        //    {
        //        g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
        //                    0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
        //    }

        //    return newImage;
        //}
    }
}



