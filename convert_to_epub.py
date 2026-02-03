#!/usr/bin/env python3
"""
Script to convert curriculum markdown files to EPUB format and rename them
for better sorting.

Format: foldername_filename.extension
"""

import os
import subprocess
import sys
from pathlib import Path


def convert_and_rename_files(base_dir="curriculum"):
    """
    Convert markdown files to EPUB and rename all files in curriculum folders.
    
    Args:
        base_dir: Base directory containing curriculum folders (default: "curriculum")
    """
    curriculum_path = Path(base_dir)
    
    if not curriculum_path.exists():
        print(f"Error: {base_dir} directory not found")
        sys.exit(1)
    
    # Process each subdirectory in curriculum
    folders = sorted([d for d in curriculum_path.iterdir() if d.is_dir()])
    
    for folder in folders:
        folder_name = folder.name
        print(f"\nProcessing folder: {folder_name}")
        
        # Find all markdown files in the folder
        md_files = list(folder.glob("*.md"))
        
        for md_file in md_files:
            # Get the filename without extension
            file_stem = md_file.stem
            
            # Create new filename: foldername_filename.epub
            new_filename = f"{folder_name}_{file_stem}.epub"
            new_filepath = folder / new_filename
            
            print(f"  Converting: {md_file.name} -> {new_filename}")
            
            # Convert to EPUB using pandoc
            try:
                # Add metadata to avoid warnings
                result = subprocess.run(
                    [
                        "pandoc",
                        str(md_file),
                        "-o", str(new_filepath),
                        "--metadata", f"title={file_stem}",
                    ],
                    capture_output=True,
                    text=True,
                    check=True
                )
                print(f"    ✓ Created: {new_filename}")
            except subprocess.CalledProcessError as e:
                print(f"    ✗ Error converting {md_file.name}: {e.stderr}")
                continue
        
        # Now rename other files (images, etc.) with the foldername prefix
        # Use rglob to get all files recursively
        all_files = [f for f in folder.rglob("*") if f.is_file() and not f.name.startswith(f"{folder_name}_")]
        
        for file_path in all_files:
            # Skip if already renamed or is an original markdown file (we converted those)
            if file_path.suffix == ".md":
                continue
            
            # Get relative path from folder
            relative_path = file_path.relative_to(folder)
            old_name = file_path.name
            
            # If file is in a subdirectory, include the subdirectory in the name
            if len(relative_path.parts) > 1:
                # e.g., images/pm-role.svg -> images_pm-role.svg
                subdir = "_".join(relative_path.parts[:-1])
                new_name = f"{folder_name}_{subdir}_{old_name}"
            else:
                new_name = f"{folder_name}_{old_name}"
            
            new_filepath = file_path.parent / new_name
            
            # Skip if file already has the folder prefix
            if file_path.name.startswith(f"{folder_name}_"):
                continue
            
            print(f"  Renaming: {relative_path} -> {new_name}")
            try:
                file_path.rename(new_filepath)
                print(f"    ✓ Renamed: {new_name}")
            except Exception as e:
                print(f"    ✗ Error renaming {old_name}: {e}")
    
    print("\n✓ Conversion and renaming complete!")
    print("\nFiles are now named with format: foldername_filename.extension")
    print("This allows for easy alphabetical sorting by folder.")


if __name__ == "__main__":
    # Get the script's directory
    script_dir = Path(__file__).parent
    os.chdir(script_dir)
    
    convert_and_rename_files()
