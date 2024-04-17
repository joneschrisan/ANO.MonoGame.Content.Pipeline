using Microsoft.Xna.Framework.Content.Pipeline;
using System.IO;

using TImport = System.String;

namespace ANO.MonoGame.Content.Pipeline
{
    [ContentImporter(".tmx", DisplayName = "Tiled Map Importer - ANO.MonoGame", DefaultProcessor = nameof(TiledMapContentProcessor))]
    internal class TiledMapContentImporter : ContentImporter<TImport>
    {
        public override TImport Import(string filename, ContentImporterContext context)
        {
            string xml = File.ReadAllText(filename);
            return xml;
        }
    }
}
