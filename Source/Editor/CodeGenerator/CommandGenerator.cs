using UnityEditor;
using System.IO;

namespace LazerLabs.Commands.Editor
{
    public static partial class CodeGenerator
    {
        [MenuItem("Assets//Create/Command/CreateCommand", false, 10)]
        private static void CreateCommand(MenuCommand menuCommand)
        {
            // Get the selected path in the project window
            string selectedPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            string defaultName = "NewCommand.cs";
            string fileName = EditorUtility.SaveFilePanelInProject("Save Command", defaultName, "cs", "Enter command name", selectedPath);

            // If the user cancels or closes the dialog, exit the method
            if (string.IsNullOrEmpty(fileName))
                return;

            // Extract the class name from the file name
            string className = Path.GetFileNameWithoutExtension(fileName);

            // Get the default namespace from the project settings
            string defaultNamespace = EditorSettings.projectGenerationRootNamespace;
            string code = default;
            // Generate the code for the command file
            if (string.IsNullOrEmpty(defaultNamespace))
            {
                code =
                    $@"using LazerLabs.Commands;

    public interface I{className} : ICommand {{}}

    public sealed class {className} : I{className}
    {{
        public void Execute()
        {{
            throw new System.NotImplementedException();
        }}
    }}
";
            }
            else
            {
                code =
                    $@"using LazerLabs.Commands;
namespace {defaultNamespace}
{{
    public interface I{className} : ICommand {{}}

    public sealed class {className} : I{className}
    {{
        public void Execute()
        {{
            throw new System.NotImplementedException();
        }}
    }}
}}
";
            }

            File.WriteAllText(fileName, code);

            AssetDatabase.Refresh();
        }
    }
}