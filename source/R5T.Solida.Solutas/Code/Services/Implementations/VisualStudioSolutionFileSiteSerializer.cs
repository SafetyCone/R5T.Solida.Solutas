using System;

using R5T.Cambridge.Types;
using R5T.Solutas;


namespace R5T.Solida.Solutas
{
    public class VisualStudioSolutionFileSiteSerializer : IVisualStudioSolutionFileSiteSerializer
    {
        private IVisualStudioSolutionFileSerializer VisualStudioSolutionFileSerializer { get; }


        public VisualStudioSolutionFileSiteSerializer(IVisualStudioSolutionFileSerializer visualStudioSolutionFileSerializer)
        {
            this.VisualStudioSolutionFileSerializer = visualStudioSolutionFileSerializer;
        }

        public SolutionFileSite Deserialize(string solutionFilePath)
        {
            var solutionFile = this.VisualStudioSolutionFileSerializer.Deserialize(solutionFilePath);

            var solutionFileSite = new SolutionFileSite()
            {
                SolutionFile = solutionFile,
                SolutionFilePath = solutionFilePath,
            };
            return solutionFileSite;
        }

        public void Serialize(SolutionFileSite solutionFileSite, bool overwrite = true)
        {
            this.VisualStudioSolutionFileSerializer.Serialize(solutionFileSite.SolutionFilePath, solutionFileSite.SolutionFile, overwrite);
        }
    }
}
