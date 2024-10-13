using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Avalonia.Controls.Documents;
using Avalonia.Controls.Primitives;

namespace AvaloniaResourceEditor.Models;

public static class ResourceFileMethods
{
    private static readonly StringBuilder StringBuilder = new();
    public const string AxamlExtension = ".axaml";
    public const string ResourceHeader = "<ResourceDictionary xmlns=\"https://github.com/avaloniaui\"\n                    xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"\n                    xmlns:s=\"clr-namespace:System;assembly=System.Runtime\">\n";
    public const string ResourceFooter = "</ResourceDictionary>";

    public static string GetFilePath(IResource resource, string folder) => 
        Path.Combine(folder, resource.Name + AxamlExtension);

    public static void Build(this IResource resource)
    {
        StringBuilder.Clear();
        StringBuilder.Append(ResourceHeader);
        foreach (var tagValue in resource.Values)
        {
            StringBuilder.Append($"    <{tagValue.Type} x:Key=\"{tagValue.Key}\">{tagValue.Value}</{tagValue.Type}>\n");
        }
        StringBuilder.Append(ResourceFooter);
    }

    public static void Parse(this IResource resource, IList<string> lines)
    {
        for(int i = 3; i < lines.Count-1; i++)
        {
            var line = lines[i];
            if(string.IsNullOrWhiteSpace(line)) continue;
            var openTagIndex = line.IndexOf('<');
            var closeTagIndex = line.IndexOf('>');
            var spaceIndex = line.IndexOf(' ', openTagIndex+1);
            var secondOpenTag = line.IndexOf('<', closeTagIndex + 1);
            var tag = resource.Create();
            tag.Value = line.Substring(closeTagIndex + 1, secondOpenTag - closeTagIndex - 1);
            tag.Type = line.Substring(openTagIndex + 1, spaceIndex - openTagIndex - 1);
            tag.Key = line.Substring(spaceIndex + 8, closeTagIndex - spaceIndex - 9);
        }
    }
    
    public static void SaveResource(this IResource resource, string folder)
    {
        var filePath = GetFilePath(resource, folder);
        resource.Build();
        File.WriteAllText(filePath, StringBuilder.ToString());
    }

    public static void ReadResource(this IResource resource, string filePath)
    {
        var read = File.ReadAllLines(filePath);
        var fileName = Path.GetFileName(filePath);
        resource.Name = fileName.Replace(".axaml", "");
        resource.Values.Clear();
        resource.Parse(read);
    }
    
}