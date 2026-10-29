# Unity CLI Environment

## Official References

- https://docs.unity.com/en-us/unity-cli/use-unity-cli
- https://docs.unity.com/en-us/unity-cli/unity-cli-reference
- https://docs.unity.com/en-us/unity-production-pipeline/local-tools-cli/unity-cli-pipeline-package

## Instructions

- Use Unity CLI for all Unity-related operations.
- Prefer official Unity documentation over assumptions.
- Verify that Unity CLI is installed and accessible before proceeding.
- Open the Unity project using Unity CLI if it is not already open.
- Verify that the Unity Pipeline package is installed and its server is running in the Unity Editor before executing Editor commands.
- Discover available Editor commands using `unity command`.
- Use `--help` and official documentation to verify unfamiliar commands and arguments.
- Never invent commands, parameters, or unsupported functionality.
- Stop and report an error if Unity CLI or the required Unity Pipeline connection is unavailable.

## Restrictions

- Operate in read-only mode unless explicitly authorized otherwise.
- Do not modify project assets, scene contents, or project settings.
- Do not delete or overwrite existing files.
- Allow non-destructive operations such as inspecting scenes, querying objects, and capturing screenshots.
- Report command failures instead of assuming an operation succeeded.