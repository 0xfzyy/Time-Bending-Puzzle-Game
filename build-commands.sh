#!/bin/bash

# Windows 64位构建
function build_windows64() {
    "$UNITY_PATH" -quit -batchmode \
        -projectPath "$PROJECT_PATH" \
        -executeMethod BuildScript.PerformBuild \
        -buildTarget StandaloneWindows64 \
        -buildPath "$BUILD_PATH/Windows64/Game.exe" \
        -logFile "$LOG_FILE"
}

# macOS构建
function build_macos() {
    "$UNITY_PATH" -quit -batchmode \
        -projectPath "$PROJECT_PATH" \
        -executeMethod BuildScript.PerformBuild \
        -buildTarget StandaloneOSX \
        -buildPath "$BUILD_PATH/macOS/Game.app" \
        -logFile "$LOG_FILE"
}

# Linux构建
function build_linux() {
    "$UNITY_PATH" -quit -batchmode \
        -projectPath "$PROJECT_PATH" \
        -executeMethod BuildScript.PerformBuild \
        -buildTarget StandaloneLinux64 \
        -buildPath "$BUILD_PATH/Linux/Game.x86_64" \
        -logFile "$LOG_FILE"
}

# WebGL构建
function build_webgl() {
    "$UNITY_PATH" -quit -batchmode \
        -projectPath "$PROJECT_PATH" \
        -executeMethod BuildScript.PerformBuild \
        -buildTarget WebGL \
        -buildPath "$BUILD_PATH/WebGL" \
        -logFile "$LOG_FILE"
} 