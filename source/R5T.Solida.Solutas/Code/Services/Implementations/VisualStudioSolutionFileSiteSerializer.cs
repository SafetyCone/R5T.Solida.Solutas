using System;

using R5T.Cambridge.Types;
using R5T.Solutas;using R5T.T0064;


namespace R5T.Solida.Solutas
{[ServiceImplementationMarker]
    public class VisualStudioSolutionFileSiteSerializer : IVisualStudioSolutionFileSiteSerializer,IServiceImplementation
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
