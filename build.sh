#!/bin/bash

# 设置Unity路径（根据你的Unity版本修改）
if [[ "$OSTYPE" == "darwin"* ]]; then
    # macOS
    UNITY_PATH="/Applications/Unity/Hub/Editor/2021.3.28f1/Unity.app/Contents/MacOS/Unity"
elif [[ "$OSTYPE" == "msys" ]] || [[ "$OSTYPE" == "cygwin" ]]; then
    # Windows
    UNITY_PATH="C:/Program Files/Unity/Hub/Editor/2021.3.28f1/Editor/Unity.exe"
else
    # Linux
    UNITY_PATH="/opt/unity/editor/2021.3.28f1/Editor/Unity"
fi

# 项目路径（当前目录）
PROJECT_PATH="$(pwd)"

# 构建命令
"$UNITY_PATH" -quit -batchmode \
    -projectPath "$PROJECT_PATH" \
    -executeMethod BuildScript.PerformBuild \
    -logFile build.log

# 检查构建结果
if [ $? -eq 0 ]; then
    echo "Build completed successfully!"
    # 打开构建输出目录
    if [[ "$OSTYPE" == "darwin"* ]]; then
        open "Builds"
    elif [[ "$OSTYPE" == "msys" ]] || [[ "$OSTYPE" == "cygwin" ]]; then
        explorer.exe "Builds"
    else
        xdg-open "Builds"
    fi
else
    echo "Build failed! Check build.log for details."
    cat build.log
fi
