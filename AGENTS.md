# Unity Asset Quality Control Pipeline

## Environment

- The working directory is the root of a Unity project.
- Unity assets are located in Assets/.
- Production standards are in Pipeline/standards.json.
- Generated artifacts must be stored in Pipeline/output/.

## Rules

- Never modify or delete Unity assets.
- Never modify Unity metadata files.
- Never invent asset properties or measurements.
- Report unavailable measurements as unknown.
- Use relative paths when referencing assets.
- Use valid JSON for structured outputs.
- Do not report a task as successful if it failed.