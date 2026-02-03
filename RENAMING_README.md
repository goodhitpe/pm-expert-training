# Curriculum File Renaming Script

## Overview
This script renames all files in the curriculum folder with a folder name prefix to enable easy alphabetical sorting.

## What It Does

1. **Renames Markdown Files**: All `.md` files in curriculum folders are renamed with the format: `foldername_filename.md`
2. **Renames Image Files**: Image files in subdirectories are renamed with format: `foldername_subdir_filename.extension`
3. **Maintains Format**: Files keep their original format (`.md` files remain `.md`)

## Results

After running the script:
- ✅ 45 markdown files renamed with folder prefix
- ✅ 18 SVG image files renamed with folder prefix
- ✅ All files now sort alphabetically by folder name (week01, week02, etc.)

## File Naming Convention

### Markdown Files (in main folder)
```
week01-pm-introduction_README.md
week01-pm-introduction_detailed-lecture-materials.md
week01-pm-introduction_prerequisite.md
```

### Image Files (in subdirectories)
```
week01-pm-introduction_images_pm-role.svg
week01-pm-introduction_images_project-lifecycle.svg
```

## Prerequisites

- Python 3

## Usage

```bash
python3 rename_files.py
```

The script is idempotent - it can be run multiple times safely. Files that already have the folder prefix will be skipped.

## Why This Approach?

1. **Sortable Names**: Prefixing with folder name ensures files sort correctly alphabetically
2. **Easy Organization**: All files from the same week/topic are grouped together when sorted
3. **Cross-Platform**: Works on any system, no external dependencies needed
4. **Simple**: No format conversion, just renaming for better organization

## Examples

### Before
```
curriculum/
  week01-pm-introduction/
    README.md
    detailed-lecture-materials.md
    prerequisite.md
    images/
      pm-role.svg
      project-lifecycle.svg
```

### After
```
curriculum/
  week01-pm-introduction/
    week01-pm-introduction_README.md                      (renamed)
    week01-pm-introduction_detailed-lecture-materials.md  (renamed)
    week01-pm-introduction_prerequisite.md                (renamed)
    images/
      week01-pm-introduction_images_pm-role.svg           (renamed)
      week01-pm-introduction_images_project-lifecycle.svg (renamed)
```
