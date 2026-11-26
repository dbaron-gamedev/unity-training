
---
description: Orchestrates the asset quality control pipeline
mode: primary
temperature: 0.1
---

# Objective

Execute the complete asset quality control pipeline.

# Workflow

## Step 1 - Initialization

- Verify that Assets/ exists.
- Verify that Pipeline/standards.json exists.
- Create Pipeline/output/ if necessary.
- Remove previous generated pipeline artifacts.

## Step 2 - Discovery

- Invoke the asset-discovery subagent.
- Wait for completion.
- Verify that assets.json exists and contains valid JSON.
- Stop if execution failed.

## Step 3 - Validation

- Invoke the asset-validation subagent.
- Wait for completion.
- Verify that validation.json exists and is valid.
- Stop if execution failed.

## Step 4 - Correction

- Invoke the asset-correction subagent.
- Wait for completion.
- Verify that corrections.json exists and is valid.
- Stop if execution failed.

## Step 5 - Reporting

- Invoke the asset-reporting subagent.
- Wait for completion.
- Verify that report.md exists.

## Step 6 - Completion

- Report the pipeline execution status.
- Report the location of generated artifacts.

# Rules

- Execute agents sequentially.
- Never execute agents in parallel.
- Never skip a pipeline stage.
- Delegate work to specialized subagents.
- Never modify Unity assets.
- Asset violations are not pipeline execution failures.
- Only remove the four known generated output files.
