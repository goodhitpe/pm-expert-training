# Curriculum File Conversion Script

## Overview
This script converts markdown files in the curriculum folder to EPUB format and renames all files with a folder name prefix to enable easy alphabetical sorting.

## What It Does

1. **Converts Markdown to EPUB**: All `.md` files in curriculum folders are converted to `.epub` format using pandoc
2. **Renames Files**: All files (including images) are renamed with the format: `foldername_filename.extension`
3. **Handles Subdirectories**: Files in subdirectories (like images) are renamed with format: `foldername_subdir_filename.extension`

## Results

After running the script:
- ✅ 45 markdown files converted to EPUB format
- ✅ 18 SVG image files renamed with folder prefix
- ✅ All files now sort alphabetically by folder name (week01, week02, etc.)

## File Naming Convention

### EPUB Files (in main folder)
```
week01-pm-introduction_README.epub
week01-pm-introduction_detailed-lecture-materials.epub
week01-pm-introduction_prerequisite.epub
```

### Image Files (in subdirectories)
```
week01-pm-introduction_images_pm-role.svg
week01-pm-introduction_images_project-lifecycle.svg
```

## Prerequisites

- Python 3
- Pandoc (for markdown to EPUB conversion)

To install pandoc:
```bash
sudo apt install -y pandoc
```

## Usage

```bash
python3 convert_to_epub.py
```

The script is idempotent - it can be run multiple times safely. EPUB files will be regenerated if markdown files change.

## Why This Approach?

1. **EPUB Format**: Better reading experience on e-readers and EPUB reader applications
2. **Sortable Names**: Prefixing with folder name ensures files sort correctly alphabetically
3. **Easy Organization**: All files from the same week/topic are grouped together
4. **Preserves Originals**: Original markdown files are kept intact for editing

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
    README.md                                              (original kept)
    detailed-lecture-materials.md                          (original kept)
    prerequisite.md                                        (original kept)
    week01-pm-introduction_README.epub                     (NEW)
    week01-pm-introduction_detailed-lecture-materials.epub (NEW)
    week01-pm-introduction_prerequisite.epub               (NEW)
    images/
      week01-pm-introduction_images_pm-role.svg           (renamed)
      week01-pm-introduction_images_project-lifecycle.svg (renamed)
```
