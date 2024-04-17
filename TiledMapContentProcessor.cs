using Microsoft.Xna.Framework.Content.Pipeline;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using TInput = System.String;
using TOutput = ANO.MonoGame.Content.Pipeline.TiledMapContentProcessorResult;

namespace ANO.MonoGame.Content.Pipeline
{
    [ContentProcessor(DisplayName = "Tiled Map Content Processor - ANO.MonoGame")]
    internal class TiledMapContentProcessor : ContentProcessor<TInput, TOutput>
    {
        public override TOutput Process(TInput input, ContentProcessorContext context)
        {
            TOutput result = new TOutput();
            result.XML = input;

            return result;
        }
    }
}
