# Asset Quality Control Report

**Generated:** 2026-11-26T03:07:58.395108+00:00

**Status:** Completed — discovery, validation, correction planning and reporting all executed.

**Assets modified:** None. This pipeline is read-only with respect to `Assets/`.

## Scope

- Standards: `Pipeline/standards.json`
- Inventory: `Pipeline/output/assets.json`
- Validation: `Pipeline/output/validation.json`
- Correction plan: `Pipeline/output/corrections.json`

## Inventory

| Asset type | Count |
| --- | ---: |
| Model | 5 |
| Texture | 2 |
| Material | 15 |
| Prefab | 3 |
| **Total** | **25** |

## Validation results

| Metric | Value |
| --- | ---: |
| Assets discovered | 25 |
| Assets validated | 25 |
| Assets with violations | 25 |
| Total violations | 27 |
| Verified violations | 27 |
| Unverified violations | 0 |

### Violations by rule

| Rule | Count |
| --- | ---: |
| `format.textures` | 1 |
| `models.max_triangles` | 1 |
| `naming.materials` | 15 |
| `naming.models` | 5 |
| `naming.prefabs` | 3 |
| `naming.textures` | 2 |

### Violations by severity

| Severity | Count |
| --- | ---: |
| Major | 2 |
| Minor | 25 |

## Validation coverage

| Check | Status | Notes |
| --- | --- | --- |
| Naming conventions | Completed | Models, textures, materials, prefabs |
| File formats | Completed | Models and textures |
| Texture dimensions | Completed | Direct header inspection |
| Triangle counts | Completed | Binary FBX polygon data |

**Skipped checks:** None.

**Failed checks:** None.

### Measurements

| Asset | Measurement | Method |
| --- | --- | --- |
| `Assets/Sprites/Basketball.png` | 1280 x 1273 px | PNG IHDR / System.Drawing |
| `Assets/Scenes/Baking/ReflectionProbe-0.exr` | 768 x 128 px | EXR dataWindow attribute |
| `Assets/Scenes/Baking/BackgroundMesh.fbx` | 1792 triangles | FBX PolygonVertexIndex parsing |
| `Assets/Scenes/Baking/SamplesFixture.fbx` | 140 triangles | FBX PolygonVertexIndex parsing |
| `Assets/Scenes/Baking/SamplesFloorSpotlight.fbx` | 724 triangles | FBX PolygonVertexIndex parsing |
| `Assets/Scenes/Baking/SamplesSpotlightModel.fbx` | 7002 triangles | FBX PolygonVertexIndex parsing |
| `Assets/Scenes/Baking/UnityMaterialBall.fbx` | 39270 triangles | FBX PolygonVertexIndex parsing |

## Recommended corrections

| Action | Count |
| --- | ---: |
| `exempt_generated` | 2 |
| `exempt_vendor` | 2 |
| `optimize_mesh` | 1 |
| `rename` | 22 |

### Renames (reference-preserving)

All renames below are planned through `AssetDatabase.MoveAsset` (or a filesystem rename that moves the `.meta` file) so the asset GUID and all scene/prefab references are preserved. No script in the project loads these assets by name.

| Current path | Target file name |
| --- | --- |
| `Assets/Materials/Blue.mat` | `M_Blue.mat` |
| `Assets/Materials/Debug.mat` | `M_Debug.mat` |
| `Assets/Materials/Green.mat` | `M_Green.mat` |
| `Assets/Materials/Purple.mat` | `M_Purple.mat` |
| `Assets/Materials/Red.mat` | `M_Red.mat` |
| `Assets/Materials/Yellow.mat` | `M_Yellow.mat` |
| `Assets/Prefabs/Entity/Projectile.prefab` | `PF_Projectile.prefab` |
| `Assets/Prefabs/Menu/DebugConsole.prefab` | `PF_DebugConsole.prefab` |
| `Assets/Prefabs/Menu/DebugMenu.prefab` | `PF_DebugMenu.prefab` |
| `Assets/Scenes/Baking/BackgroundMesh.fbx` | `SM_BackgroundMesh.fbx` |
| `Assets/Scenes/Baking/Black.mat` | `M_Black.mat` |
| `Assets/Scenes/Baking/Emissive.mat` | `M_Emissive.mat` |
| `Assets/Scenes/Baking/Gold.mat` | `M_Gold.mat` |
| `Assets/Scenes/Baking/Ground.mat` | `M_Ground.mat` |
| `Assets/Scenes/Baking/Lit.mat` | `M_Lit.mat` |
| `Assets/Scenes/Baking/Metal_Black.mat` | `M_Metal_Black.mat` |
| `Assets/Scenes/Baking/SamplesFixture.fbx` | `SM_SamplesFixture.fbx` |
| `Assets/Scenes/Baking/SamplesFloorSpotlight.fbx` | `SM_SamplesFloorSpotlight.fbx` |
| `Assets/Scenes/Baking/SamplesSpotlightModel.fbx` | `SM_SamplesSpotlightModel.fbx` |
| `Assets/Scenes/Baking/UnityMaterialBall.fbx` | `SM_UnityMaterialBall.fbx` |
| `Assets/Scenes/Baking/White.mat` | `M_White.mat` |
| `Assets/Sprites/Basketball.png` | `T_Basketball.png` |

### Exemptions (require approval)

- **C017** — `Assets/Scenes/Baking/ReflectionProbe-0.exr` (format.textures): Keep the baked reflection probe in .exr and exempt generated HDR lighting data from the texture format allow-list.
- **C018** — `Assets/Scenes/Baking/ReflectionProbe-0.exr` (naming.textures): Exempt the auto-generated baked reflection probe cubemap from the texture naming convention.
- **C026** — `Assets/TextMesh Pro/Resources/Fonts & Materials/LiberationSans SDF - Drop Shadow.mat` (naming.materials): Do not rename TextMesh Pro package material; exempt vendor/package content from the project naming convention.
- **C027** — `Assets/TextMesh Pro/Resources/Fonts & Materials/LiberationSans SDF - Outline.mat` (naming.materials): Do not rename TextMesh Pro package material; exempt vendor/package content from the project naming convention.

### Mesh optimization (destructive)

- **C022** — `Assets/Scenes/Baking/UnityMaterialBall.fbx` (models.max_triangles): Reduce the mesh from 39270 to <= 10000 triangles (decimation or retopology) and re-export the FBX.
  - Tool: DCC tool (Blender decimation/retopology) followed by FBX re-export; alternatively Unity Mesh Simplifier.
  - Impact: **high**; destructive: **yes**
  - Note: This modifies the source model and may alter UVs, normals and silhouette. The asset is a Unity sample/demo model; exempting it or raising its budget may be preferable to decimation.

## Human approval required

| Correction | Asset | Action | Reason |
| --- | --- | --- | --- |
| C017 | `Assets/Scenes/Baking/ReflectionProbe-0.exr` | `exempt_generated` | Standards-scope change affecting generated/vendor content |
| C018 | `Assets/Scenes/Baking/ReflectionProbe-0.exr` | `exempt_generated` | Standards-scope change affecting generated/vendor content |
| C022 | `Assets/Scenes/Baking/UnityMaterialBall.fbx` | `optimize_mesh` | Destructive source-asset change |
| C026 | `Assets/TextMesh Pro/Resources/Fonts & Materials/LiberationSans SDF - Drop Shadow.mat` | `exempt_vendor` | Standards-scope change affecting generated/vendor content |
| C027 | `Assets/TextMesh Pro/Resources/Fonts & Materials/LiberationSans SDF - Outline.mat` | `exempt_vendor` | Standards-scope change affecting generated/vendor content |

**Destructive operations:** C022.

## Notes and limitations

- Triangle counts were derived from the binary FBX polygon data, not from Unity's importer or an in-editor mesh query.
- Texture dimensions were read directly from the PNG header and the EXR `dataWindow` attribute.
- Naming and format findings apply the standards literally to every asset under `Assets/`, including Unity sample and TextMesh Pro package content. Exemptions are proposed where renaming or converting would be harmful.
- No Unity assets or `.meta` files were created, modified, renamed or deleted.
- No correction has been executed; the plan is advisory only.
