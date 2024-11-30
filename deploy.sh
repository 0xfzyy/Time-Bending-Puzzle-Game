#!/bin/bash

# 导入构建命令
source ./build-commands.sh

# 创建构建目录
mkdir -p "$BUILD_PATH"

# 清理旧的构建文件
echo "Cleaning old builds..."
rm -rf "$BUILD_PATH"/*

# 选择构建平台
case "$1" in
    "windows")
        echo "Building for Windows 64-bit..."
        build_windows64
        ;;
    "macos")
        echo "Building for macOS..."
        build_macos
        ;;
    "linux")
        echo "Building for Linux..."
        build_linux
        ;;
    "webgl")
        echo "Building for WebGL..."
        build_webgl
        ;;
    "all")
        echo "Building for all platforms..."
        build_windows64
        build_macos
        build_linux
        build_webgl
        ;;
    *)
        echo "Usage: $0 {windows|macos|linux|webgl|all}"
        exit 1
        ;;
esac

# 检查构建结果
if [ $? -eq 0 ]; then
    echo "Build completed successfully!"
else
    echo "Build failed! Check $LOG_FILE for details."
    exit 1
fi 