#!/bin/bash

function build_windows64() {
    "$UNITY_PATH" -quit -batchmode \
        -projectPath "$PROJECT_PATH" \
        -executeMethod BuildScript.PerformBuild \
        -buildTarget StandaloneWindows64 \
        -buildPath "$BUILD_PATH/Windows64/Game.exe" \
        -logFile "$LOG_FILE"
}

function build_macos() {
    "$UNITY_PATH" -quit -batchmode \
        -projectPath "$PROJECT_PATH" \
        -executeMethod BuildScript.PerformBuild \
        -buildTarget StandaloneOSX \
        -buildPath "$BUILD_PATH/macOS/Game.app" \
        -logFile "$LOG_FILE"
}

function build_linux() {
    "$UNITY_PATH" -quit -batchmode \
        -projectPath "$PROJECT_PATH" \
        -executeMethod BuildScript.PerformBuild \
        -buildTarget StandaloneLinux64 \
        -buildPath "$BUILD_PATH/Linux/Game.x86_64" \
        -logFile "$LOG_FILE"
}
function build_webgl() {
    "$UNITY_PATH" -quit -batchmode \
        -projectPath "$PROJECT_PATH" \
        -executeMethod BuildScript.PerformBuild \
        -buildTarget WebGL \
        -buildPath "$BUILD_PATH/WebGL" \
        -logFile "$LOG_FILE"
} 
