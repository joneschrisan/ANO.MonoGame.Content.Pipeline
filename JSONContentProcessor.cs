using Microsoft.Xna.Framework.Content.Pipeline;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using TInput = System.String;
using TOutput = ANO.MonoGame.Content.Pipeline.JSONContentProcessorResult;

namespace ANO.MonoGame.Content.Pipeline
{
    [ContentProcessor(DisplayName = "JSON Content Processor - ANO.MonoGame")]
    internal class JSONContentProcessor : ContentProcessor<TInput, TOutput>
    {
        [DisplayName("Minify JSON")]
        public bool Minify { get; set; } = true;

        [DisplayName("Runtime Identifier")]
        public string RuntimeIdentifier { get; set; } = string.Empty;

        public override TOutput Process(TInput input, ContentProcessorContext context)
        {
            if (string.IsNullOrEmpty(RuntimeIdentifier))
            {
                throw new Exception("No Runtime Identifier was specified for this JSON content.");
            }

            if (Minify)
            {
                input = MinifyJson(input);
            }

            TOutput result = new TOutput();
            result.JSON = input;
            result.RuntimeIdentifier = RuntimeIdentifier;

            return result;
        }

        private string MinifyJson(TInput json)
        {
            JsonWriterOptions options = new JsonWriterOptions()
            {
                Indented = false,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            JsonDocument doc = JsonDocument.Parse(json);

            using (MemoryStream stream = new MemoryStream())
            {
                using (Utf8JsonWriter writer = new Utf8JsonWriter(stream, options))
                {
                    doc.WriteTo(writer);
                    writer.Flush();
                }

                return Encoding.UTF8.GetString(stream.ToArray());
            }

        }
    }
}
