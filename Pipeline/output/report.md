# Asset quality control report

## Outcome

- **Validation status:** `violations_found`; `compliant: false`.
- **Discovered / validated assets:** 25 / 25.
- **Assets with violations:** 25 distinct asset paths; **violations:** 27. Two assets each have two violations.
- All 27 recorded violations are marked `verified: true` in validation. **Violation severity: unknown** — validation does not provide severity. Correction *impact* is a separate classification, not violation severity.
- **Corrections are proposed only:** `executed: false`, `assetsModified: false`. No correction or exception has been applied by this report.

## Violations by asset type and severity

| Asset type | Assets with violations | Violations | Severity | Recorded rules |
| --- | ---: | ---: | --- | --- |
| Material | 15 | 15 | Unknown (15) | `naming.materials` (15) |
| Prefab | 3 | 3 | Unknown (3) | `naming.prefabs` (3) |
| Model | 5 | 6 | Unknown (6) | `naming.models` (5); `models.max_triangles` (1) |
| Texture | 2 | 3 | Unknown (3) | `naming.textures` (2); `textures.allowed_formats` (1) |
| **Total** | **25** | **27** | **Unknown (27)** | |

The naming violations concern 25 assets: 15 materials (six in `Assets/Materials/`, seven in `Assets/Scenes/Baking/`, and two in `Assets/TextMesh Pro/Resources/Fonts & Materials/`), three prefabs in `Assets/Prefabs/`, five FBX models in `Assets/Scenes/Baking/`, and two textures (`Assets/Scenes/Baking/ReflectionProbe-0.exr` and `Assets/Sprites/Basketball.png`). The expected filename-stem prefixes are `M_`, `PF_`, `SM_`, and `T_`, respectively.

Additional verified violations:

- `Assets/Scenes/Baking/ReflectionProbe-0.exr`: `.exr` is outside the recorded allowed texture formats `.png` and `.tga`. Whether it is generated HDR probe data warranting a scoped exception is **unverified**.
- `Assets/Scenes/Baking/UnityMaterialBall.fbx`: measured 39,270 triangles against a recorded maximum of 10,000. The measurement uses FBX polygon triangulation, **not Unity import triangulation**.

## Check coverage

Validation records naming checks on 25 assets, supported-format checks on 7, texture-dimension checks on 2, and model-triangle checks on 5. It records 7 measurements. **Skipped checks: 0; failed checks: 0** (both lists are empty). No broader coverage or Unity-import results are established by these artifacts.

## Proposed corrections and approval

The correction plan contains **27 proposals**, none executed:

| Proposed action | Count | Summary |
| --- | ---: | --- |
| Rename | 22 | Rename 13 materials, 3 prefabs, 5 models, and 1 texture to their recorded naming prefixes using Unity Editor asset moves; check destinations and references before any future action. |
| Review generated-data naming exception | 1 | `C017`: verify provenance of `Assets/Scenes/Baking/ReflectionProbe-0.exr` before requesting an exception. |
| Review texture-format exception | 1 | `C018`: establish whether the same EXR contains HDR reflection data before requesting an exception; do not assume conversion is appropriate. |
| Review vendor naming exception | 2 | `C026`, `C027`: verify ownership of the two TextMesh Pro materials before requesting scoped exceptions. |
| Optimize mesh | 1 | `C023`: proposed retopology/decimation of `Assets/Scenes/Baking/UnityMaterialBall.fbx` to at most 10,000 triangles, then remeasure and inspect; alternatively seek an approved scoped policy exception. |

**Human approval required for 5 proposals:** `C017`, `C018`, `C023`, `C026`, `C027`. **One proposed destructive operation:** `C023` (mesh geometry alteration; high correction impact and potential UV, normal, silhouette, and sub-asset ID changes). The other 22 proposals have low correction impact and the four exception reviews have none, as classified by the correction plan. These impact labels do **not** supply violation severity. No approval is recorded in the artifacts; review outcomes, exceptions, and post-correction compliance remain **unverified**.
