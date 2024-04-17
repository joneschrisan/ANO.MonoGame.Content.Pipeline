using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

using TInput = ANO.MonoGame.Content.Pipeline.JSONContentProcessorResult;

namespace ANO.MonoGame.Content.Pipeline
{
    [ContentTypeWriter]
    internal class JSONContentTypeWriter : ContentTypeWriter<TInput>
    {
        private string _runtimeIdentifier;

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return _runtimeIdentifier;
        }

        protected override void Write(ContentWriter output, TInput value)
        {
            _runtimeIdentifier = value.RuntimeIdentifier;
            output.Write(value.JSON);
        }
    }
}
