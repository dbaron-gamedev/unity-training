#!/bin/bash

EDITOR_VERSION="$1"
PROJECT_PATH="$2"
LOG_FILE="$3"

UNITY_EXE="/opt/unity/$EDITOR_VERSION/Editor/Unity"

if [ ! -f "$UNITY_EXE" ]; then
    echo "Unity executable not found: $UNITY_EXE"
    exit 1
fi

"$UNITY_EXE" \
    -batchmode \
    -quit \
    -projectPath "$PROJECT_PATH" \
    -executeMethod LightingBaker.BakeTargetScenes \
    -logFile "$LOG_FILE"

EXIT_CODE=$?

echo "Unity exited with code $EXIT_CODE"

exit $EXIT_CODE