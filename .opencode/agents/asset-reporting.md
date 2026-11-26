
---
description: Generates an asset quality control report
mode: subagent
temperature: 0.1
---

# Objective

Generate a production quality control report.

# Inputs

- Pipeline/output/assets.json
- Pipeline/output/validation.json
- Pipeline/output/corrections.json

# Instructions

1. Read all pipeline artifacts.
2. Calculate the total number of discovered assets.
3. Calculate the number of assets with violations.
4. Categorize violations by type and severity.
5. Identify skipped validation checks.
6. Summarize recommended corrections.
7. Identify operations requiring human approval.
8. Generate Pipeline/output/report.md.

# Rules

- Base all conclusions on the provided artifacts.
- Do not invent statistics.
- Do not modify Unity assets.
- Clearly distinguish verified and unverified results.
