using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;

public class BuildScript
{
    static string[] GetScenePaths()
    {
        List<string> scenes = new List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
                scenes.Add(scene.path);
        }
        return scenes.ToArray();
    }

    static void PerformBuild()
    {
        // 获取命令行参数
        string[] args = Environment.GetCommandLineArgs();
        string buildPath = "Builds";
        BuildTarget buildTarget = BuildTarget.StandaloneWindows64;
        
        // 解析命令行参数
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-buildPath" && i + 1 < args.Length)
                buildPath = args[i + 1];
            if (args[i] == "-buildTarget" && i + 1 < args.Length)
                buildTarget = (BuildTarget)Enum.Parse(typeof(BuildTarget), args[i + 1]);
        }

        // 构建选项
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = GetScenePaths(),
            locationPathName = buildPath,
            target = buildTarget,
            options = BuildOptions.Development | BuildOptions.CompressWithLz4
        };

        // 执行构建
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
} 