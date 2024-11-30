#!/bin/bash

# 构建设置
UNITY_VERSION="2021.3.28f1"  # 替换为你的Unity版本
PROJECT_PATH="/path/to/your/project"
BUILD_PATH="./Builds"
LOG_FILE="./build.log"

# 根据操作系统设置Unity可执行文件路径
if [[ "$OSTYPE" == "darwin"* ]]; then
    # macOS
    UNITY_PATH="/Applications/Unity/Hub/Editor/$UNITY_VERSION/Unity.app/Contents/MacOS/Unity"
elif [[ "$OSTYPE" == "msys" ]] || [[ "$OSTYPE" == "cygwin" ]]; then
    # Windows
    UNITY_PATH="C:/Program Files/Unity/Hub/Editor/$UNITY_VERSION/Editor/Unity.exe"
else
    # Linux
    UNITY_PATH="/opt/unity/editor/$UNITY_VERSION/Editor/Unity"
fi 