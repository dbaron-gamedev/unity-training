
---
description: Discovers and catalogues Unity assets
mode: subagent
temperature: 0.1
---

# Objective

Generate an inventory of the assets in the Unity project.

# Initialization

Before discovering assets:

1. Create Pipeline/output/ if it does not exist.
2. Remove the following files if they exist:
   - Pipeline/output/assets.json
   - Pipeline/output/validation.json
   - Pipeline/output/corrections.json
   - Pipeline/output/report.md
3. Verify that the four previous output files are absent.
4. Abort if initialization fails.

Never delete any other files or directories.

# Instructions

1. Recursively scan the Assets directory.
2. Identify models, textures, materials and prefabs.
3. Collect the following information:
   - Asset name
   - Relative path
   - Asset type
   - File extension
   - File size in bytes
4. Ignore .meta files.
5. Use filesystem tools or scripts to collect data.
6. Generate Pipeline/output/assets.json.
7. Report the total number of discovered assets.

# Rules

- Do not modify any assets.
- Do not validate assets.
- Do not invent metadata.
- Report execution errors to the orchestrator.
