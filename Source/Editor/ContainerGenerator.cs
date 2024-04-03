using System.IO;
using UnityEditor;

namespace LazerLabs.Commands.Editor
{
    public static partial class CodeGenerator
    {
        [MenuItem("Assets//Create/Command/CreateValueContainer", false, 10)]
        private static void CreateValueContainer(MenuCommand menuCommand)
        {
            // Get the selected path in the project window
            string selectedPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            string defaultName = "NewMonoValueContainer.cs";
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

    public interface I{className} : IReadOnlyValueContainer<T> {{}}

    public sealed class {className} : MonoValueContainer<T>,I{className}   {{}}";
            }
            else
            {
                code =
                    $@"using LazerLabs.Commands;
namespace {defaultNamespace}
{{
    public interface I{className} : IReadOnlyValueContainer<T> {{}}

    public sealed class {className} : MonoValueContainer<T>,I{className}   {{}}
}}
";
            }

            File.WriteAllText(fileName, code);

            AssetDatabase.Refresh();
        }
    }
}