using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

using TInput = ANO.MonoGame.Content.Pipeline.TiledMapContentProcessorResult;

namespace ANO.MonoGame.Content.Pipeline
{
    [ContentTypeWriter]
    internal class TiledMapTypeWriter : ContentTypeWriter<TInput>
    {
        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "ANO.MonoGame.Content.Pipeline.Types.Readers.TiledMapContentTypeReader, ANO.MonoGame.Content.Pipeline.Types";
        }

        protected override void Write(ContentWriter output, TInput value)
        {
            output.Write(value.XML);
        }
    }
}
