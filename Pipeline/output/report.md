# Asset quality control report

Source artifacts: `Pipeline/output/assets.json`, `Pipeline/output/validation.json`, `Pipeline/output/corrections.json`.

## Results

- Discovered assets: **25** (`assets.json` count and 25 listed assets).
- Assets with violations: **25** distinct asset paths; **27** violations total (`validation.json` summary and entries). Two assets have two violations each: `Assets/Scenes/Baking/ReflectionProbe-0.exr` and `Assets/Scenes/Baking/UnityMaterialBall.fbx`.
- Violation severity: **unknown for all 27**. The validation entries provide no severity; correction *impact* is not violation severity.

| Asset type | Assets with violations | Violations | Checks |
| --- | ---: | ---: | --- |
| Material | 15 | 15 | 15 naming |
| Prefab | 3 | 3 | 3 naming |
| Model | 5 | 6 | 5 naming, 1 model_triangles |
| Texture | 2 | 3 | 2 naming, 1 format |
| **Total** | **25** | **27** | **25 naming, 1 model_triangles, 1 format** |

The format violation is `.exr` on `Assets/Scenes/Baking/ReflectionProbe-0.exr` (allowed: `.png`, `.tga`). The model-triangle violation is `Assets/Scenes/Baking/UnityMaterialBall.fbx`: **39,270** measured triangles versus a **10,000** maximum. All other violations are missing filename prefixes (`M_`, `PF_`, `SM_`, or `T_` by asset type).

## Validation coverage and measurements

- Completed checks reported: naming 25, format 7, texture_dimensions 2, model_triangles 5.
- Skipped checks: **18 format checks** — 15 materials have no `allowed_formats` standard for materials, and 3 prefabs have no `allowed_formats` standard for prefabs. Their format compliance is **unknown**, not passed.
- Failed checks: **0** (`failed_checks` is empty); this does not negate the 27 recorded violations.
- Recorded model triangle measurements (FBX mesh-geometry calculation): `Assets/Scenes/Baking/BackgroundMesh.fbx` 1,792; `Assets/Scenes/Baking/SamplesFixture.fbx` 140; `Assets/Scenes/Baking/SamplesFloorSpotlight.fbx` 724; `Assets/Scenes/Baking/SamplesSpotlightModel.fbx` 7,002; `Assets/Scenes/Baking/UnityMaterialBall.fbx` 39,270.
- Recorded texture dimensions (image headers): `Assets/Scenes/Baking/ReflectionProbe-0.exr` 768 × 128; `Assets/Sprites/Basketball.png` 1,280 × 1,273. No other dimensions or triangle counts are reported here.

## Proposed corrections and approvals

`corrections.json` proposes **27** actions: **22** Unity Editor renames with the required type prefix, **1** mesh optimization, **1** generated-data naming exception review, **1** EXR format exception review, and **2** vendor-material naming exception reviews.

The rename breakdown is **13 materials, 3 prefabs, 5 models, 1 texture = 22**; the proposed renames use Unity Editor `AssetDatabase.MoveAsset` after checking the target. Inspect name/path-based loads, importer bindings, and Unity references before any future application; do not delete or recreate metadata.

**Human approval required for 5 proposals:**

| ID | Asset | Proposed decision/action |
| --- | --- | --- |
| C017 | `Assets/Scenes/Baking/ReflectionProbe-0.exr` | Confirm generated probe provenance; consider a scoped naming exception. |
| C018 | `Assets/Scenes/Baking/ReflectionProbe-0.exr` | Confirm HDR reflection-data use; consider a scoped format exception instead of converting. |
| C023 | `Assets/Scenes/Baking/UnityMaterialBall.fbx` | Approve mesh retopology/decimation and re-export to ≤10,000 triangles, or consider a scoped policy exception. |
| C026 | `Assets/TextMesh Pro/Resources/Fonts & Materials/LiberationSans SDF - Drop Shadow.mat` | Confirm vendor ownership; consider a scoped naming exception. |
| C027 | `Assets/TextMesh Pro/Resources/Fonts & Materials/LiberationSans SDF - Outline.mat` | Confirm vendor ownership; consider a scoped naming exception. |

**Destructive proposal: C023 only.** Mesh re-export may change geometry, silhouette, UVs, normals, and FBX sub-asset IDs; it requires human approval, remeasurement, visual inspection, and reference verification if ever undertaken. The other proposals are marked non-destructive in the correction artifact. Exception outcomes and asset provenance are unverified pending human review.

**Nothing was executed:** `corrections.json` reports `executed: false` and `assetsModified: false`. This report does not authorize or perform any correction; Unity assets and metadata were not changed by the reporting stage.
