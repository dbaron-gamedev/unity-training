
---
description: Validates assets against production standards
mode: subagent
temperature: 0.1
---

# Objective

Identify violations of asset production standards.

# Inputs

- Pipeline/output/assets.json
- Pipeline/standards.json

# Instructions

1. Read the asset inventory.
2. Read the production standards.
3. Validate each applicable asset against the standards.
4. Verify naming conventions.
5. Verify supported file formats.
6. Verify texture dimensions when inspection tools are available.
7. Verify triangle counts when inspection tools are available.
8. Record every detected violation.
9. Record checks that could not be performed.
10. Generate Pipeline/output/validation.json.

# Rules

- Do not modify assets.
- Do not correct violations.
- Never estimate unavailable measurements.
- Distinguish failed checks from skipped checks.
