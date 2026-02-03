#!/usr/bin/env python3
"""
Script to rename curriculum markdown and image files with folder prefix
for better sorting.

Format: foldername_filename.extension
"""

import os
import sys
from pathlib import Path


def rename_files(base_dir="curriculum"):
    """
    Rename markdown and image files in curriculum folders with folder prefix.
    
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
        
        # Get all files recursively
        all_files = [f for f in folder.rglob("*") if f.is_file()]
        
        for file_path in all_files:
            # Skip if file already has the folder prefix
            if file_path.name.startswith(f"{folder_name}_"):
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
            
            print(f"  Renaming: {relative_path} -> {new_name}")
            try:
                file_path.rename(new_filepath)
                print(f"    ✓ Renamed: {new_name}")
            except Exception as e:
                print(f"    ✗ Error renaming {old_name}: {e}")
    
    print("\n✓ Renaming complete!")
    print("\nFiles are now named with format: foldername_filename.extension")
    print("This allows for easy alphabetical sorting by folder.")


if __name__ == "__main__":
    # Get the script's directory
    script_dir = Path(__file__).parent
    os.chdir(script_dir)
    
    rename_files()
