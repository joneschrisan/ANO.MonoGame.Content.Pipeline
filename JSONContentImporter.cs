using Microsoft.Xna.Framework.Content.Pipeline;
using System;
using System.IO;
using System.Text.Json;

using TImport = System.String;

namespace ANO.MonoGame.Content.Pipeline
{
    [ContentImporter(".json", DisplayName = "JSON Importer - ANO.MonoGame", DefaultProcessor = nameof(JSONContentProcessor))]
    public class JSONContentImporter : ContentImporter<TImport>
    {
        public override TImport Import(string filename, ContentImporterContext context)
        {
            string json = File.ReadAllText(filename);
            ThrowIfInvalidJson(json);
            return json;
        }

        private void ThrowIfInvalidJson(string json)
        {
            //  Ensure there's actually data in the file.
            if (string.IsNullOrEmpty(json))
            {
                throw new InvalidContentException("The JSON file is empty");
            }

            //  Attempt to parse the data as a JsonDocument. If it fails, return false.
            try
            {
                _ = JsonDocument.Parse(json);
            }
            catch (Exception ex)
            {
                throw new InvalidContentException("This does not appear to be valid JSON. See inner exception for details", ex);
            }
        }
    }
}
