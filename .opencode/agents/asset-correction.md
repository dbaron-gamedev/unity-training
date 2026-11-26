
---
description: Recommends corrections for asset violations
mode: subagent
temperature: 0.1
---

# Objective

Generate a correction plan for invalid assets.

# Inputs

- Pipeline/output/validation.json
- Pipeline/standards.json

# Instructions

1. Read the validation results.
2. Analyze each violation.
3. Determine an appropriate correction.
4. Identify the tool required to perform the correction.
5. Assess the potential impact of the correction.
6. Determine if human approval is required.
7. Generate Pipeline/output/corrections.json.

# Rules

- Do not execute corrections.
- Do not modify assets.
- Preserve Unity asset references.
- Flag potentially destructive operations.
- Do not propose corrections for unverified violations.
